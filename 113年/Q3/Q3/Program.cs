using System;

class Progrem
{
    static void Main(string[] args)
    {
        int[,] arr = init();

        Console.WriteLine("初始矩陣");
        print(arr);

        flip(arr);

        int[,] turns = (int[,])arr.Clone();

        for(int i = 0; i < 3; i++)
        {
            Console.WriteLine();
            turns = turn(turns);
            print(turns);
        }
    }

    private static int[,] init()
    {
        int[,] input = new int[3, 3];

        int x = 0;
        int y = 1;
        for(int i = 1; i <= 9; i++)
        {
            if (input[x, y] == new int())
            {
                input[x, y] = i;
                x = (x + 2) % 3;
                y = (y + 1) % 3;
            }
            else
            {
                y = (y + 2) % 3;
                x = (x + 2) % 3;
                i--;
            }
        }

        return input;
    }

    private static void flip(int[,] input)
    {
        int[,] min_x = (int[,])input.Clone();
        int[,] min_y = (int[,])input.Clone();
        int[,] d45  = (int[,])input.Clone();
        int[,] d135 = (int[,])input.Clone();

        for(int i = 0; i < 3; i++)
        {
            Swap(ref min_y[i, 0], ref min_y[i, 2]);
            Swap(ref min_x[0, i], ref min_x[2, i]);
        }

        for(int i = 0; i < 3; i++)
        {
            for(int j = 0; j < 2 - i; j++)
            {
                Swap(ref  d45[i, j], ref d45[2 - j, 2 - i]);
            } 
        }

        for(int i = 0; i < 3; i++)
        {
            for (int j = i; j < 3; j++)
            {
                Swap(ref d135[i, j], ref d135[j, i]);
            }
        }

        Console.WriteLine();
        print(min_x);
        Console.WriteLine();
        print(min_y);
        Console.WriteLine();
        print(d45);
        Console.WriteLine();
        print(d135);
    }

    private static int[,] turn(int[,] input)
    {
        int[,] temp = new int[3,3];

        for(int i = 0;i < 3; i++)
        {
            for(int j = 0; j < 3; j++)
            {
                temp[i, j] = input[j, 2 - i];
            }
        }
        return temp;
    }

    private static void Swap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }

    private static void print(int[,] input)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write(input[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}