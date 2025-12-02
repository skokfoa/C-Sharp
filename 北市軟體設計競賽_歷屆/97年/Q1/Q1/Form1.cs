using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
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

        private void button1_Click(object sender, EventArgs e)
        {
            List<int> priam = new List<int>();
            int n = int.Parse(textBox1.Text);

            for(int i = 2; i <= n; i++)
            {
                bool isPriam = true;
                foreach(int j in priam)
                {
                    if (i % j == 0)
                    {
                        isPriam = false;
                        break;
                    }
                }

                if (isPriam) priam.Add(i);
            }

            textBox2.Text = string.Join(Environment.NewLine, priam);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int a, b;
            a = int.Parse(textBox3.Text);
            b = int.Parse(textBox4.Text);

            int c = a > b ? a : b;

            List<int> priam = new List<int>();
            for (int i = 2; i <= c; i++)
            {
                bool isPriam = true;
                foreach (int j in priam)
                {
                    if (i % j == 0)
                    {
                        isPriam = false;
                        break;
                    }
                }

                if (isPriam) priam.Add(i);
            }

            List<(int, int , int?)> gcd = new List<(int, int, int?)>();

            gcd.Add((a, b, null));


            foreach(int i in priam)
            {
                while (a % i == 0 && b % i == 0)
                {

                }
            }
        }
    }
}
