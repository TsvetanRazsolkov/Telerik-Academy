using System;

class ComparingFloats
{
    static void Main()
    {
        // Write a program that safely compares floating-point numbers (double) with precision eps = 0.000001

        Console.WriteLine("Enter two floating-point numbers on separate lines: ");
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double eps = 0.000001;
        bool areEqual = (Math.Abs(a - b) < eps);
        Console.WriteLine("a = {0} , b = {1}", a, b);
        Console.WriteLine("Equal with precision eps = 0.000001 -> {0}", areEqual);
    }
}