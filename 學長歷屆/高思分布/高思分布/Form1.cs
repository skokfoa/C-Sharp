using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace 高思分布
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int min = int.Parse(textBox1.Text),
                max = int.Parse(textBox2.Text),
                average = int.Parse(textBox3.Text);

            double diffrent = double.Parse(textBox4.Text);

            ChartArea chart = chart1.ChartAreas[0];

            chart.AxisX.Minimum = min;
            chart.AxisX.Maximum = max;
            chart.AxisY.Minimum = -0.1;
            chart.AxisY.Maximum = 1;

            Series series = chart1.Series["機率密度函數"];

            for(double i = min; i <= max; i += 0.1)
            {
                double result = (1 / Math.Sqrt(2 * Math.PI * diffrent))
                    * Math.Exp(Math.Pow(i - average, 2) * -1 / (2 * diffrent));

                series.Points.AddXY(i, result);
            }
        }
    }
}
