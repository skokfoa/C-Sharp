using System;
using System.Numerics;

class Project
{
    static void Main(string[] args)
    {
        List<BigInteger> a = new List<BigInteger>();

        a.Add(0); a.Add(1);

        BigInteger next = new BigInteger();
        for(int i = 0; i < 90; i++)
        {
            next = a[i] + a[i + 1];
            a.Add(next);
        }

        for(int i = 0;i < a.Count; i++)
        {
            Console.WriteLine($"{i + 1} {a[i]}");
        }

        BigInteger first, second;
        Console.Write("\n請從費氏數列 (Fibonacci Sequence) 中選擇第1個數:");
        string input = Console.ReadLine();
        first = a[int.Parse(input) - 1];
        Console.Write($"您選擇的第 {input} 數字為:{first}");

        Console.Write("\n請從費氏數列 (Fibonacci Sequence) 中選擇第2個數:");
        input = Console.ReadLine();
        second = a[int.Parse(input) - 1];
        Console.Write($"您選擇的第 {input} 數字為:{second}\n");

        first = first + second;

        Console.Write("兩個費氏數列 (Fibonacci Sequence) 相加的結果為:" + first);

    }
}