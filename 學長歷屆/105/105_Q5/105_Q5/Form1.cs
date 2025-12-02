using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _105_Q5
{
    public partial class Form1 : Form
    {
        readonly Random random = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] chars = new string[4];

            for(int i = 0; i < 4; i++)
            {
                string rand = RandomChar();

                if (!chars.Contains(rand))
                    chars[i] = rand;
            }

            textBox1.Text = chars[0];
            textBox2.Text = chars[1];
            textBox3.Text = chars[2];
            textBox4.Text = chars[3];

            textBox5.Text = random.Next(1, 1000).ToString();
            textBox6.Text = random.Next(1, 1000).ToString();
            textBox7.Text = random.Next(1, 1000).ToString();
            textBox8.Text = random.Next(1, 1000).ToString();
        }

        public string RandomChar()
        {
            // reference: https://stackoverflow.com/a/15249258

            int rand = random.Next(26);

            return char.ConvertFromUtf32('a' + rand);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int[] counts = new int[4]
            {
                int.Parse(textBox5.Text),
                int.Parse(textBox6.Text),
                int.Parse(textBox7.Text),
                int.Parse(textBox8.Text),
            };

            int old = 2 * counts.Sum();

            textBox9.Text = old.ToString();

            Array.Sort(counts);

            int result = counts[0] * 3;

            for(int i = 1; i < counts.Length; i++)
            {
                result += counts[i] * (counts.Length - i);
            }

            textBox10.Text = result.ToString();
            textBox11.Text = ((float) old / result).ToString("F4");
        }
    }
}
