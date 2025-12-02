using System;
using System.Numerics;

namespace _110_Q3
{
    internal class Program
    {
        static BigInteger[] results = new BigInteger[92];

        static BigInteger Calculate(int n)
        {
            // CACHING TO BOOST CACLCULATING!!!!
            if (results[n - 1] > 0)
                return results[n - 1];

            if (n <= 2)
                return 1;

            return Calculate(n - 1) + Calculate(n - 2);
        }

        static void Main(string[] args)
        {
            for(int i = 0; i < 92; i++)
            {
                results[i] = Calculate(i + 1);

                Console.WriteLine($"{i + 1} {results[i]}");
            }

            Console.Write("請從費氏數列(Fibonacci Sequence)中選擇第1個數:");

            int first = int.Parse(Console.ReadLine());

            Console.WriteLine($"您選擇第 {first} 費氏數列(Fibonacci Sequence):\t{results[first - 1]}");

            Console.Write("請從費氏數列(Fibonacci Sequence)中選擇第2個數:");

            int last = int.Parse(Console.ReadLine());

            Console.WriteLine($"您選擇第 {last} 費氏數列(Fibonacci Sequence):\t{results[last - 1]}");
            Console.WriteLine($"兩個費氏數列(Fibonacci Sequence) 相加結果為:\t{results[first - 1] + results[last - 1]}");
            Console.ReadLine();
        }
    }
}
