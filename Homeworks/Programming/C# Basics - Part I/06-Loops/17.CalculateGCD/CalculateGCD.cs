using System;

class CalculateGCD
{
    static void Main()
    {
        // Write a program that calculates the greatest common divisor (GCD) of given two integers a and b. Use the Euclidean algorithm (find it in Internet).

        Console.WriteLine("Enter two integers a and b on separate lines: ");
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        if (a == 0)
        {
            Console.WriteLine("GCD = {0}", b);
        }
        else if (b == 0)
        {
            Console.WriteLine("GCD = {0}", a);
        }
        else
        {
            while (a != 0 || b != 0)
            {
                if (Math.Abs(a) > Math.Abs(b))
                {
                    a = Math.Abs(a % b);
                    a = Math.Abs(b) - a;
                }
                else if (Math.Abs(b) > Math.Abs(a))
                {
                    b = Math.Abs(b % a);
                    b = Math.Abs(a) - b;
                }
                else if (Math.Abs(a) == Math.Abs(b))
                {
                    Console.WriteLine("GCD = {0}", a);
                    return;
                }
            }
        }
    }
}