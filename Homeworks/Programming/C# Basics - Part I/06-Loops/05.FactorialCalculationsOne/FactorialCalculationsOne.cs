using System;

class FactorialCalculationsOne
{
    static void Main()
    {
        // Write a program that, for a given two integer numbers n and x, calculates the sum S = 1 + 1!/x + 2!/x2 + … + n!/xn. Use only one loop. Print the result with 5 digits after the decimal point.

        Console.Write("Enter an integer number n and press ENTER: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter an integer number x and press ENTER: ");
        int x = int.Parse(Console.ReadLine());

        decimal factorial = 1m;
        decimal power = 1m;
        decimal sum = 1m;

        for (int i = 1; i <= n; i++)
        {
            factorial *= i;
            power *= x;
            decimal number = factorial / power;
            sum += number;
        }
        Console.WriteLine("sum = {0:F5}", sum);
    }
}