using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            TextBox[] letter = new TextBox[4] { textBox1, textBox2, textBox3, textBox4 };
            TextBox[] number = new TextBox[4] { textBox5, textBox6, textBox7, textBox8 };
            Random random = new Random();
            HashSet<char> list = new HashSet<char>();
            while(list.Count < 4)
            {
                int b = random.Next(26);
                char a = (char)('a' + b);
                list.Add(a);
            }

            for(int i = 0;i < list.Count; i++)
            {
                int num = random.Next(1,1000);
                letter[i].Text = list.ElementAt(i).ToString();
                number[i].Text = num.ToString();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            TextBox[] number = new TextBox[4] { textBox5, textBox6, textBox7, textBox8 };
            int[] num = new int[4];
            for(int i = 0; i < number.Length; i++)
            {
                num[i] = int.Parse(number[i].Text);
            }
            Array.Sort(num);

            int sum = 0, orgsum = 0;
            sum = num[0] * 3 + num[1] * 3 + num[2] * 2 + num[3];
            textBox11.Text = sum.ToString();
            orgsum = (num[0] + num[1] + num[2] + num[3]) * 2;
            textBox9.Text = orgsum.ToString();

            double zip = orgsum/(double)sum;
            textBox13.Text = zip.ToString("F4");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
