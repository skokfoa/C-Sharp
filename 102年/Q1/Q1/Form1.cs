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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
            uint[,] first_step = new uint[6,6];
            uint[,] second_step = new uint[3,3];
            uint[] third_step = new uint[2];
            uint[,] ans_array = new uint[3,3];

            System.Windows.Forms.TextBox[] textbox =
            {
                textBox1,  textBox2,  textBox3,  textBox4,  textBox5,  textBox6,  textBox7,  textBox8,
                textBox9,  textBox10, textBox11, textBox12, textBox13, textBox14, textBox15, textBox16,
                textBox17, textBox18, textBox19, textBox20, textBox21, textBox22, textBox23, textBox24,
                textBox25, textBox26, textBox27, textBox28, textBox29, textBox30, textBox31, textBox32,
                textBox33, textBox34, textBox35, textBox36, textBox37, textBox38, textBox39, textBox40,
                textBox41, textBox42, textBox43, textBox44, textBox45, textBox46, textBox47
            };

            int number = 0;
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    first_step[i,j] = uint.Parse(textbox[number].Text);
                    number++;
                }
            }

            for (int i = 0;i < 3; i++)
            {
                for(int j = 0;j < 3; j++)
                {
                    second_step[i, j] = uint.Parse(textbox[number].Text);
                    number++;
                }
            }

            for(int i = 0;i < 2; i++)
            {
                third_step[i] = uint.Parse(textbox[number].Text);
                number++;
            }


            for(int i = 0;i < 3; i++)
            {
                for(int j = 0;j < 3; j++)
                {
                    ans_array[i,j] = first_step[i + third_step[0], j + third_step[1]];
                }
            }

            uint mid = ans_array[1, 1];

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if(ans_array[i, j] >= mid)
                    {
                        ans_array[i, j] = 1;
                    }
                    else
                    {
                        ans_array[i, j] = 0;
                    }
                }
            }

            ans_array[1, 1] = 0;
            uint final = new uint();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    final += ans_array[i, j] * second_step[i,j];
                    textBox49.Text += $"{ans_array[i, j]} ";
                }
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
