using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2
{
    public partial class Form1 : Form
    {
        bool input = true;
        int i = 0;
        private int point = new int();
        double[,] a;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e){}

        private void textBox2_TextChanged(object sender, EventArgs e){}

        private void button2_Click(object sender, EventArgs e)
        {
            if(input)
            {
                point = int.Parse(textBox1.Text);
                label2.Visible = true;
                textBox2.Visible = true;
                textBox1.ReadOnly = true;
                label4.Text = $"資料總點數 : {point}\r\n";
                a = new double[point, 2];
                input = false;

            }
            else if(i < point)
            {
                
                string[] input = textBox2.Text.Split(',');
                a[i, 0] = double.Parse(input[0]);
                a[i, 1] = double.Parse(input[1]);
                label4.Text += $"第{i + 1}點的座標 : ({a[i, 0]},{a[i, 1]})\r\n";
                textBox2.Text = "";
                ++i;
            }
            else
            {
                return;
            }
            label2.Text = $"請輸入第{i + 1}點座標 : (x,y)";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double sum_x = new double();
            double sum_y = new double();
            double sum_xy = new double();
            double avg_x = new double();
            double avg_y = new double();
            double squr_x = new double();
            double m = new double();
            double b = new double();

            for(int j = 0;j < point;j++)
            {
                sum_x += a[j, 0];
                sum_y += a[j, 1];
                sum_xy += (a[j, 0] * a[j, 1]);
                squr_x += (a[j, 0] * a[j, 0]);
            }

            avg_x = sum_x / point;
            avg_y = sum_y / point;

            m = (sum_xy - (sum_x * avg_y)) / (squr_x - (sum_x * avg_x));
            b = avg_y - m * avg_x;

            label4.Text += $"最小平方直線迴歸係數 : \r\n";
            label4.Text += $"斜率 : {m}\r\n";
            label4.Text += $"截距 : {b}\r\n";

            chart1.Series.Clear();

            // 資料點
            var seriesPoints = chart1.Series.Add("資料點");
            seriesPoints.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;

            for (int j = 0; j < point; j++)
            {
                var x = a[j, 0];
                var y = a[j, 1];
                seriesPoints.Points.AddXY(x, y);
            }

            // 計算資料範圍
            double minX = a.Cast<double>().Where((_, index) => index % 2 == 0).Min();
            double maxX = a.Cast<double>().Where((_, index) => index % 2 == 0).Max();
            double minY = a.Cast<double>().Where((_, index) => index % 2 == 1).Min();
            double maxY = a.Cast<double>().Where((_, index) => index % 2 == 1).Max();
            double marginX = (maxX - minX) * 0.1;
            double marginY = (maxY - minY) * 0.1;

            double chartMinX = Math.Floor(Math.Min(0, minX - marginX));
            double chartMaxX = Math.Ceiling(Math.Max(0, maxX + marginX));
            double chartMinY = Math.Floor(Math.Min(0, minY - marginY));
            double chartMaxY = Math.Ceiling(Math.Max(0, maxY + marginY));

            // 設定 X 軸
            var axisX = chart1.ChartAreas[0].AxisX;
            axisX.Minimum = chartMinX;
            axisX.Maximum = chartMaxX;
            axisX.Interval = 1;
            axisX.IsLabelAutoFit = false;
            axisX.MajorGrid.LineColor = Color.LightGray;

            // 設定 Y 軸
            var axisY = chart1.ChartAreas[0].AxisY;
            axisY.Minimum = chartMinY;
            axisY.Maximum = chartMaxY;
            axisY.Interval = 1;
            axisY.IsLabelAutoFit = false;
            axisY.MajorGrid.LineColor = Color.LightGray;

            // 回歸線
            var seriesLine = chart1.Series.Add("回歸線");
            seriesLine.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            seriesLine.Color = Color.Red;
            seriesLine.BorderWidth = 2;

            seriesLine.Points.AddXY(chartMinX, m * chartMinX + b);
            seriesLine.Points.AddXY(chartMaxX, m * chartMaxX + b);
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
