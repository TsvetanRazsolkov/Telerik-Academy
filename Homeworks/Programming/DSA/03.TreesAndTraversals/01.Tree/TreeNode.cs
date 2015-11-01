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
    using System.Collections.Generic;

    public class TreeNode<T>
    {
        public TreeNode(T value)
        {
            this.Value = value;
            this.HasParent = false;
            this.Children = new List<TreeNode<T>>();
        }

        public T Value { get; private set; }

        public List<TreeNode<T>> Children { get; private set; }

        public bool HasParent { get; private set; }

        public void AddChild(TreeNode<T> child)
        {
            child.HasParent = true;
            this.Children.Add(child);
        }
    }
}
