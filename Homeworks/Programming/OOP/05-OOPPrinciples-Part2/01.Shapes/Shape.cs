namespace Shapes
{
    using System;

    public abstract class Shape
    {
        private double width;
        private double height;

        public Shape(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width
        {
            get { return this.width; }
            protected set
            {
                if (value <= 0 )
                {
                    throw new ArgumentException("Height or width must be positive.");
                }
                this.width = value;
            }
        }

        public double Height
        {
            get { return this.height; }
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height or width must be positive.");
                }
                this.height = value;
            }
        }

        public abstract double CalculateSurface();
    }
}
