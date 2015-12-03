using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_04.RiskWinsRiskLoses
{
    class Program
    {
        static int[] targetArr;

        // Key is the current combination's hash
        // Value is the steps it takes to get to it
        static Dictionary<int, int> visited = new Dictionary<int, int>();


        static void Main(string[] args)
        {
            string start = Console.ReadLine();
            var startArr = start.ToCharArray().Select(c => c - '0').ToArray();

            string targer = Console.ReadLine();
            targetArr = targer.ToCharArray().Select(c => c - '0').ToArray();

            int forbiddenCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < forbiddenCount; i++)
            {
                var forbidden = Console.ReadLine().ToCharArray().Select(c => c - '0').ToArray();

                int hash = GetHashCode(forbidden);
                // this check is necessary, because on soe of the tests the forbidden combos are given as input more than once
                if (!visited.ContainsKey(hash))
                {
                    visited.Add(hash, 0);
                }
            }

            int shortest = FindShortestPathWithBFS(startArr, targetArr);

            Console.WriteLine(shortest);

            //// This solution gives 84 points 
            //int operations = 0;
            //for (int i = 0; i < start.Length; i++)
            //{
            //    operations += Math.Min(Math.Abs((start[i] - '0') - (targer[i] - '0')), 10 - Math.Abs((start[i] - '0') - (targer[i] - '0')));
            //}

            //Console.WriteLine(operations);
        }

        private static int FindShortestPathWithBFS(int[] start, int[] target)
        {
            var queue = new Queue<int[]>();

            queue.Enqueue(start);
            visited.Add(GetHashCode(start), 0);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                int currentPath = visited[GetHashCode(current)];

                for (int i = 0; i < current.Length; i++)
                {
                    int[] perm = PushLeftButton(current, i);
                    if (IsTarget(perm))
                    {
                        return currentPath + 1;
                    }

                    int hash = GetHashCode(perm);
                    if (!visited.ContainsKey(hash))
                    {
                        queue.Enqueue(perm);
                        visited.Add(hash, currentPath + 1);
                    }

                    perm = PushRightPutton(current, i);
                    if (IsTarget(perm))
                    {
                        return currentPath + 1;
                    }

                    hash = GetHashCode(perm);
                    if (!visited.ContainsKey(hash))
                    {
                        queue.Enqueue(perm);
                        visited.Add(hash, currentPath + 1);
                    }
                }
            }

            return -1;
        }

        private static bool IsTarget(int[] current)
        {
            for (int i = 0; i < current.Length; i++)
            {
                if (current[i] != targetArr[i])
                {
                    return false;
                }
            }

            return true;
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

        private static int[] PushRightPutton(int[] current, int index)
        {
            var result = current.Clone() as int[];
            if (result[index] == 9)
            {
                result[index] = 0;
            }
            else
            {

                result[index] += 1;
            }

            return result;
        }

        private static int[] PushLeftButton(int[] current, int index)
        {
            var result = current.Clone() as int[];
            if (result[index] == 0)
            {
                result[index] = 9;
            }
            else
            {

                result[index] -= 1;
            }

            return result;
        }
    }
}
