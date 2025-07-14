using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _03
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TextBox[] product = new TextBox[] { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7 };
            TextBox[] price = new TextBox[] { textBox14, textBox13, textBox12, textBox11, textBox10, textBox9, textBox8 };
            TextBox[] weight = new TextBox[] { textBox21, textBox20, textBox19, textBox18, textBox17, textBox16, textBox15 };

            string[] input = new string[7];
            double[,] project = new double[4,7];
            string[] ans = { "-1", "-1", "-1", "-1", "-1", "-1", "-1" };
            int wight = 0;
            int money = 0;
            int a = 0;
            

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    switch (i)
                    {
                        case 0:
                            project[i, j] = j;
                            input[j] = product[j].Text;
                            break;
                        case 1:
                            project[i, j] = double.Parse(price[j].Text);
                            break;
                        case 2:
                            project[i, j] = double.Parse(weight[j].Text);
                            break;
                        case 3:
                            project[i, j] = double.Parse(price[j].Text) / double.Parse(weight[j].Text);
                            break;
                    }
                }
            }

            int limit = int.Parse(textBox22.Text);

            for (int i = 0;i < 7; i++)
            {
                for(int j = i;j < 7; j++)
                {
                    if (project[3,i] < project[3, j])
                    {
                        for(int k = 0; k < 4; k++)
                        {
                            double temp = project[k,i];
                            project[k,i] = project[k,j];
                            project[k,j] = temp;
                        }
                    }
                }
            } // 排列平均大到小

            for (int i = 0; i < 7; i++)
            {
                if(wight + project[2,i] <= limit)
                {
                    ans[a] = (project[0,i]).ToString();
                    a++;
                    wight += (int)project[2,i];
                    money += (int)project[1,i];
                }
            } //判斷是否裝進背包

            for (int i = 0; i < ans.Length; i++)
            {
                for (int j = i; j < ans.Length; j++)
                {
                    if (int.Parse(ans[i]) > int.Parse(ans[j]) && int.Parse(ans[j]) != -1)
                    {
                        int temp = int.Parse(ans[i]);
                        ans[i] = ans[j]; 
                        ans[j] = temp.ToString();
                    }
                }
            } //ans從小排到大

            for (int i = 0; i < ans.Length; i++)
            {
                if(ans[i] == "-1")
                {
                    continue;
                }
                else
                {
                    ans[i] = input[int.Parse(ans[i])];
                }
            } //將ans換成商品名稱

            for (int i = 0;i < ans.Length;i++)
            {
                if (ans[i] == "-1")
                {
                    continue;
                }
                else if(i == 0)
                {
                    label7.Text += $"{ans[i]}";
                }
                else
                {
                    label7.Text += $"+{ans[i]}";
                }
            }

            label8.Text = money.ToString(); 
        }
    }
}
