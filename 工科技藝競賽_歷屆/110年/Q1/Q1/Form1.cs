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

namespace Q1
{
    public partial class Form1 : Form
    {
        private Point[] dot = new Point[7];
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(SystemColors.Control);
            Pen black = new Pen(Color.Black,1);
            
            int startL = 400 / 2;
            int endL = 400 / 2;
            int gap = 40;

            startL -= (int)(gap * 4.5);
            endL += (int)(gap * 4.5);
            

            for(int i = 0;i < 10; i++)
            {
                int gapadd = gap * i;
                g.DrawLine(black, startL, startL + gapadd, endL, startL + gapadd);
                g.DrawLine(black, startL + gapadd, startL, startL + gapadd, endL);
            }

            
            foreach (Point p in dot)
            {
                if (p == Point.Empty) continue;
                SolidBrush brush = new SolidBrush(Color.Black);
                g.FillEllipse(brush, p.X - 5, p.Y - 5, 10, 10);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label3.Text = string.Empty;
            dot = new Point[7];
            HashSet<int> x = new HashSet<int>();
            HashSet<int> y = new HashSet<int>();

            Random rand = new Random();

            while(true)
            {
                if(x.Count >= 7 && y.Count >= 7)
                {
                    break;
                }
                int x1 = 20 + rand.Next(1, 9) * 40;
                int y1 = 20 + rand.Next(1, 9) * 40;

                if(x.Count < 7)
                {
                    x.Add(x1);
                }
                if(y.Count < 7)
                {
                    y.Add(y1);
                }
            }

            for(int i = 0; i < 7; i++)
            {
                dot[i] = new Point(x.ElementAt(i), y.ElementAt(i));
            }
            panel1.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int count = 0;
            int y_args = 0;
            for(int i = 0;i < 7; i++)
            {
                y_args += (dot[i].Y - 20) / 40;
            }
            y_args /= 7;
            y_args = 20 + y_args * 40;

            int maxx = int.MinValue;
            int minx = int.MaxValue;
            for (int i = 0;i < 7; i++)
            {
                maxx = Math.Max(maxx, dot[i].X);
                minx = Math.Min(minx, dot[i].X);
            }

            count = (maxx - minx) / 40;

            using (Graphics g = panel1.CreateGraphics())
            {
                Pen red = new Pen(Color.Red, 5);
                g.DrawLine(red, minx, y_args, maxx, y_args);
                foreach (Point p in dot)
                {
                    if (p == Point.Empty) continue;
                    if (p.Y == y_args) continue;

                    count += Math.Abs(p.Y - y_args) / 40;
                    g.DrawLine(red, p.X, p.Y, p.X, y_args);
                }
            }

            label3.Text = count.ToString();
        }
    }
}
