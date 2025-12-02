using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _03
{
    public partial class Form1 : Form
    {
        int[,] a = new int[2,2];
        int[,] b = new int[2,2];
        int[,] result = new int[2, 2];
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            a[0, 0] = int.Parse(textBox1.Text);
            a[0, 1] = int.Parse(textBox4.Text);
            a[1, 0] = int.Parse(textBox2.Text);
            a[1, 1] = int.Parse(textBox3.Text);

            b[0, 0] = int.Parse(textBox8.Text);
            b[0, 1] = int.Parse(textBox6.Text);
            b[1, 0] = int.Parse(textBox7.Text);
            b[1, 1] = int.Parse(textBox5.Text);

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    result[i, j] = 0;
                    for (int k = 0; k < 2; k++)
                    {
                        result[i, j] += a[i, k] * b[k, j];
                    }
                }
            }

            textBox12.Text = result[0, 0].ToString();
            textBox10.Text = result[0, 1].ToString();
            textBox11.Text = result[1, 0].ToString();
            textBox9.Text = result[1, 1].ToString();
        }
    }
}
