using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.TextBox;

namespace _03
{
    public partial class Form1 : Form
    {
        int hour = 0;
        int min = 0;
        int sec = 0;
        public Form1()
        {
            InitializeComponent();
        }


        private void button4_Click(object sender, EventArgs e) //歸零
        {
            TextBox[] input = new TextBox[] {textBox1, textBox2, textBox3};
            
            for (int i = 0; i < input.Length; i++)
            {
                input[i].Text = "0";
                input[i].ReadOnly = true;
            }
            timer1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e) // 設定
        {
            TextBox[] input = new TextBox[] {textBox1, textBox2, textBox3};

            for(int i = 0;i < input.Length;i++)
            {
                input[i].ReadOnly = false;
            }
            timer1.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int i))
            {
                if (i < 0 || i > 99)
                {
                    MessageBox.Show("請輸入0~99之間的數字");
                    textBox1.Text = "99";
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox2.Text, out int i))
            {
                if (i < 0 || i > 59)
                {
                    MessageBox.Show("請輸入0~59之間的數字");
                    textBox2.Text = "59";
                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox3.Text, out int i))
            {
                if (i < 0 || i > 59)
                {
                    MessageBox.Show("請輸入0~59之間的數字");
                    textBox3.Text = "59";
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            hour = int.Parse(textBox1.Text);
            min = int.Parse(textBox2.Text);
            sec = int.Parse(textBox3.Text);

            TextBox[] input = new TextBox[] { textBox1, textBox2, textBox3 };

            for (int i = 0; i < input.Length; i++)
            {
                input[i].ReadOnly = true;
            }

            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (hour == 0 && min == 0 && sec == 0)
            {
                timer1.Stop();
                MessageBox.Show("倒數結束！");
                return;
            }

            if (sec == 0)
            {
                if (min > 0)
                {
                    min--;
                    sec = 59;
                }
                else if (hour > 0)
                {
                    hour--;
                    min = 59;
                    sec = 59;
                }
            }
            else
            {
                sec--;
            }

            // 更新畫面上的 TextBox 顯示
            textBox1.Text = hour.ToString("D2");
            textBox2.Text = min.ToString("D2");
            textBox3.Text = sec.ToString("D2");
        }

        private void button3_Click(object sender, EventArgs e) // 停止
        {
            timer1.Stop(); // 暫停倒數計時器
        }

    }
}
