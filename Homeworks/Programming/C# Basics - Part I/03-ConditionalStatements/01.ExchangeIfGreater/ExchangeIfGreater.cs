using System;

class ExchangeIfGreater
{
    static void Main()
    {
        // Write an if-statement that takes two integer variables a and b and exchanges their values if the first one is greater than the second one. As a result print the values a and b, separated by a space.

        Console.WriteLine("Enter two integer numbers on separate lines:");
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());

        if (a >= b)
        {
            Console.Write("{0} {1}", b, a);
            Console.WriteLine();
        }
        else
        {
            Console.Write("{0} {1}", a, b);
            Console.WriteLine();
        }
    }
}

