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
        int[,] state = new int[6, 6];
        int now = new int();
        bool start = false;

        public Form1()
        {
            InitializeComponent();
            state = new int[,] { 
                { 1, 0, 0, 0, 0, 1},
                { 1, 0, 0, 0, 1, 0},
                { 1, 0, 0, 1, 0, 0},
                { 0, 0, 1, 1, 0, 0},
                { 0, 1, 0, 1, 0, 0},
                { 1, 0, 0, 1, 0, 0} };
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

            Graphics g = e.Graphics;
            Pen p = new Pen(Color.Black, 1);

            g.Clear(SystemColors.Control);
            
            if (start)
            {
                int width = panel1.Width;
                int height = panel1.Height;

                g.DrawLine(p, 0, (int)(height / 5 * 3), width, (int)(height / 5 * 3));
                g.DrawLine(p, 0, (int)(height / 5 * 4), width, (int)(height / 5 * 4));

                g.DrawLine(p, (int)(width / 5 * 1), 0, (int)(width / 5 * 1), height);
                g.DrawLine(p, (int)(width / 5 * 2), 0, (int)(width / 5 * 2), height);

                draw(now);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            start = true;
            panel1.Invalidate();
        }

        

        

        private void draw(int n)
        {
            int[] num = new int[6];
            for(int i = 0; i < num.Length; i++)
            {
                num[i] = state[n, i];
            }

            int width = panel1.Width;
            int height = panel1.Height;

            int mid = width / 5 / 2;
            int len = 20;

            using (Graphics g = panel1.CreateGraphics())
            {
                Brush red       = new SolidBrush (Color.Red);
                Brush yellow    = new SolidBrush (Color.Yellow);
                Brush green     = new SolidBrush (Color.Green);

                if (num[0] == 1) { g.FillEllipse(red   , mid * 1 - len, mid * 1 - len, len * 2, len * 2); }
                if (num[1] == 1) { g.FillEllipse(yellow, mid * 1 - len, mid * 3 - len, len * 2, len * 2); }
                if (num[2] == 1) { g.FillEllipse(green , mid * 1 - len, mid * 5 - len, len * 2, len * 2); }
                if (num[3] == 1) { g.FillEllipse(red   , mid * 5 - len, mid * 9 - len, len * 2, len * 2); }
                if (num[4] == 1) { g.FillEllipse(yellow, mid * 7 - len, mid * 9 - len, len * 2, len * 2); }
                if (num[5] == 1) { g.FillEllipse(green , mid * 9 - len, mid * 9 - len, len * 2, len * 2); }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            start = false;
            panel1.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            now = (now + 1) % 6;
            panel1.Invalidate();
        }
    }
}
