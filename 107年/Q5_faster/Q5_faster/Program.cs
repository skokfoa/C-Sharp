using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int[] a = Console.ReadLine()
            .Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        // Kadane + 紀錄起訖位置
        int maxSoFar = a[0];      // 目前找到的最大和
        int maxEndHere = a[0];    // 以目前位置結尾的最大和

        int start = 0;            // 最佳子陣列起點
        int end = 0;              // 最佳子陣列終點
        int s = 0;                // 暫時起點

        for (int i = 1; i < n; i++)
        {
            // 判斷要不要「重新開始一段」
            if (maxEndHere + a[i] < a[i])
            {
                maxEndHere = a[i];
                s = i;       // 從 i 重新開始
            }
            else
            {
                maxEndHere += a[i];
            }

            // 更新目前找到的全域最大值
            if (maxEndHere > maxSoFar)
            {
                maxSoFar = maxEndHere;
                start = s;
                end = i;
            }
        }

        Console.WriteLine($"最大和: {maxSoFar}");
        Console.WriteLine($"起始位置: {start}");
        Console.WriteLine($"結束位置: {end}");
    }
}
