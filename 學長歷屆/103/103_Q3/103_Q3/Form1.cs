using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace _103_Q3
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
            textBox1.Text = to_string(random.Next(0, 256) - 127);
            textBox3.Text = to_string(random.Next(0, 256) - 127);
        }

        public int parse(string str)
        {
            if(str[0] == '0')
            {
                return Convert.ToInt32(str.Substring(1), 2);
            }

            // reverse all 1 with 0
            string reverse = string.Join("", str.ToCharArray().Select(c => c == '0' ? '1' : '0'));

            return Convert.ToInt32(reverse, 2) * -1 - 1;
        }

        public int[] to_bytes(string str)
        {
            return str.Select(c => c == '0' ? 0 : 1).ToArray();
        }

        public string to_string(int number)
        {
            bool negative = number <= 0;

            if (negative)
                number = number * -1 - 1;
            
            string bytes = Convert.ToString(number, 2).PadLeft(7, '0');
            
            if(!negative)
            {
                return $"0{bytes}";
            }

            string reverse = string.Join("", bytes.Select(c => c == '0' ? '1' : '0'));

            return $"1{reverse}";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = parse(textBox1.Text).ToString();
            textBox6.Text = parse(textBox3.Text).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int[] first = to_bytes(textBox1.Text);
            int[] last = to_bytes(textBox3.Text);

            bool overflow = false;

            for(int i = 0; i < first.Length; i++)
            {
                int index = first.Length - i - 1;

                first[index] += last[index];

                if(first[index] > 1)
                {
                    first[index] -= 2;

                    if (index > 0)
                    {
                        first[index - 1]++;
                    } else
                    {
                        overflow = true;
                        break;
                    }
                }
            }

            if (overflow)
            {
                int first_num = parse(textBox1.Text);
                int last_num = parse(textBox3.Text);

                if(first_num <= 0 && last_num <= 0)
                {
                    textBox5.Text = "underflow";
                    textBox8.Text = "不足位";
                } else
                {
                    textBox5.Text = "overflow";
                    textBox8.Text = "溢位";
                }
            }

            textBox4.Text = string.Join("", first);
            textBox7.Text = parse(textBox4.Text).ToString();
        }
    }
}
