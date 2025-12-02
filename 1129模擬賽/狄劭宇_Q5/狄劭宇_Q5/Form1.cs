using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace 狄劭宇_Q5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Series s = new Series();

            s.ChartType = SeriesChartType.Spline;

            int n = int.Parse(textBox1.Text);
            double tick = double.Parse(textBox2.Text);


            for (double t = -3.0; t <= 3; t += tick)
            {
                double tr = Truncated(t, n);
                s.Points.Add(new DataPoint(t, tr));
            }

            chart1.Series.Clear();
            chart1.Series.Add(s);
        }

        private static double Truncated(double t, int n)
        {
            const double Pi = Math.PI;
            double num = 0.5;
            for(int k = 1; k <= n; k += 2)
            {
                num += (2 / (k * Pi)) *
                    Math.Cos(k * Pi * t + (Math.Pow(-1, (k - 1) / 2) - 1) * Pi / 2);
            }
            return num;
        }
    }
}
