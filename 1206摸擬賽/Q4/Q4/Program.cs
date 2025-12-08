using System;
using System.Collections.Generic;
using System.Text;

class ExprNode
{
    public char Value;
    public ExprNode Left;
    public ExprNode Right;

    public ExprNode(char value, ExprNode left = null, ExprNode right = null)
    {
        Value = value;
        Left = left;
        Right = right;
    }
}

class Program
{
    static int Precedence(char op)
    {
        if (op == '+' || op == '-') return 1;
        if (op == '*' || op == '/') return 2;
        return 0;
    }

    static ExprNode BuildTree(string input)
    {
        Stack<ExprNode> values = new Stack<ExprNode>();
        Stack<char> ops = new Stack<char>();

        void ApplyTopOp()
        {
            char op = ops.Pop();
            ExprNode right = values.Pop();
            ExprNode left = values.Pop();
            values.Push(new ExprNode(op, left, right));
        }

        for (int i = 0; i < input.Length; i++)
        {
            char c = input[i];

            if (char.IsWhiteSpace(c)) continue;

            if (char.IsLetterOrDigit(c))
            {
                values.Push(new ExprNode(c));
            }
            else if (c == '(')
            {
                ops.Push(c);
            }
            else if (c == ')')
            {
                while (ops.Count > 0 && ops.Peek() != '(')
                    ApplyTopOp();
                ops.Pop();
            }
            else
            {
                while (ops.Count > 0 &&
                       Precedence(ops.Peek()) >= Precedence(c))
                {
                    ApplyTopOp();
                }
                ops.Push(c);
            }
        }

        while (ops.Count > 0)
            ApplyTopOp();

        return values.Pop();
    }

    static void ToPostfix(ExprNode node, StringBuilder sb)
    {
        if (node == null) return;
        ToPostfix(node.Left, sb);
        ToPostfix(node.Right, sb);
        sb.Append(node.Value);
    }

    public static void Main()
    {
        Console.Write("輸入一個中序式：");
        string input = Console.ReadLine();

        ExprNode root = BuildTree(input);

        StringBuilder sb = new StringBuilder();
        ToPostfix(root, sb);

        

        Console.WriteLine("後序式: " + sb.ToString());
    }
}
