using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Queue<Node> queue = new Queue<Node>();

        Console.Write("輸入初始數字:");
        double input = double.Parse(Console.ReadLine()!);

        Console.Write("輸入目標數字:");
        double target = double.Parse(Console.ReadLine()!);

        HashSet<double> visited = new HashSet<double>();

        Node start = new Node(input, null);
        queue.Enqueue(start);
        visited.Add(input);

        while (queue.Count > 0)
        {
            Node node = queue.Dequeue();

            if (node.value == target)
            {
                List<double> path = new List<double>();
                Node current = node;
                while (current != null)
                {
                    path.Add(current.value);
                    current = current.father;
                }
                path.Reverse();
                Console.WriteLine("需要幾步: " + path.Count());
                Console.WriteLine("轉換路徑: " + string.Join(" -> ", path));
                break;
            }

            List<Node> nextPath = move(node);
            foreach (Node nextNode in nextPath)
            {
                if (!visited.Contains(nextNode.value) && nextNode.value > 0 && nextNode.value <= 10000)
                {
                    visited.Add(nextNode.value);
                    queue.Enqueue(nextNode);
                }
            }
        }
        if (queue.Count == 0)
        {
            Console.WriteLine("無法到達目標數字。");
        }
    }

    static List<Node> move(Node status)
    {
        List<Node> nextMoves = new List<Node>();
        double[] operations = { 9, -10, 4, 6};
        for (int i = 0; i < operations.Length; i++)
        {
            switch (i)
            {
                case 0: // +5
                    double add = status.value + operations[i];
                    nextMoves.Add(new Node(add, status));
                    break;
                case 1: // -1
                    double subtract = status.value + operations[i];
                    nextMoves.Add(new Node(subtract, status));
                    break;
                case 2: // *2
                    double multiply = status.value * operations[i];
                    nextMoves.Add(new Node(multiply, status));
                    break;
                case 3:
                    double divide = status.value / operations[i];
                    nextMoves.Add(new Node(divide, status));
                    break;
            }
        }
        return nextMoves;
    }
}

public class Node
{
    public double value;
    public Node father;

    public Node(double value, Node? father)
    {
        this.value = value;
        this.father = father;
    }
}
