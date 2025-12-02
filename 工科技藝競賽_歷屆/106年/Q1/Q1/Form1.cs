using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Q1
{
    public partial class Form1 : Form
    {
        public static List<double> MSE = new List<double>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;

            Random rand = new Random();
            int n = int.Parse(textBox1.Text);

            label6.Text = string.Join(" ",Enumerable.Range(1, n).Select(x => x.ToString().PadLeft(2)));

            for(int i = 0; i < n; i++)
            {
                textBox3.Text += rand.Next(101).ToString().PadLeft(2) + " ";
                textBox4.Text += rand.Next(101).ToString().PadLeft(2) + " ";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random rand = new Random();

            int n = int.Parse(textBox1.Text);

            int[] math = textBox3.Text.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                             .Select(int.Parse).ToArray();
            int[] english = textBox4.Text.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                             .Select(int.Parse).ToArray();

            int k = 2;
            int q = int.Parse(textBox2.Text);

            HashSet<int> key = new HashSet<int>();
            while (key.Count != k)
                key.Add(rand.Next(n));

            double[] uM = new double[k];
            double[] uE = new double[k];
            int c = 0;
            foreach (int i in key)
            {
                uM[c] = math[i];
                uE[c] = english[i];
                c++;
            }

            MSE = new List<double>();
            List<int>[] values = { new List<int>(), new List<int>() };

            for (int p = 0; p < q; p++)
            {
                values = new List<int>[] { new List<int>(), new List<int>() };

                // 分群
                for (int i = 0; i < n; i++)
                {
                    double d1 = Math.Sqrt((math[i] - uM[0]) * (math[i] - uM[0]) +
                                          (english[i] - uE[0]) * (english[i] - uE[0]));
                    double d2 = Math.Sqrt((math[i] - uM[1]) * (math[i] - uM[1]) +
                                          (english[i] - uE[1]) * (english[i] - uE[1]));

                    int grp = d1 < d2 ? 0 : 1;
                    values[grp].Add(i);
                }

                // 更新中心（防空集合）
                for (int g = 0; g < k; g++)
                {
                    if (values[g].Count > 0)
                    {
                        uM[g] = values[g].Average(i => math[i]);
                        uE[g] = values[g].Average(i => english[i]);
                    }
                    // 否則保留原中心不動
                }

                // 計算 MSE（修正 dy）
                double mse = 0.0;
                for (int i = 0; i < k; i++)
                {
                    foreach (int j in values[i])
                    {
                        double dx = math[j] - uM[i];
                        double dy = english[j] - uE[i];  // ← 修正這行
                        mse += dx * dx + dy * dy;
                    }
                }
                mse /= n;   // 以總樣本數做平均
                MSE.Add(mse);
            }

            // 輸出分群結果
            var sb = new StringBuilder();
            for (int i = 0; i < n; i++)
                sb.Append(values[0].Contains(i) ? "1  " : "2  ");
            textBox5.Text = sb.ToString();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (MSE == null || MSE.Count == 0)
            {
                MessageBox.Show("請先執行分群（按下按鈕2）以產生 MSE。");
                return;
            }

            int q = int.Parse(textBox2.Text);

            // 清空並重建 ChartArea
            chart1.Series["Series1"].Points.Clear();
            chart1.ChartAreas.Clear();

            var area = new ChartArea("main");
            chart1.ChartAreas.Add(area);

            // 綁定 Series 到新的 ChartArea，並選擇折線圖
            var s = chart1.Series["Series1"];
            s.ChartArea = "main";
            s.ChartType = SeriesChartType.Line;

            // 設定座標軸（X: 0..q-1, Y: 給一點 padding）
            double ymin = MSE.Min();
            double ymax = MSE.Max();
            double pad = (ymax - ymin) * 0.1;
            if (pad == 0) pad = Math.Max(1e-6, Math.Abs(ymax) * 0.1); // 防所有值相同

            area.AxisX.Minimum = 0;
            area.AxisX.Maximum = (int)Math.Max(0, q - 1);
            area.AxisY.Minimum = (int)(ymin - pad);
            area.AxisY.Maximum = (int)(ymax + pad);

            area.AxisX.Title = "疊代次數";
            area.AxisY.Title = "MSE";

            // 加點
            for (int i = 0; i < Math.Min(q, MSE.Count); i++)
                s.Points.AddXY(i, MSE[i]);
        }

    }
}
