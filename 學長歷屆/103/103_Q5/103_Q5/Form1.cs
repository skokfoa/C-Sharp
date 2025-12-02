using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace _103_Q5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> mails = new List<string>();

            if(textBox1.Text.Length > 0 && textBox2.Text.Length > 0)
            {
                int first = int.Parse(textBox1.Text);
                int last = int.Parse(textBox2.Text);

                for(int i = first; i <= last; i++)
                {
                    int validated = Validate(i);

                    mails.Add($"{i}{validated}");
                }
            }

            string[] splited = textBox3.Text.Replace(' ', ',').Split(',').ToArray();

            foreach(string s in splited)
            {
                int validated = Validate(int.Parse(s.Trim()));

                mails.Add($"{s}{validated}");
            }

            textBox4.Text = string.Join(";", mails.Select(x => $"{x}@antu.edu.tw"));
        }

        public int Validate(int num)
        {
            string chars = num.ToString();

            int sum = 0;

            for(int i = 0; i < chars.Length; i++)
            {
                sum += (chars[i] - '0') * (i + 1);
            }

            sum %= 10;

            switch (sum) {
                case 0: return 0;
                case 1: return 7;
                case 2: return 4;
                case 3: return 1;
                case 4: return 8;
                case 5: return 5;
                case 6: return 2;
                case 7: return 9;
                case 8: return 6;
                case 9: return 3;
                default: return 0;
            }
        }
    }
}
