using System;
using System.Collections.Immutable;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Write("x1:");
            string input = Console.ReadLine();
            int result = int.Parse(input);
            int same = new int();
            int i = 1;

            while (result != same)
            {
                i++;
                same = result;
                result = fMax(same) - fMin(same);
                Console.WriteLine($"x{i}={fMax(same)}-{fMin(same)}={result}");
            }

            Console.WriteLine("黑洞數=" + result + Environment.NewLine);
        }
        

    }

    private static int fMax(int input)
    {
        string a = input.ToString();
        int[] num = new int[a.Length];
        num = a.Select(c => (int)char.GetNumericValue(c)).ToArray();

        Array.Sort(num);

        int output = new int();
        for (int i = 0;i < num.Length; i++)
        {
            output += num[i] * (int)Math.Pow(10, i);
        }
        return output;
    }

    private static int fMin(int input)
    {
        string a = input.ToString();
        int[] num = new int[a.Length];
        num = a.Select(c => (int)char.GetNumericValue(c)).ToArray();

        Array.Sort(num, (a, b) => b.CompareTo(a));

        int output = new int();
        for (int i = 0; i < num.Length; i++)
        {
            output += num[i] * (int)Math.Pow(10, i);
        }
        return output;
    }
}