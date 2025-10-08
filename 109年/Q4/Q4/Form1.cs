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

namespace Q4
{
    public partial class Form1 : Form
    {
        Point[] block;
        int[] lengthX;
        int[] lengthY;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            g.Clear(SystemColors.Control);

            Random random = new Random();
            int n = random.Next(2) == 0 ? 3 : 4;
            block = new Point[n];
            lengthX = new int[n];
            lengthY = new int[n];
            for(int i = 0;i < n; i++)
            {
                int x, y;
                x = random.Next(20,81);
                y = random.Next(20, 81);
                lengthX[i] = random.Next(40, 201);
                lengthY[i] = random.Next(40, 201);
                block[i] = new Point(x, y);
            }

            for(int i = 0;i < n;i++)
            {

                g.DrawRectangle(Dash(i), block[i].X, block[i].Y, lengthX[i], lengthY[i]);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DrawHull();
        }

        private Pen Dash(int n)
        {
            Pen p = new Pen(Color.Black, 1);
            switch (n)
            {
                case 0:
                    p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash; break;
                case 1:
                    p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot; break;
                case 2:
                    p.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot; break;
                case 3:
                    p.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot; break;
            }
            return p;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DrawHull()
        {
            using (Graphics g = panel2.CreateGraphics())
            using (var pen = new Pen(Color.Red, 2))
            {
                for (int i = 0; i < block.Length; i++)
                {

                    g.DrawRectangle(Dash(i), block[i].X, block[i].Y, lengthX[i], lengthY[i]);
                }

                int W = panel1.Width;
                int H = panel1.Height;

                int[] top = Enumerable.Repeat(int.MaxValue, W).ToArray();
                int[] bottom = Enumerable.Repeat(int.MinValue, W).ToArray();

                int[] left = Enumerable.Repeat(int.MaxValue, H).ToArray();
                int[] right = Enumerable.Repeat(int.MinValue, H).ToArray();

                for (int i = 0; i < block.Length; i++)
                {
                    int leftX = Math.Max(0, block[i].X);
                    int rightX = Math.Min(W - 1, block[i].X + lengthX[i] - 1);
                    int topY = Math.Max(0, block[i].Y);
                    int bottomY = Math.Min(H - 1, block[i].Y + lengthY[i] - 1);

                    for (int x = leftX; x <= rightX; x++)
                    {
                        if (topY < top[x]) top[x] = topY;
                        if (bottomY > bottom[x]) bottom[x] = bottomY;
                    }

                    for (int y = topY; y <= bottomY; y++)
                    {
                        if (leftX < left[y]) left[y] = leftX;
                        if (rightX > right[y]) right[y] = rightX;
                    }
                }

                for (int x = 1; x < W; x++)
                {
                    if (top[x] != int.MaxValue && top[x - 1] != int.MaxValue)
                        g.DrawLine(pen, x, top[x - 1], x + 1, top[x]);

                    if (bottom[x] != int.MinValue && bottom[x - 1] != int.MinValue)
                        g.DrawLine(pen, x, bottom[x - 1], x + 1, bottom[x]);
                }

                for (int y = 1; y < H; y++)
                {
                    if (left[y] != int.MaxValue && left[y - 1] != int.MaxValue)
                        g.DrawLine(pen, left[y - 1], y, left[y], y + 1);

                    if (right[y] != int.MinValue && right[y - 1] != int.MinValue)
                        g.DrawLine(pen, right[y - 1], y, right[y], y + 1);
                }
            }
        }


    }
}
