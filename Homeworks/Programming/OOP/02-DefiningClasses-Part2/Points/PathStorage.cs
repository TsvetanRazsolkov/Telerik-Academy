namespace Points
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public static class PathStorage
    {
        public static void SavePath(string filePath, Path pathOfPoints)
        {
            var writer = new StreamWriter(filePath);
            using (writer)
            {
                writer.Write(pathOfPoints);
            }
        }

        public static Path LoadPath(string filePath)
        {
            Path loadedPath = new Path();
            var reader = new StreamReader(filePath);

            using (reader)
            {
                string pathFromFile = reader.ReadToEnd();
                var arrOfPoints = pathFromFile.Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var point in arrOfPoints)
                {
                    double[] pointCoords = point
                        .Split(new char[] { ' ', ',', '{', '}' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => double.Parse(x)).ToArray();
                    loadedPath.AddPointToPath(new Point3D(pointCoords[0], pointCoords[1], pointCoords[2]));
                }
            }
            return loadedPath;
        }
    }
}
