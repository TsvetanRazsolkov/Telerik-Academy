using System;
using System.Numerics;

class TrailingZeroesInFactorial
{
    static void Main()
    {
        // Write a program that calculates with how many zeroes the factorial of a given number n has at its end. Your program should work well for very big numbers, e.g. n=100000.

        Console.Write("Enter a positive integer n and press ENTER: ");
        int n = int.Parse(Console.ReadLine());
        BigInteger factorial = 1;
        int zeroCount = 0;
        for (int i = 1; i <= n; i++)
        {
            factorial *= i;
        }

        if (factorial % 10 != 0)
        {
            Console.WriteLine("Trailing zeroes: {0}", zeroCount);
        }
        else if (factorial % 10 == 0)
        {
            zeroCount = 1;
            BigInteger number = factorial / 10;
            while (number % 10 == 0)
            {
                number /= 10;
                zeroCount++;
            }
            Console.WriteLine("Trailing zeroes: {0}", zeroCount);
        }
    }
}
