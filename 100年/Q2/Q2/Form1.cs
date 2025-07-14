using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

        private void button1_Click(object sender, EventArgs e)
        {
            string[] input = textBox1.Text.Split('.', '/');
            int[] IP = input.Select(s => int.Parse(s)).ToArray();

            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;


            string[] b_IP = new string[4];
            for (int i = 0; i < 4; i++)
            {
                b_IP[i] = Convert.ToString(IP[i],2).PadLeft(8,'0');
            }
            
            string total = b_IP[0] + b_IP[1] + b_IP[2] + b_IP[3];
            string bit = string.Empty;
            for (int i = 0; i < 32 - IP[4]; i++)
            {
                bit += "0";
            }
            bit = bit.PadLeft(32, '1');
            
            string NetworkIp = string.Empty;
            for (int i = 0; i < total.Length; i++)
            {
                int a = total[i] - '0';
                int b = bit[i] - '0';

                int c = a & b;

                NetworkIp += c.ToString();
            }

            for (int i = 0;i < 4;++i)
            {
                textBox2.Text += Convert.ToInt32(NetworkIp.Substring(i * 8, 8), 2);
                if (i < 3)
                {
                    textBox2.Text += ".";
                }

            }

            string RedioIp = string.Empty;
            for (int i = 0; i < total.Length; i++)
            {
                int a = NetworkIp[i] - '0';
                int b = 1 - (bit[i] - '0');

                int c = a | b;

                RedioIp += c.ToString();
            }

            for (int i = 0; i < 4; ++i)
            {
                textBox3.Text += Convert.ToInt32(RedioIp.Substring(i * 8, 8), 2);
                if (i < 3)
                {
                    textBox3.Text += ".";
                }

            }
            textBox4.Text = (Math.Pow(2, 32 - IP[4]) - 2).ToString();
        }
    }
}
