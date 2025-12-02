using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _105_Q4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                InitialDirectory = Application.StartupPath,
                Filter = "(*.txt)|*.txt"
            };

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            StreamReader reader = new StreamReader(dialog.OpenFile());

            textBox1.Text = reader.ReadToEnd();

            string result = textBox1.Text;

            // 1. prevent english words being splitted with a placeholder
            result = Regex.Replace(result, @"([A-Za-z-0-9-,.\?])\s([A-Za-z-0-9-])", "$1空$2");

            // 2. remove all ? into space
            result = Regex.Replace(result, @"\?{3,}", " ");

            // 3. check if only has \ as separator
            if (result.Contains('\\') && !result.Contains(' '))
                result = result.Replace('\\', ' ');

            // 4. format (X:X)
            result = Regex.Replace(result, @"\((.+)：(.+)\)", " $1：$2");

            // 5. split all spaces with newline, trim the new string then remove the placeholder added in step 1
            textBox2.Text = string.Join("\r\n", result.Split(' ')
                .Select(x => x.Trim().Replace('空', ' '))
                .Where(x => x.Length > 0)
                .ToArray());
        }
    }
}
