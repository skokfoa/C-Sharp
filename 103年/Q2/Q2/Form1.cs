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
    }
}
