namespace Points
{
    public static class DistanceCalculator
    {
        public static double CalculateDistance(Point3D first, Point3D second)
        {
            double distance = 0;

            double xComponent = second.X - first.X;
            double yComponent = second.Y - first.Y;
            double zComponent = second.Z - first.Z;
            
            distance = System.Math.Sqrt(xComponent*xComponent + yComponent*yComponent + zComponent*zComponent);
            
            return distance;
        }
    }
}
