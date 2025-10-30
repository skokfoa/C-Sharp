using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text;
            int[] num = input
                .Split(new char[] { ' ', ','} , StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            Array.Reverse(num);

            int a, b;

            a = num[0]; b = 1;
            for(int i = 1; i < num.Length; i++)
            {
                int c = a;
                a = a * num[i] + b;
                b = c;
            }
            textBox2.Text = $"{a} / {b}";
        }
    }
}
