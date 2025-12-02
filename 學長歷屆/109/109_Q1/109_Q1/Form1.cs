using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _109_Q1
{
    public partial class Form1 : Form
    { 
        string[] digits = { "零", "壹", "貳", "參", "肆", "伍", "陸", "柒", "捌", "玖" };
        string[] positions = { "", "拾", "佰", "仟", "萬", "十萬", "百萬", "千萬", "億", "十億", "百億", "千億" };
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label4.Text = label5.Text = textBox1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label4.Text = int.Parse(textBox1.Text).ToString("N0");

            bool isZero = false;
            string result = "";

            // reference: https://stackoverflow.com/a/59368940
            for (int i = 0; i < textBox1.TextLength; i++)
            {
                char text = textBox1.Text[i];

                if (text != '0')
                {
                    if (isZero)
                        result += "零";

                    result += digits[text - '0'] + positions[textBox1.TextLength - i - 1];
                }

                if (text == '0')
                    isZero = true;

                label5.Text = result;
            }
        }
    }
}