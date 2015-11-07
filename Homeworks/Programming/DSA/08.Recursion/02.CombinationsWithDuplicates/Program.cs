
/*Write a recursive program for generating and printing all the combinations with duplicatesof k elements from n-element set. Example:
n=3, k=2 → (1 1), (1 2), (1 3), (2 2), (2 3), (3 3)*/
namespace _02.CombinationsWithDuplicates
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
        static int k;

        public static void Main()
        {
            Console.WriteLine("Enter integer number n and press ENTER:");
            n = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter integer number k and press ENTER:");
            k = int.Parse(Console.ReadLine());

            vector = new int[k];

            GenerateCombinations(0, 1);
        }

        private static void GenerateCombinations(int index, int start)
        {
            if (index == k)
            {
                Console.WriteLine(string.Join(", ", vector));
                return;
            }

            for (int i = start; i <= n; i++)
            {
                vector[index] = i;

                GenerateCombinations(index + 1, i);
            }
        }
    }
}
