using System;
using System.ComponentModel.Design;
using System.Transactions;

class Program
{
    static void Main(string[] args)
    {
        int Processes;
        while (true) {
            Console.Write("請輸入行程processes數量(MAX 5)：");
            if (int.TryParse(Console.ReadLine(), out Processes) && Processes <= 5 && Processes >= 1) break;
            Console.WriteLine();
        }

        Console.WriteLine("\n請輸入每個行程的執行時間burst_time···");

        int[] P = new int[Processes];

        for(int i = 0; i < Processes; i++)
        {
            Console.Write($"P{i + 1}: ");
            P[i] = int.Parse(Console.ReadLine());
        }

        Console.Write("\n請輸入時間配額time_quantum：");
        int quantum = int.Parse(Console.ReadLine());

        int time = 0;
        int witch = 0;

        List<(int, int)> result = new List<(int, int)>();

        int[] wait = new int[Processes];

        while (true)
        {
            byte count = new byte();
            for(int i = 0; i < P.Length; i++)
            {
                if (P[i] == 0) count++;
            }

            if (count == Processes) break;

            if (P[witch] > 0)
            {
                result.Add((time, witch));

                int run = Math.Min(quantum, P[witch]);
                P[witch] -= run;
                time += run;

                for(int i = 0; i < Processes; i++)
                {
                    if (i != witch)
                    {
                        if (P[i] > 0)
                        {
                            wait[i] += run;
                        }
                    }
                }

                witch = (witch + 1) % Processes;
            }
            else
            {
                witch = (witch + 1) % Processes;
            }
        }

        Console.WriteLine("\n各行程processes執行順序為···");
        Console.WriteLine(string.Join("  ", result.Select(x => $"{x.Item1:00}:P{x.Item2 + 1}")) + $"  {time}");

        Console.WriteLine("\n" + string.Join("  ", wait.Select((x, i) => $"P{i + 1}等待時間：{x}")));

    }
}