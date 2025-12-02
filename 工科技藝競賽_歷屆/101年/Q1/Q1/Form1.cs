using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q1
{
    public partial class Form1 : Form
    {
        int[] a = new int[2];
        int[] b = new int[2];
        bool TF = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            a[0] = int.Parse(textBox1.Text);
            b[0] = int.Parse(textBox2.Text);

            if (a[0] < 1 || a[0] > 50)
            {
                MessageBox.Show("請重新輸入(1~50)");
                textBox1.Text = string.Empty;
                return;
            }
            else if (b[0] < 1 || b[0] > 50)
            {
                MessageBox.Show("請重新輸入(1~50)");
                textBox2.Text = string.Empty;
                return;
            }

            a[1] = a[0] % 10;
            a[0] = a[0] / 10;
            b[1] = b[0] % 10;
            b[0] = b[0] / 10;

            TF = true;
            panel1.Invalidate();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (TF)
            {
                Graphics g = e.Graphics;
                g.Clear(Color.White);

                Pen blue_pen = new Pen(Color.Blue, 2);
                Pen red_pen = new Pen(Color.Red, 2);

                Point[] points_top_min = new Point[a[1] * b[0]];
                int squre_long = 5;
                int extra_long = 20;

                for (int i = 0;i < a[1]; ++i)
                {
                    int start_x = panel1.Width / 2 - extra_long - squre_long * i;
                    int start_y = panel1.Height / 2 / 3 - extra_long + squre_long * i;
                    int end_x = panel1.Width / 2 / 3  * 5 + extra_long - squre_long * i + squre_long * (b[1] - 1);
                    int end_y = panel1.Height / 2 + extra_long + squre_long * i + squre_long * (b[1] - 1);

                    g.DrawLine(blue_pen, start_x, start_y, end_x, end_y);
                }

                for (int i = 0; i < a[0]; ++i)
                {
                    int start_x = panel1.Width / 2 / 3 - extra_long - squre_long * i;
                    int start_y = panel1.Height / 2 - extra_long + squre_long * i;
                    int end_x = panel1.Width / 2 + extra_long - squre_long * i + squre_long * (b[1] - 1);
                    int end_y = panel1.Height / 2 / 3 * 5 + extra_long + squre_long * i + squre_long * (b[1] - 1);

                    g.DrawLine(blue_pen, start_x, start_y, end_x, end_y);
                }

                for (int i = 0; i < b[0]; ++i)
                {
                    int start_x = panel1.Width / 2 + extra_long + squre_long * i;
                    int start_y = panel1.Height / 2 / 3 - extra_long + squre_long * i;
                    int end_x = panel1.Width / 2 / 3 - extra_long + squre_long * i - squre_long * (a[0] - 1);
                    int end_y = panel1.Height / 2 + extra_long + squre_long * i - squre_long * (a[0] - 1);

                    g.DrawLine(red_pen, start_x, start_y, end_x, end_y);
                }

                for (int i = 0; i < b[1]; ++i)
                {
                    int start_x = panel1.Width / 2 / 3 * 5 + extra_long + squre_long * i;
                    int start_y = panel1.Height / 2 - extra_long + squre_long * i;
                    int end_x = panel1.Width / 2 - extra_long + squre_long * i - squre_long * (a[0] - 1);
                    int end_y = panel1.Height / 2 / 3 * 5 + extra_long + squre_long * i - squre_long * (a[0] - 1);

                    g.DrawLine(red_pen, start_x, start_y, end_x, end_y);
                }
            }
        }
    }
}