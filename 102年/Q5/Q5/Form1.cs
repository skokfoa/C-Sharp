using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            label5.Text = string.Empty;
            label6.Text = string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int mut = new int();
            int bmut = new int();
            int ans = new int();
            if (!int.TryParse(textBox1.Text , out bmut))
            {
                MessageBox.Show("輸入錯誤");
                return;
            }
            if (!int.TryParse(textBox2.Text, out mut))
            {
                MessageBox.Show("輸入錯誤");
                return;
            }
            if (!int.TryParse(textBox3.Text, out ans))
            {
                MessageBox.Show("輸入錯誤");
                return;
            }

            int[] bmut_arr = new int[2];
            int[] mut_arr = new int[2];

            bmut_arr[0] = (int)(bmut / 10);
            bmut_arr[1] = (bmut % 10);

            mut_arr[0] = (int)(mut / 10);
            mut_arr[1] = (mut % 10);


            if (mut * bmut == ans)
            {
                label5.Text = "Very Good!";
            }
            else
            {
                label5.Text = "is wrong";
                label6.Text = string.Empty;

                int total = bmut_arr[1] * mut_arr[1];
                int add = bmut + mut_arr[1];
                label6.Text += $"(1) {bmut}+{mut_arr[1]}={add}\r\n";
                add = add * bmut_arr[0] * 10;
                label6.Text += $"(2) {bmut + mut_arr[1]}x{bmut_arr[0] * 10}={add}\r\n";
                label6.Text += $"(3) {bmut_arr[1]}x{mut_arr[1]}={total}\r\n";
                label6.Text += $"(4) {add}+{total}={add + total}\r\n";
            }
        }
    }
}
