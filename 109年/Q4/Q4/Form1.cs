using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
                lengthX[i] = random.Next(40,201);
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
            Graphics g = panel1.CreateGraphics();
            g.Clear(SystemColors.Control);
            Pen shild = new Pen(Color.Red, 2);
            int minX = int.MaxValue, minY = int.MaxValue;
            int maxX = int.MinValue, maxY = int.MinValue;
            for(int i = 0;i < block.Length;i++)
            {
                minX = Math.Min(minX, block[i].X);
                minY = Math.Min(minY, block[i].Y);

                maxX = Math.Max(maxX, (block[i].X + lengthX[i]));
                maxY = Math.Max(maxY, (block[i].Y + lengthY[i]));
            }

            for(int x = minX;x <= maxY; x++)
            {
                for(int y = minY;y <= maxY;y++)
                {
                }
            }
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
    }
}
