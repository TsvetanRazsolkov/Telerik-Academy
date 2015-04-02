
namespace FurnitureManufacturer.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using FurnitureManufacturer.Interfaces;

    public abstract class FurniturePiece : IFurniture
    {
        private string model;
        private string material;
        private decimal price;
        private decimal height;

        public FurniturePiece(string model, string material, decimal price, decimal height)
        {
            this.Model = model;
            this.Material = material;
            this.Price = price;
            this.Height = height;
        }

        public string Model
        {
            get { return this.model; }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 3)
                {
                    throw new ArgumentException("Model must be more than 3 symbol long.");
                }
                this.model = value;
            }
        }

        public string Material
        {
            get { return this.material; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Material can not be null or empty string.");
                }
                this.material = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value <= 0M)
                {
                    throw new ArgumentException("Price cannot be negative or zero.");
                }
                this.price = value;
            }
        }

        public decimal Height
        {
            get { return this.height; }
            protected set
            {
                this.ValidateSize(value);
                this.height = value;
            }
        }

        protected void ValidateSize(decimal size)
        {
            if (size <= 0M)
            {
                throw new ArgumentException("Size can not be negative or zero.");
            }
        }
    }
}
