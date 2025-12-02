using System;
using System.Drawing;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Random rand = new Random();
            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            int x1, x2, y1, y2;

            y1 = int.Parse(input[0]);
            y2 = int.Parse(input[1]);

            x1 = int.Parse(input[2]);
            x2 = int.Parse(input[3]);

            if (y1 == y2 && x1 == x2 && x1 == y1 && x1 == 0)
            {
                break;
            }

            Point inside, outside;

            int x, y;
            x = (int)(rand.Next() % (Math.Pow(10, 9) * 2 + 1) - Math.Pow(10, 9));
            y = (int)(rand.Next(y1, y2 + 1));

            inside = new Point(x, y);

            while (true)
            {
                x = (int)(rand.Next() % (Math.Pow(10, 9) * 2 + 1) - Math.Pow(10, 9));
                y = (int)(rand.Next() % (Math.Pow(10, 9) * 2 + 1) - Math.Pow(10, 9));

                if ((x < x1 || x > x2) && (y < y1 || y > y2))
                {
                    outside = new Point(x, y);
                    break;
                }
            }

            Console.WriteLine($"{inside.X} {inside.Y} {outside.X} {outside.Y}");
        }
    }
}