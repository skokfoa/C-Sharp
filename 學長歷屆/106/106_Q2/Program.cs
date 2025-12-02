using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _106_Q2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("請輸入行程processess數量(MAX 5)：");

            int count = int.Parse(Console.ReadLine());

            Console.WriteLine("請輸入每個行程的執行時間burst_time...");

            int[] processes = new int[count];

            for(int i = 0; i < count; i++)
            {
                Console.Write($"P{i + 1}: ");

                processes[i] = int.Parse(Console.ReadLine());
            }

            Console.Write("請輸入時間配額time_quantum：");

            int quota = int.Parse(Console.ReadLine()), time = 0;

            int[] waiting = new int[count];

            int current = 0;

            while(Array.Exists(processes, x => x > 0))
            {
                int run = Math.Min(quota, processes[current]);

                if(run == 0)
                {
                    current++;

                    if (current >= processes.Length)
                        current = 0;

                    continue;
                }

                string timeString = time.ToString().PadLeft(2, '0');

                Console.Write($"{timeString}:P{current + 1}  ");

                time += run;

                processes[current] -= run;

                for (int i = 0; i < count; i++)
                {
                    if(i != current && processes[i] > 0)
                        waiting[i] += run;
                }

                current++;

                if (current >= processes.Length)
                    current = 0;
            }

            Console.WriteLine();
            Console.WriteLine();

            for (int i = 0; i < processes.Length; i++)
                Console.Write($"P{i + 1}等待時間：{waiting[i]}  ");

            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
