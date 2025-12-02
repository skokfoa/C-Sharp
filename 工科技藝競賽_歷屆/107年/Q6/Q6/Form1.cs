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

        private void RandomNum(object sender, EventArgs e)
        {
            if (sender == button1) textBox12.Text = textBox13.Text = string.Empty;
            else textBox15.Text = textBox16.Text = string.Empty;

            Random rnd = new Random();
            string rand = string.Empty;

            rand = string.Join
                ("", Enumerable.Range(0, 50)
                .Select(x => rnd.Next(0, 1 + 1).ToString()));

            if(sender == button1) textBox11.Text = rand;
            else textBox14.Text = rand;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(calculate(textBox11.Text, out string result))
            {
                textBox13.Text = result;
            }
            else
            {
                textBox12.Text = "不合理";
            }
            
            if(calculate(textBox14.Text, out string result2))
            {
                textBox15.Text = result2;
            }
            else
            {
                textBox16.Text = "不合理";
            }
        }

        private bool calculate(string a, out string b)
        {
            b = string.Empty;

            string[] key = { "10", "01", "11", "001", "000" };

            while (a.Length > 0)
            {
                if (!(a.Length > 1)) return false;

                string part2 = a.Substring(0, 2);
                string part3 = a.Substring(0, Math.Min(3, a.Length));

                bool matched = false;

                for (int i = 0; i < key.Length; i++)
                {
                    if (part2 == key[i])
                    {
                        b += change(i);
                        a = a.Substring(2);
                        matched = true;
                        break;
                    }
                    else if (part3 == key[i])
                    {
                        b += change(i);
                        a = a.Substring(3);
                        matched = true;
                        break;
                    }
                }

                if (!matched) return false;
            }

            if (b.Length > 0) return true;

            return false;
        }

        private string change(int i)
        {
            switch (i)
            {
                case 0:
                    return "A";
                case 1:
                    return "B";
                case 2:
                    return "C";
                case 3:
                    return "D";
                case 4:
                    return "E";
                default:
                    return string.Empty;
            }
}

private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
