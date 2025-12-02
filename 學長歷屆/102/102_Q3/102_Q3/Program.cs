using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _102_Q3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("file.txt");

            int start = 0, end = 0;

            List<int[]> split = new List<int[]>();

            foreach(var line in lines)
            {
                int[] tempSplit = line.Split(' ')
                    .Where(x => int.TryParse(x, out _))
                    .Select(int.Parse)
                    .ToArray();

                if (tempSplit[0] > end)
                    end = tempSplit[0];

                if (tempSplit[1] > end)
                    end = tempSplit[1];
                
                split.Add(tempSplit);
            }

            int[,] matrix = new int[end, end];

            int?[] weights = new int?[end];
            int?[] lastNode = new int?[end];
            bool[] marked = new bool[end];

            end--;

            foreach (var line in split)
                matrix[line[0] - 1, line[1] - 1] = line[2];

            weights[start] = 0;

            while(true)
            {
                int node = -1;

                for(int i = 0; i < lastNode.Length; i++)
                {
                    if (!marked[i] && (node == -1 || weights[i] < weights[node]))
                        node = i;
                }

                if (node == -1)
                    break;

                marked[node] = true;

                for(int i = 0; i < lastNode.Length; i++)
                {
                    if (matrix[node, i] == 0 || marked[i] || (weights[node] + matrix[node, i] > weights[i]))
                        continue;

                    lastNode[i] = node;
                    weights[i] = weights[node] + matrix[node, i];
                }

                if (node == end)
                    break;
            }

            List<string> paths = new List<string>();
            List<string> perWeights = new List<string>();

            int findNode = end;

            while(true)
            {
                paths.Add((findNode + 1).ToString().PadLeft(2, ' '));
                perWeights.Add(matrix[lastNode[findNode].HasValue ? lastNode[findNode].Value : start, findNode].ToString().PadLeft(2));

                if (!lastNode[findNode].HasValue)
                    break;

                findNode = lastNode[findNode].Value;
            }

            paths.Reverse();
            perWeights.Reverse();

            string pathString = string.Join(" ", paths);
            string weightString = string.Join(" ", perWeights);

            Console.WriteLine($"最低成本值總和:{weights[end]}");
            Console.WriteLine($"路徑次序: {pathString}");
            Console.WriteLine($"連線數值: {weightString}");
            Console.ReadLine();
        }
    }
}
