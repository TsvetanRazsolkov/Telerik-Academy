using System;
using System.Numerics;

class CatalanNumbers
{
    static void Main()
    {
        // In combinatorics, the Catalan numbers are calculated by an exciting formula :), which can be found in wikipedia. Write a program to calculate the nth Catalan number by given n (1 < n < 100).

        Console.Write("Enter a positive integer n and press ENTER: ");
        int n = int.Parse(Console.ReadLine());

        if (n > 0 && n < 100)
        {
            
            BigInteger doubleNFactorial = 1;
            BigInteger nPlusOneFactorial = 1;

            for (int i = n + 2; i <= 2*n; i++)
            {
                doubleNFactorial *= i;
            }
            for (int j = 1; j <= n; j++)
            {
                nPlusOneFactorial *= j;
            }
            BigInteger result = doubleNFactorial / nPlusOneFactorial ;
            Console.WriteLine("Catalan(n) = {0}", result);
        }
        else if (n == 0)
        {
            Console.WriteLine("Catalan(n) = 1");
        }
        else
        {
            Console.WriteLine("Invalid input.");
        }
    }
}