namespace Shapes
{
    using System;

    public class ShapesTest
    {
        public static void Main()
        {
            var shapes = new Shape[] { 
                                      new Triangle(2, 3),
                                      new Rectangle(2, 4),
                                      new Circle(1)
                                     };

            foreach (var shape in shapes)
            {
                Console.WriteLine("{0} area = {1}", shape.GetType().Name, shape.CalculateSurface());
            }
        }
    }
}
