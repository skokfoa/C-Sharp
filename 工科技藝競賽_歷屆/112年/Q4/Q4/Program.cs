using System;
using System.Drawing;
using System.Runtime.CompilerServices;

class situation
{
    public Point lac { get; set; }
    public int dir { get; set; }
    public char[] movement { get; set; }
    public bool state;

    public situation(Point l, int d, char[] movement,bool state = true)
    {
        lac = l;
        dir = d;
        this.movement = movement;
        this.state = state;
    }

    public static int dirInt(string a)
    {
        if (a == "N")
            return 0;
        else if (a == "E")
            return 1;
        else if (a == "S")
            return 2;
        else if (a == "W")
            return 3;
        return -1;
    }

    public static string dirString(int a)
    {
        switch (a)
        {
            case 0: return "N";
            case 1: return "E";
            case 2: return "S";
            case 3: return "W";
        }
        return null;
    }
}

class Program
{
    static List<Point> destroyed = new List<Point>();
    static void Main(string[] args)
    {
        Console.Write("Enter a filepath:");
        string path = "C:\\Users\\宇\\Desktop\\C#\\112年\\Q4\\" + Console.ReadLine();
        string[] input = File.ReadAllText(path).Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

        int n = int.Parse(input[0]);
        int[] endin = Array.ConvertAll(input[1].Split(' ', StringSplitOptions.RemoveEmptyEntries), int.Parse);
        Point end = new Point(endin[0], endin[1]);

        situation[] fly = new situation[n];

        for(int i = 0; i < n; i++)
        {
            var data1 = input[i * 2 + 2].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var data2 = input[i * 2 + 3];
            Point lac = new Point(int.Parse(data1[0]), int.Parse(data1[1]));
            int dir = situation.dirInt(data1[2]);
            char[] movement = data2.ToCharArray();

            fly[i] = new situation(lac, dir, movement);
        }

        for(int i = 0; i < fly.Length; i++)
        {
            while (fly[i].state && fly[i].movement.Length > 0)
            {
                fly[i] = Step(fly[i], end);
            }
        }

        for(int i = 0; i < fly.Length; i++)
        {
            Console.Write($"{fly[i].lac.X} {fly[i].lac.Y} {situation.dirString(fly[i].dir)}");
            if (fly[i].state) Console.WriteLine();
            else Console.WriteLine(" Destroyed");
        }

        using (StreamWriter sw = new StreamWriter(@"C:\Users\宇\Desktop\C#\112年\Q4\output.txt"))
        {
            for (int i = 0; i < fly.Length; i++)
            {
                sw.Write($"{fly[i].lac.X} {fly[i].lac.Y} {situation.dirString(fly[i].dir)}");
                if (fly[i].state) sw.WriteLine();
                else sw.WriteLine(" Destroyed");
            }
        }
    }

    private static situation Step(situation a, Point end)
    {
        Point loc = a.lac;
        int dir = a.dir;
        char[] move = a.movement;
        bool state = a.state;

        if (state)
        {
            switch (move[0])
            {
                case 'R':
                    dir = (dir + 1) % 4;
                    break;
                case 'L':
                    dir = (dir + 3) % 4;
                    break;
                case 'F':
                    switch (dir)
                    {
                        case 0:
                            if (++loc.Y >= end.Y)
                            {
                                state = false;
                                destroyed.Add(loc);
                            }
                            else
                            {
                                for (int i = 0; i < destroyed.Count; i++)
                                {
                                    if (loc.X == destroyed[i].X && loc.Y == destroyed[i].Y)
                                    {
                                        loc.Y += -1;
                                    }
                                }
                            }
                            break;
                        case 1:
                            if (++loc.X >= end.X)
                            {
                                state = false;
                                destroyed.Add(loc);
                            }
                            else
                            {
                                for (int i = 0; i < destroyed.Count; i++)
                                {
                                    if (loc.X == destroyed[i].X && loc.Y == destroyed[i].Y)
                                    {
                                        loc.X += -1;
                                    }
                                }
                            }
                            break;
                        case 2:
                            if (--loc.Y < 0)
                            {
                                state = false;
                                destroyed.Add(loc);
                            }
                            else
                            {
                                for (int i = 0; i < destroyed.Count; i++)
                                {
                                    if (loc.X == destroyed[i].X && loc.Y == destroyed[i].Y)
                                    {
                                        loc.Y += 1;
                                    }
                                }
                            }
                            break;
                        case 3:
                            if (--loc.X < 0)
                            {
                                state = false;
                                destroyed.Add(loc);
                            }
                            else
                            {
                                for (int i = 0; i < destroyed.Count; i++)
                                {
                                    if (loc.X == destroyed[i].X && loc.Y == destroyed[i].Y)
                                    {
                                        loc.X += 1;
                                    }
                                }
                            }
                            break;
                    }
                    break;
            }

            char[] ca = new char[move.Length - 1];
            for (int i = 1; i < move.Length; i++)
            {
                ca[i - 1] = move[i];
            }

            return new situation(loc, dir, ca, state);
        }
        return new situation(loc, dir, new char[0], state);
    }
}