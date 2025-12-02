using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _102_Q4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.InitialDirectory = Application.StartupPath;
                dialog.Filter = "圖片(*.png, *.jpg)|*.png;*.jpg";

                if(dialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.ImageLocation = dialog.FileName;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var bmp = new Bitmap(pictureBox1.Image);
            var new_bmp = new Bitmap(bmp);

            for(int x = 0; x < bmp.Width; x++)
            {
                for(int y = 0; y < bmp.Height; y++)
                {
                    var pixel = bmp.GetPixel(x, y);
                    int gray = (pixel.R * 299 + pixel.G * 587 + pixel.B * 114 + 500) / 1000;

                    if(gray < 127)
                    {
                        for(int i = -1; i <= 1; i++)
                        {
                            for (int j = -1; j <= 1; j++)
                            {
                                if (x + i < 0 || y + i < 0 || x + i >= bmp.Width || y + i >= bmp.Height)
                                {
                                    continue;
                                }

                                new_bmp.SetPixel(x + i, y + j, pixel);
                            }
                        }
                    }
                }
            }

            pictureBox1.Image = new_bmp;
        }
    }
}
