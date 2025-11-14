using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int n = 10;

        Console.WriteLine("價格系列：");
        var input = Console.ReadLine()
            .Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

        int date = input.Length;

        if (date < n)
        {
            Console.WriteLine("資料筆數要 >= 10");
            return;
        }

        int[] x = Enumerable.Range(1, date).ToArray();

        double[] price = input.Select(double.Parse).ToArray();

        double[] slope = new double[date];
        double[] predict = new double[date];

        for (int i = 0; i <= date - n - 1; i++)
        {
            double xBar = (n + 1) / 2.0;
            double yBar = 0.0;

            for (int k = 0; k < n; k++)
            {
                yBar += price[i + k];
            }
            yBar /= n;

            double num = 0.0;
            double den = 0.0;

            for (int k = 0; k < n; k++)
            {
                double xk = k + 1;
                double yk = price[i + k];

                num += (xk - xBar) * (yk - yBar);
                den += (xk - xBar) * (xk - xBar);
            }

            double b = num / den;
            double a = yBar - b * xBar;

            int lastDayIndex = i + n - 1;
            int predictIndex = i + n;

            slope[lastDayIndex] = b;

            double yNext = a + b * (n + 1);
            predict[predictIndex] = yNext;
        }

        Console.WriteLine("直線斜率 b：");
        Console.WriteLine(string.Join(" ",
            slope.Select(v => $"{v,5:F1}")));

        Console.WriteLine("價格預測：");
        Console.WriteLine(string.Join(" ",
            predict.Select(v => $"{v,5:F1}")));
    }
}
