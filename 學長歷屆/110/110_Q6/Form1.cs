using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace _110_Q6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Queue<Car> cars = new Queue<Car>(textBox1.Text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).Select(x => new Car
            {
                start = int.Parse(x.Split(' ')[0]),
                end = int.Parse(x.Split(' ')[1])
            }).OrderBy(x => x.start));

            int success = 0, time = 1;

            Stack<Car> parking = new Stack<Car>();

            while(cars.Any())
            {
                while (parking.Any() && parking.Peek().end == time)
                    parking.Pop();

                while (true)
                {
                    if(cars.Any() && cars.Peek().start == time)
                    {
                        var car = cars.Dequeue();

                        if(!parking.Any() || parking.Peek().end >= car.end)
                        {
                            parking.Push(car);
                            success++;
                            continue;
                        }
                    }

                    break;
                }

                time++;
            }

            textBox2.Text = success.ToString();
        }
    }

    class Car
    {
        public int start;
        public int end;
    }
}
