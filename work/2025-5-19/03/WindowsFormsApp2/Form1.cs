using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        private bool drawSin = false;
        public Form1()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(pictureBox1_Paint);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            drawSin = true;
            this.Invalidate();  // 觸發重繪，會呼叫 Paint 事件
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (!drawSin) return;

            Graphics g = e.Graphics;
            g.Clear(Color.White);

            Pen axisPen = new Pen(Color.Black, 1);
            Pen sinPen = new Pen(Color.Blue, 2);

            int width = pictureBox1.ClientSize.Width;
            int height = pictureBox1.ClientSize.Height;

            // 畫 x 軸
            g.DrawLine(axisPen, 0, height / 2, width, height / 2);

            // 畫 y 軸
            g.DrawLine(axisPen, 50, 0, 50, height);

            // 繪製 sin 波形
            Point[] points = new Point[width - 50];
            for (int x = 0; x < points.Length; x++)
            {
                double radians = (x / (double)(width - 50)) * 4 * Math.PI;
                double y = Math.Sin(radians) * 100;
                points[x] = new Point(x + 50, (int)(height / 2 - y));
            }

            g.DrawLines(sinPen, points);

            axisPen.Dispose();
            sinPen.Dispose();
        }

    }
}
