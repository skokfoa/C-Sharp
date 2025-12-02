using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            label1.AllowDrop = true;
            pictureBox1.AllowDrop = true;

            button1.BackColor = Color.FromArgb(128, 50, 205, 50);
            button1.Enabled = false;
        }

        private void pictureBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(ofd.FileName);
                label1.Enabled = false;
                label1.Visible = false;
                button_Change();
            }
        }

        private void pictureBox1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (files.Length > 0)
            {
                try
                {
                    pictureBox1.Image = Image.FromFile(files[0]);
                    button_Change();
                    label1.Enabled = false;
                    label1.Visible = false;
                }
                catch
                {
                    MessageBox.Show("不是有效的圖片檔案");
                }
            }
        }

        public void button_Change()
        {
            Button b = button1;
            b.Enabled = true;
            b.BackColor = Color.FromArgb(255, 50, 205, 50);
            b.Text = "Reveal The Image Behind";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);

            for(int x = 0; x < bmp.Width; x++)
            {
                for(int y = 0; y < bmp.Height; y++)
                {
                    Color pixelColor = bmp.GetPixel(x, y);
                    int r = pixelColor.R % 2 == 0 ? 235 : 16;
                    int g = pixelColor.G % 2 == 0 ? 235 : 16;
                    int b = pixelColor.B % 2 == 0 ? 235 : 16;

                    bmp.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }

            pictureBox1.Image = bmp;
        }
    }
}
