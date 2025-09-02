using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            OpenFileDialog openFileDialog = new OpenFileDialog();
            StreamReader reader;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                reader = new StreamReader(openFileDialog.FileName);
            }
            else
            {
                MessageBox.Show("尚未選擇檔案。");
                return;
            }

            // 讀取所有行
            string[] input = reader.ReadToEnd().Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            reader.Close();

            // 第一行是筆數與欄位數，不列入顯示
            for (int i = 1; i < input.Length; i++)
            {
                string[] line = input[i].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                if (line.Length >= 2)
                {
                    double weight = double.Parse(line[0]);
                    double height = double.Parse(line[1]);

                    textBox1.Text += $"{i - 1,2}\t {weight,3}\t   {height,3}\r\n";
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<double> first = new List<double>();
            List<double> second = new List<double>();
            List<double> third = new List<double>();

            string[] input = textBox1.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            double[,] calculate = new double[input.Length,2];
            double[] avrg = new double[2];
            double[] sigma = new double[2];
            for (int i = 0; i < input.Length; i++)
            {
                string[] line = input[i].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                calculate[i,0] = double.Parse(line[1]);
                calculate[i,1] = double.Parse(line[2]);
                avrg[0] += calculate[i, 0];
                avrg[1] += calculate[i, 1];
            }
            avrg[0] /= input.Length;
            avrg[1] /= input.Length;
            for(int i = 0; i < input.Length; i++)
            {
                sigma[0] += (calculate[i, 0] - avrg[0]) * (calculate[i, 0] - avrg[0]);
                sigma[1] += (calculate[i, 1] - avrg[1]) * (calculate[i, 1] - avrg[1]);
            }
            sigma[0] /= input.Length;
            sigma[1] /= input.Length;

            for(int i = 0; i < input.Length; i++)
            {
                calculate[i,0] = (calculate[i, 0] - avrg[0])/ sigma[0];
            }

            for (int i = 0; i < 200; i++)
            {
                calculate[i, 1] = (calculate[i, 1] - avrg[1]) / sigma[1];
            }
        }
    }
}
