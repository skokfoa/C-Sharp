using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace 模擬賽_Q6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                InitialDirectory = Application.StartupPath
            };

            if(dialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = "";

                string content = File.ReadAllText(dialog.FileName);

                content = content.Replace("\r\n", "\n").Substring(content.IndexOf('\n') + 1);

                string[] articles = content.Split(new string[] { "=====" }, StringSplitOptions.None)
                    .Select(x => x.Trim()).ToArray();

                foreach(var article in articles)
                {
                    int lines = article.Split('\n').Length;

                    // counting non-space words
                    int words = Regex.Matches(article, @"\S+").Count;

                    textBox1.Text += $"{lines} {words} {article.Length}\r\n";
                }
            }
        }
    }
}
