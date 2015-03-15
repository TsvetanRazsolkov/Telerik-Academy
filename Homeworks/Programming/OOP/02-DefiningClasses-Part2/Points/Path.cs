namespace Points
{
    using System.Collections.Generic;

    public class Path
    {
        private List<Point3D> pathOfPoints;

        public Path()
        {
            this.pathOfPoints = new List<Point3D>();
        }

        public List<Point3D> PathOfPoints
        {
            get { return new List<Point3D>(this.pathOfPoints); }
        }

        public void AddPointToPath(Point3D point)
        {
            this.pathOfPoints.Add(point);
        }

        public void AddPointsToPath(params Point3D[] points)
        {
            this.pathOfPoints.AddRange(points);
        }

        public override string ToString()
        {
            string result = string.Join(" - ", this.PathOfPoints);
            return result;
        }
    }
}
