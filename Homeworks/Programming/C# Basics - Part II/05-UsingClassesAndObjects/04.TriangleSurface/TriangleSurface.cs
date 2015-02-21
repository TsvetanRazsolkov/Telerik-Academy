using System;

/* Write methods that calculate the surface of a triangle by given:
Side and an altitude to it;
Three sides;
Two sides and an angle between them;
Use System.Math.   */

class TriangleSurface
{
    static void Main()
    {
        Console.Write("Enter side a = ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Enter side b = ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("Enter angle between a and b in degrees = ");
        int angle = int.Parse(Console.ReadLine());
        Console.Write("Enter side c = ");
        double c = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter altitude to side c = ");
        double altitude = double.Parse(Console.ReadLine());

        double area1 = CalculateTriangleArea(c, altitude);
        Console.WriteLine(area1);

        double area2 = CalculateTriangleArea(a, b, c);
        Console.WriteLine(area2);

        double area3 = CalculateTriangleArea(a, b, angle);
        Console.WriteLine(area3);
    }

    static double CalculateTriangleArea(double c, double altitude)
    {
        double area = 0;
        area = (c * altitude) / 2;
        return area;
    }

    static double CalculateTriangleArea(double a, double b, double c)
    {
        double area = 0;
        double halfOfPerimeter = (a + b + c) / 2;
        area = Math.Sqrt(halfOfPerimeter * (halfOfPerimeter - a) * (halfOfPerimeter - b) * (halfOfPerimeter - c));
        return area;
    }

    static double CalculateTriangleArea(double sideA, double sideB, int angle)
    {
        double area = 0;
        double angleInRadians = (angle * Math.PI) / 180;
        area = sideA * sideB * Math.Sin(angleInRadians) / 2;
        return area;
    }
}