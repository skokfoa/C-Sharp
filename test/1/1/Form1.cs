using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int a = textBox1.SelectionStart;
            string text = textBox1.Text.ToUpper();

            textBox1.Text = text;
            textBox1.SelectionStart = a;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int a = textBox2.SelectionStart;
            string text = textBox2.Text.ToUpper();

            textBox2.Text = text;
            textBox2.SelectionStart = a;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string in1 = textBox1.Text.Trim();
            string in2 = textBox2.Text.Trim();

            // 輸入偵錯：空白檢查
            if (string.IsNullOrEmpty(in1))
            {
                MessageBox.Show("請輸入甲組字元");
                return;
            }
            if (string.IsNullOrEmpty(in2))
            {
                MessageBox.Show("請輸入乙組字元");
                return;
            }

            // 輸入偵錯：是否皆為英文字母
            if (!IsAlphaOnly(in1))
            {
                MessageBox.Show("甲組只能包含英文字母 A-Z");
                return;
            }
            if (!IsAlphaOnly(in2))
            {
                MessageBox.Show("乙組只能包含英文字母 A-Z");
                return;
            }

            // 偵錯：重複字元
            if (HasDuplicate(in1))
            {
                MessageBox.Show("甲組字元有重複");
                return;
            }
            if (HasDuplicate(in2))
            {
                MessageBox.Show("乙組字元有重複");
                return;
            }

            // 找交集並排序
            var common = in2.Intersect(in1);
            string ans = new string(common.OrderBy(c => c).ToArray());
            textBox3.Text = ans;
        }
        private bool HasDuplicate(string input)
        {
            HashSet<char> set = new HashSet<char>();
            foreach (char c in input)
            {
                if (!set.Add(c))
                    return true;
            }
            return false;
        }

        private bool IsAlphaOnly(string input)
        {
            foreach (char c in input)
            {
                if (!char.IsLetter(c))
                    return false;
            }
            return true;
        }
    }
}
