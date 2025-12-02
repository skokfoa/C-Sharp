using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        while (true)
        {
            var line = Console.ReadLine();
            if (line == null) return;
            int n = int.Parse(line.Trim());

            while (true)
            {
                string s = Console.ReadLine();
                if (s == null) return;
                s = s.Trim();
                if (s == "0")
                {
                    Console.WriteLine();
                    break;
                }

                int[] perm = s.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                              .Select(int.Parse)
                              .ToArray();

                Console.WriteLine(IsStackPermutation(n, perm) ? "YES!" : "NO!");
            }
        }
    }

    static bool IsStackPermutation(int n, int[] target)
    {
        if (target.Length != n) return false;

        var st = new Stack<int>();
        int want = 0;

        for (int next = 1; next <= n; next++)
        {
            st.Push(next);
            while (st.Count > 0 && st.Peek() == target[want])
            {
                st.Pop();
                want++;
                if (want == n) break;
            }
        }
        return want == n;
    }
}
