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

namespace Base
{
    public partial class Form1 : Form
    {
        public string[] input = {
            "File.ReadAllText",
            "File.ReadAllLines",
            "File.ReadAllBytes",
            "SttreamReader (ReadLine())",
            "Image.FormFlie(Path)",
            "OpenFileDialog"
        };
        
        public string[] output ={
            "File.WriteAllText",
            "File.AppendAllText",
            "File.WriteAllBytes",
            "SttreamWrite (WriteLine())",
            "Image.Save(Path, ImageFormat)",
            "SaveFileDialog"
        };

        public Form1()
        {
            InitializeComponent();
        }

        public void base_tostring(string input)
        {
            double a = 1234.56789;
            double p = 0.1234;
            int n = 255;
            DateTime now = DateTime.Now;
            
            if (comboBox1.SelectedIndex <= 3)
            {
                textBox1.Text = a.ToString(input) + $"\t value={a.ToString()}";
            }
            else if (comboBox1.SelectedIndex <= 4)
            {
                textBox1.Text = p.ToString(input) + $"\t value={p.ToString()}";
            }
            else if (comboBox1.SelectedIndex <= 6)
            {
                textBox1.Text = n.ToString(input) + $"\t value={n.ToString()}";
            }else if (comboBox1.SelectedIndex <= comboBox1.Items.Count - 1)
            {
                textBox1.Text = now.ToString(input) + $"\t value=TimeNow";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            base_tostring(comboBox1.Text);
        }

        public void base_linq(string input)
        {
            Random rand = new Random();
            var num = Enumerable.Range(0, 10)
                .ToArray();

            var randNum = Enumerable.Range(0,10)
                .Select(x => (int)rand.Next(10))
                .ToArray();

            var groups = num.GroupBy(n => n % 2 == 0 ? "偶數" : "奇數");

            switch (input)
            {
                case "Where":
                    textBox2.Text = "Value=" + string.Join(", ", num) + "\r\nx => x % 2 == 0\r\n";
                    textBox2.Text += $"Value.{input} = \r\n";
                    textBox2.Text += string.Join(", ", num.Where(x => x % 2 == 0)); break;
                case "Select":
                    textBox2.Text = "Value=" + string.Join(", ", num) + "\r\nx => x * x\r\n";
                    textBox2.Text += $"Value.{input} = \r\n";
                    textBox2.Text += string.Join(", ", num.Select(x => x * x)); break;
                case "OrderBy":
                    textBox2.Text = "Value=" + string.Join(", ", randNum) + "\r\nx => x\r\n";
                    textBox2.Text += $"Value.{input} = \r\n";
                    textBox2.Text += string.Join(", ", randNum.OrderBy(x => x)); break;
                case "OrderByDescending":
                    textBox2.Text = "Value=" + string.Join(", ", randNum) + "\r\nx => x\r\n";
                    textBox2.Text += $"Value.{input} = \r\n";
                    textBox2.Text += string.Join(", ", randNum.OrderByDescending(x => x)); break;
                case "Count":
                    textBox2.Text = "Value=" + string.Join(", ", num) + "\r\n";
                    textBox2.Text += $"Value.{input} = \r\n";
                    textBox2.Text += num.Count().ToString(); break;
                case "Sum":
                    textBox2.Text = "Value=" + string.Join(", ", num) + "\r\n";
                    textBox2.Text += $"Value.{input} = \r\n";
                    textBox2.Text += num.Sum().ToString(); break;
                case "Average":
                    textBox2.Text = "Value=" + string.Join(", ", num) + "\r\n";
                    textBox2.Text += $"Value.{input} = \r\n";
                    textBox2.Text += num.Average().ToString(); break;
                case "Max":
                    textBox2.Text = "Value=" + string.Join(", ", num) + "\r\n";
                    textBox2.Text += $"Value.{input} = \r\n";
                    textBox2.Text += num.Max().ToString(); break;
                case "Min":
                    textBox2.Text = "Value=" + string.Join(", ", num) + "\r\n";
                    textBox2.Text += $"Value.{input} = \r\n";
                    textBox2.Text += num.Min().ToString(); break;
                case "Any":
                    textBox2.Text = "Value=" + string.Join(", ", num) + "\r\nx => x % 2 == 0\r\n";
                    textBox2.Text += $"Value.{input} = \r\n";
                    textBox2.Text += num.Any(x => x % 2 == 0).ToString(); break;
                case "All":
                    textBox2.Text = "Value=" + string.Join(", ", num) + "\r\nx => x % 2 == 0\r\n";
                    textBox2.Text += $"Value.{input} = \r\n";
                    textBox2.Text += num.All(x => x % 2 == 0).ToString(); break;
                case "Contains":
                    textBox2.Text = "Value=" + string.Join(", ", num) + "\r\n5\r\n";
                    textBox2.Text += $"Value.{input} = \r\n";
                    textBox2.Text += num.Contains(5).ToString(); break;
                case "First":
                    textBox2.Text = "Value=" + string.Join(", ", num) + "\r\nx => x > 4\r\n";
                    textBox2.Text += $"Value.{input} = \r\n";
                    textBox2.Text += num.First(x => x > 4).ToString(); break;
                case "FirstOrDefault":
                    textBox2.Text = "Value=" + string.Join(", ", num) + "\r\nx => x > 4\r\n";
                    foreach(var g in groups)
                    {
                        textBox2.Text += $"[{g.Key}] : {string.Join(", ", g)}\r\n\r\n";
                    }
                    break;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            base_linq(comboBox2.Text);
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;

            if (cb.SelectedIndex == 0)
            {
                comboBox4.Items.Clear();
                comboBox4.Items.AddRange(input);
            }
            else if (cb.SelectedIndex == 1)
            {
                comboBox4.Items.Clear();
                comboBox4.Items.AddRange(input);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "(txt) |.txt";

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = ofd.Filter;

            string path = textBox3.Text == string.Empty ? @".\output.txt" : textBox3.Text;
            string text = textBox4.Text == string.Empty ? "Example" : textBox4.Text;

            if (comboBox3.Text == "input")
            {
                switch (comboBox4.Text)
                {
                    case "File.ReadAllText":
                        textBox4.Text = File.ReadAllText(ofd.FileName); break;
                    case "File.ReadAllLines":
                        string[] getin = File.ReadAllLines(ofd.FileName);
                        textBox4.Text = string.Join(",", getin);
                        break;
                    case "File.ReadAllBytes":
                        byte[] b = File.ReadAllBytes(ofd.FileName);
                        textBox4.Text = string.Join(",", b);
                        break;
                    case "StreamReader (ReadLine())":
                        using (StreamReader sr = new StreamReader(path))
                        {
                            textBox4.Text = sr.ReadLine();
                        }
                        break;
                    case "Image.FormFlie(Path)":
                        Image img = Image.FromFile(ofd.FileName);
                        pictureBox1.Image = img;
                        break;
                    case "OpenFileDialog":
                        if (ofd.ShowDialog() == DialogResult.OK)
                        {
                            StreamReader sr = new StreamReader(ofd.FileName);
                            textBox4.Text = sr.ReadToEnd();
                        }
                        break;
                }
            }
        }
    }
}
