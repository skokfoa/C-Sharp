using System;

class Program
{
    static void Main(string[] args)
    {
        int n = 10;
        Console.WriteLine("日期系列");
        int date = Console.ReadLine()
            .Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
            .Length;

        Console.WriteLine("價格系列::");
        var input = Console.ReadLine()
            .Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

        if (input.Length != date)
        {
            Console.WriteLine("輸入數目不相等");
            return;
        }

        int[] x = Enumerable.Range(0,date).ToArray();

        double[] price = input
            .Select(double.Parse)
            .ToArray();

        double[] b = new double[date];
        double[] a = new double[date];

        for(int i = 0; i < date - n; i++)
        {
            double dx = new double();
            double dy = new double();

            

            for(int j = i; j < i + n; j++)
            {
                dx += x[j];
                dy += price[j];
            }

            dx /= n;
            dy /= n;

            double div = new double();

            for(int j = i; j < i + n; j++)
            {
                b[i] += (x[j] - dx) * (price[j] - dy);
                div += Math.Pow(x[j] - dx, 2);
            }

            b[i + 10] /= div;

            if (i != date - 1)
                a[i + 11] = dy - b[i];
        }

        Console.WriteLine("直線斜率b:");
        Console.WriteLine(string.Join(" ", b.Select(x => $"{x:F2,3}")));

        Console.WriteLine("價格預測:");
        Console.WriteLine(string.Join(" ", a.Select(x => $"{x:F2,3}")));


    }
}