using System;
using System.Drawing;
using System.Windows.Forms;

namespace _93_Q1
{
    public partial class Form1 : Form
    {
        readonly Random random = new Random();

        public Pen pen = new Pen(Color.Black);

        public int number = 3;
        public int height = 70;

        public bool left = true;
        public bool drawFirst = false;
        public bool drawNext = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            number = random.Next(2, 7);
            height = random.Next(40, 151);

            drawFirst = true;

            pictureBox1.Refresh();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (!drawFirst)
                return;

            e.Graphics.Clear(SystemColors.Control);

            for (int i = 0; i < number; i++)
                e.Graphics.DrawRectangle(pen, new Rectangle(i * 20 + 20, 20, 10, height));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            left = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            left = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(height <= number * 20)
            {
                MessageBox.Show("無法做折線插入");
                return;
            }

            drawNext = true;

            pictureBox2.Refresh();
        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            if (!drawNext)
                return;

            e.Graphics.Clear(SystemColors.Control);

            for (int i = 0; i < number; i++)
            {
                if (left)
                {
                    e.Graphics.DrawRectangle(pen, new Rectangle(i * 20 + 20, 20, 10, (number - i - 1) * 20 + 10));
                    e.Graphics.DrawRectangle(pen, new Rectangle(i * 20 + 20, (number - i - 1) * 20 + 30, 80 + number * 20, 10));
                    e.Graphics.DrawRectangle(pen, new Rectangle(90 + (number + i) * 20, (number - i - 1) * 20 + 40, 10, i * 20 + 10));
                } else
                {
                    e.Graphics.DrawRectangle(pen, new Rectangle(i * 20 + 20, i * 20 + 40, 10, (number - i - 1) * 20 + 10));
                    e.Graphics.DrawRectangle(pen, new Rectangle(i * 20 + 20, i * 20 + 30, 80 + number * 20, 10));
                    e.Graphics.DrawRectangle(pen, new Rectangle(90 + (number + i) * 20, 20, 10, i * 20 + 10));
                }
            }
        }
    }
}
