using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.RecoverMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, Node> graph = new Dictionary<char, Node>();
            var noIncommingEdges = new SortedSet<char>();

            // Read input:
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine();
                if (!graph.ContainsKey(line[0]))
                {
                    graph.Add(line[0], new Node(line[0]));
                }

                var previousNode = graph[line[0]]; 

                for (int j = 1; j < line.Length; j++)
                {

                    if (!graph.ContainsKey(line[j]))
                    {
                        graph.Add(line[j], new Node(line[j]));
                    }

                    var currentNode = graph[line[j]];

                    previousNode.Successors.Add(currentNode);
                    currentNode.Predecessors.Add(previousNode);

                    previousNode = currentNode;
                }
            }

            // Topological sorting:
            var result = new List<char>();
            foreach (var item in graph)
            {
                if (item.Value.Predecessors.Count == 0)
                {
                    noIncommingEdges.Add(item.Key);
                }
            }

            while (noIncommingEdges.Count > 0)
            {
                var currenNodeSmbol = noIncommingEdges.Min;
                noIncommingEdges.Remove(currenNodeSmbol);

                result.Add(currenNodeSmbol);

                var currentNode = graph[currenNodeSmbol];

                // ToList() here, so that enumeration of changing collection does not throw InvalidOperationException
                var successors = currentNode.Successors.ToList();
                foreach (var child in successors)
                {
                    child.Predecessors.Remove(currentNode);
                    currentNode.Successors.Remove(child);

                    if (child.Predecessors.Count == 0)
                    {
                        noIncommingEdges.Add(child.Value);
                    }
                }
            }

            Console.WriteLine(string.Join("", result));
        }
    }

    class Node
    {
        public Node(char value)
        {
            this.Value = value;
            this.Predecessors = new List<Node>();
            this.Successors = new List<Node>();
        }

        public char Value { get; set; }

        public List<Node> Successors { get; set; }

        public List<Node> Predecessors { get; set; }
    }
}
