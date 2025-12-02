using System;
using System.Drawing;
using System.Windows.Forms;

namespace _93_Q4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Graphics graphics = pictureBox1.CreateGraphics();

            Pen pen = new Pen(pictureBox2.BackColor);
            Point current = ((MouseEventArgs)e).Location;

            int length = int.Parse(textBox1.Text);

            if (comboBox1.Text == "正三角形")
            {
                PointF left = new PointF(current.X - length / 2f, (float)(current.Y + length / 2f * Math.Sqrt(3)));
                PointF right = left;

                right.X += length;

                graphics.DrawLine(pen, current, left);
                graphics.DrawLine(pen, current, right);

                graphics.DrawLine(pen, left, right);
            }

            if(comboBox1.Text == "正方形")
                graphics.DrawRectangle(pen, new Rectangle(current, new Size(length, length)));

            if (comboBox1.Text == "圓形")
                graphics.DrawEllipse(pen, new Rectangle(current.X - length / 2, current.Y - length /2, length, length));
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            SetBackgroundColor(Color.Black);
        }

        public void SetBackgroundColor(Color color)
        {
            pictureBox1.BackColor = color;
        }

        public void SetLineColor(Color color)
        {
            pictureBox2.BackColor = color;
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            SetBackgroundColor(Color.White);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetBackgroundColor(Color.White);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            SetLineColor(Color.Black);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            SetLineColor(SystemColors.GrayText);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            SetLineColor(SystemColors.GradientActiveCaption);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            SetLineColor(SystemColors.HotTrack);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            SetLineColor(Color.Yellow);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            SetLineColor(((PictureBox)sender).BackColor);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            SetLineColor(Color.PeachPuff);
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            SetLineColor(Color.Purple);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out _))
                return;

            int value = int.Parse(textBox1.Text);

            if (value < 10 || value > 2000)
                return;

            trackBar1.Value = value;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            textBox1.Text = trackBar1.Value.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "圓形")
                label2.Text = "半徑";
            else label2.Text = "邊長";
        }
    }
}
