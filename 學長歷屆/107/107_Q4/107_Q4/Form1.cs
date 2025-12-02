using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace _107_Q4
{
    public class Rate
    {
        public int index;
        public List<double> ratings;

        public Rate(string source)
        {
            index = int.Parse(source.Split('[')[1].Split(']')[0]) - 1;
            ratings = source.Split(':')[1]
                .Split(' ')
                .Where(x => double.TryParse(x, out _))
                .Select(double.Parse).ToList();
        }
    }

    public partial class Form1 : Form
    {
        List<Rate> data;

        public Form1()
        {
            InitializeComponent();
        }

        private void 結束ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 選取資料ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                InitialDirectory = Application.StartupPath,
                Filter = "txt files (*.txt)|*.txt"
            };

            if(dialog.ShowDialog() == DialogResult.OK)
            {
                string[] inputs = File.ReadAllLines(dialog.FileName);

                data = inputs.Select(x => new Rate(x)).ToList();

                textBox1.Text = string.Join("\r\n", inputs);
            }
        }

        private void 求F統計值和dfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double all = data.Select(x => x.ratings.Sum()).Sum();
            double allCount = data.Select(x => x.ratings.Count()).Sum();
            double allAverage = all / allCount;

            double ssb = 0, ssw = 0;

            foreach (var rate in data)
            {
                double total = rate.ratings.Sum();
                int count = rate.ratings.Count();
                double uti = total / count;

                ssb += count * Math.Pow(uti - allAverage, 2);
                ssw += rate.ratings.Select(x => Math.Pow(x - uti, 2)).Sum();
            }

            double b = data.Count() - 1, w = allCount - data.Count();

            double f = (ssb / b) / (ssw / w);

            string fix = f.ToString("F3");

            textBox2.Text = $"F統計值計算:\r\nF = {fix}\r\n自由度df:{b},{w}";
        }
    }
}
