using System;

class Program
{
    static void Main(string[] args)
    {
        List<int[]> queen = new List<int[]>();

        queen = eightEmperors(queen, new int[] { });

        Console.WriteLine("Total solutions: " + queen.Count);
        Console.WriteLine(string.Join("\n", queen.Select(arr => string.Join(",", arr))));
    }

    public static List<int[]> eightEmperors(List<int[]> queen, int[] coord)
    {
        if (coord.Length == 8)
        {
            queen.Add(coord);
            return queen;
        }

        for(int i = 0; i < 8; i++)
        {
            bool canPlace = true;
            for (int j = 0; j < coord.Length; j++)
            {
                if (coord[j] == i || Math.Abs(coord[j] - i) == Math.Abs(j - coord.Length))
                {
                    canPlace = false;
                    break;
                }
            }
            if (canPlace)
            {
                int[] newCoord = new int[coord.Length + 1];
                Array.Copy(coord, newCoord, coord.Length);
                newCoord[coord.Length] = i;
                queen = eightEmperors(queen, newCoord);
            }
        }
        return queen;
    }
}