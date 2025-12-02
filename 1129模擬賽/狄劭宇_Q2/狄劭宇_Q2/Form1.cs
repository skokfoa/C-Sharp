using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 狄劭宇_Q2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] place =
            {
                "台北市", // A
                "台中市", // B
                "基隆市", // C
                "台南市", // D
                "高雄市", // E
                "台北縣", // F
                "宜蘭縣", // G
                "桃園縣", // H
                "嘉義市", // I
                "新竹縣", // J
                "苗栗縣", // K
                "台中縣", // L
                "南投縣", // M
                "彰化縣", // N
                "新竹市", // O
                "雲林縣", // P
                "嘉義縣", // Q
                "台南縣", // R
                "高雄縣", // S
                "屏東縣", // T
                "花蓮縣", // U
                "台東縣", // V
                "金門縣", // W
                "澎湖縣", // X
                "陽明山", // Y
                "連江縣"  // Z
            };

            string input = textBox1.Text;
            int[] num = Enumerable.Range(1, 9)
                .Select(x => (int)(input[x] - '0'))
                .ToArray();

            int sum = new int();

            for(int i = 0; i < num.Length - 1; i++)
            {
                sum += num[i] * (8 - i);
            }
            

            char c = char.ToLower(input[0]);
            int eng = (c - 'a' + 10);
            sum += (eng % 10 * 9) + (int)(eng / 10);

            sum = 10 - (sum % 10);

            if (sum != num[num.Length - 1])
            {
                textBox2.Text = "錯誤";
                return;
            }

            textBox2.Text = "正確";
            textBox3.Text = place[c - 'a'];
            textBox4.Text = num[0] == 1 ? "男" : "女";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = string.Empty;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
