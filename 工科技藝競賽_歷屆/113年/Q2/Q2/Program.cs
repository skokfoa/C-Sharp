using System;

class Program
{
    static void Main()
    {
        int W = 50;
        int n = 3;
        int[] w = { 0, 20, 10, 30 };
        int[] v = { 0, 100, 60, 120 };
        int[,] c = new int[n + 1, W + 1];

        for (int i = 1; i <= n; i++)
        {
            for (int weight = 0; weight <= W; weight += 10)
            {
                if (w[i] > weight)
                    c[i, weight] = c[i - 1, weight];
                else
                    c[i, weight] = Math.Max(v[i] + c[i - 1, weight - w[i]], c[i - 1, weight]);
            }
        }

        // 印出結果表
        for (int i = 0; i <= n; i++)
        {
            for (int weight = 0; weight <= W; weight += 10)
                Console.Write($"{c[i, weight],4}");
            Console.WriteLine();
        }

        Console.WriteLine($"\n最大價值 = {c[n, W]}");
    }
}
