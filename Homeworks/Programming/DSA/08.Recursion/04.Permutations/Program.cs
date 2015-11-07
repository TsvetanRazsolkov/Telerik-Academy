
/*Write a recursive program for generating and printing all permutations of the numbers 1, 2, ..., n for given integer number n. Example:
n=3 → {1, 2, 3}, {1, 3, 2}, {2, 1, 3}, {2, 3, 1}, {3, 1, 2},{3, 2, 1}*/
namespace _04.Permutations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        static int[] vector;
        static int n;
        static bool[] used;

        public static void Main()
        {
            Console.WriteLine("Enter integer number n and press ENTER:");
            n = int.Parse(Console.ReadLine());

            vector = new int[n];
            used = new bool[n + 1];

            GeneratePermutations(0);
        }

        private static void GeneratePermutations(int index)
        {
            if (index == n)
            {
                Console.WriteLine(string.Join(", ", vector));
                return;
            }

            for (int i = 1; i <= n; i++)
            {
                if (!used[i])
                {
                    vector[index] = i;
                    used[i] = true;
                    GeneratePermutations(index + 1);
                    used[i] = false;
                }
            }
        }
    }
}
