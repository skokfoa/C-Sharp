using System;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.WriteLine("請輸入一個二維陣列：");
        string input = Console.ReadLine();
        string patten = @"\[[\d*,*]*\]";

        MatchCollection matches = Regex.Matches(input, patten);
        int[][] arr = new int[matches.Count][];

        for (int i = 0; i < matches.Count; i++)
        {
            string row = matches[i].Value.Trim(new char[] { '[', ']' });
            string[] nums = row.Split(',', StringSplitOptions.RemoveEmptyEntries);
            arr[i] = row.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
        }

        Console.WriteLine("數字地圖：");
        for (int i = 0; i < arr.Length; i++)
        {
            Console.WriteLine("\t[" + string.Join(", ", arr[i]) + "]");
        }

        int rows = arr.Length;
        int cols = arr[0].Length;

        bool bigerThen8 = rows + cols < 8;

        List<List<(int, int)>> allpath = new List<List<(int, int)>>();
        DFS(arr, 0, 0, allpath);

        if (bigerThen8)
        {
            Console.WriteLine("所有路徑：");
            foreach (var p in allpath)
            {
                Console.WriteLine("\t[" + string.Join(", ", p.Select(x => arr[x.Item1][x.Item2])) + "]");
            }
        }

        var sums = allpath.Select(p => p.Sum(x => arr[x.Item1][x.Item2])).ToList();
        int minSum = sums.Min();
        int minIndex = sums.IndexOf(minSum);
        var minPath = allpath[minIndex];
        Console.WriteLine("最小路徑：");
        Console.WriteLine("[" + string.Join(", ", minPath.Select(x => arr[x.Item1][x.Item2])) + "]");
        Console.WriteLine("最小路徑和: " + minSum);
    }

    static void DFS(int[][] arr, int r, int c, List<List<(int, int)>> allpath, List<(int, int)> coord = null)
    {
        if (coord == null) coord = new List<(int, int)>();
        coord.Add((r, c));

        int rows = arr.Length;
        int cols = arr[r].Length;

        if (r == rows - 1 && c == cols - 1)
        {
            allpath.Add(new List<(int, int)>(coord));
            coord.RemoveAt(coord.Count - 1);
            return;
        }

        if (r + 1 < rows)
        {
            DFS(arr, r + 1, c, allpath, new List<(int, int)>(coord));
        }

        if (c + 1 < cols)
        {
            DFS(arr, r, c + 1, allpath, new List<(int, int)>(coord));
        }
    }
}