using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            panel1.Invalidate();
        }
        bool start = false;

        Point a1 = new Point();
        Point b1 = new Point();

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);

            Pen xy = new Pen(Color.Black, 2);
            Pen aLine = new Pen(Color.Blue, 2);
            Pen bLine = new Pen(Color.Red, 2);

            aLine.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            bLine.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;

            int width = panel1.ClientSize.Width;
            int height = panel1.ClientSize.Height;

            // 畫 X 軸與 Y 軸
            g.DrawLine(xy, 20, 0, 20, height);
            g.DrawLine(xy, 0, height - 20, width, height - 20);

            if (start)
            {
                Point origin = new Point(20, height - 20);
                int scale = 40; // 比例尺倍率，可依需要自行調整

                Point aEnd = new Point(origin.X + a1.X * scale, origin.Y - a1.Y * scale);
                Point bEnd = new Point(origin.X + b1.X * scale, origin.Y - b1.Y * scale);

                g.DrawLine(aLine, origin, aEnd);
                g.DrawLine(bLine, origin, bEnd);

                Font font = new Font("Arial", 10);
                Brush brush = Brushes.Black;

                g.DrawString("a", font, brush, aEnd.X + 5, aEnd.Y);
                g.DrawString("b", font, brush, bEnd.X + 5, bEnd.Y);
            }

            xy.Dispose();
            aLine.Dispose();
            bLine.Dispose();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string[] a = textBox1.Text.Split(',');
            string[] b = textBox2.Text.Split(',');

            a1 = new Point(int.Parse(a[0]), int.Parse(a[1]));
            b1 = new Point(int.Parse(b[0]), int.Parse(b[1]));
            start = true;
            panel1.Invalidate();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
