using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string[] num = { "零", "壹", "貳", "參", "肆", "伍", "陸", "柒", "捌", "玖" };
        private string[] ten = { "", "拾", "佰", "仟" };
        private string[] big = { "", "萬", "億", "兆" };

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            label4.Text = "";
            label5.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text;
            if (input.Length > 13) { MessageBox.Show("超過範圍，請重新輸入"); return; }
            if (int.Parse(input) < 0) { MessageBox.Show("超過範圍，請重新輸入"); return; }

            ThreePrint(input);
            ChinesePrint(input);
        }

        private void ThreePrint(string input)
        {
            string num3 = string.Empty;
            for (int i = 0; i < input.Length; i++)
            {
                if (i != 0 && i % 3 == 0)
                {
                    num3 += ",";
                }
                num3 += input[input.Length - 1 - i];
            }
            num3 = new string(num3.Reverse().ToArray());
            label4.Text = num3;
        }

        private void ChinesePrint(string input)
        {
            int[,] value = new int[input.Length,2];
            string output = string.Empty;
            for (int i = 0;i < input.Length; i++)
            {
                value[i, 0] = input[i] - '0';
                value[i, 1] = input.Length - 1 - i;

            }

            bool zero = false;
            int count = 0;
            for (int i = 0; i < input.Length; i++)
            {
                int n = value[i, 1] / 4;
                int t = value[i, 1] % 4;
                switch (n)
                {
                    case 0:
                        if (value[i, 0] != 0)
                        {
                            output += num[value[i, 0]] + ten[t];
                            zero = false;
                        }
                        else if(t == 0)
                        {
                            output += big[n];
                            zero = false;
                        }
                        else
                        {
                            if (!zero)
                            {
                                output += num[0];
                                zero = true;
                            }
                        }
                        break;
                    case 1:
                        if (value[i, 0] != 0)
                        {
                            if (t == 1 && value[i, 0] == 1 && (i == 0 || value[i - 1, 1] % 4 != 0))
                            {
                                output += ten[t];
                            }
                            else
                            {
                                output += num[value[i, 0]] + ten[t];
                                zero = false;
                            }
                        }
                        else if (t == 0) { count++; }
                        else
                        {
                            count++;
                            if (!zero)
                            {
                                output += num[0];
                                zero = true;
                            }
                        }

                        if (t == 0 && count != 4)
                        {
                            zero = false;
                            output += big[n];
                        }
                        break;
                    case 2:
                        if (value[i, 0] != 0)
                        {
                            if (t == 1 && value[i, 0] == 1 && (i == 0 || value[i - 1, 1] % 4 != 0))
                            {
                                output += ten[t];
                            }
                            else
                            {
                                output += num[value[i, 0]] + ten[t];
                                zero = false;
                            }
                        }
                        else if (t == 0) { count++; }
                        else
                        {
                            count++;
                            if (!zero)
                            {
                                output += num[0];
                                zero = true;
                            }
                        }

                        if (t == 0 && count != 4)
                        {
                            zero = false;
                            output += big[n];
                        }
                        break;
                    case 3:
                        if (value[i, 0] != 0)
                        {
                            if (t == 1 && value[i, 0] == 1 && (i == 0 || value[i - 1, 1] % 4 != 0))
                            {
                                output += ten[t];
                            }
                            else
                            {
                                output += num[value[i, 0]] + ten[t];
                                zero = false;
                            }
                        }
                        else if (t == 0) { count++; }
                        else
                        {
                            count++;
                            if (!zero)
                            {
                                output += num[0];
                                zero = true;
                            }
                        }

                        if (t == 0 && count != 4)
                        {
                            zero = false;
                            output += big[n];
                        }
                        break;
                }
            }
            label5.Text = output.TrimEnd('零');
        }
    }
}