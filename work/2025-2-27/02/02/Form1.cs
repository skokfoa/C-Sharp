using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _02
{
    public partial class Form1 : Form
    {
        private int remainingTime = 600;
        int A = 0, B = 0, chance = 0;
        int[] ans = new int[4];
        Random rnd = new Random();

        public int[] Ramd()
        {
            HashSet<int> numbers = new HashSet<int>();

            while (numbers.Count < 4)
            {
                int num = rnd.Next(10);
                numbers.Add(num);
            }

            return numbers.ToArray();
        }


        public Form1()
        {   
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (remainingTime > 0)
            {
                remainingTime--; // 每秒減少1秒
                int minutes = remainingTime / 60;
                int seconds = remainingTime % 60;
                textBox6.Text = string.Format("{0:D2}分{1:D2}秒", minutes, seconds);
                textBox5.Text = string.Format("{0:D2}分{1:D2}秒", 10-minutes, 60-seconds);
            }
            else
            {
                timer1.Stop();
                label4.Text = "時間到！";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            A = 0; B = 0;
            int[] q = new int[4];
            if (chance == 0) { ans = Ramd(); }
            string input = textBox2.Text;
            chance++;
            textBox4.Text = $"{chance}次";
            switch (InputCheck(input))
            {
                case 0:
                    q = input.Select(c => c - '0').ToArray();
                    break;
                case 1:
                    MessageBox.Show("輸入的數值不是4位數!!請重新輸入!!");
                    textBox2.Text = "";
                    return;
                    break;
                case 2:
                    MessageBox.Show("輸入數值重複!!請重新輸入!!");
                    textBox2.Text = "";
                    return;
                    break;
                case 3:
                    MessageBox.Show("輸入數值不是數字!!請重新輸入!!");
                    textBox2.Text = "";
                    return;
                    break;
            }

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (q[i] == ans[j]) 
                    { 
                        if (i == j)
                        {
                            A++;
                        }
                        else
                        {
                            B++;
                        }
                    }
                }
            }

            textBox3.Text = $"{A}A{B}B";

            if (A == 4)
            {
                label2.Text = "答對了!你一共猜了";
                return;
            }
            else
            {
                foreach (int i in q)
                {
                    textBox1.Text += i.ToString();
                }
                textBox1.Text += $"\r\n  {A}A{B}B\r\n";
            }
        }
        public int InputCheck(string input)
        {
            int AllCorrect = 0;
            int NumberLength = 1;
            int NumberRepeat = 2;
            int NotNumber = 3;

            if (input.Length != 4)
            {
                return NumberLength;
            }

            if (!input.All(char.IsDigit))
            {
                return NotNumber;
            }

            HashSet<char> uniqueNumbers = new HashSet<char>();
            foreach (char c in input)
            {
                if (!uniqueNumbers.Add(c))
                {
                    return NumberRepeat;
                }
            }

            return AllCorrect;
        }

        

    }
}
