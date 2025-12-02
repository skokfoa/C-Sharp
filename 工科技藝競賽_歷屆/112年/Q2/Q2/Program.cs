using System;

class Program
{
    static void Main()
    {
        Console.Write("輸入原來的英文單字：");
        string n = Console.ReadLine();
        Console.Write("輸入改變後的英文單字：");
        string m = Console.ReadLine();

        int result = dynamicProgramming(n, m);
        Console.WriteLine($"編輯距離為：{result}");
    }

    private static int dynamicProgramming(string a, string b)
    {
        int n = a.Length;
        int m = b.Length;

        int[,] D = new int[n + 1, m + 1];

        for(int i = 0;i <= n; i++)
            D[i, 0] = i;

        for(int j = 0;j <= m; j++)
            D[0, j] = j;

        for(int i = 1;i <= n; i++)
            for(int j = 1;j <= m; j++)
            {
                int cost = (a[i - 1] == b[j - 1]) ? 0 : 2;
                D[i, j] = Math.Min(Math.Min(D[i - 1, j] + 1, D[i, j - 1] + 1), D[i - 1, j - 1] + cost);
            }

        return D[n, m];
    }
}
