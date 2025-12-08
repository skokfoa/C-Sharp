using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q1
{
    public partial class Form1 : Form
    {
        public List<fruit> fruits = new List<fruit>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] line;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.Filter = "txt |*.txt";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(ofd.FileName);
                line = sr.ReadToEnd()
                    .Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            }
            else return;

            foreach (string s in line)
            {
                fruit f = null;
                string[] input = s
                    .Split(new string[] { " ", "\t", ",", "、" }, StringSplitOptions.RemoveEmptyEntries);

                string name = input[0];

                StringBuilder sb = new StringBuilder();
                foreach (char c in input[1])
                {
                    if (char.IsDigit(c))
                    {
                        sb.Append(c);
                    }
                }

                int count = int.Parse(sb.ToString());

                sb.Clear();

                foreach (char c in input[2])
                {
                    if (char.IsDigit(c))
                    {
                        sb.Append(c);
                    }
                }

                int gram = int.Parse(sb.ToString());

                sb.Clear();

                foreach (char c in input[3])
                {
                    if (char.IsDigit(c))
                    {
                        sb.Append(c);
                    }
                }

                int ka = int.Parse(sb.ToString());


                f = new fruit(name, count, gram, ka);

                fruits.Add(f);
            }

            textBox4.Text = string.Join(Environment.NewLine, fruits.Select(x => $"{x.name} {x.count} {x.weight} {x.ka}"));
        }

        public string output_html()
        {
            string input = "<td style=\"background-color:lightgray\">";
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(@"<!DOCTYPE html>");
            sb.AppendLine(@"<html>");
            sb.AppendLine(@"<head><title>顯示特類食材熱量</title>");
            sb.AppendLine(@"<style>img {width:100%;height:auto;}</style>");
            sb.AppendLine(@"</head>");
            sb.AppendLine(@"<body>");
            sb.AppendLine(@"<table cellspacing = 0 border = 9 >");
            sb.AppendLine();
            sb.AppendLine(@"<tr>");
            sb.AppendLine(string.Join("\r\n",
                fruits
                .Select(x => $"{input}{x.name}<br>{x.count}")
                ));
            sb.AppendLine(@"");
            sb.AppendLine(@"");
            sb.AppendLine(@"");
            sb.AppendLine(@"");
            sb.AppendLine(@"");
            sb.AppendLine(@"");
            sb.AppendLine(@"");
            sb.AppendLine(@"");
            sb.AppendLine(@"");
            sb.AppendLine(@"");
            sb.AppendLine(@"");
            sb.AppendLine(@"");
            sb.AppendLine(@"");
            sb.AppendLine(@"");
            sb.AppendLine(@"");
            sb.AppendLine(@"");
            sb.AppendLine(@"");
            sb.AppendLine(@"");
            sb.AppendLine(@"");
            sb.AppendLine(@"");
            sb.AppendLine(@"");
            sb.AppendLine(@"");
            sb.AppendLine(@"");
            sb.AppendLine(@"");
            sb.AppendLine(@"");
            sb.AppendLine(@"");
            sb.AppendLine(@"");
            sb.AppendLine(@"");
            sb.AppendLine(@"");
            sb.AppendLine(@"");
            sb.AppendLine(@"");
        }

    }

    public class fruit
    {
        public string name { get; set; }
        public int count { get; set; }
        public int weight { get; set; }
        public int ka {  get; set; }

        public fruit(string name,  int count, int weight, int ka)
        {
            this.name = name;
            this.count = count;
            this.weight = weight;
            this.ka = ka;
        }
    }
}
