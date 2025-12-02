using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q3
{
    public partial class Form1 : Form
    {
        int a, b;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            TextBox[] textBox = new TextBox[] { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8 };
            a = random.Next(256) - 128;
            b = random.Next(256) - 128;

            foreach(TextBox clear in textBox)
            {
                clear.Text = string.Empty;
            }
            print(textBox1, a);
            print(textBox3, b);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int sum = a + b;
            string a_in = textBox1.Text.PadLeft(8, '0');
            string b_in = textBox3.Text.PadLeft(8, '0');
            string output = string.Empty;

            int carry = 0;

            for (int i = 7; i >= 0; i--)
            {
                int bitA = a_in[i] - '0';
                int bitB = b_in[i] - '0';

                int c = bitA + bitB + carry;

                int resultBit = c % 2;
                carry = c / 2;

                output = resultBit.ToString() + output;
            }
            textBox5.Text = output;
            if(sum < -128 || sum > 127)
            {
                textBox7.Text = "overflow";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int sum = a + b;
            textBox2.Text = a.ToString();
            textBox4.Text = b.ToString();
            if(sum < -128 || sum > 127)
            {
                textBox8.Text = "不足位";
            }
            string input = textBox5.Text;
            int output = new int();
            if (input[0] == '0')
            {
                input = input.Substring(1);
                output = Convert.ToInt16(input,2);
            }
            else
            {
                input = input.Substring(1);
                output = Convert.ToInt16(input, 2);
                output = output - 128;
            }
            textBox6.Text = output.ToString();

        }

        private void print (TextBox textBox,int n)
        {
            if (n < 0)
            {
                n = 128 + n;
                textBox.Text = $"1{Convert.ToString(n, 2).PadLeft(7, '0')}";
            }
            else
            {
                textBox.Text = $"0{Convert.ToString(n, 2).PadLeft(7, '0')}";
            }
        }
    }
}
