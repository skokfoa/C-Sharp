using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q4
{
    public partial class Form1 : Form
    {
        bool draw = false;
        Point[] line1 = new Point[2];
        Point[] line2 = new Point[2];

        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen line_pen = new Pen(Color.Blue, 2);
            Point zero = new Point(panel1.Width / 2, panel1.Height / 2);
            int times = 6;
            clear(g, zero);
            if (draw)
            {
                for (int i = 0; i < 2; ++i)
                {
                    Point p1 = new Point(line1[i].X * times + zero.X, zero.Y - line1[i].Y * times);
                    Point p2 = new Point(line2[i].X * times + zero.X, zero.Y - line2[i].Y * times);
                    line1[i] = p1;
                    line2[i] = p2;
                }

                g.DrawLine(line_pen, line1[0], line1[1]);
                g.DrawLine(line_pen, line2[0], line2[1]);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            draw = false;
            panel1.Invalidate();
        }

        private void clear(Graphics g,Point zero)
        {
            g.Clear(Color.White);
            Pen pen = new Pen(Color.Black, 1);
            Brush brush = Brushes.Black;
            Font font = new Font("Arial", 8);
            int times = 30;


            g.DrawLine(pen, 0, panel1.Height / 2, panel1.Width, panel1.Height / 2);
            g.DrawLine(pen, panel1.Width / 2, 0, panel1.Width / 2, panel1.Height);


            
            g.DrawString("(0,0)", font, brush, zero.X + 2, zero.Y + 2);


            for (int i = -8; i <= 8; i++)
            {
                int x = zero.X + i * times;
                int y = zero.Y;


                if (i % 2 == 0)
                {
                    g.FillEllipse(brush, x - 3, y - 3, 6, 6);
                    switch (i)
                    {
                        case -8:
                            g.DrawString("(-40,0)", font, brush, x, y + 5);
                            break;
                        case 8:
                            g.DrawString("(40,0)", font, brush, x - 30, y + 5);
                            break;
                    }
                }
                else
                {
                    g.FillEllipse(brush, x - 2, y - 2, 4, 4);
                }
            }

            for (int i = -6; i <= 6; i++)
            {
                int x = zero.X;
                int y = zero.Y - i * times;

                if (i % 2 == 0)
                {
                    g.FillEllipse(brush, x - 3, y - 3, 6, 6);
                }
                else
                {
                    g.FillEllipse(brush, x - 2, y - 2, 4, 4);
                }
            }
            g.DrawString("(30,0)", font, brush, zero.X + 5, zero.Y - 6 * 30);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] input = new string[2];
            TextBox[] textBox = new TextBox[] { textBox1, textBox2, textBox3, textBox4 };
            double n = new double();
            double o = new double();
            double[] m = new double[2];
            double[] c = new double[2];


            for (int i = 0; i < 4; i++)
            {
                if (i % 2 == 0)
                {
                    input = textBox[i].Text.Split(',');
                    line1[(int)(i / 2)] = new Point(int.Parse(input[0]), int.Parse(input[1]));
                }
                else
                {
                    input = textBox[i].Text.Split(',');
                    line2[(int)(i / 2)] = new Point(int.Parse(input[0]), int.Parse(input[1]));
                }
            }

            m[0] = (double)(line1[1].Y - line1[0].Y) / (line1[1].X - line1[0].X);
            m[1] = (double)(line2[1].Y - line2[0].Y) / (line2[1].X - line2[0].X);

            c[0] = line1[0].Y - m[0] * line1[0].X;
            c[1] = line2[0].Y - m[1] * line2[0].X;

            draw = true;
            panel1.Invalidate();

            if (m[0] == m[1])
            {
                textBox5.Text = "未相交";
                return;
            }
            else
            {
                n = (c[1] - c[0]) / (m[0] - m[1]);
                o = (m[1] * c[0] - c[1] * m[0]) / (m[1] - m[0]);
            }

            int line1MinX = Math.Min(line1[0].X, line1[1].X);
            int line1MaxX = Math.Max(line1[0].X, line1[1].X);
            int line1MinY = Math.Min(line1[0].Y, line1[1].Y);
            int line1MaxY = Math.Max(line1[0].Y, line1[1].Y);

            int line2MinX = Math.Min(line2[0].X, line2[1].X);
            int line2MaxX = Math.Max(line2[0].X, line2[1].X);
            int line2MinY = Math.Min(line2[0].Y, line2[1].Y);
            int line2MaxY = Math.Max(line2[0].Y, line2[1].Y);

            if (n >= line1MinX && n <= line1MaxX && o >= line1MinY && o <= line1MaxY &&
                n >= line2MinX && n <= line2MaxX && o >= line2MinY && o <= line2MaxY)
            {
                textBox5.Text = "有相交";
                textBox6.Text = $"{n:F2},{o:F2}";
            }
            else
            {
                textBox5.Text = "未相交";
                textBox6.Text = string.Empty;
            }
        }
    }
}
