using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 字幕機
{
    public partial class Form1 : Form
    {
        private CheckBox[,] scream;
        private int count = new int();
        private List<int[]> codes = new List<int[]>();

        public Form1()
        {
            int[] init = new int[65];
            for (int i = 0; i < 65; i++) init[i] = 0;
            codes.Add(init);

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)//init
        {
            scream = new CheckBox[16, 64];
            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 64; j++)
                {
                    scream[i, j] = new CheckBox();

                    scream[i, j].Size = new System.Drawing.Size(18, 18);
                    scream[i, j].Location = new System.Drawing.Point(12 + j * 18, 90 + i * 18);

                    scream[i, j].Text = string.Empty;
                    scream[i, j].Checked = false;

                    this.Controls.Add(scream[i, j]);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)//轉換
        {
            string ins = textBox1.Text.Trim();

            Bitmap bmp = new Bitmap(64, 16);
            Graphics g = Graphics.FromImage(bmp);
            Font f = new Font("新細明體", 11);
            SolidBrush brush = new SolidBrush(Color.Black);

            g.Clear(Color.White);
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;


            g.DrawString(ins, f, brush,0,1);

            for(int i = 0; i < 16; i++)
            {
                for(int j = 0; j < 64; j++)
                {
                    Color c = bmp.GetPixel(j, i);
                    if(c.GetBrightness() < 0.5f)
                    {
                        scream[i, j].Checked = true;
                    }
                    else
                    {
                        scream[i,j].Checked = false;
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)//左
        {
            bool[] b = new bool[16];
            for(int i = 0; i < 16; i++)
            {
                b[i] = scream[i,0].Checked;
            }

            for(int i = 1; i < 64; i++)
            {
                for (int j = 0;j < 16; j++)
                {
                    scream[j,i - 1].Checked = scream[j,i].Checked; 
                }
            }

            for(int i = 0; i < 16; i++)
            {
                scream[i, 63].Checked = b[i];
            }
        }

        private void button2_Click(object sender, EventArgs e)//右
        {
            bool[] b = new bool[16];
            for (int i = 0; i < 16; i++)
            {
                b[i] = scream[i, 63].Checked;
            }

            for (int i = 62; i >= 0; i--)
            {
                for (int j = 0; j < 16; j++)
                {
                    scream[j, i + 1].Checked = scream[j, i].Checked;
                }
            }

            for (int i = 0; i < 16; i++)
            {
                scream[i, 0].Checked = b[i];
            }
        }

        private void button4_Click(object sender, EventArgs e)//上
        {
            bool[] b = new bool[64];

            for (int i = 0; i < 64; i++)
            {
                b[i] = scream[0, i].Checked;
            }

            for (int i = 1; i < 16; i++)
            {
                for (int j = 0; j < 64; j++)
                {
                    scream[i - 1, j].Checked = scream[i, j].Checked;
                }
            }

            for (int i = 0; i < 64; i++)
            {
               scream[15, i].Checked = b[i];
            }
        }

        private void button5_Click(object sender, EventArgs e)//下
        {
            bool[] b = new bool[64];

            for (int i = 0; i < 64; i++)
            {
                b[i] = scream[15, i].Checked;
            }

            for (int i = 14; i >= 0; i--)
            {
                for (int j = 0; j < 64; j++)
                {
                    scream[i + 1, j].Checked = scream[i, j].Checked;
                }
            }

            for (int i = 0; i < 64; i++)
            {
                scream[0, i].Checked = b[i];
            }
        }

        private void button7_Click(object sender, EventArgs e)//擷取螢幕
        {
            count++;
            label2.Text = count.ToString();
            int time = int.Parse(textBox2.Text);
            int[] dec = new int[65];

            dec[0] = time;

            for(int i = 1; i < dec.Length; i++)
            {
                string b = string.Empty;
                for (int j = 0; j < 16; j++)
                {
                    if (scream[j, i - 1].Checked) b = "1" + b;
                    else b = "0" + b;
                }

                dec[i] = Convert.ToInt32(b, 2);
            }

            codes.Add(dec);
            label5.Text += "泉勝出版*1  ";
        }

        private void button11_Click(object sender, EventArgs e)//取全滅
        {
            count++;
            label2.Text = count.ToString();
            int time = int.Parse(textBox2.Text);
            int[] dec = new int[65];

            dec[0] = time;

            for(int i = 1; i < dec.Length; i++)
            {
                dec[i] = 0;
            }

            codes.Add(dec);
            label5.Text += "泉勝出版*1  ";
        }

        private void button8_Click(object sender, EventArgs e)//Arduino code
        {
            int[][] b = new int[codes.Count][];
            for(int i = 0; i < codes.Count; i++)
            {
                b[i] = codes[i].ToArray();
            }

            string mid = string.Empty;

            for (int i = 0; i < codes.Count; i++)
            {
                mid = mid + "{" + string.Join(", ", b[i]).TrimEnd(new char[] { ' ' , ',' }) + "}\r\n,";
            }

            mid.TrimEnd(new char[] { ' ', ',' });
            mid = "{\r\n" + mid + "};";

            string code = "unsigned int i,j,k;\r\n" +
                "unsigned int a[64];\r\n\r\n" +
                $"unsigned int b[][64] = {mid}" + "\r\n" +
                "unsigned int num = 11;\r\n" +
                "void setup() {\r\n" +
                "\tDDRF=0xFF;\r\n" +
                "\tDDRK=0xFF;\r\n" +
                "\tDDRC=0xFF;\r\n" +
                "}\r\n" +
                "void loop() {\r\n" +
                "\tfor(k = 0;k <= num; k++){\r\n" +
                "\t\tfor(j = 1;j <= 64; j++)\r\n" +
                "\t\t\ta[j]=b[k][j]\r\n" +
                "\t\tfor(j = 0;j <= 100 * b[k][0]; j++){\r\n" +
                "\t\t\tfor(i = 0; i <= 63; i++){\r\n" +
                "\t\t\t\tPORTC=i;\r\n" +
                "\t\t\t\tPORTK=a[i] / 256;\r\n" +
                "\t\t\t\tPORTF=a[i] % 256;\r\n" +
                "\t\t\t\tdelayMicroseconds(100);\r\n" +
                "\t\t\t\tPORTF=0;\r\n" +
                "\t\t\t\tPORTK=0;\r\n" +
                "\t\t\t}\r\n" +
                "\t\t}\r\n" +
                "\t\tdelay(500);\r\n" +
                "\t}\r\n" +
                "}";
            textBox3.Text = code;
        }

        private void button9_Click(object sender, EventArgs e)//複製
        {
            Clipboard.SetText(textBox3.Text);
        }

        private void button10_Click(object sender, EventArgs e)//Exit
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)//clear
        {
            for(int i = 0; i < 16; i++)
            {
                for(int j = 0; j < 64; j++)
                {
                    scream[i, j].Checked = false;
                }
            }
        }

    }
}
