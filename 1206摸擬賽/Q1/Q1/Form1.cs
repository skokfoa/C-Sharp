using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Q1
{
    public partial class Form1 : Form
    {
        public string[] data;
        public List<Dpoint> dp;
        public int count = new int();

        public Form1()
        {
            InitializeComponent();

            data = File.ReadAllText(@".\data.txt")
                .Split(new string[] { "\r\n\r\n\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < data.Length; i++)
            {
                comboBox1.Items.Add($"第{i + 1}筆資料");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            count = new int();
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1) return;

            dp = new List<Dpoint>();

            string[] nowData = data[comboBox1.SelectedIndex]
                .Split(new char[] { '\r', '\n', ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Skip(2)
                .Select(x =>  x.Trim())
                .ToArray();

            for(int i = 0; i < nowData.Length; i += 3)
            {
                int x = int.Parse(nowData[i]);
                int y = int.Parse(nowData[i + 1]);

                int cat = int.Parse(nowData[i + 2]);

                dp.Add(new Dpoint(new DataPoint(x, y), cat));
            }

            count = new int();
        }

        private void chart1_Click(object sender, EventArgs e)
        {
            if (dp == null) return;

            if (count >= dp.Count) return;

            if (dp[count].state == 1)
            {
                chart1.Series["a"].Points.Add(dp[count].points);
            }
            else
            {
                chart1.Series["b"].Points.Add(dp[count].points);
            }

            count++;
        }

        public class Dpoint
        {
            public DataPoint points { get; set; }
            public int state { get; set; }

            public Dpoint(DataPoint points, int state)
            {
                this.points = points;
                this.state = state;
            }
        }
    }
}
