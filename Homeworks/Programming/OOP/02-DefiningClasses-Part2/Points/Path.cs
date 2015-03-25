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
            get { return new List<Point3D>(this.pathOfPoints); } // This way when someone calls the property
            // outside of the class and atempts to add or remove element from the list he/she will not 
            // change the field. The only way to do so is to use the instance methods from this class;
            private set { this.pathOfPoints = value; }
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
