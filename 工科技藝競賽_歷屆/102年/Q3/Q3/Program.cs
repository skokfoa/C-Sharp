using System.Collections.Generic;

class path
{
    public int to;
    public int cost;

    public path(int to, int cost)
    {
        this.to = to;
        this.cost = cost;
    }
}

class Project
{
    static void Main()
    {
        Dictionary<int, List<path>> graph = new Dictionary<int, List<path>>();
        Console.WriteLine("請輸入路徑：");
        string input = string.Empty;
        while(!string.IsNullOrEmpty(input = Console.ReadLine()))
        {
            string[] paths = input.Split(" ");
            int from = int.Parse(paths[0]);
            int to = int.Parse(paths[1]);
            int cost = int.Parse(paths[2]);

            if (!graph.ContainsKey(from))
                graph[from] = new List<path>();
            
            graph[from].Add(new path(to, cost));
        }

        Console.WriteLine("請輸入起點與終點：");
        string[] points = Console.ReadLine().Split(" ");
        int start = int.Parse(points[0]);
        int end = int.Parse(points[1]);

        var (dist, prev) = Dijkstra(graph, start);

        if (!dist.ContainsKey(end) || dist[end] == int.MaxValue)
        {
            Console.WriteLine($"從 {start} 到 {end} 沒有路徑。");
            return;
        }

        Console.WriteLine($"最低成本 = {dist[end]}");

        List<int> path = ReconstructPath(prev, start, end);
        Console.WriteLine("路徑: " + string.Join(" -> ", path));
    }

    static (Dictionary<int, int>, Dictionary<int, int>) Dijkstra(Dictionary<int, List<path>> graph, int start)
    {
        var dist = new Dictionary<int, int>();
        var prev = new Dictionary<int, int>();
        var pq = new PriorityQueue<int, int>();

        foreach (var node in graph.Keys)
        {
            dist[node] = int.MaxValue;
            prev[node] = -1;
        }
        dist[start] = 0;
        pq.Enqueue(start, 0);

        while(pq.Count > 0)
        {
            pq.TryDequeue(out int u, out int d);
            if (d > dist[u]) continue;
            if (!graph.ContainsKey(u)) continue;

            foreach (var edge in graph[u])
            {
                int v = edge.to;
                int cost = d+edge.cost; 
                if (!dist.ContainsKey(v) || cost < dist[v])
                {
                    dist[v] = cost;
                    prev[v] = u;
                    pq.Enqueue(v, cost);
                }
            }
        }
        return (dist, prev);
    }

    static List<int> ReconstructPath(Dictionary<int, int> prev, int s, int t)
    {
        List<int> path = new List<int>();
        for (int v = t; v != -1; v = prev.ContainsKey(v) ? prev[v] : -1)
            path.Add(v);
        path.Reverse(); 
        return path;
    }
}