namespace Methods
{
    public class Point2D
    {
        public Point2D(double horizontalCoordinate, double verticalCoordinate)
        {
            this.HorizontalCoordinate = horizontalCoordinate;
            this.VerticalCoordinate = verticalCoordinate;
        }

        public double HorizontalCoordinate { get; private set; }

        public double VerticalCoordinate { get; private set; }

        public double CalcDistanceToAnotherPoint(Point2D anotherPoint)
        {
            double horizontalCoordDifference = this.HorizontalCoordinate - anotherPoint.HorizontalCoordinate;
            double verticalCoordDifference = this.VerticalCoordinate - anotherPoint.VerticalCoordinate;
            double distance = System.Math.Sqrt((horizontalCoordDifference * horizontalCoordDifference) + (verticalCoordDifference * verticalCoordDifference));

            return distance;
        }
    }
}
