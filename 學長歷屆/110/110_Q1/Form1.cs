using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _110_Q1
{
    public partial class 水平主桿樹連線系統 : Form
    {
        readonly List<Point> points = new List<Point>();

        readonly Pen black = new Pen(Color.Black);
        readonly Pen red = new Pen(Color.Red);
        readonly SolidBrush brush = new SolidBrush(Color.Black);

        readonly Random random = new Random();

        bool draw = false;

        public 水平主桿樹連線系統()
        {
            InitializeComponent();

            red.Width = 8;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            points.Clear();

            for (int i = 0; i < 7; i++)
            {
                Point point = new Point(random.Next(2, 10), random.Next(2, 10));

                while (point.X == point.Y || points.Exists(x => x.X == point.X || x.Y == point.Y))
                    point = new Point(random.Next(2, 10), random.Next(2, 10));

                points.Add(point);
            }

            draw = false;

            pictureBox1.Refresh();
        }

        public void Clear(Graphics graphics)
        {
            graphics.Clear(Color.White);

            for (int i = 0; i <= 10; i++)
            {
                graphics.DrawLine(black, 48 * i, 0, 48 * i, 480);
                graphics.DrawLine(black, 0, 48 * i, 480, 48 * i);
            }

            if(draw)
            {
                Point right = points.First(), left = points.First();

                foreach (var point in points)
                {
                    if (point.X > right.X)
                        right = point;

                    if (point.X < left.X)
                        left = point;
                }

                int length = right.X - left.X;

                graphics.DrawLine(red, right.X * 48, right.Y * 48, left.X * 48 - 4, right.Y * 48);

                foreach(var point in points)
                {
                    if (point == right)
                        continue;

                    graphics.DrawLine(red, point.X * 48, point.Y * 48, point.X * 48, right.Y * 48 - 4);

                    length += Math.Abs(point.Y - right.Y);
                }

                textBox1.Text = length.ToString();
            }

            foreach(var point in points)
                graphics.FillEllipse(brush, point.X * 48 - 8, point.Y * 48 - 8, 16, 16);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        { 
            Clear(e.Graphics);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            draw = true;

            pictureBox1.Refresh();
        }
    }
}
