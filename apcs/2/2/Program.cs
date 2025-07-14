using System;

namespace score
{
    class Program
    {
        static void Main(string[] args)
        {
            int std, Max = -1, Min = 101;

            std = int.Parse(Console.ReadLine());

            int[] score = new int[std];

            string[] input = Console.ReadLine().Split();
            for (int i = 0; i < std; i++)
            {
                score[i] = int.Parse(input[i]);
                if (score[i] > 60)
                {
                    Min = Math.Min(Min, score[i]);
                }else if (score[i] < 60)
                {
                    Max = Math.Max(Max, score[i]);
                }
            }

            for (int i = 0;i < std; i++)
            {
                for (int j = i; j < std; j++)
                {
                    if (score[j] < score[i])
                    {
                        int temp = score[i];
                        score[i] = score[j];
                        score[j] = temp;
                    }
                }
            }

            Console.WriteLine();

            for (int i = 0;i <std; i++)
            {
                Console.Write($"{score[i]} ");
            }

            if (Max == -1)
            {
                Console.WriteLine("\nbest case");
            }
            else
            {
                Console.WriteLine($"\n{Max}");
            }

            if (Min == 101)
            {
                Console.WriteLine("worse case");
            }
            else
            {
                Console.WriteLine($"{Min}");
            }
        }
    }
}