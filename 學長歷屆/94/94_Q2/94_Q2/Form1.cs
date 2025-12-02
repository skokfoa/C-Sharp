using System;
using System.Drawing;
using System.Windows.Forms;

namespace _94_Q2
{
    public partial class Form1 : Form
    {
        int a = int.MaxValue, b = int.MaxValue;
        bool draw = false;

        Font font = new Font("新細明體", 12);
        Brush brush = new SolidBrush(Color.Black);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Minimized)
                return;

            a = int.MaxValue;
            b = int.MaxValue;

            label3.Text = "";
            label4.Text = "";
            label5.Text = "";

            if (draw)
                Refresh();
        }

        public void Clear(Graphics graphics)
        {
            graphics.Clear(Color.White);

            graphics.DrawLine(new Pen(Color.Black), 320, 0, 320, 540);
            graphics.DrawLine(new Pen(Color.Black), 0, 260, 640, 260);

            graphics.DrawString("y軸線", font, brush, new Point(320, 20));
            graphics.DrawString("x軸線", font, brush, new Point(580, 260));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            draw = true;

            if(int.TryParse(textBox1.Text, out _))
            {
                a = int.Parse(textBox1.Text);
                b = int.Parse(textBox2.Text);
            }

            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (!draw)
                return;

            draw = false;

            Clear(e.Graphics);

            if (a == int.MaxValue && b == int.MaxValue)
            {
                label3.Text = "";
                label4.Text = "";
                label5.Text = "";

                return;
            }

            for(float i = -3; i < 2; i += 0.2f)
            {
                float y = Calculate(i);

                e.Graphics.FillEllipse(brush,
                    320 + i * 16, 
                    260 + y * 16, 4, 4
                );
            }

            label3.Text = $"(-1, {-Calculate(-1)})";
            label4.Text = $"(0, {-Calculate(0)})";
            label5.Text = $"(1, {-Calculate(1)})";

            label3.Location = new Point(320 - 16, (int)(260 + Calculate(-1) * 16));
            label4.Location = new Point(320, (int)(260 + Calculate(0) * 16));
            label5.Location = new Point(320 + 16, (int)(260 + Calculate(1) * 16));
        }

        public float Calculate(float x)
        {
            return -(float)(a * Math.Pow(x, 2) + b * x + 1);
        }
    }
}
