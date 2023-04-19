using CSC595_IntroToAI_DFSandBFS;
using System.Xml.Linq;

public class Program
{
    public static void Main()
    {
        Console.Write("Max value each node can have: ");
        int maxVal = Convert.ToInt32(Console.ReadLine());
        Console.Write("Number of levels the tree should have: ");
        int levels = Convert.ToInt32(Console.ReadLine());
        Console.Write("What value should the algorithms try to find: ");
        int val = Convert.ToInt32(Console.ReadLine());
        Tree tree =new(maxVal, levels);

        tree.printTree();

        Console.WriteLine("\nStarting PreOrder:");
        Console.WriteLine(dfsPreOrder(tree.Root, val));
        Console.WriteLine("-----------------");

        Console.WriteLine("\nStarting PostOrder:");
        Console.WriteLine(dfsPostOrder(tree.Root, val));
        Console.WriteLine("-----------------");

        Console.WriteLine("\nStarting InOrder:");
        Console.WriteLine(dfsInOrder(tree.Root, val));
        Console.WriteLine("-----------------");

        Console.WriteLine("\nStarting BFS:");
        Console.WriteLine(bfs(tree.Root, val));
        Console.WriteLine("-----------------");

    }

    public static bool dfsPreOrder(Node node, int val) {
        if (node == null) return false;

        Console.Write($"{node.Val} ");
        if (node.Val == val) return true; 

        return dfsPreOrder(node.Left, val) || dfsPreOrder(node.Right, val);
        

    }


    public static bool dfsPostOrder(Node node, int val)
    {
        if (node == null) return false;

        if (dfsPostOrder(node.Left, val)) return true;

        if (dfsPostOrder(node.Right, val)) return true;

        Console.Write($"{node.Val} ");
        if (node.Val == val) return true;
        
        return false;
    }

    public static bool dfsInOrder(Node node, int val)
    {
        if (node == null) return false;


        if (dfsInOrder(node.Left, val)) return true;


        Console.Write($"{node.Val} ");
        if (node.Val == val) return true;

        if (dfsInOrder(node.Right, val)) return true;

        return false;
    }
    public static bool bfs(Node node, int val)
    {
        if (node == null) return false;

        Queue<Node> q = new();

        q.Enqueue(node);
        while (q.Count != 0)
        {
            Node n = q.Dequeue();
            Console.Write($"{n.Val} ");

            if (n.Val == val) return true;

            if (n.Left != null) q.Enqueue(n.Left);
            if (n.Right != null) q.Enqueue(n.Right);
        }
        return false;

    }

    public static void print(string algo, List<Node> visited)
    {
        Console.WriteLine($"Using the algorithm '{algo}', this is the order of the nodes that were visited");
        Console.Write("[ ");
        foreach(Node n in visited)
        {
            Console.Write($"{n.Val} ");
        }
        Console.WriteLine(" ]");
    }
}