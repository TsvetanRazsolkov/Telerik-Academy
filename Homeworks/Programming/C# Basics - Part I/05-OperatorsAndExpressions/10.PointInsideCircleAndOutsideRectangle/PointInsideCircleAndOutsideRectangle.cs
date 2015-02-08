using System;

class PointInsideCircleAndOutsideRectangle
{
    static void Main()
    {
        // Write an expression that checks for given point (x, y) if it is within the circle K({1, 1}, 1.5) and out of the rectangle R(top=1, left=-1, width=6, height=2).

        Console.Write("Enter coordinate \"x\" and press ENTER: ");
        double xPoint = double.Parse(Console.ReadLine());

        Console.Write("Enter coordinate \"y\" and press ENTER: ");
        double yPoint = double.Parse(Console.ReadLine());

        double xCenter = 1;
        double yCenter = 1;
        double radius = 1.5;

        bool isWithinCircle = (Math.Pow((xPoint - xCenter), 2) + Math.Pow((yPoint - yCenter), 2)) < Math.Pow(radius, 2);
        bool isWithinRectangle = ((xPoint > -1) && (xPoint < 5)) && ((yPoint > -1) && (yPoint < 1));

        if (isWithinCircle && !isWithinRectangle)
        {
            Console.WriteLine("Inside circle & Outside rectangle -> YES.");
        }
        else
        {
            Console.WriteLine("Inside circle & Outside rectangle -> NO.");
        }
    }
}