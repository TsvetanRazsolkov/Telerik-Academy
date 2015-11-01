/*The majorant of an array of size N is a value that occurs in it at least N/2 + 1 times.
Write a program to find the majorant of given array (if exists).
Example:
{2, 2, 3, 3, 2, 3, 4, 3, 3} → 3*/
namespace _08.MajorantOfArray
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var integers = new int[] { 2, 2, 3, 3, 2, 3, 4, 3, 3 };
            
            // array without majorant
            //integers = new int[] { 2, 2, 3, 3, 2, 4, 4, 5, 5 };

            var mostCommonElement = integers.GroupBy(i => i)
                                            .OrderByDescending(gr => gr.Count())
                                            .FirstOrDefault();

            int minMajorantCount = integers.Length/2 + 1;

            if (mostCommonElement == null || mostCommonElement.Count() < minMajorantCount)
            {
                Console.WriteLine("No majorant in {0}", string.Join(", ", integers));
            }
            else
            {
                Console.WriteLine("Majorant in {0} -> {1}", string.Join(", ", integers), mostCommonElement.Key);
            }
        }
    }
}
