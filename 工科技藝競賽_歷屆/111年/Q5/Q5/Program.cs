using System;
using System.IO;
using System.Globalization;
using Microsoft.VisualBasic;

class Program
{
    static void Main()
    {
        List<float> larr = new List<float>();
        HashSet<float> harr = new HashSet<float>();
        Console.Write("Enter filename:");
        string filePath = @"C:\Users\宇\Desktop\C#\111年\Q5\" + Console.ReadLine();
        string content = string.Empty;

        if (File.Exists(filePath))
        {
            content = File.ReadAllText(filePath);
            Console.WriteLine("所輸入的對稱矩陣：");
            Console.WriteLine(content);
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("File does not exist.");
        }

        string[] lines = content.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        float[,] arr = new float[8, 8];

        for (int i = 0; i < 8; i++)
        {
            string[] numbers = lines[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            for (int j = 0; j < 8; j++)
            {
                arr[i, j] = float.Parse(numbers[j]);
            }
        }

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                arr[i, j] = CalculateTC(arr, i, j);
            }
        }

        Console.WriteLine("經過幾次遞移律(Transitive Closure)運算後的對稱矩陣：");

        for(int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                Console.Write(arr[i, j].ToString("F2") + "  ");
            }
            Console.WriteLine();
        }

        for(int i = 0;i < 8; i++)
        {
            float max = float.MinValue;
            for (int j = i + 1;j < 8;j++)
            {
                max = Math.Max(max, arr[i, j]);
            }
            larr.Add(max);
        }
        larr.Remove(float.MinValue);

        for(int i = 0;i < larr.Count; i++)
        {
            harr.Add(larr[i]);
        }

        Console.WriteLine("對稱矩陣的右上半每列最大值：");
        Console.WriteLine(string.Join(" ", larr.ConvertAll(x => x.ToString("F2"))));

        Console.WriteLine("對稱矩陣的右上半每列最大值的排序(各值只出現一次)：");
        Console.WriteLine(string.Join(" ", harr.ToArray().OrderBy(x => x).Select(x => x.ToString("F2"))));
    }

    private static float CalculateTC(float[,] arr, int i, int j)
    {
        float f = float.MinValue;
        for (int k = 0; k < 8; k++)
        {
           f = Math.Max(f, Math.Min(arr[i, k], arr[k, j]));
        }
        return f;
    }
}
