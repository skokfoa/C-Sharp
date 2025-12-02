using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace _104_Q3
{
    public partial class Form1 : Form
    {
        Random random = new Random();

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
            textBox1.Text = random.Next(2).ToString();
            textBox2.Text = Convert.ToString(random.Next(127) + 127, 2);

            List<int> floats = new List<int>();

            for(int i = 0; i < 23; i++)
            {
                floats.Add(random.Next(2));
            }

            textBox3.Text = string.Join("", floats);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string prefix = textBox1.Text == "1" ? "-" : "";

            int pow = Convert.ToInt32(textBox2.Text, 2) - 127;

            string floats = Parse(textBox3.Text.Substring(pow)).ToString().Substring(2);

            int integer = Convert.ToInt32($"1{textBox3.Text.Substring(0, pow)}", 2);

            textBox4.Text = $"{prefix}{integer}.{floats}";
        }

        public double Parse(string str)
        {
            double _base = 1;
            double sum = 0;

            foreach(char c in str)
            {
                _base /= 2;

                if (c == '1')
                    sum += _base;
            }

            return sum;
        }
    }
}
