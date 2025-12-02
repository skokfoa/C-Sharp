using System;
using System.Windows.Forms;

namespace _104_Q5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TextBox[,] inputs =
            {
                { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7 },
                { textBox14, textBox13, textBox12, textBox11, textBox10, textBox9, textBox8 },
                { textBox21, textBox20, textBox19, textBox18, textBox17, textBox16, textBox15 },
                { textBox28, textBox27, textBox26, textBox25, textBox24, textBox23, textBox22 },
                { textBox35, textBox34, textBox33, textBox32, textBox31, textBox30, textBox29 },
                { textBox42, textBox41, textBox40, textBox39, textBox38, textBox37, textBox36 },
                { textBox49, textBox48, textBox47, textBox46, textBox45, textBox44, textBox43 },
            };
            
            TextBox[,] kernels =
            {
                {textBox98, textBox97, textBox96 },
                {textBox91, textBox90, textBox89 },
                {textBox84, textBox83, textBox82 },
            };

            TextBox[,] output =
            {
                { textBox59, textBox58, textBox57, textBox56, textBox55, textBox54, textBox53 },
                { textBox66, textBox65, textBox64, textBox63, textBox62, textBox61, textBox60 },
                { textBox73, textBox72, textBox71, textBox70, textBox69, textBox68, textBox67 },
                { textBox80, textBox79, textBox78, textBox77, textBox76, textBox75, textBox74 },
                { textBox93, textBox92, textBox88, textBox87, textBox86, textBox85, textBox81 },
                { textBox103, textBox102, textBox101, textBox100, textBox99, textBox95, textBox94 },
                { textBox110, textBox109, textBox108, textBox107, textBox106, textBox105, textBox104 }
            };

            for (int i = 1; i < 6; i++)
            {
                for(int j = 1; j < 6; j++)
                {
                    int total = 0;

                    for(int x = -1; x < 2; x++)
                    {
                        for (int y = -1; y < 2; y++)
                        {
                            Console.WriteLine($"{i} {j} {x} {y}");
                            total += int.Parse(inputs[i + x, j + y].Text) * int.Parse(kernels[1 - x, 1 - y].Text);
                        }
                    }

                    output[i, j].Text = total.ToString();
                }
            }

            double mse = 0, mae = 0;

            for(int i = 0; i < 7; i++)
                for (int j = 0; j < 7; j++)
                {
                    mse += Math.Pow(int.Parse(inputs[i, j].Text) - int.Parse(output[i, j].Text), 2);
                    mae += Math.Abs(int.Parse(inputs[i, j].Text) - int.Parse(output[i, j].Text));
                }

            mse /= 49;
            mae /= 49;

            textBox50.Text = mse.ToString();
            textBox51.Text = mae.ToString();
            textBox52.Text = (10 * Math.Log10(255 * 255 / mse)).ToString();
        }
    }
}
