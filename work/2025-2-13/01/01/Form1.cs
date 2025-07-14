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

        private void button2_Click(object sender, EventArgs e) // 清除
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button1_Click(object sender, EventArgs e) // 轉換
        {
            int a, b, x;

            string[] latter = {"0","1","2","3","4","5","6","7","8","9","A", "B", "C", "D", "E", "F", "G", "H", "I",
                               "J","K", "L", "M", "N", "O", "P", "Q", "R", "S", "T","U", "V", "W", "X", "Y", "Z"};

            a = int.Parse(textBox1.Text);
            b = int.Parse(textBox2.Text);

            textBox3.Text = "";

            while (a != 0)
            {
                int r = a % b;
                a = a / b;

                if( r < 0)
                {
                    r += Math.Abs(b);
                    a++;
                }
                textBox3.Text = latter[r] + textBox3.Text; 
            }
        }
    }
}
