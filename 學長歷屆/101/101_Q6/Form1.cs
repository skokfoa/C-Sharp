using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace _101_Q6
{
    public partial class Form1 : Form
    {
        readonly Point[] possibles =
        {
            // 是北(N)、東北(NE)、東(E)、東南(SE)、南(S)、西南(SW)、西(W)、西北(NW)。
            // 以老鼠為正面去判斷
            new Point(0, 1),
            new Point(1, 1),
            new Point(1, 0),
            new Point(1, -1),
            new Point(0, -1),
            new Point(-1, -1),
            new Point(-1, 0),
            new Point(-1, 1),
        };

        Stack<Point> paths;
        int[][] matrix;
        bool[,] walked;
        readonly Point final = new Point(7, 7);

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            matrix = File.ReadAllLines(textBox2.Text).Where(x => x.Trim().Length > 0)
                .Select(x => x.Trim().Split(' ').Select(int.Parse).ToArray()).ToArray();

            walked = new bool[matrix.Length, matrix.Length];

            walked[0, 0] = true;

            paths = new Stack<Point>();
            paths.Push(new Point(0, 0));

            Walk(new Point(0, 0));

            textBox1.Text = string.Join("", paths.Reverse().Select(x => $"({x.Y},{x.X})"));
        }

        public bool Walk(Point point)
        {
            if(point == final)
                return true;

            foreach(var possible in possibles) { 
                var next = new Point
                {
                    X = point.X + possible.X,
                    Y = point.Y - possible.Y
                };

                if (next.X >= 0 && next.Y >= 0 && next.X <= 7 && next.Y <= 7 && matrix[next.Y][next.X] == 0 && !walked[next.X, next.Y])
                {
                    paths.Push(next);
                    walked[next.X, next.Y] = true;

                    if(Walk(next))
                        return true;

                    // paths.Pop();
                }
            }

            // paths.Pop();

            return false;
        }
    }
}
