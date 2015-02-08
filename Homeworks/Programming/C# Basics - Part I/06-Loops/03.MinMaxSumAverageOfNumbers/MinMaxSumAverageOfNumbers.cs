using System;
using System.Linq; // For the array solution.

class MinMaxSumAverageOfNumbers
{
    static void Main()
    {
        /* Write a program that reads from the console a sequence of n integer numbers and returns the minimal, the maximal number, the sum and the average of all numbers (displayed with 2 digits after the decimal point).
          The input starts by the number n (alone in a line) followed by n lines, each holding an integer number.
          The output is like in the examples below. */

        Console.Write("Enter positive integer number and press ENTER: ");
        int n = int.Parse(Console.ReadLine());
        int minimum = int.MaxValue;
        int maximum = int.MinValue;
        int sum = 0;
        int count = 0;
        while (count < n)
        {
            Console.Write("Enter an integer number and press ENTER: ");
            int number = int.Parse(Console.ReadLine());
            if (number <= minimum)
            {
                minimum = number;
            }
            if (number >= maximum)
            {
                maximum = number;
            }
            sum += number;
            count++;
        }
        double average = (double)sum / n;
        Console.WriteLine("min = {0}", minimum);
        Console.WriteLine("max = {0}", maximum);
        Console.WriteLine("sum = {0}", sum);
        Console.WriteLine("avg = {0:F2}", average);

        //int[] numbers = new int[n];
        //int i = 0; 
        //do
        //{
        //    Console.Write("Enter an integer number: ");
        //    numbers[i] = int.Parse(Console.ReadLine());
        //    i++;
        //} while ( i < n);

        //int maxValue = numbers.Max();
        //int minValue = numbers.Min();
        //double sum = (double)numbers.Sum();
        //double avg = sum / n;

        //Console.WriteLine("min = {0}",minValue);
        //Console.WriteLine("max = {0}",maxValue);
        //Console.WriteLine("sum = {0}",sum);
        //Console.WriteLine("avg = {0:F2}",avg);
    }
}
