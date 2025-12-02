using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 模擬賽_Q3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double a = int.Parse(textBox1.Text),
                m = int.Parse(textBox2.Text),
                b = int.Parse(textBox3.Text),
                max = int.Parse(textBox4.Text);

            var chart = chart1.Series["三角形歸屬函數圖"];

            chart.Points.Clear();

            for(int x = 0; x < max; x++)
            {
                if (a < x && x <= m)
                    chart.Points.AddXY(x, (x - a) / (m - a));
                else if (m < x && x < b)
                    chart.Points.AddXY(x, (b - x) / (b - m));

                else chart.Points.AddXY(x, 0);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double a = int.Parse(textBox8.Text),
                b = int.Parse(textBox7.Text),
                c = int.Parse(textBox6.Text),
                d = int.Parse(textBox9.Text),
                max = int.Parse(textBox5.Text);

            var chart = chart2.Series["梯形歸屬函數圖"];

            chart.Points.Clear();

            for (int x = 0; x < max; x++)
            {
                if (a <= x && x <= b)
                    chart.Points.AddXY(x, (x - a) / (b - a));
                else if (c <= x && x <= d)
                    chart.Points.AddXY(x, 1 - (x - c) / (d - c));
                else if (b <= x && x <= c)
                    chart.Points.AddXY(x, 1);

                else chart.Points.AddXY(x, 0);
            }
        }
    }
}
