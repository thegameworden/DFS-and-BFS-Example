

namespace CSC595_IntroToAI_DFSandBFS
{

    public class Node
    {
        int val;
        Node left;
        Node right;

        public Node(int val)
        {
            this.val = val;
        }

        public int Val { get => val; set => val = value; }
        public Node Left { get => left; set => left = value; }
        public Node Right { get => right; set => right = value; }
    }
    public class Tree
    {
        Node root;
        int maxVal;
        int levels;
        public Tree(int maxVal, int levels)
        {
            this.maxVal = maxVal;
            this.levels = levels;
            Random random= new Random();
            root = new(random.Next(maxVal + 1));
            populate(root,1);
            

        
        }

        private void populate(Node node,int currLevel) {
            if (currLevel == levels) return;

            Random random = new Random();
            node.Left = new Node(random.Next(maxVal + 1));
            node.Right = new Node(random.Next(maxVal + 1));

            populate(node.Left,currLevel+1);
            populate(node.Right,currLevel+1);

        }

        public void printTree()
        {
            Console.WriteLine("Printing Tree");
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);
            while(queue.Count > 0)
            {
               Node n = queue.Dequeue();
                if (n.Left == null && n.Right == null) continue;

                Console.Write($"Node {n.Val} -> [ ");
                if (n.Left != null) {
                    Console.Write($"{n.Left.Val} ");
                    queue.Enqueue(n.Left); 
                }
                if (n.Right != null)
                {
                    Console.Write($"{n.Right.Val} ");
                    queue.Enqueue(n.Right);
                }
                Console.WriteLine("]");
            }

        }

        internal Node Root { get => root; set => root = value; }
    }
}
