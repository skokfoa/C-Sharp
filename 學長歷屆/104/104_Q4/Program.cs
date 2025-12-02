using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _104_Q4
{
    internal class Program
    {
        static Position[] positions;

        static void Main(string[] args)
        {
            while(true)
            {
                Console.WriteLine("請選擇操作項目：");
                Console.WriteLine("\t(1)輸入模型資料:");
                Console.WriteLine("\t(2)計算平均相似度:");
                Console.WriteLine("\t(3)顯示各資料相似度:");
                Console.Write("請選擇：");

                int action = int.Parse(Console.ReadLine().Trim());

                if (action == 1)
                {
                    Console.Write("輸入模型資料，總筆數為：");

                    int amount = int.Parse(Console.ReadLine().Trim());

                    Console.Write("　　序列(x軸):");

                    positions = Console.ReadLine().Split(' ').Where(x => int.TryParse(x, out _)).Select(x => new Position
                    {
                        x = int.Parse(x)
                    }).ToArray();

                    Console.Write("數值串列(上限):");

                    int[] top = Console.ReadLine().Split(' ').Where(x => int.TryParse(x, out _)).Select(int.Parse).ToArray();

                    for (int i = 0; i < amount; i++)
                        positions[i].bottom = top[i];

                    Console.Write("數值串列(中心):");

                    int[] center = Console.ReadLine().Split(' ').Where(x => int.TryParse(x, out _)).Select(int.Parse).ToArray();

                    for (int i = 0; i < amount; i++)
                        positions[i].center = center[i];

                    Console.Write("數值串列(下限):");

                    int[] bottom = Console.ReadLine().Split(' ').Where(x => int.TryParse(x, out _)).Select(int.Parse).ToArray();

                    for (int i = 0; i < amount; i++)
                        positions[i].top = bottom[i];

                    Array.Sort(positions, (v, x) => v.x - x.x);
                }

                if (action == 2)
                {
                    Console.Write("請輸入「資料串列」檔名：");

                    string name = Console.ReadLine().Trim();

                    double[] data = File.ReadAllText(name).Trim().Split(' ').Where(x => double.TryParse(x, out _)).Select(double.Parse).ToArray();

                    Console.WriteLine($"已開啟「資料串列」檔名：{name}");
                    Console.WriteLine();

                    double total = 0;

                    for(int i = 0; i < data.Length; i++)
                    {
                        if (data[i] <= positions[i].center)
                            total += Math.Max(0, (data[i] - positions[i].top) / (positions[i].center - positions[i].top));
                        else total += Math.Max(0, 1 - (data[i] - positions[i].center) / (positions[i].bottom - positions[i].center));
                    }

                    string output = (total / data.Length).ToString("F6");

                    Console.WriteLine($"平均相似度為 {output}");
                }

                Console.WriteLine();
                Console.Write("繼續：請按1，結束：請按0：");

                if (Console.ReadLine().Trim() == "0")
                    break;
            }
        }
    }

    class Position
    {
        public int x;
        public int center;
        public int top;
        public int bottom;
    }
}
