using System;
using System.Numerics;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        string input = string.Empty;
        while (!string.IsNullOrEmpty(input = Console.ReadLine()))
        {
            int n = int.Parse(input);
            BigInteger a = Factorial(n);

            int digitSum = 0;
            string numStr = a.ToString();
            for (int i = 0; i < numStr.Length; i++)
            {
                digitSum += numStr[i] - '0';
            }

            List<BigInteger> primeFactors = new List<BigInteger>();
            BigInteger temp = a;

            for (BigInteger i = 2; i * i <= temp; i++)
            {
                while (temp % i == 0)
                {
                    primeFactors.Add(i);
                    temp /= i;
                }
            }

            if (temp > 1)
            {
                primeFactors.Add(temp);
            }

            Console.WriteLine(a);
            Console.WriteLine(digitSum);
            Console.WriteLine(primeFactors.Count);
            Console.WriteLine();
        }
    }

    private static BigInteger Factorial(int n)
    {
        if (n == 1 || n == 0) return 1;
        return n * Factorial(n - 1);
    }
}