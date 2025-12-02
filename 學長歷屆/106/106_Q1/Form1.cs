using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace _106_Q1
{
    public partial class Form1 : Form
    {
        readonly Random random = new Random();

        List<double> mse = new List<double>();

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label3.Text = string.Join(" ", Enumerable.Range(1, int.Parse(textBox1.Text)));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label3.Text = string.Join(" ", Enumerable.Range(1, int.Parse(textBox1.Text)));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox3.Text = string.Join(" ", Enumerable.Range(1, int.Parse(textBox1.Text)).Select(_ => random.Next(0, 101)));
            textBox4.Text = string.Join(" ", Enumerable.Range(1, int.Parse(textBox1.Text)).Select(_ => random.Next(0, 101)));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int amount = int.Parse(textBox1.Text), times = int.Parse(textBox2.Text), k = int.Parse(textBox6.Text), count = 0;

            List<Score> scores = new List<Score>();

            int[] math = textBox3.Text.Trim().Split(' ').Where(x => int.TryParse(x, out _)).Select(int.Parse).ToArray();
            int[] english = textBox4.Text.Trim().Split(' ').Where(x => int.TryParse(x, out _)).Select(int.Parse).ToArray();

            for (int i = 0; i < amount; i++)
                scores.Add(new Score
                {
                    math = math[i],
                    english = english[i]
                }); ;

            mse.Clear();

            Stack[] stacks = new Stack[k];

            List<Score> exists = new List<Score>();

            for (int i = 0; i < k; i++)
            {
                Score item;

                do {
                    item = scores[random.Next(0, scores.Count())];
                } while (exists.Contains(item));

                exists.Add(item);

                stacks[i] = new Stack
                {
                    center = new Center
                    {
                        math = item.math,
                        english = item.english
                    }
                };
                item.stack = stacks[i];
            }

            foreach(var item in scores)
            {
                if (exists.Contains(item))
                    continue;

                stacks[0].scores.Add(item);
                item.stack = stacks[0];
            }

            while(count < times)
            {
                foreach(var score in scores)
                {
                    double distance = double.MaxValue;
                    Stack closest = stacks[0];

                    for (int j = 0; j < stacks.Length; j++)
                    {
                        double _distance = Math.Sqrt(Math.Pow(score.math - stacks[j].center.math, 2) + Math.Pow(score.english - stacks[j].center.english, 2));

                        if (_distance < distance)
                        {
                            distance = _distance;
                            closest = stacks[j];
                        }
                    }

                    if(closest != score.stack)
                    {
                        score.stack.scores.Remove(score);
                        closest.scores.Add(score);
                        score.stack = closest;
                    }
                }

                for (int i = 0; i < stacks.Length; i++)
                {
                    stacks[i].center.math = stacks[i].scores.Average(x => x.math);
                    stacks[i].center.english = stacks[i].scores.Average(x => x.english);
                }

                double total = 0;

                for (int i = 0; i < stacks.Length; i++)
                {
                    for (int j = 0; j < stacks[i].scores.Count(); j++)
                    {
                        total += Math.Pow(stacks[i].scores[j].math - stacks[i].center.math, 2) +
                            Math.Pow(stacks[i].scores[j].english - stacks[i].center.english, 2);
                    }
                }

                mse.Add(total / amount);

                count++;
            }

            textBox5.Text = string.Join(" ", scores.Select(x => Array.IndexOf(stacks, x.stack) + 1));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var chart = chart1.Series[0];

            chart.Points.Clear();

            int times = int.Parse(textBox2.Text);

            for(int i = 0; i < times; i++)
                chart.Points.AddXY(i, mse[i]);
        }
    }
    
    class Stack
    {
        public Center center;
        public List<Score> scores = new List<Score>();
    }

    class Center
    {
        public double math;
        public double english;
    }

    class Score
    {
        public double math;
        public double english;
        public Stack stack;
    }
}
