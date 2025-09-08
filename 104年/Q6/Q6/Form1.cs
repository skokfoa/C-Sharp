using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Q6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamReader reader = new StreamReader(openFileDialog.FileName);
                richTextBox1.Text = reader.ReadToEnd();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                MessageBox.Show("未輸入搜尋的字串");
                return;
            }

            richTextBox1.Select(0, richTextBox1.TextLength);
            richTextBox1.SelectionBackColor = Color.Transparent;

            int found = 0;

            for(int i = 0;i <= richTextBox1.TextLength - textBox1.TextLength; ++i)
            {
                if (richTextBox1.Text.Substring(i, textBox1.TextLength) == textBox1.Text)
                {
                    richTextBox1.Select(i, textBox1.TextLength);
                    richTextBox1.SelectionBackColor = Color.Yellow;

                    i += textBox1.TextLength - 1;
                    found++;
                }
            }

            label3.Text = $"{found}";

            File.WriteAllText("output.txt", $"一共找到了 {found} 個「{textBox1.Text}」");
        }
    }
}
