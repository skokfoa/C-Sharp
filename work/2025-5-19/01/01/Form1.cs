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

        private void button1_Click(object sender, EventArgs e)
        {
            char[] T1 = textBox1.Text.ToCharArray();
            char[] T2 = textBox2.Text.ToCharArray();
            int[] a1 = new int[T1.Length];
            int[] a2 = new int[T2.Length];


            switch (Check(T1))
            {
                case 1:
                    MessageBox.Show("請勿輸入數字");
                    break;
                case 2:
                    MessageBox.Show("甲組字元有重複");
                    break;
            }
            switch (Check(T2))
            {
                case 1:
                    MessageBox.Show("請勿輸入數字");
                    break;
                case 2:
                    MessageBox.Show("乙組字元有重複");
                    break;
            }
        }

        private int Check(char[] T1)
        {
            HashSet<char> rep = new HashSet<char>();
            foreach (char c in T1)
            {
                if (char.IsDigit(c))
                {
                    return 1;
                }
                if (!rep.Add(c))
                {
                    return 2;
                }
            }
            return 0;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int cursorPos = textBox1.SelectionStart;

            string input = textBox1.Text;
            string upper = input.ToUpper();

            if (textBox1.Text != upper)
            {
                textBox1.Text = upper;
                textBox1.SelectionStart = cursorPos;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int cursorPos = textBox2.SelectionStart;

            string input = textBox2.Text;
            string upper = input.ToUpper();

            if (textBox1.Text != upper)
            {
                textBox2.Text = upper;
                textBox2.SelectionStart = cursorPos;
            }
        }
    }
}
