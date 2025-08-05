class project
{
    static void Main(string[] args)
    {
        List<int> startMove = new List<int>();
        List<int> endMove = new List<int>();
        List<int> cost = new List<int>();
        List<string[]> input = new List<string[]>();
        int i = new int();
        while(Console.ReadLine() != null)
        {
            input[i] = Console.ReadLine().Split();
            i++;
        }

        for(int j = 0; j < input.Count; j++)
        {
            startMove.Add(int.Parse(input[j][0]));
            endMove.Add(int.Parse(input[j][1]));
            cost.Add(int.Parse(input[j][2]));
        }
    }
    List<Node> solve(List<int> start, List<int> goal, List<int> cost)
    {
        Queue<Node> queue = new Queue<Node>();
        HashSet<int> visited = new HashSet<int>();

        Node start_node = new Node(1, null);
        int end = 7;

        queue.Enqueue(start_node);
        visited.Add(start_node.status);

        while(queue.Count > 0)
        {
            Node now = queue.Dequeue();
            if(now.status == end)
            {
                return constructPath(now);
            }
            List<Node> nextPath = move(now, start, goal);
            foreach (var path in nextPath)
            {
                if (!visited.Add(path))
                {           
                    queue.Enqueue(path);
                    visited.Add(path);
                }
            }
        }
    }

    List<Node> move(Node now, List<int> start, List<int> goal)
    {
        List<Node> move = new List<Node>();
        for(int i = 0; i < start.Count; i++)
        {
            if(now.status == start[i])
            {
                move.Add(new Node(goal[i], now));
            }
        }
        return move;
    }

    List<Node> constructPath(Node current)
    {
        List<Node> path = new List<Node>();
        while(current != null)
        {
            path.Add(current);
            current = current.father;
        }
        path.Reverse();
        return path;
    }
}

public class Node
{
    public int status;
    public Node father;
    public Node(int status, Node father)
    {
        this.status = status;
        this.father = father;
    }
}