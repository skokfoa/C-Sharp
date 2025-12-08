using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Q1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a, b, c, d;
            int ab, ac, bc, bd, cd, ad;

            bc = int.Parse(textBox1.Text);
            ab = int.Parse(textBox2.Text);
            cd = int.Parse(textBox3.Text);

            ad = int.Parse(textBox6.Text);
            bd = int.Parse(textBox5.Text);
            ac = int.Parse(textBox4.Text);

            if (overRange(bc) || overRange(ab) || overRange(cd) ||
                overRange(ad) || overRange(bd) || overRange(ac))
            {
                label5.Text = "數字超過範圍";
                return;
            }

            a = (ab + ac - bc) / 2;
            b = (bc + bd - cd) / 2;
            c = (cd + ac - ad) / 2;
            d = (ad + bd - ab) / 2;

            if (a + b != ab || a + c != ac || a + d != ad ||
                b + c != bc || b + d != bd || c + d != cd)
            {
                label5.Text = "無解";
                return;
            }

            label1.Text = a.ToString();
            label2.Text = b.ToString();
            label3.Text = c.ToString();
            label4.Text = d.ToString();
        }

        private static bool overRange(int num) => Math.Abs(num) <= 20 ? false : true;

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.Black, 1);

            Point[] start = new Point[6];
            Point[] end = new Point[6];

            start[0] = new Point(label2.Right, label2.Top);
            end[0]   = new Point(textBox1.Left, textBox1.Top + textBox1.Height / 2);

            start[1] = new Point(label2.Right, label2.Top + label2.Height / 2);
            end[1]   = new Point(textBox2.Left, textBox2.Top + textBox2.Height / 2);
            
            start[2] = new Point(label4.Right, label4.Top + label4.Height / 2);
            end[2]   = new Point(textBox3.Left, textBox3.Top + textBox3.Height / 2);
            
            start[3] = new Point(label4.Right, label4.Bottom);
            end[3]   = new Point(textBox6.Left, textBox6.Top);

            start[4] = new Point(label4.Left + label4.Width / 2, label4.Bottom);
            end[4]   = new Point(textBox5.Left + textBox5.Width / 2, textBox5.Top);

            start[5] = new Point(label3.Left + label3.Width / 2, label3.Bottom);
            end[5]   = new Point(textBox4.Left + textBox4.Width / 2, textBox4.Top);

            for(int i = 0; i < start.Length; i++)
            {
                g.DrawLine(p, start[i], end[i]);
            }
        }
    }
}
