using System;
using System.Linq;
using System.Windows.Forms;

namespace _94_Q5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox1.TextLength.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox1.Text[2].ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = $"{textBox1.Text.Substring(0, 3)}{textBox3.Text}{textBox1.Text.Substring(3)}";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox1.Text.ToUpper();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox1.Text.ToLower();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox2.Text = new string(textBox1.Text.Reverse().ToArray());
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox2.Text = string.Join(" ", textBox1.Text.Split(','));
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Focus();
            textBox1.SelectionStart = textBox1.Text.IndexOf(textBox3.Text);
            textBox1.SelectionLength = textBox3.TextLength;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox1.SelectedText;
        }
    }
}
