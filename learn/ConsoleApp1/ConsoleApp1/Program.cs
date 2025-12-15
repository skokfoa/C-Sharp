public class Program
{
    static int Precedence(char op)
    {
        if (op == '+' || op == '-') return 1;
        if (op == '*' || op == '/') return 2;
        return 0;
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("輸入一個後序式：");
        string input = Console.ReadLine();

        Stack<char> op = new Stack<char>();
        string output = "";


        for(int i = 0; i < input.Length; i++)
        {
            char token = input[i];
            if (char.IsLetterOrDigit(token))
            {
                output += token;
            }
            else if (token == '(')
            {
                op.Push(token);
            }
            else if (token == ')')
            {
                while (op.Count > 0 && op.Peek() != '(')
                {
                    output += op.Pop();
                }
                if (op.Count > 0 && op.Peek() == '(')
                {
                    op.Pop();
                }
            }
            else
            {
                while (op.Count > 0 && Precedence(op.Peek()) >= Precedence(token))
                {
                    output += op.Pop();
                }
                op.Push(token);
            }
        }

        while (op.Count > 0)
        {
            output += op.Pop();
        }
        Console.WriteLine("後序式為：" + output);
    }
}