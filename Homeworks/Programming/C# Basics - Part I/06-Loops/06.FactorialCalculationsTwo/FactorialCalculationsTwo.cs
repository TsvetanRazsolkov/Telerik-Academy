using System;
using System.Numerics;

class FactorialCalculationsTwo
{
    static void Main()
    {
        //Write a program that calculates n! / k! for given n and k (1 < k < n < 100). Use only one loop.

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

            Console.WriteLine("n!/k! = {0}", nDividedByKFactorial);
        }
        else
        {
            Console.WriteLine("Invalid input.");
        }
    }
}
