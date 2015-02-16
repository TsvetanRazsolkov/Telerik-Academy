using System;

/* Write methods to calculate minimum, maximum, average, sum and product of given set
of integer numbers.
Use variable number of arguments.   */

class IntegerCalculations
{
    static void Main()
    {
        PerformCalculations(1, 2, 3, 4);
    }

    static void PerformCalculations(params int[] numbers)
    {
        int minimum = CalculateMinimum(numbers);
        Console.WriteLine("Min = " + minimum);

        int maximum = CalculateMaximum(numbers);
        Console.WriteLine("Max = " + maximum);

        double average = CalculateAverage(numbers);
        Console.WriteLine("Average = " + average);

        long sum = CalculateSum(numbers);
        Console.WriteLine("Sum = " + sum);

        long product = CalculateProduct(numbers);
        Console.WriteLine("Product = " + product);
    }

    static long CalculateSum(params int[] numbers)
    {

        long sum = 0;
        foreach (var number in numbers)
        {
            sum += number;
        }
        return sum;
    }

    static long CalculateProduct(params int[] numbers)
    {
        long product = 1;
        foreach (var number in numbers)
        {
            product *= number;
        }
        return product;
    }

    static double CalculateAverage(params int[] numbers)
    {
        double average = 0;
        foreach (var number in numbers)
        {
            average += number;
        }
        average /= numbers.Length;
        return average;
    }

    static int CalculateMaximum(params int[] numbers)
    {
        int max = int.MinValue;
        foreach (var number in numbers)
        {
            if (number >= max)
            {
                max = number;
            }
        }
        return max;
    }

    static int CalculateMinimum(params int[] numbers)
    {
        int min = int.MaxValue;
        foreach (var number in numbers)
        {
            if (number <= min)
            {
                min = number;
            }
        }
        return min;
    }
}