using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int sign = random.Next(2);
            int exponent = random.Next(256);
            int mantissa = random.Next((int)Math.Pow(2,23));

            textBox1.Text = sign.ToString();
            textBox2.Text = Convert.ToString(exponent,2).PadLeft(8,'0');
            textBox3.Text = Convert.ToString(mantissa,2).PadLeft(23,'0');
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int sign = int.Parse(textBox1.Text);
            int exponent = Convert.ToInt32(textBox2.Text, 2) - 127;
            string m_input = "1" + textBox3.Text;
            double mantissa = new double();

            for (int i = 0; i < m_input.Length; i++)
            {
                mantissa += (double)(int.Parse(m_input[i].ToString()) * Math.Pow(2, exponent - i));
            }

            if (sign == 1)
            {
                mantissa *= -1;
            }

            textBox4.Text = mantissa.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
