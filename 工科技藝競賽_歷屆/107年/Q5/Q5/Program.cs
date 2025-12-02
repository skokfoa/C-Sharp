using System;

class Program
{
    static void Main(string[] args)
    {
        string input = string.Empty;

        while (!string.IsNullOrWhiteSpace(input = Console.ReadLine()))
        {
            int n = int.Parse(input);

            int[] a = new int[n];

            a = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            List<int[]> result = new List<int[]>();

            if (n != a.Length)
            {
                Console.WriteLine("輸入錯誤");
                return;
            }

            for (int i = 2; i < n; i++)
            {
                for (int j = i - 1; j < n; j++)
                {
                    int[] arr = new int[i];
                    for (int k = 0; k < i; k++)
                    {
                        arr[k] = a[j - i + 1 + k];
                    }
                    result.Add(arr);
                }
            }

            var Maxresult = result
                .Max(x => x.Sum());

            var MaxIndex = result
                .FindIndex(x => x.Sum() == Maxresult);

            var MaxArray = result[MaxIndex];

            var start = a
                .ToList()
                .FindIndex(x => x == MaxArray[0]);

            var end = a
                .ToList()
                .FindIndex(x => x == MaxArray[MaxArray.Length - 1]);

            Console.WriteLine(Maxresult);
            Console.WriteLine($"{start} {end}");
        }
    }
}