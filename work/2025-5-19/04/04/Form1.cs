using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _04
{
    public partial class Form1 : Form
    {
        private short color = 1;
        private short shape = 1;
        private short thickness = 1;
        private Point startPoint;
        private Point endPoint;

        private List<ShapeData> shapes = new List<ShapeData>();

        public Form1()
        {
            InitializeComponent();
            hScrollBar1.Minimum = 1;
            hScrollBar1.Maximum = 10;
            hScrollBar1.Value = 1;
            textBox1.Text = "1";

            pictureBox1.MouseDown += pictureBox1_MouseDown;
            pictureBox1.MouseUp += pictureBox1_MouseUp;
            pictureBox1.Paint += pictureBox1_Paint;
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            textBox1.Text = hScrollBar1.Value.ToString();
            thickness = (short)hScrollBar1.Value;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int val;
            if (int.TryParse(textBox1.Text, out val))
            {
                if (val >= 1 && val <= 10)
                {
                    hScrollBar1.Value = val;
                    thickness = (short)val;
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            color = 1;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            color = 2;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            color = 3;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            shape = 1;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            shape = 2;
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            shape = 3;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            shapes.Clear();
            pictureBox1.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            startPoint = e.Location;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            endPoint = e.Location;
            shapes.Add(new ShapeData
            {
                Color = color,
                Shape = shape,
                Thickness = thickness,
                Start = startPoint,
                End = endPoint
            });
            pictureBox1.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            foreach (var s in shapes)
            {
                Pen pen = new Pen(GetColor(s.Color), s.Thickness);
                switch (s.Shape)
                {
                    case 1:
                        e.Graphics.DrawLine(pen, s.Start, s.End);
                        break;
                    case 2:
                        int radius = (int)Math.Sqrt(Math.Pow(s.End.X - s.Start.X, 2) + Math.Pow(s.End.Y - s.Start.Y, 2));
                        e.Graphics.DrawEllipse(pen, s.Start.X - radius, s.Start.Y - radius, radius * 2, radius * 2);
                        break;
                    case 3:
                        Rectangle rect = new Rectangle(
                            Math.Min(s.Start.X, s.End.X),
                            Math.Min(s.Start.Y, s.End.Y),
                            Math.Abs(s.Start.X - s.End.X),
                            Math.Abs(s.Start.Y - s.End.Y));
                        e.Graphics.DrawRectangle(pen, rect);
                        break;
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private Color GetColor(short c)
        {
            switch (c)
            {
                case 1: return Color.Red;
                case 2: return Color.Blue;
                case 3: return Color.Green;
                default: return Color.Black;
            }
        }
    }

    class ShapeData
    {
        public short Color;
        public short Shape;
        public short Thickness;
        public Point Start;
        public Point End;
    }
}

