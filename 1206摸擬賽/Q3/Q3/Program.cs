using System;
using System.Numerics;

class Program
{
    public const int G = 34943;

    static void Main(string[] args)
    {
        string? input = string.Empty;

        while ((input = Console.ReadLine()) != "-1")
        {
            if (input == string.Empty) 
            { 
                Console.WriteLine("00 00");
                continue;
            }
            string X = string.Empty;

            foreach(char c in input)
            {
                X += Convert.ToString(c, 16);
            }
            BigInteger num = new BigInteger();

            for(int i = 0; i< X.Length; i++)
            {
                num += Convert.ToInt16(X[i].ToString(), 16);
                if (i != X.Length - 1) num *= 16;
            }

            num *= (long)Math.Pow(16, 4);

            int CRC = (int)(num % G);

            if (CRC != 0)
            {
                CRC = G - CRC;
            }

            string result = Convert.ToString(CRC, 16).PadLeft(4,'0');

            result = result.ToUpper();

            Console.WriteLine($"{result.Substring(0,2)} {result.Substring(2)}");
        }
    }
}