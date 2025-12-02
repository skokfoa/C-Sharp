using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _104_Q2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";

            string[] names = textBox1.Text.Split('\n');

            foreach (string name in names)
            {
                string result = name[0].ToString();

                for(int i = 1; i < name.Length; i++)
                {
                    if (result.Length >= 4)
                        break;

                    switch (name[i])
                    {
                        case 'B':
                        case 'P':
                        case 'F':
                        case 'V':
                            result += "1";
                            break;
                        case 'C':
                        case 'S':
                        case 'K':
                        case 'G':
                        case 'J':
                        case 'Q':
                        case 'X':
                        case 'Z':
                            result += "2";
                            break;
                        case 'D':
                        case 'T':
                            result += "3";
                            break;
                        case 'L':
                            result += "4";
                            break;
                        case 'M':
                        case 'N':
                            result += "5";
                            break;
                        case 'R':
                            result += "6";
                            break;
                    }
                }

                textBox2.Text += result.PadRight(4, '0');
                textBox2.Text += "\n";
            }
        }
    }
}
