using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _103Q5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox4.Text = string.Empty;
            string input = string.Empty;
            int start = 0;
            int end = 0;
            List<int> more = new List<int>();
            List<string> output = new List<string>();

            if (!string.IsNullOrEmpty(input = textBox1.Text))
            {
                start = int.Parse(input);
            }
            if(!string.IsNullOrEmpty(input = textBox2.Text))
            {
                end = int.Parse(input);
            }
            if(!string.IsNullOrEmpty(input = textBox3.Text.TrimEnd(',',' ')))
            {
                string[] a = input.Split(',',' ');
                foreach(string s in a)
                {
                    more.Add(int.Parse(s));
                }
            }


            for(int i = start; i <= end; ++i)
            {
                int c = check(i);
                output.Add($"{i}{c}");
            }

            for(int i = 0;i < more.Count; ++i)
            {
                int c = check(more[i]);
                output.Add($"{more[i]}{c}");
            }

            for(int i = 0; i < output.Count; ++i)
            {
                if (i % 3 == 0 && i != 0)
                {
                    textBox4.Text += "\r\n";
                }
                textBox4.Text += output[i] + "@antu.edu.tw;";
            }
        }

        private int check(int n)
        {
            byte[] checks = new byte[] { 0, 7, 4, 1, 8, 5, 2, 9, 6, 3 };
            int[] num = new int[8];
            int sum = 0;
            for(int i = 0;i < num.Length; ++i)
            {
                num[i] = n % 10;
                n /= 10;
                sum += num[i] * (8 - i);
            }

            sum %= 10;
            return checks[sum];
        }
    }
}
