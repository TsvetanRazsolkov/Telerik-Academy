using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Sorting
{
    class Program
    {

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int k = int.Parse(Console.ReadLine());

            // key will be hashcode of the current array(permutation)
            // value will be the path to it
            Dictionary<int, int> visited = new Dictionary<int, int>();

            Queue<int[]> queue = new Queue<int[]>();
            // Mark the current node as visited and enqueue it

            queue.Enqueue(numbers);
            visited.Add(GetHashCode(numbers), 0);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                int currentPath = visited[GetHashCode(current)];

                if (IsSortedAscending(current))
                {
                    Console.WriteLine(currentPath);
                    return;
                }

                for (int i = 0; i <= n - k; i++)
                {
                    var perm = current.Clone() as int[];
                    Array.Reverse(perm, i, k);

                    int hash = GetHashCode(perm);
                    if (!visited.ContainsKey(hash))
                    {
                        queue.Enqueue(perm);
                        visited.Add(hash, currentPath + 1);
                    }
                }
            }

            Console.WriteLine(-1);
        }


        private static int GetHashCode(int[] arr)
        {
            int hash = 0;

            foreach (var val in arr)
            {
                hash *= 10;
                hash += val;
            }

            return hash;
        }

        private static bool IsSortedAscending(int[] current)
        {
            for (int i = 1; i < current.Length; i++)
            {
                if (current[i - 1] >= current[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
