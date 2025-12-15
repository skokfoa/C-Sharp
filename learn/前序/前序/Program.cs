using System;
using System.Collections.Generic;

public class Program
{
    static int Precedence(char op)
    {
        if (op == '+' || op == '-') return 1;
        if (op == '*' || op == '/') return 2;
        return 0;
    }

    public static void Main()
    {
        Console.WriteLine("輸入一個中序式：");
        string input = Console.ReadLine();

        Stack<char> ops = new Stack<char>();
        string output = "";

        for (int i = 0; i < input.Length; i++)
        {
            char c = input[i];

            if (char.IsWhiteSpace(c)) continue;

            if (char.IsLetterOrDigit(c))
            {
                output += c;
                Console.WriteLine("目前堆疊: " + string.Join("", ops).PadLeft(3,' ') + ", 輸出: " + output);
            }
            else if (c == '(')
            {
                ops.Push(c);
            }
            else if (c == ')')
            {
                while (ops.Count > 0 && ops.Peek() != '(')
                    output += ops.Pop();
                ops.Pop();
                Console.WriteLine("目前堆疊: " + string.Join("", ops).PadLeft(3, ' ') + ", 輸出: " + output);
            }
            else
            {
                while (ops.Count > 0 && Precedence(ops.Peek()) >= Precedence(c))
                    output += ops.Pop();
                ops.Push(c);
                Console.WriteLine("目前堆疊: " + string.Join("", ops).PadLeft(3, ' ') + ", 輸出: " + output);
            }
        }

        while (ops.Count > 0)
            output += ops.Pop();

        Console.WriteLine("後序式: " + output);
    }
}
