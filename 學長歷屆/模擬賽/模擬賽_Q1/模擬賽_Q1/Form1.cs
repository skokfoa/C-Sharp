using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 模擬賽_Q1
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

            List<int> results = new List<int>();

            while(number != 0)
            {
                if(number > 0)
                {
                    results.Add(number % _base);

                    number /= _base;
                } else
                {
                    int temp = number;

                    number /= _base;
                    number++;

                    results.Add(temp - number * _base);
                }
            }

            textBox3.Text = new string(
                results.Select(x => Convert.ToString(x, 16).First()).Reverse().ToArray());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }
    }
}
