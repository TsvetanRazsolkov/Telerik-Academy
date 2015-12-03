using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_02.Renewal
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read input:
            int n = int.Parse(Console.ReadLine());

            List<string> paths = new List<string>();
            List<string> builds = new List<string>();
            List<string> destroys = new List<string>();

            for (int i = 0; i < n; i++)
            {
                paths.Add(Console.ReadLine());
            }

            for (int i = 0; i < n; i++)
            {
                builds.Add(Console.ReadLine());
            }

            for (int i = 0; i < n; i++)
            {
                destroys.Add(Console.ReadLine());
            }

            int totalCost = 0;

            List<Edge> edges = new List<Edge>();
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (paths[i][j] == '0')
                    {
                        edges.Add(new Edge(i, j, GetValue(builds[i][j])));
                    }
                    else
                    {
                        int value = GetValue(destroys[i][j]);
                        edges.Add(new Edge(i, j, -value));
                        totalCost += value;
                    }
                }
            }

            // Solve using Kruskal for minimum spanning tree:
            edges.Sort();
            int minSpanningDistance = 0;

            var visited = new HashSet<int>();
            var roots = new int[n];
            for (int i = 0; i < n; i++)
            {
                roots[i] = i;
            }

            for (int i = 0; i < edges.Count; i++)
            {
                var edge = edges[i];
                var v1 = edge.V1;
                var v2 = edge.V2;
                if (visited.Contains(v1) && visited.Contains(v2))
                {
                    if (roots[v1] == roots[v2])
                    {
                        continue;
                    }

                    minSpanningDistance += edge.Weight;

                    var oldRoot = roots[v2];
                    var newRoot = roots[v1];
                    for (int j = 0; j < roots.Length; j++)
                    {
                        if (roots[j] == oldRoot)
                        {
                            roots[j] = newRoot;
                        }
                    }
                }
                else if (visited.Contains(v1))
                {
                    // v2 is not in a tree
                    roots[v2] = roots[v1];
                    minSpanningDistance += edge.Weight;
                }
                else if (visited.Contains(v2))
                {
                    // v1 is not in a tree
                    roots[v1] = roots[v2];
                    minSpanningDistance += edge.Weight;
                }
                else
                {
                    // build new tree
                    minSpanningDistance += edge.Weight;
                    roots[v1] = v1;
                    roots[v2] = roots[v1];
                }

                visited.Add(v1);
                visited.Add(v2);
			}

            Console.WriteLine(minSpanningDistance + totalCost);
        }

        static int GetValue(char c)
        {
            if (c >= 'A' && c <= 'Z')
            {
                return c - 'A';
            }
            else
            {
                return c - 'a' + 26;
            }
        }
    }

    class Edge : IComparable<Edge>
    {
        public Edge(int v1, int v2, int weight)
        {
            this.V1 = v1;
            this.V2 = v2;
            this.Weight = weight;
        }

        public int V1 { get; set; }

        public int V2 { get; set; }

        public int Weight { get; set; }

        public int CompareTo(Edge other)
        {
            return this.Weight.CompareTo(other.Weight);
        }
    }
}
