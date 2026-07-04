using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

class UnionFind
{
    private int[] parent;

    public UnionFind(int size)
    {
        parent = new int[size];
        for (int i = 0; i < size; i++)
        {
            parent[i] = i;
        }
    }

    public int Find(int i)
    {
        if (parent[i] == i)
        {
            return i;
        }
        return parent[i] = Find(parent[i]);
    }

    public void Union(int i, int j)
    {
        int rootI = Find(i);
        int rootJ = Find(j);

        if (rootI != rootJ)
        {
            parent[rootI] = rootJ;
        }
    }
}

class path
{
    public int dot1 { get; set; }
    public int dot2 { get; set; }
    public int cost { get; set; }

    public path(int dot1, int dot2, int cost)
    {
        this.dot1 = dot1;
        this.dot2 = dot2;
        this.cost = cost;
    }
}

class Program
{
    static void Main(string[] args)
    {
        int T = int.Parse(Console.ReadLine());
        while (T-- > 0)
        {
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            int m = int.Parse(input[0]);
            int n = int.Parse(input[1]);

            List<path> paths = new List<path>();
            int totalOriginalCost = 0;

            for (int i = 0; i < n; i++)
            {
                input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int d1 = int.Parse(input[0]);
                int d2 = int.Parse(input[1]);
                int cost = int.Parse(input[2]);

                paths.Add(new path(d1, d2, cost));
                totalOriginalCost += cost;
            }

            start_loop:
                Console.WriteLine("Choose Solution:");
                Console.WriteLine("\t1. Kruskal");
                Console.WriteLine("\t2. Prim");
                Console.Write("Your choice:");
                string solution = Console.ReadLine();

                int mstCost = 0;
                switch (solution)
                {
                    case "1": mstCost = Kruskal(paths, m, n); break;
                    case "2": mstCost = Prim(paths, m, n); break;
                    default: Console.WriteLine("error type"); goto start_loop;
                }

            Console.WriteLine(totalOriginalCost - mstCost);
        }
    }

    static int Kruskal(List<path> paths, int m, int n)
    {
        var OrderPath = new PriorityQueue<path, int>(paths.Select(x => (x, x.cost)));

        UnionFind uf = new UnionFind(m);

        int mstTotalCost = 0;
        int edgeCount = 0;

        while (OrderPath.Count > 0 && edgeCount < m - 1)
        {
            var currentEdge = OrderPath.Dequeue();

            int root1 = uf.Find(currentEdge.dot1);
            int root2 = uf.Find(currentEdge.dot2);

            if (root1 != root2)
            {
                mstTotalCost += currentEdge.cost;
                uf.Union(root1, root2);
                edgeCount++;
            }
        }

        return mstTotalCost;
    }

    static int Prim(List<path> paths, int m, int n)
    {
        List<path>[] adj = new List<path>[m];
        for (int i = 0; i < m; i++)
        {
            adj[i] = new List<path>();
        }

        foreach (var p in paths)
        {
            adj[p.dot1].Add(p);
            adj[p.dot2].Add(p);
        }

        int mstTotalCost = 0;
        var pq = new PriorityQueue<path, int>();
        var visit = new HashSet<int>();

        for (int start = 0; start < m; start++)
        {
            if (visit.Contains(start)) continue;

            visit.Add(start);
            foreach (var p in adj[start])
            {
                pq.Enqueue(p, p.cost);
            }

            while (pq.Count > 0 && visit.Count < m)
            {
                path now = pq.Dequeue();
                int targetNode = visit.Contains(now.dot1) ? now.dot2 : now.dot1;

                if (visit.Contains(targetNode))
                {
                    continue;
                }

                visit.Add(targetNode);
                mstTotalCost += now.cost;

                foreach (var p in adj[targetNode])
                {
                    int nextTarget = (p.dot1 == targetNode) ? p.dot2 : p.dot1;
                    if (!visit.Contains(nextTarget))
                    {
                        pq.Enqueue(p, p.cost);
                    }
                }
            }
        }

        return mstTotalCost;
    }
}