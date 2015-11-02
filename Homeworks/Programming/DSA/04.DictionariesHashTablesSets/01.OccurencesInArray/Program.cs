
/*Write a program that counts in a given array of double values the number of occurrences of each value. Use Dictionary<TKey,TValue>.

Example: array = {3, 4, 4, -2.5, 3, 3, 4, 3, -2.5}

-2.5 -> 2 times

3 -> 4 times

4 -> 3 times*/
namespace _01.OccurencesInArray
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            double[] numbers = new double[] { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };

            var occurencesCounter = new Dictionary<double, int>();
            foreach (var number in numbers)
            {
                if (occurencesCounter.ContainsKey(number))
                {
                    occurencesCounter[number]++;
                }
                else
                {
                    occurencesCounter.Add(number, 1);
                }
            }

            // Or the Linq way:
            // var occurencesCounter = numbers.GroupBy(n => n).ToDictionary(gr => gr.Key, gr => gr.Count());

            Console.WriteLine("{ " + string.Join(", ", numbers) + " }");
            foreach (var pair in occurencesCounter)
            {
                Console.WriteLine("{0} -> {1} times", pair.Key, pair.Value);
            }
        }
    }
}
