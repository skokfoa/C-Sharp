using System;
using System.Drawing;
using System.Windows.Forms;

namespace _94_Q3
{
    public partial class Form1 : Form
    {
        bool started = false, ended = false, on = true;
        int hour = 0, minute = 0, seconds = 0;

        private void button2_Click(object sender, EventArgs e)
        {
            started = true;
            ended = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            started = !started;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            started = false;
            hour = 0;
            minute = 0;
            seconds = 0;

            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = "0";
            textBox4.Text = "0";
            textBox5.Text = "0";
            textBox6.Text = "0";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(ended)
            {
                var graphics = pictureBox1.CreateGraphics();

                graphics.FillEllipse(
                    new SolidBrush(on ? Color.Red : Color.White), 0, 0, 32, 32);

                on = !on;

                return;
            }

            if (!started)
                return;

            seconds -= 1;

            if (seconds < 0)
            {
                minute -= 1;
                seconds = 59;
            }

            if(minute < 0)
            {
                hour -= 1;
                minute = 59;
            }

            if(hour < 0)
            {
                minute = 0;
                seconds = 0;
                hour = 0;
                ended = true;
            }

            textBox1.Text = (hour / 10).ToString();
            textBox2.Text = (hour % 10).ToString();
            textBox4.Text = (minute / 10).ToString();
            textBox3.Text = (minute % 10).ToString();
            textBox6.Text = (seconds / 10).ToString();
            textBox5.Text = (seconds % 10).ToString();
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hour = int.Parse(textBox1.Text) * 10 + int.Parse(textBox2.Text);
            minute = int.Parse(textBox4.Text) * 10 + int.Parse(textBox3.Text);
            seconds = int.Parse(textBox6.Text) * 10 + int.Parse(textBox5.Text);
        }
    }
}
