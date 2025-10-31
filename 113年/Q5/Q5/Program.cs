using System;

class Progrem
{
    static void Main(string[] args)
    {
        Console.WriteLine("***模擬今彩539***");
        Console.Write("今彩539之5個1~39號碼:\t");
        int[] num = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToArray();



        Console.Write("請輸入存今彩539之5個號碼的檔名: ");
        string name = @"C:\Users\宇\Desktop\C#\113年\Q5\" + Console.ReadLine();
        using(StreamWriter sw = new StreamWriter(name))
        {
            sw.WriteLine(string.Join(" ", num));
        }

        Console.Write("\n請輸入要讀今彩539之5個號碼的檔名: ");
        string path = @"C:\Users\宇\Desktop\C#\113年\Q5\" + Console.ReadLine();
        using(StreamReader sr = new StreamReader(path))
        {
            string result = sr.ReadToEnd();
            num = result.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
        }

        double Arithmetic = new double();
        double Harmonic = new double();
        double Geometric = 1;

        for(int i = 0; i < num.Length; i++)
        {
            Arithmetic += num[i];
            Harmonic += (1.0 / num[i]);
            Geometric *= num[i];
        }

        Arithmetic = Arithmetic / num.Length;
        Harmonic = num.Length / Harmonic;
        Geometric = Math.Pow(Geometric, 1.0 / num.Length);
        Console.WriteLine($"今彩539之5個號碼的算術平均數: {Arithmetic:F6}");
        Console.WriteLine($"今彩539之5個號碼的調和平均數: {Harmonic:F6}");
        Console.WriteLine($"今彩539之5個號碼的幾何平均數: {Geometric:F6}");
        Console.WriteLine();

        Console.WriteLine("排序前的資料:\t" + string.Join(" ", num) + Environment.NewLine);
        for(int i = 0; i < num.Length - 1; i++)
        {
            int min = i;
            for(int j = i; j < num.Length; j++)
            {
                if (num[j] < num[min]) { min = j; }
            }

            Console.Write($"第 {i + 1} 次選擇:\t");
            for(int j = 0; j < num.Length; ++j)
            {
                if (j == min)
                {
                    Console.Write($"{num[j]}*  ");
                }
                else
                {
                    Console.Write($"{num[j]}  ");
                }
            }
            Console.WriteLine();

            swap(ref num[i], ref num[min]);
        }

        Console.WriteLine("排序後的資料:\t" + string.Join(" ", num) + Environment.NewLine);

        int mid = num.Length % 2 == 0 ? num.Length / 2 : num.Length / 2 + 1;
        Console.WriteLine("今彩539之5個號碼的中位數: " + num[mid].ToString());
    }

    private static void swap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }
}