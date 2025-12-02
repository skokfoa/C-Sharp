using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _107_Q1
{
    public partial class Form1 : Form
    {
        int[,] states =
        {
            {1, 0, 0, 0, 0, 1 },
            {1, 0, 0, 0, 1, 0 },
            {1, 0, 0, 1, 0, 0 },
            {0, 0, 1, 1, 0, 0 },
            {0, 1, 0, 1, 0, 0 },
            {1, 0, 0, 1, 0, 0 }
        };

        int state = -1;

        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(SystemColors.Control);
            e.Graphics.DrawLine(new Pen(Color.Black), 50, 0, 50, 500);
            e.Graphics.DrawLine(new Pen(Color.Black), 100, 0, 100, 500);
            e.Graphics.DrawLine(new Pen(Color.Black), 0, 220, 500, 220);
            e.Graphics.DrawLine(new Pen(Color.Black), 0, 260, 500, 260);

            if (state > -1)
            {
                if(states[state, 0] == 1)
                    e.Graphics.FillEllipse(new SolidBrush(Color.Red), 0, 20, 40, 40);

                if (states[state, 1] == 1)
                    e.Graphics.FillEllipse(new SolidBrush(Color.Orange), 0, 70, 40, 40);

                if (states[state, 2] == 1)
                    e.Graphics.FillEllipse(new SolidBrush(Color.Green), 0, 120, 40, 40);

                if (states[state, 3] == 1)
                    e.Graphics.FillEllipse(new SolidBrush(Color.Red), 200, 270, 40, 40);

                if (states[state, 4] == 1)
                    e.Graphics.FillEllipse(new SolidBrush(Color.Orange), 250, 270, 40, 40);

                if (states[state, 5] == 1)
                    e.Graphics.FillEllipse(new SolidBrush(Color.Green), 300, 270, 40, 40);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            state = 0;

            // call Refresh to preform re-painting the pictureBox
            Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (state < 0)
                return;

            state++;

            if (state >= 6)
                state = 0;
            Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (state < 0)
                return;

            state = -1;
            Refresh();
        }
    }
}
