using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            float x_min = float.Parse(textBox1.Text);
            float x_max = float.Parse(textBox2.Text);
            int accurative_float = int.Parse(textBox3.Text);
            int x_total = (int)((x_max-x_min) * Math.Pow(10, accurative_float));
            int digits = new int();
            string input = textBox4.Text;
            string output = string.Empty;

            if((int)(Math.Log(x_total, 2)) < Math.Log(x_total, 2))
            {
                digits = (int)(Math.Log(x_total, 2)) + 1;
            }
            else
            {
                digits = (int)(Math.Log(x_total, 2));
            }

            if (input.Contains('.'))
            {
                double Decimal = (double.Parse(input));
                Decimal = (Decimal - x_min) * (Math.Pow(2, digits) - 1) / (x_max - x_min);
                string check = ((int)(Decimal) * (x_max - x_min) / (Math.Pow(2, digits) - 1) + x_min).ToString($"F{accurative_float}");
                if (double.Parse(check) != double.Parse(input))
                {
                    Decimal += 1;
                }
                output = Convert.ToString((int)Decimal,2).PadLeft(digits,'0');
            }
            else
            {
                double Binary = Convert.ToInt32(input, 2);
                Binary = Binary * (x_max - x_min) / (Math.Pow(2, digits) - 1) + x_min;
                output = Binary.ToString($"F{accurative_float}");
            }

            label5.Text = $"Ans = {output}";
        }
    }
}
