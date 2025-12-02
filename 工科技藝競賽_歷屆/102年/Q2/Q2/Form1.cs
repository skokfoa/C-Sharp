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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int int_num = random.Next(9999);
            int float_num = random.Next(999999);
            double number = int_num + (float_num / 1000000.0);
            textBox1.Text = number.ToString(".######");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double number;
            if (!double.TryParse(textBox1.Text, out number))
            {
                MessageBox.Show("輸入錯誤!");
                return;
            }

            int intPart = (int)number;
            string bar_int_num = Convert.ToString(intPart, 2);


            double fracPart = number - intPart;
            fracPart = Math.Round(fracPart, 10);
            string bar_float_num = "";

            int limit = 10;
            int count = 0;
            double epsilon = 1e-10;

            while (fracPart > epsilon && count < limit)
            {
                fracPart *= 2;
                int bit = (int)fracPart;
                bar_float_num += bit.ToString();
                fracPart -= bit;
                fracPart = Math.Round(fracPart, 12);
                count++;
            }

            string finalBinary = bar_int_num + "." + bar_float_num;
            textBox2.Text = finalBinary;
            textBox3.Text = finalBinary.TrimEnd('0');
        }

    }
}
