using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace _104_Q6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            if(dialog.ShowDialog() == DialogResult.OK)
            {
                StreamReader reader = new StreamReader(dialog.FileName);
                richTextBox1.Text = reader.ReadToEnd();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Length == 0)
            {
                MessageBox.Show("未輸入搜尋的字串");
                return;
            }

            richTextBox1.Select(0, richTextBox1.TextLength);
            richTextBox1.SelectionBackColor = Color.Transparent;

            int found = 0;

            for(int i = 0; i < richTextBox1.TextLength - textBox1.TextLength; i++)
            {
                if(richTextBox1.Text.Substring(i, textBox1.TextLength) == textBox1.Text)
                {
                    richTextBox1.Select(i, textBox1.TextLength);
                    richTextBox1.SelectionBackColor = Color.Yellow;

                    i += textBox1.TextLength - 1;
                    found++;
                }
            }

            label2.Text = $"找到的個數\n{found}";
        }
    }
}
