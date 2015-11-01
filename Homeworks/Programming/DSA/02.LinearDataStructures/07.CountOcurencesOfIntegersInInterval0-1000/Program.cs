/*Write a program that finds in given array of integers (all belonging to the range [0..1000]) how many times each of them occurs.
Example: array = {3, 4, 4, 2, 3, 3, 4, 3, 2}
2 → 2 times
3 → 4 times
4 → 3 times*/
namespace _07.CountOcurencesOfIntegersInInterval0_1000
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var integers = new int[] { 3, 4, 4, 2, 3, 3, 4, 3, 2 };
            Console.WriteLine(string.Join(", ", integers));

            // Can be done with a dictionary similar to the previous task, but considering the specific interval let's try it this way:
            int[] occurencesCounter = new int[1001];

            for (int i = 0; i < integers.Length; i++)
            {
                occurencesCounter[integers[i]]++;
            }

            Console.WriteLine("With an array of length 1001:");
            for (int i = 0; i < occurencesCounter.Length; i++)
            {
                if (occurencesCounter[i] != 0)
                {
                    Console.WriteLine("{0} -> {1} times", i, occurencesCounter[i]);
                }
            }

            // And now with a dictionary:
            var occurences = integers.GroupBy(n => n)
                                     .ToDictionary(gr => gr.Key, gr => gr.Count());

            Console.WriteLine("With a dictionary:");
            foreach (var pair in occurences)
            {
                Console.WriteLine("{0} -> {1} times", pair.Key, pair.Value);
            }
        }
    }
}
