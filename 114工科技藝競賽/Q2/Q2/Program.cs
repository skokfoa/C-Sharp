using System;
using System.Drawing;

class Program
{
    static void Main(string[] args)
    {
        char[,] p1 = new char[18, 24];
        char[,] p2 = new char[5, 13];

        int H1 = new int();
        int H2 = new int();
        Point first = new Point();
        Point last = new Point();

        Console.Write("Enter 1st filename：");
        string path1 = @"./" + Console.ReadLine();
        Console.Write("Enter 2en filename：");
        string path2 = @"./" + Console.ReadLine();

        using (StreamReader sr = new StreamReader(path1))
        {
            string[] input = sr.ReadToEnd()
                .Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            int f1 = int.MaxValue;
            int f2 = int.MaxValue;
            bool f = true;
            for (int i = 0; i < 18; i++)
            {
                for (int j = 0; j < 24; j++)
                {
                    p1[i, j] = input[i][j];

                    if (p1[i, j] == 'H')
                    {
                        if (j < 12)
                        {
                            f1 = Math.Min(f1, i);
                        }
                        else
                        {
                            f2 = Math.Min(f2, i);
                        }
                        if (f)
                        {
                            first = new Point(i, j);
                            f = false;
                        }
                        last.X = Math.Max(i, last.X);
                        last.Y = Math.Max(j, last.Y);
                    }

                }
            }
            H1 = Math.Abs(f1 - f2);
        }

        Console.WriteLine();

        using (StreamReader sr = new StreamReader(path2))
        {
            string[] input = sr.ReadToEnd()
                .Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            int f1 = int.MaxValue;
            int f2 = int.MinValue;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    p2[i, j] = input[i][j];
                    if (p2[i, j] == 'O')
                    {
                        f1 = Math.Min(f1, i);
                        f2 = Math.Max(f2, i);
                    }
                }
            }
            H2 = Math.Abs(f1 - f2) + 1;
        }
        
        
        char[,] result = new char[18, 24];
        if (H2 <= H1)
        {
            Point now = first;
            first.Y -= (H2 * 2 - 1);
            for(int i = first.X; i < H2 - 1; i++)
            {
                for(int j = first.Y; j < H2 - 1; j++)
                {
                    now.Y++;
                }
                
            }
        }
        else
        {
            last.Y -= (H2 - 1);

        }

    }
}