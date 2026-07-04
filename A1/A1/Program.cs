public class Solution
{
    static void Main(string[] args)
    {
        int[] nums = Console.ReadLine()
                    .Split(new char[] { ' ', ',', '[', ']' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
        int target = int.Parse(Console.ReadLine());

        int n = nums.Length;
        int i, j;
        i = j = new int();
        int[,] dym = new int[n, n];
        for (i = 0; i < n; i++)
            dym[i, 0] = nums[i];


        for (i = 1; i < n; i++)
        {
            for (j = 0; j < n; j++)
            {
                if (i == j) continue;
                dym[i, j] = dym[i, 0] + nums[j];
                Console.Write(dym[i, j] + " ");
                if (dym[i, j] == target) break;
            }
            Console.WriteLine();
        }
        int[] result = new int[] { i, j };
    }
}