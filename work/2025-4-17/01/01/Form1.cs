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
            string a1 = textBox1.Text;
            string a2 = textBox2.Text;

            string result = AddBigNumbers(a1, a2);

            textBox3.Text = result;

        }

        static string AddBigNumbers(string num1, string num2)
        {
            // 將字串倒轉，方便從最低位開始相加
            char[] n1 = num1.ToCharArray();
            Array.Reverse(n1);
            char[] n2 = num2.ToCharArray();
            Array.Reverse(n2);

            int maxLength = Math.Max(n1.Length, n2.Length);
            int carry = 0;
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < maxLength; i++)
            {
                int digit1 = i < n1.Length ? n1[i] - '0' : 0;
                int digit2 = i < n2.Length ? n2[i] - '0' : 0;

                int sum = digit1 + digit2 + carry;
                result.Append(sum % 10);
                carry = sum / 10;
            }

            if (carry > 0)
                result.Append(carry);

            // 結果再倒回來
            char[] res = result.ToString().ToCharArray();
            Array.Reverse(res);
            return new string(res);
        }
    }
}
