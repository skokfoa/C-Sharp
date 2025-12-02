using System;
using System.Drawing;
using System.Windows.Forms;

namespace _92_Q4
{
    public partial class Form1 : Form
    {
        int[,] sobel_x =
        {
            { -1, 0, 1 },
            { -2, 0, 2 },
            { -1, 0, 1 },
        };

        int[,] sobel_y =
        {
            { -1, -2, -1 },
            { 0, 0, 0 },
            { 1, 2, 1 },
        };


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TextBox[,] boxes =
                {
                    { textBox1, textBox2, textBox3 },
                    { textBox6, textBox5, textBox4 },
                    { textBox9, textBox8, textBox7 },
                };

            pictureBox2.Image = null;

            var map = new Bitmap(pictureBox1.Image);

            if (radioButton2.Checked)
            {
                int[,] matrix = new int[3, 3];

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        matrix[i, j] = int.Parse(boxes[i, j].Text);
                    }
                }

                pictureBox2.Image = Draw(map, matrix);
                return;
            }

            if (comboBox1.Text == "Average")
            {
                Bitmap source = (Bitmap)map.Clone();

                for (int i = 0; i < map.Width; i++)
                {
                    for (int j = 0; j < map.Height; j++)
                    {
                        int R = 0, G = 0, B = 0;

                        for (int x = 0; x < 3; x++)
                        {
                            for (int y = 0; y < 3; y++)
                            {
                                Color pixel = source.GetPixel(
                                    Math.Min(Math.Max(0, i + x - 1), map.Width - 1),
                                    Math.Min(Math.Max(0, j + y - 1), map.Height - 1)
                                );

                                R += pixel.R;
                                G += pixel.G;
                                B += pixel.B;

                                // Console.WriteLine($"{Math.Min(Math.Max(0, i + x - 1), map.Width - 1)} {Math.Min(Math.Max(0, j + y - 1), map.Height - 1)} {pixel.G}");
                            }
                        }

                        map.SetPixel(i, j, Color.FromArgb(
                            Math.Min(255, Math.Max(0, R / 9)),
                            Math.Min(255, Math.Max(0, G / 9)),
                            Math.Min(255, Math.Max(0, B / 9))
                        ));
                    }
                }

                pictureBox2.Image = map;

                return;
            }

            if (comboBox1.Text == "Sobel_x")
            {
                pictureBox2.Image = Draw(map, sobel_x);
            }

            if (comboBox1.Text == "Sobel_y")
            {
                pictureBox2.Image = Draw(map, sobel_y); 
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                InitialDirectory = Application.StartupPath
            };

            if(dialog.ShowDialog() == DialogResult.OK)
            {
                var map = new Bitmap(dialog.FileName);

                pictureBox1.Image = map;
                pictureBox2.Image = null;

                toolStripStatusLabel1.Text = $"Width={map.Width}, Height={map.Height}";
            }
        }

        public Bitmap Draw(Bitmap map, int[,] matrix)
        {
            Bitmap source = (Bitmap) map.Clone();

            for (int i = 0; i < map.Width; i++)
            {
                for (int j = 0; j < map.Height; j++)
                {
                    int R = 0, G = 0, B = 0;

                    for (int x = 0; x < 3; x++)
                    {
                        for (int y = 0; y < 3; y++)
                        {
                            Color pixel = source.GetPixel(
                                Math.Min(Math.Max(0, i + x - 1), map.Width - 1),
                                Math.Min(Math.Max(0, j + y - 1), map.Height - 1)
                            );

                            R += matrix[x, y] * pixel.R;
                            G += matrix[x, y] * pixel.G;
                            B += matrix[x, y] * pixel.B;

                            // Console.WriteLine($"{Math.Min(Math.Max(0, i + x - 1), map.Width - 1)} {Math.Min(Math.Max(0, j + y - 1), map.Height - 1)} {pixel.G}");
                        }
                    }

                    map.SetPixel(i, j, Color.FromArgb(
                        Math.Min(255, Math.Max(0, R)),
                        Math.Min(255, Math.Max(0, G)),
                        Math.Min(255, Math.Max(0, B))
                    ));
                }
            }

            return map;
        }

        private void saevToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog
            {
                InitialDirectory = Application.StartupPath
            };

            if(dialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image.Save(dialog.FileName);
            }
        }
    }
}
