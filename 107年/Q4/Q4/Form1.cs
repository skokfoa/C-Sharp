using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void 選取資料ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text = "麵[1]:" + $"{3.00,6:F2} {4.00,6:F2} {6.00,6:F2} {5.00,6:F2}\r\n" +
                "麵[2]:" + $"{8.00,6:F2} {12.00,6:F2} {9.00,6:F2} {11.00,6:F2} {10.00,6:F2} {8.00,6:F2}\r\n" +
                "麵[3]:" + $"{13.00,6:F2} {9.00,6:F2} {11.00,6:F2} {8.00,6:F2} {12.00,6:F2}\r\n";
        }

        private void 結束ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 求F統計值和自由度ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] input = textBox1.Text
                .Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            double[][] noodle = new double[input.Length][];

            for(int i = 0; i < input.Length; i++)
            {
                noodle[i] = input[i]
                    .Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                    .Skip(1)
                    .Select(double.Parse)
                    .ToArray();
            }

            double F = new double();
            
            double Msb = new double();
            double Msw = new double();

            double Ssb = new double();
            double Ssw = new double();
            
            double dfb = new double();
            double dfw = new double();

            double[] uti = new double[noodle.Length];
            double UT = new double();


            for(int i = 0; i < noodle.Length; i++)
            {
                uti[i] = noodle[i].Sum() / noodle[i].Length;
                UT += noodle[i].Sum();
            }
            UT = UT / noodle.Sum(x => x.Length);

            Ssb = noodle.Select((x, i) => x.Length * (uti[i] - UT) * (uti[i] - UT)).Sum();
            Ssw = noodle.Select((x, i) => x.Select(y => (y - uti[i]) * (y - uti[i])).Sum()).Sum();

            dfb = 2;
            dfw = noodle.Sum(x => x.Length) - noodle.Length;

            Msb = Ssb / dfb;
            Msw = Ssw / dfw;

            F = Msb / Msw;

            textBox2.Text = "F統計值計算:\r\n" +
                $"F = {F:F3}\r\n" +
                $"自由度df:{dfb},{dfw}";
        }
    }
}
