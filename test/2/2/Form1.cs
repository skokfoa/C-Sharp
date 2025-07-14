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

namespace _2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string t1 = textBox1.Text.Trim();
            string t2 = textBox2.Text.Trim();

            char[] c1 = t1.ToCharArray();
            char[] c2 = t2.ToCharArray();

            List<string> list = new List<string>();
            int c = 0;


            if (t1.Any(ch => char.IsDigit(ch) && t2.Any(a => char.IsDigit(a)))) 
            { }else
            
            {
                MessageBox.Show("請輸入數字");
                return;
            }

            for (int i = t1.Length - 1; i >= 0; i--)
            {
                int a1 = (int)(c1[i] - '0');
                int a2 = (int)(c2[i] - '0');
                int ans = a1 + a2 + c;
                if (ans <= 9)
                {
                    c = 0;
                }
                else
                {
                    ans -= 10;
                    c = 1;
                }
                list.Add(ans.ToString());
            }
            list.Reverse();

            textBox3.Text = string.Join("", list);
        }
    }
}
