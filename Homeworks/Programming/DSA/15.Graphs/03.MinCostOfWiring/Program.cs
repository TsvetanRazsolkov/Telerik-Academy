namespace _03.MinCostOfWiring
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Wintellect.PowerCollections;

    class Program
    {
        static void Main(string[] args)
        {
            // Let the input be pairs of houses and the cable cost between them
            // The resulting graph is connected, so we can use Prim's algorithm for
            // finding the minimum spanning tree to get the lowest cost of cabling
            var input = new string[] {
                "1 2 12",
                "2 3 32",
                "1 4 18",
                "3 7 22",
                "1 5 15",
                "6 7 12",
                "3 4 99",
                "5 3 12",
                "8 1 32",
                "4 7 12",
                "3 8 22"
            };

            Dictionary<int, List<Cable>> graph = FillGraphFromInput(input);

            List<Cable> minimumSpanningTree = Prim(graph);

            var minCostForWiring = minimumSpanningTree.Sum(c => c.Cost);
            Console.WriteLine(minCostForWiring);
        }

        private static List<Cable> Prim(Dictionary<int, List<Cable>> graph)
        {
            var minSpanningTree = new List<Cable>();

            var startHouse = graph.First().Key;

            var orderedCables = new OrderedBag<Cable>();
            foreach (var cable in graph[startHouse])
            {
                orderedCables.Add(cable);
            }

            var visitedHouses = new HashSet<int>();
            visitedHouses.Add(startHouse);

            while (orderedCables.Count > 0)
            {
                var minCostCable = orderedCables.RemoveFirst();
                if (visitedHouses.Contains(minCostCable.ToHouse))
                {
                    continue;
                }

                minSpanningTree.Add(minCostCable);
                visitedHouses.Add(minCostCable.ToHouse);

                foreach (var cable in graph[minCostCable.ToHouse])
                {
                    orderedCables.Add(cable);
                }
            }

            return minSpanningTree;
        }

        private static Dictionary<int, List<Cable>> FillGraphFromInput(string[] input)
        {
            var graph = new Dictionary<int, List<Cable>>();

            foreach (var connection in input)
            {
                var elements = connection.Split(' ');
                int from = int.Parse(elements[0]);
                int to = int.Parse(elements[1]);
                int cost = int.Parse(elements[2]);

                if (!graph.ContainsKey(from))
                {
                    graph.Add(from, new List<Cable>());
                }

                if (!graph.ContainsKey(to))
                {
                    graph.Add(to, new List<Cable>());
                }

                graph[from].Add(new Cable(from, to, cost));
                graph[to].Add(new Cable(to, to, cost));
            }

            return graph;
        }
    }

    class Cable : IComparable<Cable>
    {
        public Cable(int from, int to, int cost)
        {
            this.FromHouse = from;
            this.ToHouse = to;
            this.Cost = cost;
        }

        public int FromHouse { get; private set; }

        public int ToHouse { get; private set; }

        public int Cost { get; private set; }

        public int CompareTo(Cable other)
        {
            return this.Cost.CompareTo(other.Cost);
        }
    }
}
