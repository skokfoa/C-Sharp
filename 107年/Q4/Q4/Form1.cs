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
            textBox1.Text = "麵[1]:" + $"{3.00,6:F2} {4.00,6:F2} {6.00,6:F2} {5.00,6:F2}" +
                "麵[2]:" + $"{8.00,6:F2} {12.00,6:F2} {9.00,6:F2} {11.00,6:F2} {10.00,6:F2} {8.00,6:F2}" +
                "麵[3]:" + $"{13.00,6:F2} {9.00,6:F2} {11.00,6:F2} {8.00,6:F2} {12.00,6:F2}";
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
                noodle[i] = input[i].Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select((x,j) => j != 0? double.Parse(x): 0 ).ToArray();
            }
        }
    }
}
