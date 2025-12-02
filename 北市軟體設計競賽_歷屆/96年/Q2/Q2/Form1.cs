using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
            int[] num = textBox1.Text
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            const int n = 6;

            if (num.Length != n) return;

            double arvg = num.Average();
            double max = num.Max();
            double min = num.Min();
            double Standard = Math.Sqrt(num.Sum(x => Math.Pow(x - arvg,2)) / n);

            label6.Text = arvg.ToString();
            label7.Text = max.ToString();
            label8.Text = min.ToString();
            label9.Text = Standard.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "10 30 50 60 80 100";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            label6.Text = string.Empty;
            label7.Text = string.Empty;
            label8.Text = string.Empty;
            label9.Text = string.Empty;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
