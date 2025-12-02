using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _102_Q1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TextBox[,] input_fields = new TextBox[6, 6]
            {
                {textBox1, textBox2, textBox3, textBox4, textBox5, textBox6 },
                {textBox7, textBox8, textBox9, textBox10, textBox11, textBox12 },
                {textBox13, textBox14, textBox15, textBox16, textBox17, textBox18 },
                {textBox19, textBox20, textBox21, textBox22, textBox23, textBox24 },
                {textBox25, textBox26, textBox27, textBox28, textBox29, textBox30 },
                {textBox31, textBox32, textBox33, textBox34, textBox35, textBox36 },
            };

            TextBox[,] areas = new TextBox[3, 3]
            {
                {textBox37, textBox38, textBox39 },
                {textBox40, textBox41, textBox42 },
                {textBox43, textBox44, textBox45 },
            };

            int[] positions = new int[]
            {
                Int32.Parse(textBox46.Text),
                Int32.Parse(textBox47.Text),
            };

            int[,] inputs = new int[3, 3];
            int[,] masks = new int[3, 3];

            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    inputs[i, j] = Int32.Parse(input_fields[i + positions[0], j + positions[1]].Text);
                }
            }

            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    masks[i, j] = Int32.Parse(areas[i, j].Text);
                }
            }

            int center = inputs[1, 1];
            int sum = 0;

            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    if(inputs[i, j] > center)
                    {
                        sum += inputs[i, j] * masks[i, j];
                    }
                }
            }

            textBox48.Text = sum.ToString();
        }
    }
}
