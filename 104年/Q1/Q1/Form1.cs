using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q1
{
    public partial class Form1 : Form
    {
        public Label[] place1 = new Label[4];
        public Label[] place2 = new Label[4];
        public Label[] place3 = new Label[4];
        public Label[] place4 = new Label[4];
        public Label[,] all = new Label[4,4];
        public int[] now = new int[2];
        public int[,] num = new int[4, 4];
        public Form1()
        {
            InitializeComponent();
            place1 = new Label[4] { label1, label2, label3, label4};
            place2 = new Label[4] { label8, label7, label6, label5 };
            place3 = new Label[4] { label12, label11, label10, label9 };
            place4 = new Label[4] { label16, label15, label14, label13 };
            all = new Label[4, 4]
            {
                { label1, label2, label8, label7 },
                { label3, label4, label6, label5 },
                { label12, label11, label16, label15 },
                { label10, label9, label14, label13 }
            };
            start();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            now = new int[] { 1, 0 };
            clear_label();
            label1.BorderStyle = BorderStyle.FixedSingle;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            now = new int[] { 1, 1 };
            clear_label();
            label2.BorderStyle = BorderStyle.FixedSingle;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            now = new int[] { 1, 2 };
            clear_label();
            label3.BorderStyle = BorderStyle.FixedSingle;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            now = new int[] { 1, 3 };
            clear_label();
            label4.BorderStyle = BorderStyle.FixedSingle;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            now = new int[] { 2, 3 };
            clear_label();
            label5.BorderStyle = BorderStyle.FixedSingle;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            now = new int[] { 2, 2 };
            clear_label();
            label6.BorderStyle = BorderStyle.FixedSingle;
        }

        private void label7_Click(object sender, EventArgs e)
        {
            now = new int[] { 2, 1 };
            clear_label();
            label7.BorderStyle = BorderStyle.FixedSingle;
        }

        private void label8_Click(object sender, EventArgs e)
        {
            now = new int[] { 2, 0 };
            clear_label();
            label8.BorderStyle = BorderStyle.FixedSingle;
        }

        private void label9_Click(object sender, EventArgs e)
        {
            now = new int[] { 3, 3 };
            clear_label();
            label9.BorderStyle = BorderStyle.FixedSingle;
        }

        private void label10_Click(object sender, EventArgs e)
        {
            now = new int[] { 3, 2 };
            clear_label();
            label10.BorderStyle = BorderStyle.FixedSingle;
        }

        private void label11_Click(object sender, EventArgs e)
        {
            now = new int[] { 3, 1 };
            clear_label();
            label11.BorderStyle = BorderStyle.FixedSingle;
        }

        private void label12_Click(object sender, EventArgs e)
        {
            now = new int[] { 3, 0 };
            clear_label();
            label12.BorderStyle = BorderStyle.FixedSingle;
        }

        private void label13_Click(object sender, EventArgs e)
        {
            now = new int[] { 4, 3 };
            clear_label();
            label13.BorderStyle = BorderStyle.FixedSingle;
        }

        private void label14_Click(object sender, EventArgs e)
        {
            now = new int[] { 4, 2 };
            clear_label();
            label14.BorderStyle = BorderStyle.FixedSingle;
        }

        private void label15_Click(object sender, EventArgs e)
        {
            now = new int[] { 4, 1 };
            clear_label();
            label15.BorderStyle = BorderStyle.FixedSingle;
        }

        private void label16_Click(object sender, EventArgs e)
        {
            now = new int[] { 4, 0 };
            clear_label();
            label16.BorderStyle = BorderStyle.FixedSingle;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string a = "1";
            switch(now[0])
            {
                case 1:
                    place1[now[1]].Text = a; break;
                case 2:
                    place2[now[1]].Text = a; break;
                case 3:
                    place3[now[1]].Text = a; break;
                case 4:
                    place4[now[1]].Text = a; break;
            }
            num[now[0]-1, now[1]] = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string a = "2";
            switch (now[0])
            {
                case 1:
                    place1[now[1]].Text = a; break;
                case 2:
                    place2[now[1]].Text = a; break;
                case 3:
                    place3[now[1]].Text = a; break;
                case 4:
                    place4[now[1]].Text = a; break;
            }
            num[now[0] - 1, now[1]] = 2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string a = "3";
            switch (now[0])
            {
                case 1:
                    place1[now[1]].Text = a; break;
                case 2:
                    place2[now[1]].Text = a; break;
                case 3:
                    place3[now[1]].Text = a; break;
                case 4:
                    place4[now[1]].Text = a; break;
            }
            num[now[0] - 1, now[1]] = 3;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string a = "4";
            switch (now[0])
            {
                case 1:
                    place1[now[1]].Text = a; break;
                case 2:
                    place2[now[1]].Text = a; break;
                case 3:
                    place3[now[1]].Text = a; break;
                case 4:
                    place4[now[1]].Text = a; break;
            }
            num[now[0] - 1, now[1]] = 4;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            List<int[]> num1 = new List<int[]>();
            List<int[]> num2 = new List<int[]>();
            List<int[]> num3 = new List<int[]>();
            List<int[]> num4 = new List<int[]>();
            List<int[]> output = new List<int[]>();

            for (int i = 0;i < 4; i++)
            {
                for(int j = 0;j < 4; j++)
                {
                    textBox1.Text += $"{num[i,j]} ";
                    switch (num[i,j])
                    {
                        case 1:
                            num1.Add(new int[] { i, j }); break;
                        case 2:
                            num2.Add(new int[] { i, j }); break;
                        case 3:
                            num3.Add(new int[] { i, j }); break;
                        case 4:
                            num4.Add(new int[] { i, j }); break;
                        case 0:
                            output.Add(new int[] { i, j }); break;
                    }
                }
                textBox1.Text += Environment.NewLine;
            }

            for (int i = 0; i < output.Count; i++)
            {
                var (x, y) = (output[i][0], output[i][1]);
                all[x, y].Text = string.Empty;
                all[x, y].BackColor = SystemColors.ActiveCaption;
                if (!num1.Any(n => n[0] == x) && !num1.Any(n => n[1] == y))
                {
                    all[x,y].Text += "1,";
                }
                if (!num2.Any(n => n[0] == x) && !num2.Any(n => n[1] == y))
                {
                    all[x, y].Text += "2,";
                }
                if (!num3.Any(n => n[0] == x) && !num3.Any(n => n[1] == y))
                {
                    all[x, y].Text += "3,";
                }
                if (!num4.Any(n => n[0] == x) && !num4.Any(n => n[1] == y))
                {
                    all[x, y].Text += "4,";
                }
                all[x, y].Text = all[x, y].Text.TrimEnd(',');
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Label[][] label = new Label[][]
            {
                place1,
                place2,
                place3,
                place4
            };
            HashSet<int> setx = new HashSet<int>();
            HashSet<int> sety = new HashSet<int>();
            HashSet<int> place = new HashSet<int>();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (num[i,j] == 0)
                    {
                        MessageBox.Show("輸入有誤");
                        return;
                    }
                }
                
            }

            for(int i = 0;i < 4; i++)
            {
                for(int j = 0;j < 4; j++)
                {
                    if (!setx.Add(num[i, j]))
                    {
                        label17.Text = "錯誤";
                        return;
                    }

                    if (!sety.Add(num[j, i]))
                    {
                        label17.Text = "錯誤";
                        return;
                    }

                    if (!place.Add(int.Parse(label[i][j].Text)))
                    {
                        label17.Text = "錯誤";
                        return;
                    }
                }
                setx = new HashSet<int>();
                sety = new HashSet<int>();
                place = new HashSet<int>();
            }

            label17.Text = "正確";
        }

        private void start()
        {
            Random random = new Random();
            HashSet<(int x, int y)> point = new HashSet<(int x, int y)>();
            while(point.Count<4)
            {
                int x = random.Next(4);
                int y = random.Next(4);
                point.Add((x,y));
            }

            Label[][] placeCols = new Label[][]
            {
                place1,
                place2,
                place3,
                place4
            };

            var put = point.ToList();

            for (int i = 0;i < put.Count;i++)
            {
                string a = (i+1).ToString();
                var (x, y) = put[i];
                placeCols[x][y].Text = a;
                num[x, y] = i + 1;
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(SystemColors.Control);

            Pen a1 = new Pen(Color.Black, 1);

            g.DrawLine(a1, 0, panel1.Height / 2, panel1.Width, panel1.Height / 2);
            g.DrawLine(a1, panel1.Width/2, 0, panel1.Width / 2, panel1.Height);
        }

        private void clear_label()
        {
            foreach (var item in place1)
            {
                item.BorderStyle = BorderStyle.Fixed3D;
            }
            foreach (var item in place2)
            {
                item.BorderStyle = BorderStyle.Fixed3D;
            }
            foreach (var item in place3)
            {
                item.BorderStyle = BorderStyle.Fixed3D;
            }
            foreach (var item in place4)
            {
                item.BorderStyle = BorderStyle.Fixed3D;
            }
        }
    }
}
