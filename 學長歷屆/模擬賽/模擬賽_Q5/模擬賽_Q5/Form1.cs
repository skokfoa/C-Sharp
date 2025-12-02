using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 模擬賽_Q5
{
    public partial class Form1 : Form
    {
        public static int[] seeds = { 
            0x64, 0x73, 0x66, 0x64, 0x3b, 0x6b, 0x66, 0x6f, 0x41, 0x2c, 0x2e, 
            0x69, 0x79, 0x65, 0x77, 0x72, 0x6b, 0x6c, 0x64, 0x4a, 0x4b, 0x44,
            0x48, 0x53, 0x55, 0x42
        };

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int seed = int.Parse(textBox2.Text);

            textBox3.Text = Convert.ToString(seed, 16).PadLeft(2, '0').ToUpper();

            for (int i = 0; i < textBox1.TextLength; i++, seed++)
                textBox3.Text += Convert.ToString(textBox1.Text[i] ^ seeds[seed], 16).PadLeft(2, '0').ToUpper();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if(textBox3.TextLength % 2 != 0 || !Regex.IsMatch(textBox3.Text, @"^\w{2,}$"))
                {
                    label5.Text = "輸入值有誤";
                    return;
                }

                int seed = Convert.ToInt32(textBox3.Text.Substring(0, 2), 16);

                label5.Text = "";

                for (int i = 2; i < textBox3.TextLength; i += 2, seed++)
                {
                    label5.Text += char.ConvertFromUtf32(
                        Convert.ToInt32(textBox3.Text.Substring(i, 2), 16) ^ seeds[seed]);
                }
            } catch(Exception)
            {
                label5.Text = "輸入值有誤";
            }
        }
    }
}
