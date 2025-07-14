using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Q3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int min = new int();
        int sec = new int();

        private void button1_Click(object sender, EventArgs e)
        {
            min = int.Parse(textBox1.Text);
            sec = int.Parse(textBox2.Text);

            textBox1.Text = min.ToString();
            textBox2.Text = sec.ToString();
            timer1.Enabled = true;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (min == 0 && sec == 0)
            {
                timer1.Stop();
                MessageBox.Show("倒數結束！");
                return;
            }

            if (sec == 0)
            {
                if (min > 0)
                {
                    min--;
                    sec = 59;
                }
            }
            else
            {
                sec--;
            }

            textBox1.Text = min.ToString();
            textBox2.Text = sec.ToString();
        }
    }
}
