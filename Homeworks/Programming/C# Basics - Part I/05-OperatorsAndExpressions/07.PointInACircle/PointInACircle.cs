using System;

class PointInACircle
{
    static void Main()
    {
        // Write an expression that checks if given point (x, y) is inside a circle K({0, 0}, 2)

        Console.Write("Enter coordinate \"x\" and press ENTER: ");
        double xPoint = double.Parse(Console.ReadLine());
        Console.Write("Enter coordinate \"y\" and press ENTER: ");
        double yPoint = double.Parse(Console.ReadLine());
        double xCenter = 0;
        double yCenter = 0;
        double radius = 2;
        bool isWithinCircle = ((xPoint - xCenter) * (xPoint - xCenter) + (yPoint - yCenter) * (yPoint - yCenter)) <= radius * radius;
        if (isWithinCircle)
        {
            Console.WriteLine("The point with the specified coordinates IS within a circle with radius {0}.", radius);
        }
        else
        {
            Console.WriteLine("The point with the specified coordinates IS NOT within a circle with radius {0}.", radius);

        }
    }
}