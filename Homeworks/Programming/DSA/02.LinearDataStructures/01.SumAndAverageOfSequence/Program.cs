/*
Write a program that reads from the console a sequence of positive integer numbers.
The sequence ends when empty line is entered.
Calculate and print the sum and average of the elements of the sequence.
Keep the sequence in List<int>.
 Not sure if checks for negative values are necessary, so to be on the lazy side I've decided to skip on them :)
 */
namespace _01.SumAndAverageOfSequence
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            // Task can be done with just an int counter of entered values, that we'll use to calculate the average
            var integers = new List<int>();
            long sum = 0L;

            while (true)
            {
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    break;
                }

                int inputInteger = int.Parse(input);
                sum += inputInteger;
                integers.Add(inputInteger);
            }

            long average = sum / integers.Count;

            Console.WriteLine("Sum -> {0}", sum);
            Console.WriteLine("average -> {0}", average);
        }
    }
}
