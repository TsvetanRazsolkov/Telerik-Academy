using System;

class RandomNumbersInGivenRange
{
    static void Main()
    {
        //Write a program that enters 3 integers n, min and max (min < max) and prints n random numbers in the range [min...max].

        Console.Write("Enter an integer n and press ENTER: ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter integers min and max (min < max) on seperate lines: ");
        int min = int.Parse(Console.ReadLine());
        int max = int.Parse(Console.ReadLine());

        Random randomGenerator = new Random();

        for (int i = 0; i < n; i++)
        {
            Console.Write("{0} ", randomGenerator.Next(min, max + 1));
        }
        Console.WriteLine();
    }
}