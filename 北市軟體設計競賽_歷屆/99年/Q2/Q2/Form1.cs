using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Q2
{
    public partial class Form1 : Form
    {
        public string[] data;
        public List<dpoint> dp;
        public int count = new int();

        public Form1()
        {
            InitializeComponent();
            data = File.ReadAllText(@".\DataXY.txt")
                .Split(new string[] { "\r\n\r\n\r\n" },StringSplitOptions.RemoveEmptyEntries);

            for(int i = 0; i < data.Length; i++)
            {
                comboBox1.Items.Add($"第{i + 1}筆資料");
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {
            Series s1 = chart1.Series[0];
            Series s2 = chart1.Series[1];

            if (count >= dp.Count) return;

            dpoint input = dp.ElementAt(count);

            if (input.category == 0)
            {
                s2.Points.Add(input.point);
            }
            else
            {
                s1.Points.Add(input.point);
            }

            count++;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] now_data;
            dp = new List<dpoint>();

            if (comboBox1.SelectedIndex == -1) return;

            now_data = data[comboBox1.SelectedIndex]
                    .Split(new char[] { '\r' , '\n', ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                    .Skip(2)
                    .Select(x => x.Trim(' '))
                    .ToArray();

            for (int i = 0; i < now_data.Length; i+=3)
            {
                int x = int.Parse(now_data[i]);
                int y = int.Parse(now_data[i+1]);
                int cat = int.Parse(now_data[i+2]);

                dpoint d = new dpoint(new DataPoint(x, y), cat);
                dp.Add(d);
            }
            button1.PerformClick();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            count = new int();
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
        }
    }

    public class dpoint
    {
        public DataPoint point { get; set; }
        public int category { get; set; }
        
        public dpoint(DataPoint point, int category)
        {
            this.point = point;
            this.category = category;
        }
    }
}
