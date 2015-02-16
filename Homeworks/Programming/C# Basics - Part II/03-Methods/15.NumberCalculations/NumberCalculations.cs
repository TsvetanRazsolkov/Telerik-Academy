using System;

// Modify your last program and try to make it work for any number type, not just integer
// (e.g. decimal, float, byte, etc.)
// Use generic method (read in Internet about generic methods in C#).

class NumberCalculations
{
    static void Main()
    {
        PerformCalculations(1.0, 1.33, -2.13, 164.2);
    }

    static void PerformCalculations<T>(params T[] numbers) where T : IComparable<T>
    {
        T minimum = CalculateMinimum(numbers);
        Console.WriteLine("Min = " + minimum);

        T maximum = CalculateMaximum(numbers);
        Console.WriteLine("Max = " + maximum);

        T average = CalculateAverage(numbers);
        Console.WriteLine("Average = " + average);

        T sum = CalculateSum(numbers);
        Console.WriteLine("Sum = " + sum);

        T product = CalculateProduct(numbers);
        Console.WriteLine("Product = " + product);
    }

    static T CalculateSum<T>(params T[] numbers) where T : IComparable<T>
    {

        dynamic sum = 0;
        foreach (var number in numbers)
        {
            sum += number;
        }
        return sum;
    }

    static T CalculateProduct<T>(params T[] numbers) where T : IComparable<T>
    {
        dynamic product = 1;
        foreach (var number in numbers)
        {
            product *= number;
        }
        return product;
    }

    static T CalculateAverage<T>(params T[] numbers) where T : IComparable<T>
    {
        dynamic average = 0;
        foreach (var number in numbers)
        {
            average += number;
        }
        average /= numbers.Length;
        return average;
    }

    static T CalculateMaximum<T>(params T[] numbers) where T : IComparable<T>
    {
        T max = numbers[0];
        foreach (var number in numbers)
        {
            if (max.CompareTo(number) <= 0)
            {
                max = number;
            }
        }
        return max;
    }

    static T CalculateMinimum<T>(params T[] numbers) where T : IComparable<T>
    {
        T min = numbers[0];
        foreach (var number in numbers)
        {
            if (min.CompareTo(number) >= 0)
            {
                min = number;
            }
        }
        return min;
    }
}