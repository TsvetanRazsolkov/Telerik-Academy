using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algoStuff
{
    class MaximalPath
    {
        static Dictionary<int, Node> tree = new Dictionary<int, Node>();
        static Dictionary<int, bool> used = new Dictionary<int, bool>();
        static long maxPath = long.MinValue;
        static long currentPath = 0;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n - 1; i++)
            {
                var nums = Console.ReadLine()
                    .Split(new char[] {'(', ')', ' ', '<', '-' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                if (!tree.ContainsKey(nums[0]))
                {
                    tree.Add(nums[0], new Node(nums[0]));
                    if (!used.ContainsKey(nums[0]))
                    {
                        used.Add(nums[0], false);
                    }
                }

                var parent = tree[nums[0]];

                // for child
                if (!tree.ContainsKey(nums[1]))
                {
                    tree.Add(nums[1], new Node(nums[1]));
                    if (!used.ContainsKey(nums[1]))
                    {
                        used.Add(nums[1], false);
                    }
                }

                var child = tree[nums[1]];
                parent.Children.Add(child);
                child.Children.Add(parent);
            }

            foreach (var node in tree)
            {
                if (node.Value.Children.Count == 1)
                {
                    TraverseDFS(node.Value);
                }
            }

            Console.WriteLine(maxPath);
        }

        private static void TraverseDFS(Node node)
        {
            currentPath += node.Value;

            used[node.Value] = true;

            foreach (var child in node.Children)
            {
                if (used[child.Value])
                {
                    continue;
                }

                TraverseDFS(child);
            }
            used[node.Value] = false;
            maxPath = Math.Max(maxPath, currentPath);
            currentPath -= node.Value;
        }        
    }

    class Node
    {
        public Node(int value)
        {
            this.Value = value;
            this.Children = new List<Node>();
        }

        public int Value { get; set; }

        public List<Node> Children { get; set; }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}
