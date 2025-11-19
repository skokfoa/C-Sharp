using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter number:");

        if (!int.TryParse(Console.ReadLine(), out int n))
        {
            Console.WriteLine("Invalid input. Please enter a valid integer.");
            return;
        }

        if (n < 1 || n > 50)
        {
            Console.WriteLine("Number out of range. Please enter a number between 1 and 50.");
            return;
        }

        List<List<int>> path = new List<List<int>>();

        GeneratePaths(n, path);

        var result = path.OrderBy(p => p.Count);

        Console.WriteLine(string.Join(Environment.NewLine, result.Select(p => string.Join(", ", p))));
        

    }

    private static void GeneratePaths(int n, List<List<int>> allPaths, List<int> currentPath = null)
    {
        if (currentPath == null)
            currentPath = new List<int>();

        if (n <= 0)
        {
            allPaths.Add(new List<int>(currentPath));
            return;
        }

        if (n - 1 >= 0)
        {
            currentPath.Add(1);
            GeneratePaths(n - 1, allPaths, currentPath);
            currentPath.RemoveAt(currentPath.Count - 1);
        }

        if (n - 2 >= 0)
        {
            currentPath.Add(2);
            GeneratePaths(n - 2, allPaths, currentPath);
            currentPath.RemoveAt(currentPath.Count - 1);
        }
    }
}   