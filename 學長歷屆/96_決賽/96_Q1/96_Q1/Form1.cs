using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _96_Q1
{
    public partial class Form1 : Form
    {
        string[] dating = { "未婚", "已婚" };
        string[] grade = { "博士", "碩士", "大學", "專科", "高中", "國中", "小學", "未知" };

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BigInteger result = int.Parse(textBox1.Text.Substring(2));

            result |= int.Parse(textBox1.Text);
        }
    }
}
