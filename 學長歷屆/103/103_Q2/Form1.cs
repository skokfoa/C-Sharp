using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace _103_Q2
{
    public partial class Form1 : Form
    {
        List<Person> people = new List<Person>();
        List<Person>[] stacks = new List<Person>[3];

        readonly Random random = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                InitialDirectory = Application.StartupPath
            };

            if(dialog.ShowDialog() == DialogResult.OK)
            {
                int index = 0;

                foreach (var line in File.ReadLines(dialog.FileName).Skip(1))
                {
                    if (line.Trim().Count() == 0)
                        continue;

                    string[] split = line.Split(' ').ToArray();

                    people.Add(new Person
                    {
                        index = index,
                        weight = double.Parse(split[0]),
                        height = double.Parse(split[1])
                    });

                    index++;
                }

                textBox1.Text = string.Join(Environment.NewLine, people);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                stacks[i] = new List<Person>
                {
                    people[i]
                };

                people[i].stack = i;
            }

            for (int i = 3; i < people.Count; i++)
            {
                int position = random.Next(0, 3);

                stacks[position].Add(people[i]);
                people[i].stack = position;
            }

            while(true)
            {
                bool finished = true;

                for(int i = 0; i < stacks.Length; i++)
                {
                    for (int j = 0; j < stacks[i].Count; j++)
                    {
                        // use Point to represent (weight, height)
                        Point[] weights = stacks.Select((x, _i) => new Point
                        {
                            index = _i,
                            distance = 0,
                            weight = x.Average(p => p.weight),
                            height = x.Average(p => p.height)
                        }).ToArray();

                        for (int k = 0; k < weights.Length; k++)
                            weights[k].distance = Math.Sqrt(
                                Math.Pow(stacks[i][j].weight - weights[k].weight, 2) + 
                                Math.Pow(stacks[i][j].height - weights[k].height, 2)
                            );

                        Point closest = weights[0];

                        for (int k = 0; k < weights.Length; k++)
                            if (weights[k].distance < closest.distance)
                                closest = weights[k];

                        if(closest.index != i)
                        {
                            finished = false;

                            Person person = stacks[i][j];

                            stacks[i].RemoveAt(j);
                            stacks[closest.index].Add(person);
                            person.stack = closest.index;

                            break;
                        }
                    }
                }

                if (finished)
                    break;
            }

            textBox2.Text = string.Join(Environment.NewLine, people.Select(p => $"第{p.index}筆屬於第{p.stack}堆"));

            textBox3.Text = string.Join(Environment.NewLine, people.Where(p => p.stack == 0).Select(p => $"{p.index,2}　　{p.weight}　　{p.height}"));
            textBox4.Text = string.Join(Environment.NewLine, people.Where(p => p.stack == 1).Select(p => $"{p.index,2}　　{p.weight}　　{p.height}"));
            textBox5.Text = string.Join(Environment.NewLine, people.Where(p => p.stack == 2).Select(p => $"{p.index,2}　　{p.weight}　　{p.height}"));
        }
    }

    class Point
    {
        public double weight;
        public double height;
        public double distance;
        public int index;
    }

    class Person
    {
        public int stack;
        public int index;
        public double weight;
        public double height;

        public override string ToString()
        {
            return $"{index,2}　　{weight}　　{height}";
        }
    }
}
