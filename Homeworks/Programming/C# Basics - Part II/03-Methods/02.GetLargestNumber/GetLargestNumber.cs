using System;

/* Write a method GetMax() with two parameters that returns the larger of two integers.
Write a program that reads 3 integers from the console and prints the largest of them
using the method GetMax().  */

class GetLargestNumber
{
    static void Main()
    {
        Console.Write("Enter integer a = ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("Enter integer b = ");
        int b = int.Parse(Console.ReadLine());
        Console.Write("Enter integer c = ");
        int c = int.Parse(Console.ReadLine());

        int largestNumber = GetMax(GetMax(a, b), c);

        Console.WriteLine("The largest number is: {0}", largestNumber);
    }

    static int GetMax(int first, int second)
    {
        if (first > second)
        {
            return first;
        }
        else
        {
            return second;
        }
    }
}