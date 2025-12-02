using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q5
{
    public partial class Form1 : Form
    {
        private rect[] block;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            int n = rand.Next(2, 5);
            block = new rect[n];
            HashSet<(int , int)> a = new HashSet<(int, int)>();
            
            while (a.Count < n)
            {
                int x = rand.Next(20, 80 + 1);
                int y = rand.Next(20, 80 + 1);
                a.Add((x, y));
            }

            for(int i = 0;i < n; i++)
            {
                block[i] = new rect(new Point(a.ElementAt(i).Item1, a.ElementAt(i).Item2), rand.Next(40, 200 + 1), rand.Next(40, 200 + 1));
            }

            draw(1);
            using(Graphics g = panel2.CreateGraphics()) g.Clear(BackColor);
        }

        private void draw(int a)
        {            
            if (block == null) return;

            Panel panel = a == 1 ? panel1 : panel2;

            using(Graphics g = panel.CreateGraphics())
            {
                g.Clear(panel.BackColor);

                for(int i = 0; i < block.Length; i++)
                {
                    using(Pen p = Dash(i))
                    {
                        block[i].draw(g, p);
                    }
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
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (Graphics g = panel2.CreateGraphics())
            {
                g.Clear(BackColor);

                for (int i = 0; i < block.Length; i++)
                {
                    Pen p = Dash(i);
                    block[i].draw(g, p);
                }

                for (int i = 0; i < block.Length; i++)
                {
                    for (int j = 0; j < block.Length; j++)
                    {
                        if (i == j) continue;

                        if (TryIntersect(block[i], block[j], out Rectangle inter))
                        {
                            SolidBrush b = new SolidBrush(Color.HotPink);
                            g.FillRectangle(b, inter);
                        }
                    }
                }
            }
        }

        private bool TryIntersect(rect a, rect b, out Rectangle inter)
        {
            int left = Math.Max(a.org.X, b.org.X);
            int top = Math.Max(a.org.Y, b.org.Y);
            int right = Math.Min(a.org.X + a.wid, b.org.X + b.wid);
            int botton = Math.Min(a.org.Y + a.hgt, b.org.Y + b.hgt);

            if (left < right && top < botton)
            {
                inter = new Rectangle(left, top, right - left, botton - top);
                return true;
            }

            inter = Rectangle.Empty;
            return false;
        }
    }

    public class rect
    {
        public Point org { get; set; }
        public int wid { get; set; }
        public int hgt { get; set; }

        public rect(Point o, int w, int h)
        {
            org = o;
            wid = w;
            hgt = h;
        }

        public void draw(Graphics g,Pen p)
        {
            g.DrawRectangle(p, org.X, org.Y, wid, hgt);
        }
    }
}
