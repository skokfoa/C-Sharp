using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace _102_Q6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out _))
                return;

            int times = int.Parse(textBox1.Text);

            if (times < 3 || times > 10)
                return;

            TextBox[] boxes = GetBoxes();
            Label[] labels = GetLabels();

            label2.Visible = true;
            button1.Visible = true;
            label2.Text = $"請輸入m1~m{times}的矩陣大小<維度>：";

            for (int i = 0; i < boxes.Length; i += 2)
            {
                boxes[i].Visible = times > i / 2;
                boxes[i + 1].Visible = times > i / 2;
                labels[i / 2].Visible = times > i / 2;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TextBox[] boxes = GetBoxes();

            int times = int.Parse(textBox1.Text) + 1;

            List<int> points = new List<int>();

            points.Add(int.Parse(boxes[0].Text));

            for (int i = 0; i < times - 1; i++)
                points.Add(int.Parse(boxes[i * 2 + 1].Text));

            int[,] matrix = new int[times, times],
                steps = new int[times, times];

            for (int i = 0; i < times; i++)
            {
                for (int j = 0; j < times; j++)
                {
                    if (i == j)
                        continue;

                    matrix[i, j] = int.MaxValue;
                    steps[i, j] = int.MaxValue;
                }
            }

            for(int chain = 2; chain < times; chain++)
            {
                for(int i = 1; i < times - chain + 1; i++)
                {
                    int j = i + chain - 1;

                    for(int k = i; k < j; k++)
                    {
                        int cost = matrix[i, k] + matrix[k + 1, j] + points[i - 1] * points[k] * points[j];

                        if(cost < matrix[i, j])
                        {
                            matrix[i, j] = cost;
                            steps[i, j] = k;
                        }
                    }
                }
            }

            label12.Text = $"矩陣的相乘次序為：";

            int index = 1;

            Print(1, times - 1, ref index, steps);

            label13.Text = $"最少的乘法運算次數：{matrix[1, times - 1]}";
            label12.Visible = true;
            label13.Visible = true;
        }

        public void Print(int i, int j, ref int index, int[,] steps)
        {
            if(i == j)
            {
                label12.Text += $"A{index++}";
                return;
            }

            label12.Text += "<";

            Print(i, steps[i, j], ref index, steps);
            Print(steps[i, j] + 1, j, ref index, steps);

            label12.Text += ">";
        }

        public Label[] GetLabels()
        {
            return new Label[]
            {
                label3,
                label4,
                label5,
                label6,
                label7,
                label8,
                label9,
                label10,
                label11,
            };
        }

        public TextBox[] GetBoxes()
        {
            return new TextBox[] {
                textBox2,
                textBox3,
                textBox4,
                textBox5,
                textBox6,
                textBox7,
                textBox8,
                textBox9,
                textBox10,
                textBox11,
                textBox12,
                textBox13,
                textBox14,
                textBox15,
                textBox16,
                textBox17,
                textBox18,
                textBox19,
            };
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (var box in GetBoxes())
                box.Visible = false;

            var labels = GetLabels();

            for(int i = 0; i < labels.Length; i++)
            {
                labels[i].Text = $"m{i + 1}的矩陣大小：";
                labels[i].Visible = false;
            }

            label12.Visible = false;
            label13.Visible = false;
            label2.Visible = false;
            button1.Visible = false;
        }
    }
}
