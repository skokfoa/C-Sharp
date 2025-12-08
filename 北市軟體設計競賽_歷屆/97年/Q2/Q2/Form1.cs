using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms.VisualStyles;

namespace Q2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int Rmin = int.Parse(textBox1.Text);
            int Rmax = int.Parse(textBox2.Text);
            int dR = int.Parse(textBox3.Text);

            int Eth = int.Parse(textBox4.Text);
            int Er = int.Parse(textBox5.Text);

            Axis x = chart1.ChartAreas["ChartArea1"].AxisX;
            Axis y = chart1.ChartAreas["ChartArea1"].AxisY;

            chart1.Enabled = true;
            chart1.Visible = true;

            Series s = chart1.Series["Series1"];
            s.Points.Clear();

            s.ChartType = SeriesChartType.Line;

            for(int i = Rmin; i <= Rmax; i += dR)
            {
                double Ir = (double)Eth / (Er + i);
                double p = Ir * Ir * i;
                s.Points.AddXY(i, p);
            }

            x.Interval = 10.0;
            y.Interval = 10.0;
        }
    }
}
