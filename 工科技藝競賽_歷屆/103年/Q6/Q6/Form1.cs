using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x = int.Parse(textBox1.Text);
            int p = int.Parse(textBox2.Text);
            int n = int.Parse(textBox3.Text);

            int r = 1;

            while (p > 0)
            {
                if (p % 2 == 1)
                {
                    r = (r * x) % n;
                }

                x = (x * x) % n;
                p = p / 2;

            }

            label4.Text = $"餘數 = {r}";

        }
    }
}
