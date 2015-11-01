// Write a program that reads a sequence of integers (List<int>) ending with an empty line and sorts them in an increasing order.
namespace _03.SortListOfIntegers
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var integers = new List<int>();

            while (true)
            {
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    break;
                }

                int inputInteger = int.Parse(input);
                integers.Add(inputInteger);
            }

            integers.Sort();

            Console.WriteLine(string.Join(", ", integers));
        }
    }
}
