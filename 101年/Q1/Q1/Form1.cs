using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q1
{
    public partial class Form1 : Form
    {
        int[] a = new int[2];
        int[] b = new int[2];
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
            }else if (b[0] < 1 || b[0] > 50)
            {
                MessageBox.Show("請重新輸入(1~50)");
                textBox2.Text = string.Empty;
                return;
            }

            a = textBox1.Text.Select(c => c - '0').ToArray();
            b = textBox2.Text.Select(c => c - '0').ToArray();
            

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.Transparent);

            Pen blue_pen = new Pen(Color.Blue, 2);
            Pen red_pen = new Pen(Color.Red, 2);

            Point[] points_top_min = new Point[a[1] * b[0]];
            int squre_long = 40;
            int extra_long = 50;

            for (int i = 0; i < points_top_min.Length; i++)
            {
                if (a[1] % 2 == 0)
                {
                    int top_mid_height_point = panel1.Height / 3 / 2;
                    int top_mid_wigth_point = panel1.Width /3 / 2 * 3;

                    int top_mid_point_num = a[1] + b[0] - 1;
                    if(top_mid_point_num % 2 == 0)
                    {
                        
                    }
                }
            }

        }
    }
}
