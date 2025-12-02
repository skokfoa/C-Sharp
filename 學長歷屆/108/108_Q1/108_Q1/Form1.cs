using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _108_Q1
{
    public partial class Form1 : Form
    {
        int balance = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RadioButton[] buttons = { radioButton1, radioButton2, radioButton3 };
            int[] coins = { 5, 10, 50 };

            for (int i = 0; i < coins.Length; i++)
                if (buttons[i].Checked)
                {
                    balance += coins[i];
                    Display();
                    break;
                }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Buy(35, "Cola");
        }

        public void Buy(int price, string item)
        {
            if (balance < price)
                return;

            if (label6.Text.Length > 0)
                label6.Text += ",";

            label6.Text += $" 送出 {item}";
            balance -= price;
            Display();
        }

        public void Display()
        {
            textBox1.Text = balance.ToString("F1");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label6.Text += $" 退還{balance}元";

            balance = 0;
            Display();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Buy(30, "PEPSO");
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Buy(25, "Diet PEPSO");
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Buy(30, "Diet Cola");
        }
    }
}
