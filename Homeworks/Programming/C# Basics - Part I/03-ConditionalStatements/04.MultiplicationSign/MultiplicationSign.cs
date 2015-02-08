using System;

class MultiplicationSign
{
    static void Main()
    {
        // Write a program that shows the sign (+, - or 0) of the product of three real numbers, without calculating it, using if-operators.

        Console.WriteLine("Enter 3 real numbers on separate lines:");
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double c = double.Parse(Console.ReadLine());

        if (a == 0 || b == 0 || c == 0)
        {
            Console.WriteLine('0');
        }
        else if (a < 0 && b > 0 && c > 0)
        {
            Console.WriteLine('-');
        }
        else if (a < 0 && b < 0 && c > 0)
        {
            Console.WriteLine('+');
        }
        else if (a < 0 && b < 0 && c < 0)
        {
            Console.WriteLine('-');
        }
        else if (a < 0 && b > 0 && c < 0)
        {
            Console.WriteLine('+');
        }
        else if (a > 0 && b > 0 && c > 0)
        {
            Console.WriteLine('+');
        }
        else if (a > 0 && b < 0 && c > 0)
        {
            Console.WriteLine('-');
        }
        else if (a > 0 && b < 0 && c < 0)
        {
            Console.WriteLine('+');
        }
        else if (a > 0 && b > 0 && c < 0)
        {
            Console.WriteLine('-');
        }
    }
}
