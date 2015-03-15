namespace Points
{
    using System;
    using System.IO;

    class PointsTest
    {
        public const string filePath = "..\\..\\PathTest.txt";

        static void Main()
        {
            Point3D first = new Point3D(1, 2, 3);
            Point3D second = new Point3D(1, 2, 4);
            Point3D third = new Point3D(-1.5, 14, 4);
            Point3D fourth = new Point3D(3, 2, 1);

            double distance = DistanceCalculator.CalculateDistance(first, second);
            Console.WriteLine("Distance between points {0} and {1} is: {2}\n",
                first, second, distance);

            Path somePath = new Path();
            somePath.AddPointsToPath(Point3D.Point0, first, second, third);
            somePath.AddPointToPath(fourth);

            PathStorage.SavePath(filePath, somePath);

            try
            {
                Path loadedPath = PathStorage.LoadPath(filePath);
                Console.WriteLine("The path loaded from file {0} is:", System.IO.Path.GetFullPath("PathTest.txt"));
                Console.WriteLine(loadedPath);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File was not found.");
            }            
        }
    }
}
