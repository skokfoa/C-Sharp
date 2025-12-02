using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _110_Q2
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

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";

            label2.Text = "";
            label3.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!ValidatePassword())
                return;

            int number = Regex.Matches(textBox1.Text, @"\d").Count,
                alaphbet = Regex.Matches(textBox1.Text, @"[A-Za-z]").Count;

            label2.Text = $"{alaphbet}, {number}";
        }

        public bool ValidatePassword()
        {
            if(textBox1.TextLength < 8 || textBox1.TextLength > 20)
            {
                textBox1.Text = "";
                label2.Text = "請重新輸入";
                return false;
            }

            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!ValidatePassword())
                return;

            int strong = 0;

            if (textBox1.TextLength >= 12)
                strong++;

            int number = Regex.Matches(textBox1.Text, @"\d").Count,
                alaphbet = Regex.Matches(textBox1.Text, @"[A-Za-z]").Count;

            if (number > 0 && alaphbet > 0)
                strong++;

            if (alaphbet > number)
                strong++;

            label3.Text = strong == 3 ? "strong" : "weak";
        }
    }
}
