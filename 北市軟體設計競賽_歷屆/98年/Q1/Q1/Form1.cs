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

namespace Q1
{
    public partial class Form1 : Form
    {
        public Point[] p;
        public Series s;
        public double m = new double();
        public double c = new double();

        public Form1()
        {
            InitializeComponent();
            s = chart1.Series["Series1"];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x1 = int.Parse(textBox1.Text);
            int y1 = int.Parse(textBox2.Text);
            int y2 = int.Parse(textBox3.Text);
            int x2 = int.Parse(textBox4.Text);
            int y3 = int.Parse(textBox5.Text);
            int x3 = int.Parse(textBox6.Text);

            s.Points.Clear();


            p = new Point[3];

            p[0] = new Point(x1, y1);
            p[1] = new Point(x2, y2);
            p[2] = new Point(x3, y3);

            s.Points.Add(new DataPoint(x1, y1));
            s.Points.Add(new DataPoint(x2, y2));
            s.Points.Add(new DataPoint(x3, y3));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            m = 3 * p.Sum(x => x.X * x.Y) - p.Sum(x => x.X) * p.Sum(x => x.Y);
            m /= 3 * (p.Sum(x => x.X * x.X)) - Math.Pow(p.Sum(x => x.X), 2);

            c = p.Sum(x => x.X * x.X) * p.Sum(x => x.Y) - p.Sum(x => x.X) * p.Sum(x => x.X * x.Y);
            c /= 3 * (p.Sum(x => x.X * x.X)) - Math.Pow(p.Sum(x => x.X), 2);

            label13.Text = m.ToString();
            label12.Text = c.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Series line;

            
            if (chart1.Series.IsUniqueName("Line") == false)
            {
                line = chart1.Series["Line"];
            }
            else
            {
                line = chart1.Series.Add("Line");
                line.ChartType = SeriesChartType.Line;
            }

            line.Points.Clear();
            line.Color = Color.Blue;

            for (double x = 0; x <= 60; x += 0.1)   // 步長 0.1 就很平滑了
            {
                double y = m * x + c;
                if (y > 60) break;
                line.Points.AddXY(x, y);
            }
        }

    }
}
