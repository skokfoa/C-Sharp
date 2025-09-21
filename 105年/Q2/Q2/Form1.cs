using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Q2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Bitmap bitmap = new Bitmap(ofd.FileName);
                pictureBox1.Image = bitmap;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(pictureBox1.Image);
            double args = count_arvg(bitmap);

            Color[,] right = new Color[bitmap.Width / 2,bitmap.Height];
            Point Top = new Point(0, int.MinValue);
            Point Low = new Point(0, int.MaxValue);
            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width / 2; x++)
                {
                    right[x, y] = bitmap.GetPixel(x + bitmap.Width / 2, y);
                    int colorValue = (int)(right[x, y].R * 0.3 + right[x, y].G * 0.59 + right[x, y].B * 0.11);
                    if (colorValue <= 200)
                    {
                        if (y < Low.Y) Low = new Point(x + bitmap.Width / 2, y);
                        if (y > Top.Y) Top = new Point(x + bitmap.Width / 2, y);
                    }
                }
            }
            double high = Math.Abs(Top.Y - Low.Y) * args;
            textBox1.Text = high.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(pictureBox1.Image);
            double args = count_arvg(bitmap);

            Color[,] right = new Color[bitmap.Width / 2, bitmap.Height];
            Point Xleft = new Point(int.MaxValue, 0);
            Point Xright = new Point(int.MinValue, 0);
            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width / 2; x++)
                {
                    right[x, y] = bitmap.GetPixel(x + bitmap.Width / 2, y);
                    int colorValue = (int)(right[x, y].R * 0.3 + right[x, y].G * 0.59 + right[x, y].B * 0.11);
                    if (colorValue <= 200)
                    {
                        if (x < Xleft.X) Xleft = new Point(x, y);
                        if (x > Xright.X) Xright = new Point(x, y);
                    }
                }
            }
            double high = Math.Abs(Xleft.X - Xright.X) * args;
            textBox2.Text = high.ToString();
            pictureBox1.Image = bitmap;

        }
        private static double count_arvg(Bitmap bitmap)
        {
            Pen pen = new Pen(Color.Red, 2);
            double args = new double();
            Color[,] chair = new Color[bitmap.Width / 3, bitmap.Height];
            Point ChairTop = new Point(0, int.MinValue);
            Point ChairLow = new Point(0, int.MaxValue);
            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width / 3; x++)
                {
                    chair[x, y] = bitmap.GetPixel(x, y);
                    int colorValue = (int)(chair[x, y].R * 0.3 + chair[x, y].G * 0.59 + chair[x, y].B * 0.11);
                    if (colorValue <= 200)
                    {
                        if (y < ChairLow.Y) ChairLow = new Point(x, y);
                        if (y > ChairTop.Y) ChairTop = new Point(x, y);
                    }
                }
            }
            args = 830.0 / Math.Abs(ChairTop.Y - ChairLow.Y);
            return args;
        }
    }
}
