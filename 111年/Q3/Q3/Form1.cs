using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q3
{
    public partial class Form1 : Form
    {
        private Brush[] color = new Brush[]
        {
            new SolidBrush(Color.Black),
            new SolidBrush(Color.Blue),
            new SolidBrush(Color.Red),
            new SolidBrush(Color.Green),
            new SolidBrush(Color.Orange),
            new SolidBrush(Color.Purple),
            new SolidBrush(Color.Brown),
            new SolidBrush(Color.Gray),
            new SolidBrush(Color.Yellow),
            new SolidBrush(Color.Cyan),
            new SolidBrush(Color.Magenta),
            new SolidBrush(Color.Pink),
            new SolidBrush(Color.Lime),
            new SolidBrush(Color.Gold),
            new SolidBrush(Color.DarkCyan),
            new SolidBrush(Color.DarkRed)
        };
        int[,] intcolor = new int[4, 4];
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            Graphics g = panel1.CreateGraphics();

            HashSet<int> set = new HashSet<int>();
            

            while(set.Count < 16)
            {
                set.Add(random.Next(0, color.Length));
            }

            for (int i = 0;i < 4; i++)
            {
                for(int j = 0;j < 4; j++)
                {
                    int c = set.ElementAt(i * 4 + j);
                    g.FillRectangle(color[c], i * 40, j * 40, 40, 40);
                    intcolor[i, j] = c;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for(int i = 0;i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {

                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void draw()
        {
            Graphics g = panel1.CreateGraphics();
            g.Clear(SystemColors.Control);
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    g.FillRectangle(color[intcolor[i, j]], i * 40, j * 40, 40, 40);
                }
            }
        }
    }
}
