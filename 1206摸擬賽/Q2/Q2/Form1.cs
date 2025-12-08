using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
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

        private void button_Ckick(object sender, EventArgs e)
        {
            BigInteger a = BigInteger.Parse(textBox1.Text);
            BigInteger b = BigInteger.Parse(textBox2.Text);
            BigInteger sum = new BigInteger();
            if (sender == button1)
            {
                sum = a + b;
            }
            else if (sender == button2)
            {
                sum = a - b;
            }
            else if (sender == button3)
            {
                sum = a * b;
            }
            else
            {
                return;
            }

                textBox3.Text = sum.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox2.Text = textBox3.Text = string.Empty;
        }
    }
}
