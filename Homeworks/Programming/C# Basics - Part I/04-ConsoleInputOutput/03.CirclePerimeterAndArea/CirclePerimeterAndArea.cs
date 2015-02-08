using System;
using System.Globalization;
using System.Threading;

class CirclePerimeterAndArea
{
    static void Main()
    {
        // Write a program that reads the radius r of a circle and prints its perimeter and area formatted with 2 digits after the decimal point.

        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        Console.Write("Enter a radius r: ");
        double radius;
        string input = Console.ReadLine();
        input = input.Replace(',', '.');
        bool isDouble = double.TryParse(input, out radius);
        if (isDouble && radius > 0)
        {
            Console.WriteLine("A circle with:\nperimeter={0:0.00}\narea={1:0.00}", 2 * Math.PI * radius, Math.PI * radius * radius);
        }
        else
        {
            Console.WriteLine("Invalid input");
        }
    }
}