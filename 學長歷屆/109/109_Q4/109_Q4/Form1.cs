using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace _109_Q4
{
    public partial class Form1 : Form
    {
        readonly Random random = new Random();
        readonly Color[] colors = new Color[] { 
            Color.Blue,
            Color.Green,
            Color.Purple,
            Color.Black
        };

        readonly List<Rectangle> points = new List<Rectangle>();

        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            points.Clear();

            int amount = random.Next(3, 5);

            for(int i = 0; i < amount; i++)
                points.Add(new Rectangle(
                    random.Next(20, 80),
                    random.Next(20, 80),
                    random.Next(40, 200),
                    random.Next(40, 200)
                ));
            
            pictureBox1.Refresh();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (points.Count == 0)
                return;

            e.Graphics.Clear(Color.White);

            for(int i = 0; i < points.Count; i++)
            {
                var pen = new Pen(colors[i]);

                e.Graphics.DrawRectangle(pen, points[i]);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
