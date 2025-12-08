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

namespace Q5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] ipdir = textBox1.Text
                .Split(new char[] { ' ', '.', '/' }, StringSplitOptions.RemoveEmptyEntries)
                .Take(4)
                .Select(int.Parse)
                .ToArray();

            int NB = int.Parse(textBox1.Text
                .Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries)
                .Last());

            string Ip = string.Empty;

            foreach(int i in ipdir)
            {
                Ip += Convert.ToString(i, 2).PadLeft(8, '0');
            }

            Ip = Ip.Substring(0, NB).PadRight(32,'0');

            int[] numip = new int[4];

            for(int i = 0; i < 4; i++)
            {
                string s = Ip.Substring(i * 8, 8);
                numip[i] = Convert.ToInt32(s, 2);
            }

            textBox2.Text = string.Join(".", numip);

            string r = string.Empty;

            for(int i = 0; i < 32 - NB; i++)
            {
                r += "1";
            }

            r = r.PadLeft(32, '0');

            string redio = string.Empty;
            for(int i = 0; i < 32; i++)
            {
                redio += r[i] == '1' || Ip[i] == '1' ? "1" : "0";
            }

            for (int i = 0; i < 4; i++)
            {
                string s = redio.Substring(i * 8, 8);
                numip[i] = Convert.ToInt32(s, 2);
            }

            textBox3.Text = string.Join(".", numip);

            long count = (long)Math.Pow(2, 32 - NB) - 2;
            textBox4.Text = count.ToString();
        }
    }
}
