using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Q4
{
    public partial class Form1 : Form
    {
        public const double g = -9.81;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DrawBlueLine();
            WriteText();
        }

        private void DrawBlueLine()
        {
            chart1.Series.Clear();

            int count = 0;
            List<List<DataPoint>> fly = new List<List<DataPoint>>();

            for (int degree = 0; degree <= 90; degree++)
            {
                List<DataPoint> points = new List<DataPoint>();
                double rad = degree * Math.PI / 180.0;
                double vxo = 20 * Math.Cos(rad);
                double vyo = 20 * Math.Sin(rad);

                for (double t = 0; t < 1000; t += 0.001)
                {
                    double x = vxo * t;
                    double y = vyo * t + 0.5 * g * t * t;

                    if (x >= 0 && y >= 0)
                        points.Add(new DataPoint(x, y));
                    else
                        break;
                }

                // 只取 5,15,25,...,85 度
                if (degree % 10 - 5 == 0)
                    fly.Add(points);
            }

            // 這裡每條線都 new 一個 Series
            for (int i = 0; i < fly.Count; i++)
            {
                Series s = new Series($"θ={5 + i * 10}°");
                s.ChartType = SeriesChartType.Spline;
                s.Color = Color.Blue;

                foreach (DataPoint point in fly[i])
                {
                    s.Points.Add(point);
                }

                chart1.Series.Add(s);
            }
        }

        private void WriteText()
        {
            double max = double.MinValue;
            int Index = 0;
            textBox1.Text = string.Empty;
            textBox1.Text = $"{"角度",6} {"水平距離", 6}\r\n";
            for(int degree = 0; degree <= 90; degree++)
            {
                double rad = Math.PI * degree / 180;
                double vxo = 20 * Math.Sin(rad);
                double vyo = 20 * Math.Cos(rad);

                double t = -2 * vyo / g;
                double x = vxo * t;

                if (x > max)
                {
                    Index = degree;
                    max = x;
                }

                textBox1.Text += $"{degree,6} {x,12:F4}\r\n";
            }

            DrawRedLine(Index);
        }

        private void DrawRedLine(int degree)
        {
            List<DataPoint> p = new List<DataPoint>();
            double rad = degree * Math.PI / 180;
            double vxo = 20 * Math.Cos(rad);
            double vyo = 20 * Math.Sin(rad);

            double tMax = -2 * vyo / g;
            double gap = tMax / 100;
            for (double t = 0; t <= tMax; t += gap)
            {
                double y = vyo * t + 0.5 * g * t * t;
                double x = vxo * t;
                p.Add(new DataPoint(x, y));
            }

            Series r = new Series();
            r.ChartType = SeriesChartType.Spline;
            r.Color = Color.Red;
            foreach(var n in p)
            {
                r.Points.Add(n);
            }

            r.Points.AddXY(vxo * tMax, 0);

            chart1.Series.Add(r);
        }
    }
}
