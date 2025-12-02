using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace Q3
{
    public partial class Form1 : Form
    {
        public static Label[] seven = new Label[7];
        public static int[] numbers = new int[10];
        public Form1()
        {
            InitializeComponent();

            seven = new Label[] { label2, label7, label8, label4, label6, label5, label3 };
            numbers = new int[] { 0b1111110, 0b0110000, 0b1101101, 0b1111001, 0b0110011, 0b1011011, 0b1011111, 0b1110000, 0b1111111, 0b1111011 };
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            int num = 0;

            for (int i = 0; i < seven.Length; i++)
            {
                int n = rand.Next(2);
                num += n * (int)Math.Pow(2, i);
            }

            changeled(num);
        }

        private void changeled(int bin)
        {
            for(int i = seven.Length - 1; i >= 0; i--)
            {
                if(bin % 2 == 1)
                {
                    seven[i].BackColor = Color.Black;
                }
                else
                {
                    seven[i].BackColor= SystemColors.Control;
                }
                bin = bin / 2;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            const int six = 0b0011111;
            const int nine = 0b1110011;
            const int a = 0b1111111;
            int num = readnum();
            string result = "非數字";

            if (num == six)
            {
                result = "6";
            }
            else if (num == nine)
            {
                result = "9";
            }
            else
            {

                for (int i = 0; i < numbers.Length; i++)
                {
                    if (num == numbers[i])
                    {
                        result = i.ToString();
                    }
                }
            }

            textBox1.Text = result;
        }

        private static int readnum()
        {
            int num = 0;
            for(int i = 0; i < seven.Length; i++)
            {
                if(seven[6 - i].BackColor == Color.Black)
                {
                    num += 1 * (int)Math.Pow(2, i);
                }
            }
            return num;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Label now = label2;
            if (now.BackColor == Color.Black)
            {
                now.BackColor = SystemColors.Control;
            }
            else
            {
                now.BackColor = Color.Black;
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Label now = label7;
            if (now.BackColor == Color.Black)
            {
                now.BackColor = SystemColors.Control;
            }
            else
            {
                now.BackColor = Color.Black;
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Label now = label8;
            if (now.BackColor == Color.Black)
            {
                now.BackColor = SystemColors.Control;
            }
            else
            {
                now.BackColor = Color.Black;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Label now = label4;
            if (now.BackColor == Color.Black)
            {
                now.BackColor = SystemColors.Control;
            }
            else
            {
                now.BackColor = Color.Black;
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Label now = label6;
            if (now.BackColor == Color.Black)
            {
                now.BackColor = SystemColors.Control;
            }
            else
            {
                now.BackColor = Color.Black;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Label now = label5;
            if (now.BackColor == Color.Black)
            {
                now.BackColor = SystemColors.Control;
            }
            else
            {
                now.BackColor = Color.Black;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Label now = label3;
            if (now.BackColor == Color.Black)
            {
                now.BackColor = SystemColors.Control;
            }
            else
            {
                now.BackColor = Color.Black;
            }
        }
    }
}
