using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            float a, b, c;

            a = float .Parse(textBox1.Text);
            b = float .Parse(textBox2.Text);
            c = float .Parse(textBox3.Text);

            float[] arr = { a, b, c };

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i;j < arr.Length; j++)
                {
                    if(arr[i] < arr[j])
                    {
                        float tent = arr[i];
                        arr[i] = arr[j];
                        arr[j] = tent;
                    }
                }
            }
                        
            if (arr[0] >= arr[1] + arr[2])
            {
                textBox6.Text = "否";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox7.Text = "";
                return;
            }
            else
            {
                textBox6.Text = "是";
            }

            if (Math.Pow(arr[0], 2) > Math.Pow(arr[1], 2) + Math.Pow(arr[2], 2))
            {
                textBox5.Text = "鈍角三角形";
            }
            else if (Math.Pow(arr[0], 2) == Math.Pow(arr[1], 2) + Math.Pow(arr[2], 2))
            {
                textBox5.Text = "直角三角形";
            }
            else
            {
                textBox5.Text = "銳角三角形";
            }

            textBox4.Text = $"{a+b+c}";
            float s = (a + b + c) / 2;
            double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));
            textBox7.Text = $"{Math.Round(area,2)}";
        }
    }
}
