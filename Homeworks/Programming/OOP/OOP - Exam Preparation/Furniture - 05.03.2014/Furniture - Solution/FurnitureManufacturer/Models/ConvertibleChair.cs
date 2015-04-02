namespace FurnitureManufacturer.Models
{
    using System;
    using FurnitureManufacturer.Interfaces;

    public class ConvertibleChair : Chair, IFurniture, IConvertibleChair
    {
        private const decimal ConvertedHeight = 0.10M;
        private readonly decimal initialHeight;

        private bool isConverted;

        public ConvertibleChair(string model, string material, decimal price, decimal height, int numberOfLegs)
            : base(model, material, price, height, numberOfLegs)
        {
            this.initialHeight = this.Height;
            this.IsConverted = false;
        }        

        public bool IsConverted
        {
            get { return this.isConverted; }
            private set
            {
                this.isConverted = value;
            }
        }

        public void Convert()
        {
            if (!this.IsConverted)
            {
                this.Height = ConvertedHeight;
                this.IsConverted = true;
            }
            else
            {
                this.Height = this.initialHeight;
                this.IsConverted = false;
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(", State: {0}", this.IsConverted ? "Converted" : "Normal");
        }
    }
}
