using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Elevator
{
    public int Location { get; set; }
    public char Direction { get; set; }
    public int Time { get; set; }

    public Elevator(int location, char direction, int time = 0)
    {
        Location = location;
        Direction = direction;
        Time = time;
    }
}

class Program
{
    static readonly string[] RowNames = { "AI", "BI", "OU", "OD", "TAU", "TAD", "TBU", "TBD" };
    static readonly string[] ColNames =
        new[] { "B2", "B1" }
        .Concat(Enumerable.Range(1, 16).Select(i => i.ToString()))
        .ToArray();

    static void Main()
    {
        Console.Write("Enter 1st filename:");
        string p1 = @"C:\Users\宇\Desktop\C#\112年\Q6\" + Console.ReadLine();
        var lines1 = File.ReadAllLines(p1).Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();

        Elevator A = ParseElevatorLine(lines1[0]);
        Elevator B = ParseElevatorLine(lines1[1]);

        var lastParts = SplitTokens(lines1[2]);
        char lastDir = lastParts[0][0];
        int lastFloor = int.Parse(lastParts[1]);

        Console.WriteLine($"A  {A.Direction}  {A.Location}");
        Console.WriteLine($"B  {B.Direction}  {B.Location}");
        Console.WriteLine($"{lastDir}  {lastFloor}");

        Console.Write("Enter 2nd filename:");
        string p2 = @"C:\Users\宇\Desktop\C#\112年\Q6\" + Console.ReadLine();
        var table = InitTable(File.ReadAllText(p2));

        Console.WriteLine("樓層".PadRight(4) + string.Join("", ColNames.Select(x => x.PadRight(4))));
        foreach (var row in RowNames)
        {
            Console.Write(row.PadLeft(3) + "    ");
            int[] value = table[row];
            for(int i = 0;i < value.Length; i++)
            {
                Console.Write(value[i].ToString().PadRight(4));
            }
            Console.WriteLine();
        }
    }

    static Elevator ParseElevatorLine(string line)
    {
        var t = SplitTokens(line);
        int loc = int.Parse(t[2]);
        char dir = t[1][0];
        return t[0] == "A" ? new Elevator(loc, dir) : new Elevator(loc, dir);
    }

    static string[] SplitTokens(string s) =>
        s.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

    static Dictionary<string, int[]> InitTable(string input)
    {
        var lines = input.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

        var dict = new Dictionary<string, int[]>(StringComparer.OrdinalIgnoreCase);

        foreach (var line in lines)
        {
            var parts = SplitTokens(line);
            string rowName = parts[0];
            int[] values = parts.Skip(1).Select(int.Parse).ToArray();

            if (values.Length != 18)
                throw new InvalidDataException($"列 {rowName} 欄位數不是 18（實際 {values.Length}）。");

            dict[rowName] = values;
        }

        foreach (var r in RowNames)
            if (!dict.ContainsKey(r)) dict[r] = new int[18];

        return dict;
    }
}
