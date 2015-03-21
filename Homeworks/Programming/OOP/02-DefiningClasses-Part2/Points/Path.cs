namespace Points
{
    using System.Collections.Generic;

    public class Path
    {
        private List<Point3D> pathOfPoints;

        public Path()
        {
            this.PathOfPoints = new List<Point3D>();
        }

        public List<Point3D> PathOfPoints
        {
            get { return new List<Point3D>(this.pathOfPoints); }
            private set { this.pathOfPoints = value; }
        }

        public void AddPointToPath(Point3D point)
        {
            this.PathOfPoints.Add(point);
        }

        public void AddPointsToPath(params Point3D[] points)
        {
            this.PathOfPoints.AddRange(points);
        }

        public override string ToString()
        {
            string result = string.Join(" - ", this.PathOfPoints);
            return result;
        }
    }
}
