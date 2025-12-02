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

namespace Q4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            const double Pi = Math.PI;

            int n = int.Parse(textBox1.Text);
            double gap = double.Parse(textBox2.Text);
            chart1.Series.Clear();

            Series series = new Series();
            series.ChartType = SeriesChartType.Spline;

            for (double t = -3; t <= 3; t += gap)
            {
                double Y = new double();
                for (double k = 1; k < n; k += 2)
                {
                    Y += 2 / (k * Pi) * Math.Cos(k * Pi * t + (Math.Pow(-1, (k - 1) / 2) - 1) * Pi / 2);
                }
                Y = Y + 0.5;

                DataPoint p = new DataPoint(t,Y);
                series.Points.Add(p);
            }

            chart1.Series.Add(series);
        }
    }
}
