using System;
using System.Buffers;

class Node
{
    public string State { get; set; }
    public Node Parent { get; set; }
    public string Answer { get; set; }

    public Node(string state, Node parent = null, string answer = null)
    {
        State = state;
        Parent = parent;
        Answer = answer;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("3*3 8-puzzle");
        Console.WriteLine("\t1. Random Number");
        Console.WriteLine("\t2. Enter Number");
        Console.Write("Choose one:");

        string input = Console.ReadLine();

        string num = string.Empty;

        switch (input)
        {
            case "1":
                Random rand = new Random();

                HashSet<int> number = new HashSet<int>();
                while (number.Count < 9)
                {
                    number.Add(rand.Next(0, 9));
                }
                num = string.Join("", number);

                Console.WriteLine($"Generated number: {num}");
                break;
            case "2":
                Console.Write("Enter 9 digits (0-8) without spaces:");
                num = Console.ReadLine();

                if (num.Length != 9 || num.Any(x => x - '0' < 0 || x - '0' > 8))
                {
                    Console.WriteLine("Invalid input");
                    return;
                }

                break;
            default:
                Console.WriteLine("Invalid input");
                return;
        }

        string[] endstate = { "123804765" , "234105876" , "345206187" , "456307218" ,
                              "567408321" , "678501432" , "781602543" , "812703654" };

        Node start = new Node(num);
        Node result = null;

        var bfs = new Queue<Node>();
        var visited = new HashSet<string>();

        bfs.Enqueue(start);

        Console.WriteLine("\nloding...\n");

        while (bfs.Count > 0)
        {
            Node now = bfs.Dequeue();

            foreach (string end in endstate)
            {
                if (now.State == end)
                {
                    now.Answer = end;
                    result = now;
                    break;
                }
            }

            if (visited.Add(now.State) == false) continue;

            List<Node> next = new List<Node>();
            next = move(now);

            foreach (var n in next)
            {
                bfs.Enqueue(n);
            }
        }

        if (result == null)
        {
            Console.WriteLine("No solution found");
            return;
        }

        var path = getPath(result);

        Console.WriteLine($"You Final Answer : {result.Answer}");
        Console.WriteLine($"Solution found in {path.Count - 1} moves:");


        Console.WriteLine(string.Join("\r\n", path.Select(x => string.Join(" ", x.Select((y) => x.IndexOf(y) % 3 == 0 ? $"\r\n{y}" : $"{y}" )))));
    }


    public static List<Node> move (Node now)
    {
        List<Node> next = new List<Node>();
        int[] num = now.State.Select(x => x - '0').ToArray();

        int index = Array.IndexOf(num, 0);

        if (index % 3 != 0)//left
        {
            int[] clone = (int[])num.Clone();
            swap(ref clone[index], ref clone[index - 1]);
            string newstate = string.Join("", clone);
            next.Add(new Node(newstate,now));
        }

        if (index % 3 != 2)//right
        {
            int[] clone = (int[])num.Clone();
            swap(ref clone[index], ref clone[index + 1]);
            string newstate = string.Join("", clone);
            next.Add(new Node(newstate, now));
        }

        if (index / 3 != 0)//up
        {
            int[] clone = (int[])num.Clone();
            swap(ref clone[index], ref clone[index - 3]);
            string newstate = string.Join("", clone);
            next.Add(new Node(newstate, now));
        }

        if (index / 3 != 2)//down
        {
            int[] clone = (int[])num.Clone();
            swap(ref clone[index], ref clone[index + 3]);
            string newstate = string.Join("", clone);
            next.Add(new Node(newstate, now));
        }

        return next;
    }

    public static List<string> getPath(Node result)
    {
        List<string> path = new List<string>();
        Node now = result;
        while (now != null)
        {
            path.Add(now.State);
            now = now.Parent;
        }
        path.Reverse();
        return path;
    }

    public static void swap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }
}