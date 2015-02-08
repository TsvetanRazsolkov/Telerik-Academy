using System;

class Trapezoids
{
    static void Main()
    {
        // Write an expression that calculates trapezoid's area by given sides a and b and height h.

        Console.Write("Enter side a and press ENTER: ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Enter side b and press ENTER: ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("Enter height h and press ENTER: ");
        double h = double.Parse(Console.ReadLine());
        double area = ((a + b) / 2) * h;
        Console.WriteLine("Trapezoid area = {0}", area);
    }
}
