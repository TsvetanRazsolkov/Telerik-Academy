
/*Write a program that removes from given sequence all numbers that occur odd number of times.
Example:
{4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2} → {5, 3, 3, 5}*/
namespace _06.RemoveNumbersOccuringOddTimes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var sequence = new List<int> { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };
            Console.WriteLine(string.Join(", ", sequence));

            var occurencesDictionary = sequence.GroupBy(n => n)
                                               .ToDictionary(gr => gr.Key, gr => gr.Count());

            var changedSequence = sequence.Where(n => occurencesDictionary[n] % 2 == 0);

            Console.WriteLine(string.Join(", ", changedSequence));
        }
    }
}
