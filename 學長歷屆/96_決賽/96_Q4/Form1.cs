using System;
using System.Windows.Forms;

namespace _96_Q4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int amount = int.Parse(textBox1.Text);
            double sample = double.Parse(textBox2.Text);

            var chart = chart1.Series["傅立葉級數"];

            chart.Points.Clear();

            for(double i = -3; i <= 3; i += sample)
            {
                double result = 0.5;

                for(int k = 1; k <= amount; k += 2)
                    result += (2 / (k * Math.PI)) *
                        Math.Cos(k * Math.PI * i + (Math.Pow(-1, (k - 1) / 2) - 1) * (Math.PI / 2));

                chart.Points.AddXY(i, result);
            }
        }
    }
}
