namespace FurnitureManufacturer.Models
{
    using System;
    using FurnitureManufacturer.Interfaces;

    public class Table : FurniturePiece, IFurniture, ITable
    {
        private decimal length;
        private decimal width;
        
        public Table(string model, string material, decimal price, decimal height, decimal length, decimal width)
                    : base(model, material, price, height)
        {
            this.Length = length;
            this.Width = width;
        }

        public decimal Length
        {
            get { return this.length; }
            private set
            {
                base.ValidateSize(value);
                this.length = value;
            }
        }

        public decimal Width
        {
            get { return this.width; }
            private set
            {
                base.ValidateSize(value);
                this.width = value;
            }
        }

        public decimal Area
        {
            get { return this.Length * this.Width; }
        }

        

        

        

        

        public override string ToString()
        {
            return string.Format("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}, Length: {5}, Width: {6}, Area: {7}",
                this.GetType().Name, this.Model, this.Material, this.Price, this.Height, this.Length, this.Width, this.Area);
        }

        
    }
}
