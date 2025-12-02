using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _103_Q1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double x = double.Parse(textBox1.Text), 
                y = double.Parse(textBox2.Text), 
                z = double.Parse(textBox3.Text),
                a = double.Parse(textBox6.Text),
                b = double.Parse(textBox5.Text), 
                c = double.Parse(textBox4.Text);

            // preventing float number incaccurate!
            if(x * 100000 + y * 100000 + z * 100000 != 100000)
            {
                label19.Text = "無解";
                return;
            }

            double chance = x * a + y * b + z * c;

            label19.Text = $"在台北市的上班族遲到的機率為: {chance}";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double x = double.Parse(textBox1.Text),
                y = double.Parse(textBox2.Text),
                z = double.Parse(textBox3.Text),
                a = double.Parse(textBox6.Text),
                b = double.Parse(textBox5.Text),
                c = double.Parse(textBox4.Text);

            // preventing float number incaccurate!
            if (x * 100000 + y * 100000 + z * 100000 != 100000)
            {
                label19.Text = "無解";
                return;
            }

            double chance = x * a + y * b + z * c;

            label19.Text = $"如果已知有一個人上班遲到，那他是自己開車的機率為何: {z * c / chance}";
        }
    }
}
