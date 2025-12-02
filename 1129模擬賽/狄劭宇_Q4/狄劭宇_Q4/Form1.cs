using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 狄劭宇_Q4
{
    public partial class Form1 : Form
    {
        public bool mid = false;
        public byte upOrDown = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            upOrDown = 1;
            button2.Enabled = false;
            button3.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            upOrDown = 2;
            button3.Enabled = false;
            button2.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (mid)
            {
                mid = false;
                button4.BackColor = SystemColors.Control;
            }
            else
            {
                mid = true;
                button4.BackColor = SystemColors.ActiveBorder;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (upOrDown == 0)
            {
                MessageBox.Show("Choose Up or Down");
                return;
            }

            int n = int.Parse(textBox1.Text);
            string result = string.Empty;
            string updown = upOrDown == 1 ? "正向" : "垂直翻轉";

            if (upOrDown == 1)
            {
                for(int i = 0; i <= n / 2; i++)
                {
                    for(int j = 0; j < n / 2 - i; j++)
                    {
                        result += "　";
                    }

                    for(int k = 0; k < i * 2 + 1; k++)
                    {
                        result += "＊";
                    }
                    result += Environment.NewLine;
                }
            }
            else if (upOrDown == 2)
            {
                for (int i = n / 2; i >= 0; i--)
                {
                    for (int j = 0; j < n / 2 - i; j++)
                    {
                        result += "　";
                    }

                    for (int k = 0; k < i * 2 + 1; k++)
                    {
                        result += "＊";
                    }
                    result += Environment.NewLine;
                }
            }

            label1.Text = $"數值：　　　　{n}\r\n" +
                $"顯示方向：{updown}\r\n" +
                $"{result}";

            result = string.Empty;
            if (mid)
            {

                if (upOrDown == 1)
                {
                    for (int i = 0; i < n / 2; i++)
                    {
                        for (int j = 0; j < n / 2 - i; j++)
                        {
                            result += "　";
                        }

                        for (int k = 0; k < i * 2 + 1; k++)
                        {
                            if (k == 0 || k == i * 2) result += "＊";
                            else result += "　";
                        }
                        result += Environment.NewLine;
                    }
                    
                    for(int i = 0; i < n; i++)
                    {
                        result += "＊";
                    }
                }
                else if (upOrDown == 2)
                {
                    for (int i = 0; i < n; i++)
                    {
                        result += "＊";
                    }

                    result += Environment.NewLine;

                    for (int i = n / 2 - 1; i >= 0; i--)
                    {
                        for (int j = 0; j < n / 2 - i; j++)
                        {
                            result += "　";
                        }

                        for (int k = 0; k < i * 2 + 1; k++)
                        {
                            if (k == 0 || k == i * 2) result += "＊";
                            else result += "　";
                        }
                        result += Environment.NewLine;
                    }
                }
                label1.Text += $"\r\n數值：　　　　{n}\r\n" +
                    $"顯示方向：{updown}\r\n" +
                    $"設為中空\r\n" +
                    $"{result}";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label1.Text = "數值：　　　　\r\n" +
                "顯示方向：";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
