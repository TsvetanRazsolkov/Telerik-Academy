using System;

class Rectangles
{
    static void Main()
    {
        // Write an expression that calculates rectangle’s perimeter and area by given width and height.

        Console.Write("Enter width and press ENTER: ");
        double width = double.Parse(Console.ReadLine());
        Console.Write("Enter height and press ENTER: ");
        double height = double.Parse(Console.ReadLine());
        double area = width * height;
        double perimeter = 2 * width + 2 * height;
        if ((width <= 0) || (height <= 0))
        {
            Console.WriteLine("Enter positive integer values for both width and height.");
        }
        else
        {
            Console.WriteLine("Rectangle area = {0}\nRectangle perimeter = {1}", area, perimeter);

        }
    }
}