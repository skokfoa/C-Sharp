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

namespace _103_Q6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            int target = int.Parse(textBox1.Text);
            int pow = int.Parse(textBox2.Text);
            int mod = int.Parse(textBox3.Text);

            BigInteger number = target;

            for (int i = 0; i < pow - 1; i++)
                number *= target;

            number %= mod;

            label5.Text = number.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label5.Text = "0";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
