using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a, b;
            string result = string.Empty;
            a = int.Parse(textBox1.Text);
            b = int.Parse(textBox2.Text);
            int c = 0;
            while (a != 0)
            {
                int r = a % b;
                a /= b;
                if (r < 0)
                {
                    a++;
                    r -= b;
                }
                result += r.ToString();
                c++;
                if (c == 100) break;
            }
            result = new string(result.Reverse().ToArray());
            textBox3.Text = result;
        }
    }
}
