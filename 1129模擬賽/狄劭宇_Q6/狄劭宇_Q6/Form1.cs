using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 狄劭宇_Q6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader(@"C:\Users\宇\Desktop\狄劭宇_Contest\狄劭宇_Q6\" + textBox1.Text);
            string[] line = sr.ReadToEnd()
                .Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

            double[] highest = line[1]
                .Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Skip(1)
                .Select(double.Parse)
                .ToArray();

            double[] lowwest = line[2]
                .Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Skip(1)
                .Select(double.Parse)
                .ToArray();

            double[] price = line[3]
                .Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Skip(1)
                .Select(double.Parse)
                .ToArray();

            int n = 9;

            double k8 = double.Parse(textBox3.Text);
            double d8 = double.Parse(textBox4.Text);

            double[] k = new double[12];
            double[] d = new double[12];

            k[7] = k8;
            d[7] = d8;

            for(int i = 8; i < 12; i++)
            {
                double rsv = new double();

                double max = highest
                    .Skip(i - 8)
                    .Take(n)
                    .Max();

                double min = lowwest
                    .Skip(i - 8)
                    .Take(n)
                    .Min();

                rsv = ((price[i] - min) / (max - min)) * 100;
                k[i] = 2 * k[i - 1] / 3 + rsv / 3;
                d[i] = 2 * d[i - 1] / 3 + k[i] / 3;
            }

            string output = line[0] + "\r\n" +
                "K 值    " + string.Join("", k.Select(x => $"{x,-7:F2}")) + "\r\n" +
                "D 值    " + string.Join("", d.Select(x => $"{x,-7:F2}")) + "\r\n";

            string outputPath = @"C:\Users\宇\Desktop\狄劭宇_Contest\狄劭宇_Q6\" + textBox2.Text;

            using (StreamWriter sw = new StreamWriter(outputPath))
            {
                sw.WriteLine(output);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
