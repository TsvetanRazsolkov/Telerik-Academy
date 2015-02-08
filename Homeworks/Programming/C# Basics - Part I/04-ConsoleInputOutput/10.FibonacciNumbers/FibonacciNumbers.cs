using System;
using System.Numerics;

class FibonacciNumbers
{
    static void Main()
    {
        // Write a program that reads a number n and prints on the console the first n members of the Fibonacci sequence (at a single line, separated by comma and space - ,) : 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, ….

        Console.Write("Enter positive integer and press ENTER: ");
        int n;
        if (int.TryParse(Console.ReadLine(), out n) && n > 2)
        {
            BigInteger fibFirst = 0;
            BigInteger fibSecond = 1;
            BigInteger fibNext;
            Console.Write("{0}", fibFirst);
            Console.Write(", {0}", fibSecond);
            for (int i = 3; i <= n; i++)
            {
                fibNext = fibFirst + fibSecond;
                fibFirst = fibSecond;
                fibSecond = fibNext;
                Console.Write(", {0}", fibNext);
            }
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("Invalid number n.");
        }
    }
}