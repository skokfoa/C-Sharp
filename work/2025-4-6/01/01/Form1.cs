using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = int.Parse(textBox1.Text) + 1;
            int[,] arr = new int[n, n];

            arr[0, 0] = 1;
            
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < i + 1; j++)
                {
                    if(j == 0)
                    {
                        arr[i, j] = 1;
                    }
                    else if(j == i)
                    {
                        arr[i, j] = 1;
                    }
                    else
                    {
                        arr[i, j] = arr[i - 1, j - 1] + arr[i - 1, j];
                    }
                    
                }
            }

            label1.Text = "";
            label3.Text = "";

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < i + 1; j++)
                {
                    label1.Text += $"{arr[i,j].ToString().PadRight(3)} ";
                }
                label1.Text += $"\n";
                label3.Text += $"n = {i}\n";
            }//print
        }
    }
}
