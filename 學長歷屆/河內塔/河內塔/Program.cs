using System;

namespace 河內塔
{
    internal class Program
    {
        static void run(int n, char a, char b, char c)
        {
            if(n == 1)
            {
                Console.WriteLine($"由 {a} 移動到 {c}");
                return;
            }

            run(n - 1, a, c, b);
            run(1, a, b, c);
            run(n - 1, b, a, c);
        }

        static void Main(string[] args)
        {
            Console.Write("請輸入n：");

            int n = int.Parse(Console.ReadLine());

            run(n, 'A', 'B', 'C');
            Console.ReadLine();
        }
    }
}
