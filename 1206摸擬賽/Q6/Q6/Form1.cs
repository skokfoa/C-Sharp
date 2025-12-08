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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double r, g, b;
            double h, s, i;
            double rgb;

            r = double.Parse(textBox1.Text);
            g = double.Parse(textBox2.Text);
            b = double.Parse(textBox3.Text);

            i = (r + g + b) / (3 * 255);
            
            rgb = r + g + b;

            r = r / rgb;
            g = g / rgb;
            b = b / rgb;

            
            
            h = (0.5 * ((r - g) + (r - b))) / pow((pow(r - g, 2) + (r - b) * (g - b)), 0.5);
            h = Math.Acos(h);

            if (b > g) h = 2 * Math.PI - h;

            s = 1 - 3 * Math.Min(r, Math.Min(g, b));


            h = h * 180 / Math.PI;
            s = s * 255;
            i = i * 255;

            textBox4.Text = h.ToString();
            textBox5.Text = s.ToString();
            textBox6.Text = i.ToString();
        }

        private double pow(double x,double y) => Math.Pow(x,y);

        private void button2_Click(object sender, EventArgs e)
        {
            double h, s, i;
            double r, g, b;

            h = double.Parse(textBox4.Text);
            s = double.Parse(textBox5.Text);
            i = double.Parse(textBox6.Text);

            h = h * Math.PI / 180;
            s = s / 255;
            i = i / 255;

            double x, y, z;

            x = i * (1.0 - s);
            

            if (h < 2 * Math.PI / 3)
            {
                y = i * (1.0 + (s * Math.Cos(h)) / Math.Cos(Math.PI / 3.0 - h));
                z = 3 * i - (x + y);
                z = Math.Round(z, 2);
                r = y;
                g = z;
                b = x;
            }
            else if (h < 4 * Math.PI / 3)
            {
                h = h - 2 * Math.PI / 3;
                y = i * (1.0 + (s * Math.Cos(h)) / Math.Cos(Math.PI / 3.0 - h));
                z = 3 * i - (x + y);
                z = Math.Round(z, 2);
                r = x;
                g = y;
                b = z;
            }
            else
            {
                h = h - 4 * Math.PI / 3;
                y = i * (1.0 + (s * Math.Cos(h)) / Math.Cos(Math.PI / 3.0 - h));
                z = 3 * i - (x + y);
                z = Math.Round(z, 2);
                r = z;
                g = x;
                b = y;
            }

            r = r * 255;
            g = g * 255;
            b = b * 255;

            textBox1.Text = r.ToString();
            textBox2.Text = g.ToString();
            textBox3.Text = b.ToString();
        }
    }
}
