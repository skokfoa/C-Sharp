using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text;

            if (!input.Replace("-", "").All(char.IsDigit))
            {
                textBox1.Text = "輸入的號碼不對";
                return;
            }

            int[] isbn = input.Replace("-", "").Select(c => c - '0').ToArray();
            string i10, i13;

            i10 = Isbn10(isbn).ToString();
            i13 = Isbn13(isbn).ToString();

            if (i10 == "10")
            {
                i10 = "X";
            }else if (i10 == "11")
            {
                i10 = "0";
            }

            if (i13 == "10")
            {
                i13 = "0";
            }

            textBox2.Text = $"{isbn[0]}{isbn[1]}{isbn[2]}-{isbn[3]}{isbn[4]}{isbn[5]}{isbn[6]}-{isbn[7]}{isbn[8]}-{i10}";
            textBox3.Text = $"978-{isbn[0]}{isbn[1]}{isbn[2]}-{isbn[3]}{isbn[4]}{isbn[5]}{isbn[6]}-{isbn[7]}{isbn[8]}-{i13}";
        }

        private static int Isbn10(int[] no)
        {
            int s = 0;
            int m, n;

            for (int i = 0; i < no.Length; ++i)
            {
                s += no[i] * (10 - i);
            }

            m = s % 11;
            n = 11 - m;
            return n;
        }

        private static int Isbn13(int[] no)
        {
            int[] isbn = new int[13] {9,7,8,0,0,0,0,0,0,0,0,0,0};
            int s = 0;
            int m, n;

            for (int i = 0; i < no.Length; ++i)
            {
                isbn[i + 3] = no[i];
            }

            for (int i = 0; i < 12; i = i + 2)
            {
                s += isbn[i] * 1;
                s += isbn[i + 1] * 3;
            }

            m = s % 10;
            n = 10 - m;
            return n;
        }
    }
}
