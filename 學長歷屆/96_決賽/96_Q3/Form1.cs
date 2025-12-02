using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace _96_Q3
{
    public partial class Form1 : Form
    {
        readonly char[] possibles = { 'K', 'L', 'M', 'N', 'O' };

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string check = Validate(textBox1.Text) == -1 ? "" : "不";

            textBox2.Text = $"{textBox1.Text} {check}是正確的密碼文字";
        }

        public int Validate(string str)
        {
            if (Array.Exists(str.ToCharArray(), x => !possibles.Contains(x)))
                return 7;

            if(str.Length < 3)
                return 1;

            if (str[0] == 'K')
                return 2;

            if (str.Contains('L') && str.Count(x => x == 'L') < 2)
                return 3;

            if (str[str.Length - 1] == 'M' || str[str.Length - 2] == 'M')
                return 4;

            if (str.Contains('K') && !str.Contains('N'))
                return 5;

            if (str[str.Length - 1] == 'O' && !str.Contains('L'))
                return 6;

            return -1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int check = Validate(textBox4.Text);

            if (check == -1)
            {
                textBox3.Text = $"{textBox4.Text} 是正確的密碼文字";

                return;
            }

            textBox3.Text = $"本輸入密碼無法滿足第{Validate(textBox4.Text)}條件";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string clone;

            for(int i = 0; i < textBox6.TextLength; i++)
            {
                for (int j = 0; j < possibles.Length; j++)
                {
                    clone = textBox6.Text.Remove(i, 1).Insert(i, possibles[j].ToString());
                    Console.WriteLine(clone);
                    if(Validate(clone) == -1)
                    {
                        textBox8.Text = clone;

                        break;
                    }
                }
            }

            for (int i = 0; i < textBox5.TextLength; i++)
            {
                for (int j = 0; j < possibles.Length; j++)
                {
                    clone = textBox5.Text.Remove(i, 1).Insert(i, possibles[j].ToString());

                    if (Validate(clone) == -1)
                    {
                        textBox7.Text = clone;

                        break;
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            List<string> results = new List<string>();

            for(int i = 1; i < possibles.Length; i++)
            {
                string input = string.Join("", Enumerable.Repeat(possibles[i], 3));

                if (Validate(input) == -1)
                    results.Add(input);
            }

            textBox9.Text = string.Join("、", results);
            textBox10.Text = results.Count.ToString();
        }
    }
}
