using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _102_Q2
{
    public partial class Form1 : Form
    {
        readonly Random random = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double number = random.Next(0, 10000) + random.NextDouble();
            textBox1.Text = number.ToString("F6");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] split = textBox1.Text.Split('.');

            string number = Convert.ToString(int.Parse(split[0]), 2);
            double small = double.Parse(textBox1.Text) - double.Parse(split[0]);

            string small_str = "";

            int count = 0;

            while(small > 0 && count < 10)
            {
                small *= 2;

                int a = (int) Math.Floor(small);

                small -= a;
                small_str += a;
                count++;
            }

            textBox2.Text = $"{number}.{small_str}";
            textBox3.Text = double.Parse(textBox2.Text).ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
