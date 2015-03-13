namespace DefiningClasses_Part1
{
    using System;

    public class Display
    {
        private double? size;
        private int? numberOfColours;

        public Display()
        {

        }

        public Display(double? size, int? numberOfColours)
        {
            this.Size = size;
            this.NumberOfColours = numberOfColours;
        }

        public double? Size
        {
            get { return this.size; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Display size cannot be 0 or less than 0.");
                }

                this.size = value;
            }
        }

        public int? NumberOfColours
        {
            get { return this.numberOfColours; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Display number of colours cannot be 0 or less than 0.");
                }

                this.numberOfColours = value;
            }
        }

        public override string ToString()
        {
            string characteristics = string.Format("Display size: {0}inches, Display colours: {1}", this.Size, this.NumberOfColours);

            return characteristics;
        }
    }
}
