namespace VariablesExpressionsConstants
{
    using System;

    public class Rectangle
    {
        private double width;
        private double height;

        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width
        {
            get
            { 
                return this.width;
            }

            set 
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Width should not be negative or zero");
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

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Height should not be negative or zero");
                }

                this.height = value;
            }
        }

        public Rectangle GetBoundingBoxOfRotatedRectangle(Rectangle figure, double angleOfRotation)
        {
            double sinusAbs = Math.Abs(Math.Sin(angleOfRotation));
            double cosinusAbs = Math.Abs(Math.Cos(angleOfRotation));

            double boundingBoxWidth = (this.Height * sinusAbs) + (this.Width * cosinusAbs);
            double boundingBoxHeight = (this.Height * cosinusAbs) + (this.Width * sinusAbs);

            Rectangle boundingBox = new Rectangle(boundingBoxWidth, boundingBoxHeight);

            return boundingBox;
        }
    }
}
