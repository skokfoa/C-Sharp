using System;
using System.ComponentModel;

class Program
{
    static void Main(string[] args)
    {
        int n, k;
        string input = Console.ReadLine();

        var line = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        n = int.Parse(line[0]);
        k = int.Parse(line[1]);

        int[] narr = new int[n];

        input = Console.ReadLine();
        narr = input
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        if (narr.Length != n) return;

        List<int[]> ty = new List<int[]>();
        int c = 0;

        while (c < narr.Length)
        {
            HashSet<int> visit = new HashSet<int>();
            List<int> index = new List<int>();


            for(int i = c; i <  narr.Length; i++)
            {
                if (visit.Contains(narr[i]))
                {
                    ty.Add(index.ToArray());
                    break;
                }
                else
                {
                    visit.Add(narr[i]);
                    index.Add(i);
                }
            }
            c++;
        }

        var top = ty.OrderByDescending(x => x.Length)
            .Take(k)
            .ToList();

        HashSet<int> allIndex = top
            .SelectMany(x => x)
            .ToHashSet();

        Console.WriteLine(allIndex.Count);
    }
}