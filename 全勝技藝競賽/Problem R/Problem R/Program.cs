using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata;

class Node
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Sum { get; set; }
    public Node father { get; set; }

    public Node(int x, int y, int sum, Node father)
    {
        X = x;
        Y = y;
        Sum = sum;
        this.father = father;
    }
}

class Program
{
    static void Main(string[] args)
    {
        int n, m;
        string[] input = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);

        n = int.Parse(input[0]);
        m = int.Parse(input[1]);

        int[,] maze = new int[n, m];
        
        for(int i = 0; i < n; i++)
        {
            string[] rowInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            for (int j = 0; j < m; j++)
            {
                maze[i, j] = int.Parse(rowInput[j]);
            }
        }

        int[,] minCost = new int[n, m];
        for (int i = 0; i < n; i++)
            for (int j = 0; j < m; j++)
                minCost[i, j] = int.MaxValue;

        PriorityQueue<Node, int> pq = new PriorityQueue<Node, int>();

        Node startNode = new Node(0, 0, 0, null);
        pq.Enqueue(startNode, startNode.Sum);
        minCost[0, 0] = 0;

        while (pq.Count > 0)
        {
            Node now = pq.Dequeue();

            if (now.X == n - 1 && now.Y == m - 1)
            {
                Console.WriteLine(now.Sum);
                return;
            }

            if (now.Sum > minCost[now.X, now.Y]) continue;

            if (now.X + 1 < n)
            {
                int nextSum = now.Sum + maze[now.X + 1, now.Y];
                if (nextSum < minCost[now.X + 1, now.Y])
                {
                    minCost[now.X + 1, now.Y] = nextSum;
                    pq.Enqueue(new Node(now.X + 1, now.Y, nextSum, now), nextSum);
                }
            }

            if (now.Y + 1 < m)
            {
                int nextSum = now.Sum + maze[now.X, now.Y + 1];
                if (nextSum < minCost[now.X, now.Y + 1])
                {
                    minCost[now.X, now.Y + 1] = nextSum;
                    pq.Enqueue(new Node(now.X, now.Y + 1, nextSum, now), nextSum);
                }
            }
        }

        Console.WriteLine("No path found");
    }
}