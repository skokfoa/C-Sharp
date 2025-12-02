using System;
using System.Drawing;
using System.Windows.Forms;

namespace _93_Q3
{
    public partial class Form1 : Form
    {
        int[,] points = new int[0, 0];

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int length = int.Parse(textBox1.Text);

            if(length < 3)
            {
                MessageBox.Show("錯誤的 N");
                return;
            }

            if(length % 2 == 0)
            {
                MessageBox.Show("N 需要是奇數");
                return;
            }

            points = new int[length, length];

            int x = length / 2, y = 0;

            int current = 1;

            do
            {
                if (points[x, y] > 0)
                {
                    y = GetPoint(y + 2);
                    x = GetPoint(x - 1);

                }

                points[x, y] = current++;

                x = GetPoint(x + 1);
                y = GetPoint(y - 1);
            } while (current <= length * length);

            pictureBox1.Refresh();
        }

        public int GetPoint(int point)
        {
            int length = points.GetLength(0);

            if (point >= length)
                return point - length;

            if (point < 0)
                return length + point;

            return point;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            int length = points.GetLength(0);

            if (length == 0)
                return;

            e.Graphics.Clear(SystemColors.Control);

            var pen = new Pen(Color.Black);
            var font = new Font("微軟正黑體", 12);
            var brush = new SolidBrush(Color.Black);

            for (int i = 0; i <= length + 1; i++)
            {
                e.Graphics.DrawLine(pen, i * 40, 10, i * 40, (length + 1) * 40 + 10);
                e.Graphics.DrawLine(pen, 0, i * 40 + 10, (length + 1) * 40, i * 40 + 10);
            }

            for(int i = 0; i <= length; i++)
            {
                for (int j = 0; j <= length; j++)
                {
                    var point = new Point(i * 40 + 2, j * 40 + 12);

                    if (i == length || j == length)
                        e.Graphics.DrawString((length * (((length * length) + 1) / 2)).ToString(), font, brush, point);

                    else e.Graphics.DrawString(points[i, j].ToString(), font, brush, point);
                }
            }
        }
    }
}
