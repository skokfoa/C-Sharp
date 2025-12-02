using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q1
{
    public partial class Form1 : Form
    {
        TextBox[] input = new TextBox[6];
        public Form1()
        {
            InitializeComponent();
            input = new TextBox[] { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6 };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!checkInput())
            {
                textBox7.Text = "無解";
                return;
            }
            double[] a = new double[3];
            double[] b = new double[3];
            for (int i = 0; i < input.Length; i++)
            {
                if(i < 3)
                {
                    a[i] = double.Parse(input[i].Text);
                }
                else
                {
                    b[i - 3] = double.Parse(input[i].Text);
                }
            }
            double result = 0;
            for (int i = 0; i < 3; i++)
            {
                result += a[i] * b[i];
            }
            textBox7.Text = $"在台北市的上班族遲到的機率為:{result}";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!checkInput())
            {
                textBox7.Text = "無解";
                return;
            }
            double[] a = new double[3];
            double[] b = new double[3];
            for (int i = 0; i < input.Length; i++)
            {
                if (i < 3)
                {
                    a[i] = double.Parse(input[i].Text);
                }
                else
                {
                    b[i - 3] = double.Parse(input[i].Text);
                }
            }
            double result = 0;
            for (int i = 0; i < 3; i++)
            {
                result += a[i] * b[i];
            }
            result = (a[2] * b[2]) / result;
            textBox7.Text = $"如果已知一個人上班遲到，那他是自己開車的機率為何:{result}";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool checkInput()
        {
            double[] a = new double[6];
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].Text == "")
                {
                    return false;
                }
                if (!double.TryParse(input[i].Text, out a[i]))
                {
                    return false;
                }

                if (a[i] < 0 || a[i] > 1)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
