using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Q4
{
    public partial class Form1 : Form
    {
        private Image image;
        private Bitmap bmp = null;
        private int[,] gray;
        public Form1()
        {
            InitializeComponent();
        }

        private void 開啟色彩影像OpenColorImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                image = Image.FromFile(openFileDialog.FileName);
                pictureBox1.Image = image;
            }
        }

        private void 結束離開ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void 色彩影像轉灰階影像ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(image);
            gray = new int[bmp.Width, bmp.Height];
            for (int i = 0;i < bmp.Width;i++)
            {
                for(int j = 0;j < bmp.Height;j++)
                {
                    Color color = bmp.GetPixel(i, j);

                    int r = color.R;
                    int g = color.G;
                    int b = color.B;

                    gray[i,j] = (int)(r * 0.3 + g * 0.59 + b * 0.11);

                    bmp.SetPixel(i, j, Color.FromArgb(gray[i, j], gray[i, j], gray[i, j]));
                }
            }
            pictureBox2.Image = bmp;
        }

        private void 劃出灰階影像直方圖ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] Max_gray_count = new int[256];
            chart1.Series.Clear();

            chart1.Series.Add("Series1");
            chart1.Series["Series1"].ChartType = SeriesChartType.Line;

            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    Max_gray_count[gray[i, j]]++;
                }
            }

            for (int i = 0;i < 256; i++)
            {
                chart1.Series["Series1"].Points.AddXY(i, Max_gray_count[i]);
            }
        }

        private void 求最小灰階和最大灰階ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int min = 255;
            int max = 0;
            for (int i = 0; i < bmp.Width;i++)
            {
                for (int j = 0; j < bmp.Height;j++)
                {
                    min = Math.Min(min, gray[i, j]);
                    max = Math.Max(max, gray[i, j]);
                }
            }
            textBox1.Text = min.ToString();
            textBox2.Text = max.ToString();
        }

        private void 求出環最多之灰階和此機率ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int max_count_ans = new int();
            int[] Max_gray_count = new int[256];
            double max_count = new double();
            double total_pixel = bmp.Width * bmp.Height;

            for (int i = 0;i < bmp.Width; i++)
            {
                for(int j = 0;j < bmp.Height; j++)
                {
                    Max_gray_count[gray[i,j]]++;
                }
            }

            for (int i = 0;i < Max_gray_count.Length ; i++)
            {
                if(max_count < Max_gray_count[i])
                {
                    max_count = Max_gray_count[i];
                    max_count_ans = i;
                }
            }
            double output_pixel = max_count / total_pixel;

            textBox3.Text = max_count_ans.ToString();
            textBox4.Text = output_pixel.ToString();
        }
    }
}
