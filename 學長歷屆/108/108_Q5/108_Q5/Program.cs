using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _108_Q5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("請輸入大地遊戲關卡文字檔名：");

            string name = Console.ReadLine();

            Console.WriteLine($"你輸入的檔名為 '{name}'\r\n大地遊戲關卡文字檔內容為：");

            string[] lines = File.ReadAllLines(name);

            foreach(var line in lines)
                Console.WriteLine(line);

            int size = int.Parse(lines[0]);

            double[,] matrix = new double[size, size];

            for(int i = 0; i < size; i++)
            {
                double[] numbers = lines[i + 1]
                    .Split(' ')
                    .Where(x => double.TryParse(x, out _))
                    .Select(double.Parse)
                    .ToArray();

                for (int j = 0; j < numbers.Length; j++)
                    matrix[i, j] = numbers[j];
            }

            int[] split = lines[lines.Length - 1]
                .Split(' ')
                .Where(x => int.TryParse(x, out _))
                .Select(int.Parse)
                .ToArray();

            int start = split[0] - 1, 
                end = split[1] - 1;

            int?[] lastNodes = new int?[size];
            double?[] weights = new double?[size];

            bool[] marked = new bool[size];

            weights[start] = 0;

            while(true)
            {
                int node = -1;

                for(int i = 0; i < lastNodes.Length; i++)
                {
                    if (!marked[i] && (node == -1 || weights[i] < weights[node]))
                        node = i;
                }

                if (node == -1)
                    break;
                
                marked[node] = true;

                for (int i = 0; i < lastNodes.Length; i++)
                {
                    if (matrix[node, i] == 0 || marked[i] ||
                        (weights[i].HasValue && weights[node].Value + matrix[node, i] > weights[i].Value))
                        continue;

                    lastNodes[i] = node;
                    weights[i] = weights[node].Value + matrix[node, i];
                }

                if (node == end)
                    break;
            }

            List<int> paths = new List<int>();

            int findNode = end;

            while(true)
            {
                paths.Add(findNode + 1);

                if (!lastNodes[findNode].HasValue)
                    break;

                findNode = lastNodes[findNode].Value;
            }

            paths.Reverse();

            Console.WriteLine($"最快的闖關路線 [{start + 1} -> {end + 1}]: {string.Join("->", paths)} ({weights[end]})");
            Console.ReadLine();
        }
    }
}
