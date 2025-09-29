class path
{
    public int to;
    public double cost;

    public path(int to, double cost)
    {
        this.to = to;
        this.cost = cost;
    }
}

class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        path[] p = new path[n];

        Dictionary<int,List<path>> dict = new Dictionary<int,List<path>>();
        for (int i = 0; i < n; i++)
        {
            double[] x = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            for(int j = 0;j < n; j++)
            {
                if(x[j] != 0)
                {
                    if(!dict.ContainsKey(i))
                    {
                        dict[i] = new List<path>();
                    }
                    dict[i].Add(new path(j, x[j]));
                }
            }
        }

        var input = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        int start = input[0] - 1;
        int goal = input[1] - 1;

        var dist = new Dictionary<int, double>();
        var prev = new Dictionary<int, int?>();
        var queue = new SortedSet<(double cost, int node)>();
        for (int i = 0; i < n; i++)
        {
            dist[i] = double.MaxValue;
            prev[i] = null;
            queue.Add((dist[i], i));
        }
        dist[start] = 0;
        queue.Add((dist[start], start));
        while (queue.Count > 0)
        {
            var (cost, node) = queue.Min;
            queue.Remove(queue.Min);
            if (node == goal)
            {
                break;
            }

            if (!dict.ContainsKey(node))
            {
                continue;
            }
            foreach (var edge in dict[node])
            {
                double newCost = cost + edge.cost;
                if (newCost < dist[edge.to])
                {
                    queue.Remove((dist[edge.to], edge.to));
                    dist[edge.to] = newCost;
                    prev[edge.to] = node;
                    queue.Add((dist[edge.to], edge.to));
                }
            }
        }

        if (dist[goal] == double.MaxValue)
        {
            Console.WriteLine("No path");
        }
        else
        {
            List<int> path = new List<int>();
            for (int? at = goal; at != null; at = prev[at.Value])
            {
                path.Add(at.Value + 1);
            }
            path.Reverse();
            Console.WriteLine($"最快的闖關路線[{start + 1} -> {goal + 1}]: " + string.Join("->", path) +　$" (路途險峻程度 {dist[goal]:0.##})");
        }

        return;
    }
}