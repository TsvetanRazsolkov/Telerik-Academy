using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.SuperSum
{
    class Program
    {
        // For the recursive solution
        private static long sum;

        // For the DP solution
        private static long[,] supersums;

        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            int k = input[0];
            int n = input[1];
            
            // Naive recursive solution - still works for a 100 points, running time = 0.140s
            sum = 0;
            //SupersumRecursive(k, n);

            // DP solution - running time = 0.015s
            supersums = new long[k + 1, n + 1];

            SupersumDP();

            Console.WriteLine(supersums[k, n]);
            //Console.WriteLine(sum);
        }

        private static void SupersumDP()
        {
            for (int i = 0; i < supersums.GetLength(0); i++)
            {
                // Starts from 1, because for every K the supersum with N = 0 will be 0;
                for (int j = 1; j < supersums.GetLength(1); j++)
                {
                    if (i == 0) // СуперСума(0, N) = N, за всяко положително цяло число N.
                    {
                        supersums[i, j] = j;
                    }
                    else
                    {
                        // To see why write it down on a piece of paper as a table for let's say k = 2 and n = 3 ;)
                        supersums[i, j] = supersums[i - 1, j] + supersums[i, j - 1];
                    }
                }
            }
        }

        private static void SupersumRecursive(int k, int n)
        {
            if (k == 0)
            {
                sum += n;
                return;
            }

            for (int i = 1; i <= n; i++)
            {
                SupersumRecursive(k - 1, i);
            }
        }
    }
}
