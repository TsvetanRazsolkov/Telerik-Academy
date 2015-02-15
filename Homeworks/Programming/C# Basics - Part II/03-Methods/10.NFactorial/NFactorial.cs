using System;
using System.Collections.Generic;

/* Write a program to calculate n! for each n in the range [1..100].
Hint: Implement first a method that multiplies a number represented as array of digits
by given integer number.  */

class NFactorial
{
    static void Main()
    {
        List<int> factorial = new List<int>();

        for (int i = 1; i <= 100; i++)
        {
        factorial.Add(1);
        for (int j = 1; j <= i; j++)
        {
            factorial = MultiplyNumbers(factorial, j);
        }
        Console.Write("{0}! = ", i);
        PrintFactorial(factorial);
        factorial.Clear();
        }
    }

    static void PrintFactorial(List<int> factorial)
    {
        for (int i = 0; i < factorial.Count; i++)
        {
            Console.Write(factorial[i]);
        }
        Console.WriteLine();
    }
    static List<int> MultiplyNumbers(List<int> factorial, int number)
    {
        char[] numberAsChars = number.ToString().ToCharArray();
        int[] numberAsArray = new int[numberAsChars.Length];
        for (int i = 0; i < numberAsArray.Length; i++)
        {
            numberAsArray[i] = numberAsChars[i] - '0';
        }

        int[] result = new int[factorial.Count + numberAsArray.Length - 1];
        int remainder = 0;

        for (int i = factorial.Count - 1; i >= 0; i--)
        {
            for (int j = numberAsArray.Length - 1; j >= 0; j--)
            {
                int resultIndex = factorial.Count - i + numberAsArray.Length - j - 2;
                result[resultIndex] += factorial[i] * numberAsArray[j];
            }
        }
        factorial.Clear();
        for (int k = 0; k < result.Length; k++)
        {
            factorial.Add((result[k] + remainder) % 10);
            remainder = (result[k] + remainder) / 10;
        }
        if (remainder != 0)
        {
            factorial.Add(remainder);
        }

        factorial.Reverse();
        return factorial;
    }
}