/*You are given a tree of N nodes represented as a set of N-1 pairs of nodes
(parent node, child node), each in the range (0..N-1). 
Write a program to read the tree and find:

the root node
all leaf nodes
all middle nodes
the longest path in the tree
(*) all paths in the tree with given sum `S` of their nodes
(*) all subtrees with given sum `S` of their nodes*/
namespace _01.Tree
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Program
    {
        private const string Input = @"7
2 4
3 2
5 0
3 5
5 6
5 1
";

        public static void Main()
        {
            Console.SetIn(new StringReader(Input));
            var nodes = ReadInput();

            // First three tasks can be solved by just analyzing the input.
            // -If we have an element on the left and it is missing on the right part of the input - it is the root.
            // -Analogically if an element is only found on the right side of the input - it is a leaf.
            // -If an element is on the both sides of the input lines - it is a middle node.

            // Find the root node:
            var rootNode = FindRoot(nodes);
            Console.WriteLine("Root node -> {0}", rootNode.Value);

            // Find all leaf nodes:
            var leafs = FindLeafs(nodes);
            Console.WriteLine("Leaf nodes -> {0}", string.Join(", ", leafs));

            // Find all middle nodes:
            var middleNodes = FindMiddleNodes(nodes);
            Console.WriteLine("Middle nodes -> {0}", string.Join(", ", middleNodes));

            // Find the longest path in the tree - the tree is directed, so the longest path is the longest path from the root to a leaf;
            int longestPath = FindLongestPath(rootNode);
            Console.WriteLine("Longest path from root -> {0}", longestPath);
        }

        private static int FindLongestPath(TreeNode<int> node)
        {
            if (node.Children.Count == 0)
            {
                return 0;
            }

            int longestPath = 0;
            foreach (var child in node.Children)
            {
                longestPath = Math.Max(longestPath, FindLongestPath(child));
            }

            return longestPath + 1;
        }

        private static List<int> FindMiddleNodes(TreeNode<int>[] nodes)
        {
            var middleNodes = new List<int>();

            foreach (var node in nodes)
            {
                if (node.Children.Count != 0 && node.HasParent)
                {
                    middleNodes.Add(node.Value);
                }
            }

            return middleNodes;
        }

        private static List<int> FindLeafs(TreeNode<int>[] nodes)
        {
            var leafs = new List<int>();

            foreach (var node in nodes)
            {
                if (node.Children.Count == 0)
                {
                    leafs.Add(node.Value);
                }
            }

            return leafs;
        }

        private static TreeNode<int> FindRoot(TreeNode<int>[] nodes)
        {
            foreach (var node in nodes)
            {
                if (!node.HasParent)
                {
                    return node;
                }
            }

            throw new ArgumentException("Tree has no root.");
        }

        private static TreeNode<int>[] ReadInput()
        {
            int n = int.Parse(Console.ReadLine());

            var nodes = new TreeNode<int>[n];

            for (int i = 0; i < n; i++)
            {
                nodes[i] = new TreeNode<int>(i);
            }

            for (int i = 0; i < n - 1; i++)
            {
                var nodesFromInputLine = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                                           .Select(x => int.Parse(x))
                                                           .ToList();
                int parentNodeIndex = nodesFromInputLine[0];
                int childNodeIndex = nodesFromInputLine[1];

                nodes[parentNodeIndex].AddChild(nodes[childNodeIndex]);
            }

            return nodes;
        }
    }
}
