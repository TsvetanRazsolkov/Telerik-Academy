using System;

class BiggestOfThreeNumbers
{
    static void Main()
    {
        // Write a program that finds the biggest of three numbers.

        Console.WriteLine("Enter 3 real numbers on separate lines:");

        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double c = double.Parse(Console.ReadLine());

        if (a > b)
        {
            if (a > c)
            {
                Console.WriteLine(a);
            }
            else
            {
                Console.WriteLine(c);
            }
        }
        else
        {
            if (b > c)
            {
                Console.WriteLine(b);
            }
            else
            {
                Console.WriteLine(c);
            }
        }

    }
}

