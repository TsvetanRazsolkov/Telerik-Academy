using System;
using System.Text;

class QuadraticEquation
{
    static void Main()
    {
        // Write a program that reads the coefficients a, b and c of a quadratic equation ax2 + bx + c = 0 and solves it (prints its real roots).

        Console.OutputEncoding = Encoding.UTF8;

        Console.Write("Enter coefficient a and press ENTER: ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Enter coefficient b and press ENTER: ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("Enter coefficient c and press ENTER: ");
        double c = double.Parse(Console.ReadLine());

        double discriminant = (b * b) - (4 * a * c);
        if (discriminant == 0)
        {
            double onlyRealRoot = -b / (2 * a);
            Console.WriteLine("The only root of the quadratic equation " + a + 'x' + '\u00B2' + '+' + b + 'x' + '+' + c + "=0 is:");
            Console.WriteLine("x" + '\u2081' + ',' + '\u2082' + '=' + onlyRealRoot);
        }
        else if (discriminant < 0)
        {
            Console.WriteLine("No real roots.");
        }
        else
        {
        double rootOne = ((-b) + Math.Sqrt(discriminant)) / (2 * a);
        double rootTwo = ((-b) - Math.Sqrt(discriminant)) / (2 * a);

        Console.WriteLine("The roots of the quadratic equation " + a + 'x' + '\u00B2' + '+' + b + 'x' + '+' + c + "=0 are:");
        Console.WriteLine("x" + '\u2081' + '=' + rootOne);
        Console.WriteLine("x" + '\u2082' + '=' + rootTwo);
        }
    }
}