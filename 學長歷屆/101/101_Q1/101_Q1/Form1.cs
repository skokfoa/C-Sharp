using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace _101_Q1
{
    public partial class Form1 : Form
    {
        int[,] cords =
        {
            {  }
        };

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] from =
            {
                textBox1.Text[0] - '0',
                textBox1.Text[1] - '0',
                textBox2.Text[0] - '0',
                textBox2.Text[1] - '0',
            };

            Graphics graphics = pictureBox1.CreateGraphics();

            Pen red = new Pen(Color.Red),
                blue = new Pen(Color.Blue);

            // 1
            red.DashStyle = from[0] == 0 ?
                DashStyle.Dash : DashStyle.Solid;

            for (int i = 0; i < from[0]; i++)
                graphics.DrawLine(red, 80, 200 + i * 15, 280, 20 + i * 15);

            // 2
            red.DashStyle = from[1] == 0 ?
                DashStyle.Dash : DashStyle.Solid;

            for (int i = 0; i < from[1]; i++)
                graphics.DrawLine(red, 120, 300 - i * 15, 320, 120 - i * 15);

            // 3
            blue.DashStyle = from[2] == 0 ?
                DashStyle.Dash : DashStyle.Solid;

            for (int i = 0; i < from[2]; i++)
                graphics.DrawLine(blue, 60 + i * 15, 160 - i * 15, 220 + i * 15, 240 - i * 15);

            // 3
            blue.DashStyle = from[3] == 0 ?
                DashStyle.Dash : DashStyle.Solid;

            for (int i = 0; i < from[3]; i++)
                graphics.DrawLine(blue, 180 - i * 15, 60 + i * 15, 300 - i * 10, 140 + i * 15);
        }
    }
}
