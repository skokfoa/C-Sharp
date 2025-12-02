using System;
using System.Drawing;
using System.Windows.Forms;

namespace _105_Q6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                InitialDirectory = Application.StartupPath
            };

            if(dialog.ShowDialog() == DialogResult.OK)
                pictureBox1.ImageLocation = dialog.FileName;

            button1.Enabled = true;
            button1.Text = "Reveal The Image Behind";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var map = new Bitmap(pictureBox1.Image);

            for(int x = 0; x < map.Width; x++)
            {
                for (int y = 0; y < map.Height; y++)
                {
                    var pixel = map.GetPixel(x, y);

                    map.SetPixel(x, y, Color.FromArgb(
                        GetPixel(pixel.R),
                        GetPixel(pixel.G),
                        GetPixel(pixel.B)
                    ));
                }
            }

            button1.Enabled = false;
            pictureBox1.Image = map;
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[]) e.Data.GetData(DataFormats.FileDrop);

            if (files.Length == 0)
                return;

            pictureBox1.ImageLocation = files[0];

            button1.Enabled = true;
            button1.Text = "Reveal The Image Behind";
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Move;
        }

        public int GetPixel(int color)
        {
            if ((color & 1) > 0)
                return 16;

            return 235;
        }
    }
}
