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

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = string.Empty;
            string[] input = textBox1.Text.Split('\n');
            for(int i = 0; i < input.Length; i++)
            {
                string output = change(input[i]);
                string put = string.Empty;
                for (int j = 0; j < output.Length; ++j)
                {
                    if (output[j] == '0')
                    {
                        continue;
                    }

                    put += $"{output[j]}";
                }
                string trim = put.Length > 4 ? put.Substring(0, 4) : put;
                textBox2.Text += trim.PadRight(4, '0') + "\r\n";
            }
        }

        private string change(string soundex)
        {
            char[] nochange = { 'A', 'E', 'I', 'O', 'U', 'Y', 'W', 'H' };
            char[] one = { 'B', 'P', 'F', 'V' };
            char[] two = { 'C', 'S', 'K', 'G', 'J', 'Q', 'X', 'Z' };
            char[] three = { 'D', 'T' };
            char[] four = { 'L' };
            char[] five = { 'M', 'N' };
            char[] six = { 'R' };

            string output = soundex[0].ToString();
            List<int> outnum = new List<int>();



            for (int i = 0; i < soundex.Length; ++i)
            {
                for (int j = 0; j < nochange.Length; ++j)
                {
                    if (soundex[i] == nochange[j])
                    {
                        outnum.Add(0);
                    }
                }

                for (int j = 0; j < one.Length; ++j)
                {
                    if (soundex[i] == one[j])
                    {
                        outnum.Add(1);
                    }
                }

                for (int j = 0; j < two.Length; ++j)
                {
                    if (soundex[i] == two[j])
                    {
                        outnum.Add(2);
                    }
                }

                for (int j = 0; j < three.Length; ++j)
                {
                    if (soundex[i] == three[j])
                    {
                        outnum.Add(3);
                    }
                }

                for (int j = 0; j < four.Length; ++j)
                {
                    if (soundex[i] == four[j])
                    {
                        outnum.Add(4);
                    }
                }

                for (int j = 0; j < five.Length; ++j)
                {
                    if (soundex[i] == five[j])
                    {
                        outnum.Add(5);
                    }
                }

                for (int j = 0; j < six.Length; ++j)
                {
                    if (soundex[i] == six[j])
                    {
                        outnum.Add(6);
                    }
                }
            }

            for (int i = 0; i < outnum.Count - 1; ++i)
            {
                if (outnum[i] == outnum[i + 1])
                {
                    outnum.RemoveAt(i);
                }
            }

            for (int i = 1; i < outnum.Count; i++) output += outnum[i].ToString();
            return output;
        }
    }
}
