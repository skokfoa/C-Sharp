using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace _104_Q1
{
    public partial class Form1 : Form
    {
        readonly int[,] grid = new int[4, 4];

        Point selected = new Point(0, 0);

        Label[,] labels;

        public Form1()
        {
            InitializeComponent();

            for (int i = 0; i < 4; i++)
                grid[i, i] = i + 1;
        }


        private void label1_Click(object sender, EventArgs e)
        {
            selected = new Point(0, 0);
        }

        private void label3_Click_1(object sender, EventArgs e)
        {
            selected = new Point(0, 1);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            selected = new Point(0, 2);
        }

        private void label5_Click(object sender, EventArgs e)
        {
            selected = new Point(0, 3);
        }

        private void label7_Click(object sender, EventArgs e)
        {
            selected = new Point(1, 0);
        }

        private void label6_Click(object sender, EventArgs e)
        {
            selected = new Point(1, 1);
        }

        private void label9_Click(object sender, EventArgs e)
        {
            selected = new Point(1, 2);
        }

        private void label8_Click(object sender, EventArgs e)
        {
            selected = new Point(1, 3);
        }

        private void label14_Click(object sender, EventArgs e)
        {
            selected = new Point(2, 0);
        }

        private void label13_Click(object sender, EventArgs e)
        {
            selected = new Point(2, 1);
        }

        private void label18_Click(object sender, EventArgs e)
        {
            selected = new Point(2, 2);
        }

        private void label17_Click(object sender, EventArgs e)
        {
            selected = new Point(2, 3);
        }

        private void label12_Click(object sender, EventArgs e)
        {
            selected = new Point(3, 0);
        }

        private void label11_Click(object sender, EventArgs e)
        {
            selected = new Point(3, 1);
        }

        private void label16_Click(object sender, EventArgs e)
        {
            selected = new Point(3, 2);
        }

        private void label15_Click(object sender, EventArgs e)
        {
            selected = new Point(3, 3);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for(int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    if (grid[x, y] > 0)
                        continue;

                    List<int> available = Enumerable.Range(1, 4).ToList();

                    for(int k = 0; k < 4; k++)
                    {
                        if (grid[k, y] > 0 && available.Contains(grid[k, y]))
                            available.Remove(grid[k, y]);

                        if (grid[x, k] > 0 && available.Contains(grid[x, k]))
                            available.Remove(grid[x, k]);
                    }

                    labels[x, y].Text = string.Join(",", available);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            labels[selected.X, selected.Y].Text = "1";
            grid[selected.X, selected.Y] = 1; 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            labels = new Label[,] {
                { label1, label3, label4, label5 },
                { label7, label6, label9, label8 },
                { label14, label13, label18, label17 },
                { label12, label11, label16, label15 },
            };
        }

        private void button4_Click(object sender, EventArgs e)
        {
            labels[selected.X, selected.Y].Text = "2";
            grid[selected.X, selected.Y] = 2;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            labels[selected.X, selected.Y].Text = "3";
            grid[selected.X, selected.Y] = 3;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            labels[selected.X, selected.Y].Text = "4";
            grid[selected.X, selected.Y] = 4;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    for (int k = 0; k < 4; k++)
                    {
                        if (
                            (grid[k, y] == grid[x, y] && k != x) || 
                            (grid[x, k] == grid[x, y] && k != y)
                        )
                        {
                            label19.Text = "錯誤";
                            return;
                        }
                    }
                }
            }

            label19.Text = "正確";
        }
    }
}
