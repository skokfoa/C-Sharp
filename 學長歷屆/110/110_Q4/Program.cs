using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _110_Q4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("請輸入一個二維陣列:");

            string raw = Console.ReadLine();

            List<int[]> cols = new List<int[]>();

            int cursor = 0;

            while(cursor < raw.Length)
            {
                if(raw[cursor] == '[')
                {
                    cursor++;
                    continue;
                }

                string slice = raw.Substring(cursor);

                int end = slice.IndexOf(']');

                int[] numbers = slice
                    .Substring(0, slice.IndexOf(']'))
                    .Split(',')
                    .Where(x => int.TryParse(x, out _))
                    .Select(int.Parse).ToArray();

                if (numbers.Length > 0)
                    cols.Add(numbers);

                cursor += end + 2;
            }

            Console.WriteLine("數字地圖:");

            foreach (var col in cols)
            {
                Console.WriteLine(Join(col));
            }

            if(cols.Count + cols[0].Length < 8)
                Console.WriteLine("所有路徑:");

            List<int[]> possibles = new List<int[]>();

            Walk(cols, ref possibles, new List<int>(), 0, 0);

            int[] smallest = possibles[0];

            foreach(var possible in possibles)
            {
                if (possible.Sum() < smallest.Sum())
                    smallest = possible;
            }

            Console.WriteLine($"最小路徑:\t{Join(smallest)}");
            Console.WriteLine($"最小路徑和:\t{smallest.Sum()}");

            Console.ReadLine();
        }

        public static void Walk(List<int[]> cols, ref List<int[]> possibles, List<int> current, int x, int y)
        {
            if (x >= cols[0].Length || y >= cols.Count)
            {
                if (current.Count != cols[0].Length + cols.Count - 1 || 
                    possibles.Exists(p => p.SequenceEqual(current)))
                    return;

                if (cols.Count + cols[0].Length < 8)
                    Console.WriteLine(Join(current.ToArray()));

                possibles.Add(current.ToArray());

                return;
            }

            List<int> clone = new List<int>(current)
            {
                cols[y][x]
            };

            Walk(cols, ref possibles, clone, x, y + 1);
            Walk(cols, ref possibles, clone, x + 1, y);
        }

        public static string Join(int[] numbers)
        {
            string join = string.Join(", ", numbers);
            return $"\t[{join}]";
        }
    }
}
