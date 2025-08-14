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
            textBox4.Text = string.Empty;
            List<int> numbers = new List<int>();

            int[] checkNum = new int[] { 0, 7, 4, 1, 8, 5, 2, 9, 6, 3 };
            int min = 0;
            int max = 0;
            string input = textBox1.Text;
            if(input != string.Empty)
            {
                min = int.Parse(input);
            }
            input = textBox2.Text;
            if (input != string.Empty)
            {
                max = int.Parse(input);
            }
            input = textBox3.Text;
            string[] extre = input.Split(' ',',');
            int[] extremes = new int[extre.Length];
            if (input != string.Empty)
            {
                foreach (string s in extre)
                {
                    if (int.TryParse(s, out int value))
                    {
                        extremes[Array.IndexOf(extre, s)] = value;
                    }
                    else
                    {
                        MessageBox.Show("Invalid extreme value: " + s);
                        return;
                    }
                }
            }

            if(min < max)
            {
                for (int i = min; i <= max; i++)
                {
                    int email = i * 10 + count(i);
                    numbers.Add(email);
                }
            }
            for(int i = 0; i < extremes.Length; i++)
            {
                int email = extremes[i] * 10 + count(extremes[i]);
                numbers.Add(email);
            }

            for(int i = 0; i < numbers.Count; i++)
            {
                if (i != 0 && i % 3 == 0)
                {
                    textBox4.Text += Environment.NewLine;
                }
                if(i == numbers.Count - 1)
                {
                    textBox4.Text += $"{numbers[i]}@antu.edu.tw";
                }
                else
                {
                    textBox4.Text += $"{numbers[i]}@antu.edu.tw;";
                }
            }
        }

        private int count(int a)
        {
            int[] checkNum = new int[] { 0, 7, 4, 1, 8, 5, 2, 9, 6, 3 };
            int[] b = new int[8];
            int sum = 0;
            for(int i = 0; i < 8; i++)
            {
                b[i] = a % 10;
                a /= 10;
                sum += b[i] * (i + 1);
            }

            sum = sum % 10;

            return checkNum[sum];
        }
    }
}
