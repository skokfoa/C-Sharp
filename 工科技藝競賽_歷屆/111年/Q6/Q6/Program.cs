using System;

public class Program
{

    public static void Main()
    {
        string input = string.Empty;
        while(!string.IsNullOrEmpty(input = Console.ReadLine()))
        {
            Dictionary<int,int> num1 = new Dictionary<int,int>();
            Dictionary<int,int> num2 = new Dictionary<int,int>();

            var num = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            int i1 = int.Parse(num[0]),
                i2 = int.Parse(num[1]);

            num1 = Count(i1, num1);
            num2 = Count(i2, num2);
            int gcd = GCD(i1, i2);
            string result = IsPrime(gcd) ? "Y" : "N";
            string output = BuildOutput(num1) + ", " + BuildOutput(num2) + $", {gcd},{result}";
            Console.WriteLine(output);
        }
        
    }

    public static Dictionary<int,int> Count(int n, Dictionary<int,int> num)
    {
        for(int i = 2; i <= n; i++)
        {
            while(n % i == 0)
            {
                if(num.ContainsKey(i))
                {
                    num[i]++;
                }
                else
                {
                    num[i] = 1;
                }
                n /= i;
            }
        }
        return num;
    }

    public static int GCD(int a, int b)
    {
        if(b == 0) return a;
        return GCD(b, a % b);
    }

    public static bool IsPrime(int n)
    {
        if(n <= 1) return false;
        for(int i = 2; i <= Math.Sqrt(n); i++)
        {
            if(n % i == 0) return false;
        }
        return true;
    }

    public static string BuildOutput(Dictionary<int,int> num)
    {
        string output = "";
        foreach(var pair in num)
        {
            if (pair.Value > 1)
                output += $"{pair.Key}^{pair.Value}*";
            else
                output += $"{pair.Key}*";
        }
        return output.Trim('*');
    }
}