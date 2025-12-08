using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Type7 = textBox1.Text;
            int value = int.Parse(textBox2.Text);

            string result = Convert.ToString(value, 16).PadLeft(2,'0');

            if (Type7.Length  > 10)
            {
                MessageBox.Show("Enter error");
                return;
            }

            foreach (char c in Type7)
            {
                int i = (int)c ^ Seed(value);
                result += Convert.ToString(i, 16).PadLeft(2, '0');
                value++;
            }

            textBox3.Text = result.ToUpper();
        }

        public static int Seed(int value)
        {
            int[] s = { 0x64, 0x73, 0x66, 0x64, 0x3b, 0x6b, 0x66, 0x6f, 0x41, 0x2c, 0x2e, 0x69, 0x79,
                        0x65, 0x77, 0x72, 0x6b, 0x6c, 0x64, 0x4a, 0x4b, 0x44, 0x48, 0x53, 0x55, 0x42 };

            if (value >= s.Length || value < 0)
            {
                return -1;
            }

            return s[value];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string result = textBox3.Text;
            int value = Convert.ToInt32(result.Substring(0, 2), 16);
            result = result.Substring(2);
            result = result.ToUpper();

            if (value < 0 || value > 15)
            {
                label5.Text = "輸入值有誤";
                return;
            }

            if (result.Any(x => !((x >= 'A' && x <= 'F') ||( x >= '0' && x <= '9'))))
            {
                label5.Text = "輸入值有誤";
                return;
            }

            string output = string.Empty;

            for (int i = 0; i < result.Length; i += 2)
            {
                int x = Convert.ToInt32(result.Substring(i, 2), 16);
                char c = (char)(Seed(value) ^ x);
                output += c.ToString();
                value++;
            }

            label5.Text = output;
        }
    }
}
