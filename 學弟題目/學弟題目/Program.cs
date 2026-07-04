using System;

class Program
{
    static void Main()
    {
        string input;

        Console.Write("請輸入菱形高度(n >= 3)：");
        input = Console.ReadLine();
        if (int.Parse(input) < 3) return;
        int height = int.Parse(input);

        Console.Write("請輸入菱形字形：");
        input = Console.ReadLine();
        if (input.Length > 1) return;
        char shape = input[0];

        int half = (height + 1) / 2;

        for(int i = 0; i < half; i++)
        {
            for(int j = 1; j < half - i; j++)
            {
                Console.Write(" ");
            }
            Console.Write(shape);
            if (i != 0)
            {
                for (int k = 0; k < i - 1 + i; k++)
                {
                    Console.Write(" ");
                }
                Console.Write(shape);
            }
            Console.WriteLine();
        }
        
        int anotherHalf = height - half;
        int IsOdd = 1;

        if(anotherHalf == half)
        {
            IsOdd = 0;
        }

        for(int i = 0; i < anotherHalf; i++)
        {
            for(int j = 0; j < i + IsOdd; j++)
            {
                Console.Write(" ");
            }
            Console.Write(shape);
            if (i != anotherHalf - 1)
            {
                for (int k = IsOdd * 2; k < (anotherHalf - i + IsOdd - 1) * 2 - 1; k++)
                {
                    Console.Write(" ");
                }
                Console.Write(shape);
            }
            Console.WriteLine();
        }

    }
}