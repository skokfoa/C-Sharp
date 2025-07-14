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
        int N = new int();
        string color = string.Empty;
        bool draw = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if(draw)
            {
                Graphics g = e.Graphics;
                Pen pens;
                switch (color)
                {
                    case "B":
                        pens = new Pen(Color.Black, 2);
                        break;
                    case "R":
                        pens = new Pen(Color.Red, 2);
                        break;
                    case "G":
                        pens = new Pen(Color.Green, 2);
                        break;
                    case "L":
                        pens = new Pen(Color.Blue, 2);
                        break;
                    default:
                        textBox2.Text = string.Empty;
                        MessageBox.Show("請輸入正確的顏色");
                        return;
                }


                int circleX = panel1.ClientSize.Width / 2;
                int circleY = panel1.ClientSize.Height / 2;
                Point[] point = new Point[N];
                int r = 150;
                for (int i = 0; i < N; i++)
                {
                    double x, y;

                    x = r * Math.Cos((2 * Math.PI / N) * i) + circleX;
                    y = r * Math.Sin((2 * Math.PI / N) * i) + circleY;
                    point[i] = new Point((int)x, (int)y);
                }

                //g.DrawPolygon(pens, point);

                for (int i = 0; i < N; i++)
                {
                    for (int j = i + 1; j < N; j++)
                    {
                        g.DrawLine(pens, point[i], point[j]);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Length < 1)
            {
                MessageBox.Show("請輸入N,3 <= N <= 10");
                return;
            }
            N = int.Parse(textBox1.Text);
            if (N < 3 || N > 10)
            {
                MessageBox.Show("請重新輸入,3 <= N <= 10");
                textBox1.Text = string.Empty;
            }

            color = textBox2.Text;
            if (textBox2.Text.Length > 1)
            {
                MessageBox.Show("輸入單一字母就好");
                char[] chars = textBox2.Text.ToCharArray();
                textBox2.Text = chars[0].ToString();
            }
            draw = true;
            panel1.Invalidate();
        }
    }
}
