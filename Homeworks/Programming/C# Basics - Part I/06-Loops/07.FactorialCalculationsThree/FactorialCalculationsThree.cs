using System;
using System.Numerics;

class FactorialCalculationsThree
{
    static void Main()
    {
        // Your task is to write a program that calculates n! / (k! * (n-k)!) for given n and k (1 < k < n < 100). Try to use only two loops.

        Console.Write("Enter an integer number n and press ENTER: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter an integer number k and press ENTER: ");
        int k = int.Parse(Console.ReadLine());

        if (k > 1 && k < n && n < 100)
        {
            BigInteger nDividedByKFactorial = 1;

            // 1*2*3*4*5*6*7*8/1*2*3*4 = 5*6*7*8, so n!/k! = (k+1)*...*n;

            for (int i = k + 1; i <= n; i++)
            {
                nDividedByKFactorial *= i;
            }
            BigInteger nMinusKFactorial = 1;

            for (int j = 1; j <= (n-k); j++)
            {
                nMinusKFactorial *= j;
            }
            BigInteger result = nDividedByKFactorial / nMinusKFactorial;
            Console.WriteLine("n!/(k!*(n-k)!) = {0}", result);
        }
        else
        {
            Console.WriteLine("Invalid input.");
        }
    }
}