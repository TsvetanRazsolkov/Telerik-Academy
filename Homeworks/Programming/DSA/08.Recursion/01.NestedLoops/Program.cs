
/*Write a recursive program that simulates the execution of n nested loopsfrom 1 to n.

Examples:
         1 1
n=2  ->  1 2
         2 1
         2 2

         1 1 1
         1 1 2
         1 1 3
         1 2 1
n=3  ->  ...
         3 2 3
         3 3 1
         3 3 2
         3 3 3*/
namespace _01.NestedLoops
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

        public static void Main()
        {
            n = int.Parse(Console.ReadLine());
            vector = new int[n];

            GenerateLoops(0);
        }

        private static void GenerateLoops(int index)
        {
            if (index == n)
            {
                Console.WriteLine(string.Join(", ", vector));
                return;
            }

            for (int i = 1; i <= n; i++)
            {
                vector[index] = i;

                GenerateLoops(index + 1);
            }
        }
    }
}
