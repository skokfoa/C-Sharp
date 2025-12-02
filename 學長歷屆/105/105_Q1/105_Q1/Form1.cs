using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _105_Q1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int number = int.Parse(textBox1.Text);
            int _base = int.Parse(textBox2.Text);

            List<int> lefts = new List<int>();

            while(number != 0)
            {
                int left = number % _base;

                if(left >= 0) { 
                    lefts.Add(left);
                    number /= _base;
                } else
                {
                    int tmp = number;

                    number /= _base;
                    number += 1;
                    lefts.Add(tmp - number * _base);
                }
            }

            textBox3.Text = new string(lefts.Select(x =>
            {
                if (x < 10)
                {
                    return (char) ('0' + x);
                }

                return (char) ('A' + x - 10);
            }).Reverse().ToArray());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }
    }
}
