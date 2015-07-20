namespace CohesionAndCoupling
{
    using System;
    using Utils;

    public class RectangularPrism
    {
        private const string InvalidPrismDimensionsMessage = "Prism {0} cannot be zero or negative";

        private double width;
        private double height;
        private double depth;

        public RectangularPrism(double width, double height, double depth)
        {
            this.Width = width;
            this.Height = height;
            this.Depth = depth;
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(InvalidPrismDimensionsMessage, "width"));
                }

                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(InvalidPrismDimensionsMessage, "height"));
                }

                this.height = value;
            }
        }

        public double Depth
        {
            get
            {
                return this.depth;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(InvalidPrismDimensionsMessage, "depth"));
                }

                this.depth = value;
            }
        }

        public double CalcVolume()
        {
            double volume = this.Width * this.Height * this.Depth;
            return volume;
        }

        public double CalcDiagonalXYZ()
        {
            double diagonal = GeometryUtils.CalcDistance3D(0, 0, 0, this.Width, this.Height, this.Depth);
            return diagonal;
        }

        public double CalcDiagonalXY()
        {
            double diagonal = GeometryUtils.CalcDistance2D(0, 0, this.Width, this.Height);
            return diagonal;
        }

        public double CalcDiagonalXZ()
        {
            double diagonal = GeometryUtils.CalcDistance2D(0, 0, this.Width, this.Depth);
            return diagonal;
        }

        public double CalcDiagonalYZ()
        {
            double diagonal = GeometryUtils.CalcDistance2D(0, 0, this.Height, this.Depth);
            return diagonal;
        }
    }
}
