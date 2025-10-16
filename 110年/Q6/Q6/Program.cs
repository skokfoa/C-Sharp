using System;

public class Program
{
    public static void Main()
    {
        int count = 0;
        string input = string.Empty;
        List<(int In,int Out)> num = new List<(int,int)>();


        while(!string.IsNullOrEmpty(input = Console.ReadLine()))
        {
            var a = input.Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            num.Add((a[0], a[1]));
        }

        Stack<(int In,int Out)> car = new Stack<(int,int)>();
        while (num.Count > 0)
        {
            if (car.Count == 0)
            {
                car.Push(num[0]);
                num.RemoveAt(0);
                count++;
            }
            else
            {
                if (num[0].In < car.Peek().Out)
                {
                    if(num[0].In > car.Peek().In && num[0].Out < car.Peek().Out)
                    {
                        car.Push(num[0]);
                        num.RemoveAt(0);
                        count++;
                    }
                    else
                    {
                        num.RemoveAt(0);
                    }
                }
                else
                {
                    car.Pop();
                    continue;
                }
            }
        }

        Console.WriteLine(count);

    }
}