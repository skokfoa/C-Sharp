using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 狄劭宇_Q1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = @"C:\Users\宇\Desktop\狄劭宇_Contest\狄劭宇_Q1\第一題(撲克牌數字)\";
            string[] porkerPath =
            {
                "1.jpg",
                "2.jpg",
                "3.jpg",
                "4.jpg",
                "5.jpg",
                "6.jpg",
                "7.jpg",
                "8.jpg",
                "9.jpg",
                "10.jpg",
                "11.jpg",
                "12.jpg",
                "13.jpg",
            };

            int sum1 = int.Parse(textBox3.Text);
            int sum2 = int.Parse(textBox2.Text);

            int biggest = int.Parse(textBox1.Text);

            List<(int, int, int)> ans = new List<(int, int, int)>();

            for(int a = 1; a < biggest; a++)
            {
                for(int b = 1; b < biggest; b++)
                {
                    if (a == b) continue;
                    if (a + b != sum1) continue;
                    for(int c = 1; c < biggest; c++)
                    {
                        if (a == c || b == c) continue;
                        if (a + c != sum2) continue;
                        ans.Add((a, b, c));
                    }
                }
            }

            if (ans.Count == 0)
            {
                textBox4.Text = "無解";
                return;
            }

            textBox4.Text = string.Join(Environment.NewLine, ans.Select(x => $"({x.Item1}, {x.Item2}, {x.Item3})"));

            int num1, num2, num3;
            (num1, num2, num3) = ans.ElementAt(0);

            Bitmap bmp = new Bitmap(path + porkerPath[num1 - 1]);
            pictureBox1.Image = bmp;

            bmp = new Bitmap(path + porkerPath[num2 - 1]);
            pictureBox2.Image = bmp;

            bmp = new Bitmap(path + porkerPath[num3 - 1]);
            pictureBox3.Image = bmp;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
