using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace Q4
{
    public partial class Form1 : Form
    {
        public static double[] W = new double[3];
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "1\t0\t1\t-1\r\n" +
                "0\t-1\t-1\t1\r\n" +
                "-1\t-0.5\t-1\t1";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] input = textBox1.Text
                .Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            List<(double[], int)> num = new List<(double[], int)>();

            foreach (string s in input)
            {
                var line = s.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                double[] x = new double[3];
                int y = 0;

                for(int i = 0; i < 3; i++)
                {
                    x[i] = double.Parse(line[i]);
                }

                y = int.Parse(line[line.Length - 1]);

                num.Add((x, y));
            }//input

            W = textBox4.Text
                .Split(new char[] { ' ', '\t' , ',' , ';' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse).ToArray();

            int count = int.Parse(textBox2.Text);
            double n = double.Parse(textBox3.Text);
            double E = double.MaxValue;


            while (E > 0 && count-- > 0)
            {
                E = 0;

                foreach ((double[] x, int y) in num)
                {
                    E += train(x, y, n);
                }
            }

            label9.Text = string.Join("; ", W);
        }

        private double train(double[] x, int y, double eta)
        {
            double f = inner(W, x);

            int o = sign(f);

            if (y == o)
            {
                return 0;
            }

            for (int i = 0; i < 3; i++)
            {
                W[i] = W[i] + eta * (y - o) * x[i];
            }

            double e = 0.5 * Math.Pow(y - o, 2);
            return e;
        }


        private int sign(double f) => f < 0 ? -1 : 1;

        private double inner(double[] a, double[] b)
        {
            double[] result = new double[3];
            for(int i = 0; i < result.Length; i++)
            {
                result[i] = a[i] * b[i];
            }

            return result.Sum();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double[] x = textBox5.Text
                .Split(new char[] { ' ', ',', ';', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            double f = inner(W, x);

            int o = sign(f);
            string result = f < 0 ? "右" : "左";

            label11.Text += $"{o}({result})";
        }
    }
}
