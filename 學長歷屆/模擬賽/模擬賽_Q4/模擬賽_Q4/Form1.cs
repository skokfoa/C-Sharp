using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 模擬賽_Q4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int[] numbers = textBox1.Text.Split(' ').Select(x => int.Parse(x.Trim())).ToArray();

                if(numbers.Length != 6)
                {
                    MessageBox.Show("錯誤的成績數量");
                    return;
                }

                if(numbers.Any(x => x > 100 || x < 0))
                {
                    MessageBox.Show("錯誤的成績範圍");
                    return;
                }

                double average = numbers.Average();

                label6.Text = average.ToString();
                label7.Text = numbers.Max().ToString();
                label8.Text = numbers.Min().ToString();
                label9.Text = Math.Sqrt(numbers.Sum(x => Math.Pow(x - average, 2)) / numbers.Length).ToString();
            } catch(Exception)
            {
                MessageBox.Show("錯誤的輸入格式");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            label6.Text = "";
            label7.Text = "";
            label8.Text = "";
            label9.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "10 30 50 60 80 100";
        }
    }
}
