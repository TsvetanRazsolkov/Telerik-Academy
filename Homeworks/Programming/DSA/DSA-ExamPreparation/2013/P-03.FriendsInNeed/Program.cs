namespace P_03.FriendsInNeed
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class Program
    {
        static int absoluteShortestPath = int.MaxValue;

        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ')
                                                   .Select(x => int.Parse(x))
                                                   .ToArray();

            HashSet<int> hospitals = new HashSet<int>(
                                                      Console.ReadLine()
                                                      .Split(' ')
                                                      .Select(x => int.Parse(x)));

            int nodes = input[0]; // points on the map
            int edges = input[1]; // streets

            Dictionary<Node, List<Edge>> graph = new Dictionary<Node, List<Edge>>();
            Dictionary<int, Node> nodeNames = new Dictionary<int, Node>();

            for (int i = 0; i < edges; i++)
            {
                var edge = Console.ReadLine().Split(' ')
                                             .Select(x => int.Parse(x))
                                             .ToArray();
                int fromNode = edge[0];
                int toNode = edge[1];
                int weight = edge[2];

                if (!nodeNames.ContainsKey(fromNode))
                {
                    Node node = new Node(fromNode);
                    nodeNames.Add(fromNode, node);
                    graph.Add(node, new List<Edge>());
                }

                if (!nodeNames.ContainsKey(toNode))
                {
                    Node node = new Node(toNode);
                    nodeNames.Add(toNode, node);
                    graph.Add(node, new List<Edge>());
                }

                graph[nodeNames[fromNode]].Add(new Edge(nodeNames[toNode], weight));
                graph[nodeNames[toNode]].Add(new Edge(nodeNames[fromNode], weight)); // Two way streets;
            }

            // for each hospital - dijkstra to each of the houses(not the other hospitals - check for them in the hospitals hashset)
            // Then sum the shortest paths to all the houses and compare with the absolute minimum path
            foreach (var hospital in hospitals)
            {
                foreach (var pair in graph)
                {
                    pair.Key.Path = int.MaxValue;
                }

                var startNode = nodeNames[hospital];
                startNode.Path = 0;

                var queue = new OrderedBag<Node>(); // Will do the work as a priority queue in this case;
                queue.Add(startNode);
                while (queue.Count > 0)
                {
                    var minPathNode = queue.RemoveFirst();
                    if (minPathNode.Path == int.MaxValue)
                    {
                        break;
                    }

                    var minPathNodeEdges = graph[minPathNode];
                    foreach (var edge in minPathNodeEdges)
                    {
                        int path = minPathNode.Path + edge.Weight;
                        if (path < edge.ToNode.Path)
                        {
                            edge.ToNode.Path = path;
                            queue.Add(edge.ToNode);
                        }
                    }
                }

                int currentPath = 0;
                foreach (var pair in nodeNames)
                {
                    if (!hospitals.Contains(pair.Key))
                    {
                        currentPath += pair.Value.Path;
                    }
                }

                if (currentPath < absoluteShortestPath)
                {
                    absoluteShortestPath = currentPath;
                }
            }

            Console.WriteLine(absoluteShortestPath);
        }
    }

    public class Node : IComparable<Node>
    {
        public Node(int name)
        {
            this.Name = name;
        }

        public int Name { get; set; }

        public int Path { get; set; }

        public int CompareTo(Node other)
        {
            return this.Path.CompareTo(other.Path);
        }
    }

    public class Edge
    {
        public Edge(Node toNode, int weight)
        {
            this.ToNode = toNode;
            this.Weight = weight;
        }

        public Node ToNode { get; set; }

        public int Weight { get; set; }
    }
}
