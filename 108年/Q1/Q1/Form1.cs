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
        private int balance = new int();
        List<string> output = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                balance += 5;
            }
            else if (radioButton2.Checked)
            {
                balance += 10;
            }else if (radioButton3.Checked)
            {
                balance += 50;
            }
                textBox1.Text = balance.ToString("F1");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (balance >= 35)
            {
                output.Add("Cola");
                balance -= 35;
            }
            showOutput();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (balance >= 30)
            {
                output.Add("Pepso");
                balance -= 30;
            }
            showOutput();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (balance >= 25)
            {
                output.Add("Diet Pepso");
                balance -= 25;
            }
            showOutput();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (balance >= 30)
            {
                output.Add("Diet Cola");
                balance -= 30;
            }
            showOutput();
        }

        private void showOutput()
        {
            textBox1.Text = balance.ToString("F1");
            if (output.Count > 0)
            {
                label6.Text = "";
                for (int i = 0; i < output.Count; i++)
                {
                    if (i == 0)
                    {
                        label6.Text += $"送出{output[i]}";
                    }
                    else
                    {
                        label6.Text += $"，送出{output[i]}";
                    }

                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            showOutput();
            label6.Text += $"  退回{balance}元";
            balance = 0;
            textBox1.Text = balance.ToString("F1");
        }
    }
}
