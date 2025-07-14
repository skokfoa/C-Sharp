using System;
using System.Diagnostics;

namespace cube
{
    class Project
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();

            ushort r, c, M;
            string[] input = Console.ReadLine().Split();

            r = ushort.Parse(input[0]);
            c = ushort.Parse(input[1]);
            M = ushort.Parse(input[2]);

            int[,] x = new int[r, c];

            for (int i = 0; i < r; i++)
            {
                input = Console.ReadLine().Split();
                for (int j = 0; j < c; j++)
                {
                    x[i, j] = int.Parse(input[j]);
                }
            }

            int[] m = new int[M];
            input = Console.ReadLine().Split();
            for (int i = 0; i < M; i++)
            {
                m[i] = int.Parse(input[i]);
            }
            
            stopwatch.Start();

            for (int i = 0; i < M; i++)
            {
                if (m[i] == 0)
                {
                    x = Turn(x, r, c);
                    ushort temp = r;
                    r = c;
                    c = temp;
                }
                else if (m[i] == 1)
                {
                    x = Flip(x, r, c);
                }
            }
            PrintMatrix(x, r, c);

            stopwatch.Stop();
            Console.WriteLine($"\nExecution Time: {stopwatch.ElapsedMilliseconds} ms");
        }

        static int[,] Turn(int[,] matrix, int r, int c)
        {
            int[,] rotated = new int[c, r];

            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    rotated[j, r - 1 - i] = matrix[i, j];
                }
            }

            return rotated;
        }

        static int[,] Flip(int[,] matrix, int r, int c)
        {
            for (int i = 0; i < r / 2; ++i)
            {
                for (int j = 0; j < c; ++j)
                {
                    int temp = matrix[i, j];
                    matrix[i, j] = matrix[r - 1 - i, j];
                    matrix[r - 1 - i, j] = temp;
                }
            }
            return matrix;
        }

        static void PrintMatrix(int[,] matrix, int r, int c)
        {
            Console.WriteLine($"\n{r} {c}");
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
