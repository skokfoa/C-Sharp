using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace 八皇后
{
    internal class Program
    {
        static readonly List<string> results = new List<string>();

        static void Main(string[] _)
        {
            int result = 0;
            int[] fields = new int[8];

            Calculate(fields, 0, ref result);

            File.WriteAllLines("out.txt", results.ToArray());

            Console.WriteLine($"結果為 {result}\n輸入檔案名字");
            
            string name = Console.ReadLine();

            string[] contents = File.ReadAllLines(name);

            List<string> sorted = new List<string>();

            foreach (string content in contents)
            {
                int[] nums = content.ToCharArray().Select(x => x - '0').ToArray();

                Array.Sort(nums);

                sorted.Add(string.Join("", nums));
            }

            File.WriteAllLines("out_sorted.txt", sorted);

            Console.WriteLine("OK");
            Console.ReadLine();
        }

        public static void Calculate(int[] fields, int line, ref int result)
        {
            if (line >= 8)
            {
                string mix = string.Join("", fields);

                Console.WriteLine(mix);
                results.Add(mix);

                result++;
                return;
            }

            for (int i = 0; i < 8; i++)
            {
                if (Check(fields, line, i))
                {
                    int[] cloned = (int[]) fields.Clone();

                    cloned[line] = i;

                    Calculate(cloned, line + 1, ref result);
                }
            }
        }

        public static bool Check(int[] fields, int line, int index)
        {
            for (int i = 0; i < line; i++)
            {
                if (fields[i] == index || (fields[i] + line - i == index) || (fields[i] - (line - i) == index))
                    return false;
            }

            return true;
        }
    }
}
