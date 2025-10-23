using System;
using System.Drawing;
using System.Runtime.CompilerServices;

class situation
{
    public Point lac { get; set; }
    public int dir { get; set; }
    public char[] movement { get; set; }
    bool state;

    public situation(Point l, int d, char[] movement)
    {
        lac = l;
        dir = d;
        this.movement = movement;
        state = true;
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
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a filepath");
        string path = "C:\\Users\\宇\\Desktop\\C#\\112年\\Q4\\" + Console.ReadLine();
        string[] input = File.ReadAllText(path).Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

        int n = int.Parse(input[0]);
        int[] endin = Array.ConvertAll(input[1].Split(' '), int.Parse);
        Point end = new Point(endin[0], endin[1]);

        situation[] fly = new situation[n];

        for(int i = 0; i < n; i++)
        {
            var data1 = input[i * 2 + 2].Split(' ');
            var data2 = input[i * 2 + 3].Split(' ');
            Point lac = new Point(int.Parse(data1[0]), int.Parse(data1[1]));
            int dir = situation.dirInt(data1[2]);
            char[] movement = data2[0].ToCharArray();

            fly[i] = new situation(lac, dir, movement);
        }
    }

    private static situation Step(situation a, Point end)
    {
        Point loc = a.lac;
        int dir = a.dir;
        

        switch (c)
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
                }
                break;
        }
    }

    private static Point overend(int dir, Point now,Point end)
    {
        switch (dir)
        {
            case 0:
                if (++now.X >= end.X)
                {
                    
                }
                break;
            case 1:
                now.X = ++now.Y >= end.Y ? now.Y : now.Y - 1;
                break;
            case 2:
                now.X = --now.X <= end.Y ? now.X : now.X - 1;
                break;
            case 3:
                now.X = ++now.Y > end.Y ? now.Y : now.Y - 1;
                break;
        }
    }
}