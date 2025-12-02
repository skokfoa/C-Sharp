using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace 模擬賽_Q2
{
    public partial class Form1 : Form
    {
        int side = 0;
        readonly int[] inputs = Enumerable.Repeat(-1, 9).ToArray();
        bool ended = false, first = true;
        string[] symbol = new string[] { "A", "B" };

        public Form1()
        {
            InitializeComponent();
        }

        public void Down(int index, Button button)
        {
            if(first)
            {
                if(!Regex.IsMatch(textBox1.Text, @"^[A-Za-z]{1}$") || !Regex.IsMatch(textBox2.Text, @"^[A-Za-z]{1}$"))
                {
                    MessageBox.Show("輸入的符號無效", "Ticp");
                    return;
                }

                symbol = new string[]
                {
                    textBox1.Text,
                    textBox2.Text
                };

                first = false;
            }

            if (ended || inputs[index] > -1)
                return;

            inputs[index] = side;
            button.Text = symbol[side];

            for (int i = 0; i < inputs.Length; i++)
            {
                if (
                    (inputs[0] == i && inputs[1] == i && inputs[2] == i) ||
                    (inputs[3] == i && inputs[4] == i && inputs[5] == i) ||
                    (inputs[6] == i && inputs[7] == i && inputs[8] == i) ||
                    (inputs[0] == i && inputs[3] == i && inputs[6] == i) ||
                    (inputs[1] == i && inputs[4] == i && inputs[7] == i) ||
                    (inputs[2] == i && inputs[5] == i && inputs[8] == i) ||
                    (inputs[0] == i && inputs[4] == i && inputs[8] == i) ||
                    (inputs[2] == i && inputs[4] == i && inputs[6] == i)
                )
                {
                    if (i == 0)
                        label3.Text = "甲方獲勝";
                    else label3.Text = "乙方獲勝";

                    ended = true;

                    return;
                }
            }

            if(!inputs.Any(x => x == -1))
            {
                label3.Text = "和局";
                ended = true;

                return;
            }

            side = side == 0 ? 1 : 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Down(1, button2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Down(2, button3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Down(3, button4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Down(4, button5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Down(5, button6);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Down(6, button7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Down(7, button8);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Down(8, button9);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Down(0, button1);
        }
    }
}
