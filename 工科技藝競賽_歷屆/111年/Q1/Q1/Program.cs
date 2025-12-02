using System;
using System.Numerics;

public class Program
{
    public static void Main()
    {
        Console.Write("n=");
        int n = int.Parse(Console.ReadLine());

        BigInteger[,] A = new BigInteger[,] { { 1, 1 }, 
                                              { 1, 0 } };


        for(int i = 2; i <= n; i++)
        {
            A = Multiply(A);
        }

        string result = "A";

        Console.WriteLine($"{result}^{n}=[{A[0,0]}  {A[0,1]}]");
        for(int i = 0; i < n.ToString().Length; i++) Console.Write(" ");
        Console.WriteLine($"   [{A[1,0]}  {A[1,1]}]");
    }

    private static BigInteger[,] Multiply(BigInteger[,] a)
    {
        BigInteger[,] c = new BigInteger[2,2];
        BigInteger[,] b = new BigInteger[,] { { 1, 1 },
                                              { 1, 0 } };
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                c[i,j] = b[i,0] * a[0,j] + b[i,1] * a[1,j];
            }
        }
        return c;
        
    }
}