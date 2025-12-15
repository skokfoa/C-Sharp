using System;

class node
{
    public int value { get; set; }
    public node left { get; set; }
    public node right { get; set; }

    public node(int value)
    {
        this.value = value;
        left = null;
        right = null;
    }
}

class Program
{
    static void Main(string[] args)
    {
        node root = new node(10);
        root.left = new node(5);
        root.right = new node(15);
        root.left.left = new node(3);
        root.left.right = new node(7);
        root.right.right = new node(20);
        Console.WriteLine("In-order Traversal:");
        InOrderTraversal(root);
    }
    static void InOrderTraversal(node root)
    {
        if (root == null)
            return;
        InOrderTraversal(root.left);
        Console.WriteLine(root.value);
        InOrderTraversal(root.right);
    }
}