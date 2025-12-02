using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int num = new int();
            int letter = new int();

            string input = textBox1.Text;

            (num, letter) = count(input);

            label2.Text = $"{letter} {num}";
        }

        private bool isStrong(string s,int n,int l)
        {
            if (!(s.Length >= 12))
            {
                return false;
            }

            if (!(n > 0 &&  l > 0))
            {
                return false;
            }

            if(!(l > n))
            {
                return false;
            }
            return true;
        }

        private bool isWeek(string s, int n, int l)
        {
            if (s.Length >= 8 && s.Length < 12)
            {
                return true;
            }

            if ((n == 0 && l > 0) || (l == 0 && n > 0))
            {
                return true;
            }

            return (n >= l);
        }

        private (int num, int letter) count(string s)
        {
            int num = 0, letter = 0;
            foreach (char c in s)
            {
                if (c >= '0' && c <= '9')
                {
                    num++;
                }
                else if (c >= 'a' && c <= 'z')
                {
                    letter++;
                }
            }
            return (num, letter);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int num, letter;
            string input = textBox1.Text;

            (num, letter) = count(input);

            if (isStrong(input, num, letter))
            {
                label3.Text = "strong";
                return;
            }else if (isWeek(input, num, letter))
            {
                label3.Text = "week";
                return;
            }
            else
            {
                label3.Text = "Wrong";
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            label2.Text = string.Empty;
            label3.Text = string.Empty;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
