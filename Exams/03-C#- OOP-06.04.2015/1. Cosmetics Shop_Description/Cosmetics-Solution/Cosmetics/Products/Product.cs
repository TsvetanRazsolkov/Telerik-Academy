
namespace Cosmetics.Products
{
    using System;
    using System.Text;
    using Cosmetics.Common;
    using Cosmetics.Contracts;

    public abstract class Product : IProduct
    {
        private const int MinProdNameLength = 3;
        private const int MaxProdNameLength = 10;
        private const int MinBrandNameLength = 2;
        private const int MaxBrandNameLength = 10;

        private string name;
        private string brand;
        private decimal price;

        public Product(string name, string brand, decimal price, GenderType gender)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.Gender = gender;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                Validator.CheckIfStringIsNullOrEmpty(value, string.Format(GlobalErrorMessages.StringCannotBeNullOrEmpty, "Product name"));
                Validator.CheckIfStringLengthIsValid(value, MaxProdNameLength, MinProdNameLength, 
                    string.Format(GlobalErrorMessages.InvalidStringLength, "Product name", MinProdNameLength, MaxProdNameLength));
                this.name = value;
            }
        }

        public string Brand
        {
            get { return this.brand; }
            private set
            {
                Validator.CheckIfStringIsNullOrEmpty(value, string.Format(GlobalErrorMessages.StringCannotBeNullOrEmpty, "Product brand"));
                Validator.CheckIfStringLengthIsValid(value, MaxBrandNameLength, MinBrandNameLength, 
                    string.Format(GlobalErrorMessages.InvalidStringLength, "Product brand", MinBrandNameLength, MaxBrandNameLength));
                this.brand = value;
            }
        }

        public virtual decimal Price
        {
            get { return this.price; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price can not be zero or less.");
                }
                this.price = value;
            }
        }

        public GenderType Gender { get; private set; }// Value null can not be passed to an Enum, the code will not compile, because Enum is not a nullable type;
         
        public virtual string Print()
        {
            var result = new StringBuilder();

            result.AppendFormat("{0}- {1} - {2}:", Environment.NewLine, this.Brand, this.Name);
            result.AppendFormat("{0}  * Price: ${1}", Environment.NewLine, this.Price);
            result.AppendFormat("{0}  * For gender: {1}", Environment.NewLine, this.Gender);

            return result.ToString();
        }
    }
}
