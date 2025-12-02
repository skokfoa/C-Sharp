using System;
using System.Data;

namespace _109_Q5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                Console.WriteLine("請輸入運算式：（輸入＠以結束）");
                string input = Console.ReadLine();

                if (input == "@")
                    break;

                DataTable table = new DataTable();

                string result = table.Compute(input, "false").ToString();

                Console.WriteLine($"妳輸入的數學運算式為：\n{input}\n運算結果 = {result}");
            }
        }
    }
}
