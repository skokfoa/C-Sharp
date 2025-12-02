using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q6
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

            ofd.Title = "請選擇一張圖片";
            ofd.Filter = "圖片檔 (*.jpg;*.png;*.bmp;*.tif)|*.jpg;*.png;*.bmp;*.tif";
            ofd.Multiselect = false;
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Bitmap bmp = new Bitmap(ofd.FileName);
                pictureBox1.Image = bmp;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image == null)
            {
                MessageBox.Show("未載入影像");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "PNG|*.png|JPEG|*.jpg;*.jpeg|Bitmap|*.bmp|TIFF|*.tif;*.tiff";
            sfd.FileName = "image";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Image img = pictureBox2.Image;

                img.Save(sfd.FileName);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap bmp = null;
            bmp = gray((Bitmap)pictureBox1.Image);

            pictureBox2.Image = bmp;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bitmap bmp = null;
            bmp = gray((Bitmap)pictureBox1.Image);

            int[,] Gx = new int[,] { { -1, 0, 1 }
                                    ,{ -2, 0, 2 }
                                    ,{ -1, 0, 1 } };

            int[,] Gy = new int[,] { { -1, -2, -1}
                                    ,{  0,  0,  0 }
                                    ,{  1,  2,  1 }};

            Bitmap output = new Bitmap(bmp.Width,bmp.Height);

            for(int i = 1; i < bmp.Width - 1; i++)
            {
                for(int j = 1; j < bmp.Height - 1; j++)
                {
                    double sumx = new double();
                    double sumy = new double();

                    for(int k = -1; k < 2; k++)
                    {
                        for(int l = -1; l < 2; l++)
                        {
                            int pixel = bmp.GetPixel(i + k, j + l).R;

                            sumx += pixel * Gx[k + 1, l + 1];
                            sumy += pixel * Gy[k + 1, l + 1];
                        }
                    }

                    int G = (int)Math.Sqrt(sumx * sumx + sumy * sumy);
                    G = G > 255 ? 255 : G;
                    G = G < 0 ? 0 : G;
                    output.SetPixel(i, j, Color.FromArgb(G, G, G));
                }
            }

            pictureBox2.Image = output;
        }

        private static Bitmap gray(Bitmap bmp)
        {
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    Color c = bmp.GetPixel(i, j);

                    int red = c.R; int green = c.G; int blue = c.B;
                    int gray = (int)(0.3 * red + 0.59 * green + 0.11 * blue);

                    bmp.SetPixel(i, j, Color.FromArgb(gray, gray, gray));
                }
            }

            return bmp;
        }
    }
}
