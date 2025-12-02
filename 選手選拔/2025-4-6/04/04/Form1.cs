using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _04
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text;
            char[] num = input.ToCharArray();
            int a = new int();
            for(int i = 2;i < 10; ++i)
            {
                int digit = num[i] - '0';
                a += digit * (int)Math.Pow(10, 9 - i);
            }
            string b_0_26 = Convert.ToString(a, 2).PadLeft(27, '0');

            string b_27 = Convert.ToString(num[1] - 1, 2).PadLeft(1, '0');
            a = num[0] - 'A';

            string b_28_32 = Convert.ToString(a, 2).PadLeft(5, '0');

            input = textBox2.Text;
            string year = input.Substring(0, 4);
            string month = input.Substring(4, 2);
            string day = input.Substring(6, 2);

            a = int.Parse(day);
            string b_33_37 = Convert.ToString(a, 2).PadLeft(5, '0');

            a = int.Parse(month);
            string b_38_41 = Convert.ToString(a, 2).PadLeft(4, '0');

            a = int.Parse(year) - 1900;
            string b_42_48 = Convert.ToString(a, 2).PadLeft(7, '0');


            switch (comboBox1.SelectedItem.ToString())
            {
                case "未婚":
                    a = 0; break;
                case "已婚":
                    a = 1; break;
            }
            string b_49 = Convert.ToString(a, 2).PadLeft(1, '0');

            switch (comboBox2.SelectedItem.ToString())
            {
                case "博士":
                    a = 0; break;
                case "碩士":
                    a = 1; break;
                case "大學":
                    a = 2; break;
                case "專科":
                    a = 3; break;
                case "高中":
                    a = 4; break;
                case "國中":
                    a = 5; break;
                case "小學":
                    a = 6; break;
                case "未知":
                    a = 7; break;
            }
            string b_50_52 = Convert.ToString(a, 2).PadLeft(3, '0');

            a = int.Parse(textBox3.Text);
            string b_53_79 = Convert.ToString(a, 2).PadLeft(27, '0');

            string allBits =
                b_0_26 +  b_27 + b_28_32 + b_33_37 + b_38_41 +
                b_42_48 + b_49 + b_50_52 + b_53_79;

            List<byte> byteList = new List<byte>();
            for (int i = 0; i < 80; i += 8)
            {
                string byteStr = allBits.Substring(i, 8);
                byte b = Convert.ToByte(byteStr, 2);
                byteList.Add(b);
            }
            string hexString = BitConverter.ToString(byteList.ToArray()).Replace("-", "");
            textBox4.Text = hexString;
        }
    }
}
