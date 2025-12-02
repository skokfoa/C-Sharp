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
        TextBox[,] input;
        TextBox[,] kernel;
        TextBox[,] output;
        public Form1()
        {
            InitializeComponent();
            input = new TextBox[,] { { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7 },
                                     { textBox8, textBox9, textBox10, textBox11, textBox12, textBox13, textBox14 },
                                     { textBox15, textBox16, textBox17, textBox18, textBox19, textBox20, textBox21 },
                                     { textBox22, textBox23, textBox24, textBox25, textBox26, textBox27, textBox28 },
                                     { textBox29, textBox30, textBox31, textBox32, textBox33, textBox34, textBox35 },
                                     { textBox36, textBox37, textBox38, textBox39, textBox40, textBox41, textBox42 },
                                     { textBox43, textBox44, textBox45, textBox46, textBox47, textBox48, textBox49 },};
            kernel = new TextBox[,] {{ textBox50, textBox51, textBox52 },
                                     { textBox53, textBox54, textBox55 },
                                     { textBox56, textBox57, textBox58 }};
            output = new TextBox[,] { { textBox59, textBox60, textBox61, textBox62, textBox63, textBox64, textBox65 },
                                      { textBox66, textBox67, textBox68, textBox69, textBox70, textBox71, textBox72 },
                                      { textBox73, textBox74, textBox75, textBox76, textBox77, textBox78, textBox79 },
                                      { textBox80, textBox81, textBox82, textBox83, textBox84, textBox85, textBox86 },
                                      { textBox87, textBox88, textBox89, textBox90, textBox91, textBox92, textBox93 },
                                      { textBox94, textBox95, textBox96, textBox97, textBox98, textBox99, textBox100 },
                                      { textBox101, textBox102, textBox103, textBox104, textBox105, textBox106, textBox107 },};
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TextBox MSE_text = textBox108;
            TextBox MAE_text = textBox109;
            TextBox PSNR_text = textBox110;

            int[,] inum = new int[7, 7];
            int[,] knum = new int[3, 3];
            int[,] onum = new int[7, 7];

            double MSE = new double();
            double MAE = new double();
            double PSNR = new double();

            inum = downlode(input, 7);
            knum = downlode(kernel, 3);

            for(int i = 0;i < 7; i++)
            {
                for(int j = 0;j < 7; j++)
                {
                    onum[i, j] = step1(knum, inum, i, j);
                    output[i, j].Text = onum[i, j].ToString();
                }
            }

            for (int i = 0;i < 7; i++)
            {
                for(int j = 0;j < 7; j++)
                {
                    MSE += Math.Pow(inum[i, j] - onum[i, j], 2);
                    MAE += Math.Abs(inum[i, j] - onum[i, j]);
                }
            }

            MSE = 1 / 49.0 * MSE;
            MAE = 1 / 49.0 * MAE;
            PSNR = 10 * Math.Log10(255 * 255 / MSE);

            MSE_text.Text = MSE.ToString();
            MAE_text.Text = MAE.ToString();
            PSNR_text.Text = PSNR.ToString();
        }

        private int[,] downlode(TextBox[,] t,int x)
        {
            int[,] back = new int[x, x]; 
            for(int i = 0;i < x; i++)
            {
                for(int j = 0;j < x; j++)
                {
                    back[i, j] = int.Parse(t[i, j].Text);
                }
            }
            return back;
        }

        private int step1(int[,] k,int[,] inum,int m,int n)
        {
            int sum = 0;
            for(int i = 0;i < 3; i++)
            {
                for(int j = 0;j < 3; j++)
                {
                    sum += inum[(m + i-1+7)%7, (n + j-1+7)%7] * k[2-i,2-j];
                }
            }
            return sum;
        }
    }
}
