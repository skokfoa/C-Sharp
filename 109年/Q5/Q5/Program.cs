using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Text.RegularExpressions;


class Project
{
    static void Main(string[] args)
    {
        while (true) {
            Console.WriteLine("請輸入運算式：  (輸入 @ 結束)");
            string pattern = @"[+\-*/]+";
            string input = Console.ReadLine();
            if (input == "@") break;

            BigInteger[] a = input.Split(new char[] { '+', '-', '*', '/', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                      .Select(x => BigInteger.Parse(x))
                      .ToArray();

            List<BigInteger> num = new List<BigInteger>();
            foreach (BigInteger n in a) num.Add(n);

            MatchCollection match = Regex.Matches(input, pattern);
            List<char> op = new List<char>();
            foreach (Match n in match) op.Add(n.Value[0]);
            
            BigInteger sum = 0;

            for(int i = 0; i < op.Count; i++)
            {
                switch(op[i])
                {
                    case '*':
                        sum = num[i] * num[i + 1];
                        num.RemoveAt(i); num.RemoveAt(i);
                        num.Insert(i, sum);
                        op.RemoveAt(i);
                        break;
                    case '/':
                        sum = num[i] / num[i + 1];
                        num.RemoveAt(i); num.RemoveAt(i);
                        num.Insert(i, sum);
                        op.RemoveAt(i);
                        break;
                }
            }

            sum = num[0];

            for (int i = 0; i < op.Count; i++)
            {
                switch (op[i])
                {
                    case '+':
                        sum += num[i + 1];
                        break;
                    case '-':
                        sum -= num[i + 1];
                        break;
                }
            }
            Console.WriteLine("\n你輸入的數學運算式為：\n" + input);
            int output = (int)(sum % 10000);
            Console.WriteLine("運算結果 = " + output + Environment.NewLine);
        }
    }
}