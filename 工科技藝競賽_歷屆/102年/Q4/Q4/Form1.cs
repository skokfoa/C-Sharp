using System;
using System.Numerics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q4
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
                pictureBox1.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap result = new Bitmap(bmp);
            
            for(int i = 0; i < bmp.Width; i++)
            {
                for(int j = 0; j < bmp.Height; j++)
                {
                    Color c = bmp.GetPixel(i, j);
                    if ((c.R + c.G + c.B) / 3 > 128) continue;
                    for(int k = -1; k < 2; k++)
                    {
                        if (i + k < 0 || i + k >= bmp.Width) continue;
                        for(int l = -1; l < 2; l++)
                        {
                            if (j + l < 0 || j + l >= bmp.Height) continue;
                            result.SetPixel(i + k, j + l, Color.Black);
                        }
                    }
                }
            }

            pictureBox1.Image = result;
        }
    }
}
