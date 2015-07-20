namespace CohesionAndCoupling
{
    using System;
    using Utils;

    public class UtilsExamples
    {
        public static void Main()
        {
            // The line below will throw exception.
            // Console.WriteLine(FileUtils.GetFileExtension("example"));
            Console.WriteLine(FileUtils.GetFileExtension("example.pdf"));
            Console.WriteLine(FileUtils.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine("Distance in the 2D space = {0:f2}", GeometryUtils.CalcDistance2D(1, -2, 3, 4));
            Console.WriteLine("Distance in the 3D space = {0:f2}", GeometryUtils.CalcDistance3D(5, 2, -1, 3, -6, 4));

            RectangularPrism prism = new RectangularPrism(3, 4, 5);
            Console.WriteLine("Volume = {0:f2}", prism.CalcVolume());
            Console.WriteLine("Diagonal XYZ = {0:f2}", prism.CalcDiagonalXYZ());
            Console.WriteLine("Diagonal XY = {0:f2}", prism.CalcDiagonalXY());
            Console.WriteLine("Diagonal XZ = {0:f2}", prism.CalcDiagonalXZ());
            Console.WriteLine("Diagonal YZ = {0:f2}", prism.CalcDiagonalYZ());
        }
    }
}
