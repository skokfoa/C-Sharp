using System;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace _105_Q2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                InitialDirectory = Application.StartupPath,
            };

            if (dialog.ShowDialog() == DialogResult.OK)
                pictureBox1.ImageLocation = dialog.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var map = new Bitmap(pictureBox1.Image);

            int center = GetCenter();

            int chairTop = 0, chairBottom = 0;

            GetChair(center, map, ref chairTop, ref chairBottom);

            double scale = 830f / (chairBottom - chairTop);

            int objectTop = 0, objectBottom = 0;

            // then get object
            for (int y = 0; y < map.Height; y++)
            {
                for (int x = center; x < map.Width; x++)
                {
                    var pixel = map.GetPixel(x, y);

                    var colorValue = pixel.R * 0.3 + pixel.G * 0.59 + pixel.B * 0.11;

                    if (colorValue > 200)
                        continue;

                    if (objectTop == 0)
                        objectTop = y;

                    objectBottom = y;
                }
            }

            textBox1.Text = ((objectBottom - objectTop) * scale).ToString();
        }

        public void GetChair(int center, Bitmap map, ref int chairTop, ref int chairBottom) {
            // get chair first
            for (int y = 0; y < map.Height; y++)
            {
                for (int x = 0; x < center; x++)
                {
                    var pixel = map.GetPixel(x, y);

                    var colorValue = pixel.R * 0.3 + pixel.G * 0.59 + pixel.B * 0.11;

                    if (colorValue > 200)
                        continue;

                    if (chairTop == 0)
                        chairTop = y;

                    chairBottom = y;
                }
            }
        }

        public int GetCenter()
        {
            var map = new Bitmap(pictureBox1.Image);

            // prevent starting from border
            for (int x = map.Width / 4; x < map.Width; x++)
            {
                bool pass = true;

                for (int y = 0; y < map.Height; y++)
                {
                    var pixel = map.GetPixel(x, y);

                    var colorValue = pixel.R * 0.3 + pixel.G * 0.59 + pixel.B * 0.11;

                    if (colorValue > 200)
                        continue;

                    pass = false;
                    break;
                }

                // successfully find a center
                if (pass)
                    return x;
            }

            // fallback to math
            return map.Width / 2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var map = new Bitmap(pictureBox1.Image);

            int center = GetCenter();

            int chairTop = 0, chairBottom = 0;

            GetChair(center, map, ref chairTop, ref chairBottom);

            double scale = 830f / (chairBottom - chairTop);

            int objectLeft = 0, objectRight = 0;

            // then get object
            for (int x = center; x < map.Width; x++)
            {
                for (int y = 0; y < map.Height; y++)
                {
                    var pixel = map.GetPixel(x, y);

                    var colorValue = pixel.R * 0.3 + pixel.G * 0.59 + pixel.B * 0.11;

                    if (colorValue > 200)
                        continue;

                    if (objectLeft == 0)
                        objectLeft = x;

                    objectRight = x;
                }
            }

            textBox2.Text = ((objectRight - objectLeft) * scale).ToString();
        }
    }
}
