namespace Points
{
    public struct Point3D
    {
        static readonly Point3D point0;

        public Point3D(double x, double y, double z) : this()
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        static Point3D()
        {
            point0 = new Point3D(0, 0, 0);
        }

        public static Point3D Point0
        {
            get { return point0; }
        }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public override string ToString()
        {
            string point = string.Format("{{{0}, {1}, {2}}}", this.X, this.Y, this.Z);
            return point;
        }
    }
}
