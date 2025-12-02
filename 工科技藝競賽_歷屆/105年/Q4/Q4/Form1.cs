using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string raw = File.ReadAllText(ofd.FileName, Encoding.UTF8);
                richTextBox1.Text = raw; // 左邊顯示原始文字

                // 用正則式抓取所有「欄位：值」
                var matches = System.Text.RegularExpressions.Regex.Matches(
                    raw,
                    @"([\u4e00-\u9fa5A-Za-z0-9\(\)／/]+)：([^：\r\n]+)"
                );

                StringBuilder sb = new StringBuilder();
                foreach (System.Text.RegularExpressions.Match m in matches)
                {
                    string field = m.Groups[1].Value.Trim();
                    string value = m.Groups[2].Value.Trim();
                    sb.AppendLine($"{field}：{value}");
                }

                richTextBox2.Text = sb.ToString();
            }
        }

    }
}
