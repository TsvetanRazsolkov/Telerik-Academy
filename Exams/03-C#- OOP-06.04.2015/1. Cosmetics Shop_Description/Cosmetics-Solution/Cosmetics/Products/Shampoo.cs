
namespace Cosmetics.Products
{
    using System;
    using System.Text;
    using Cosmetics.Common;
    using Cosmetics.Contracts;

    public class Shampoo : Product, IShampoo
    {
        private uint milliliters;

        public Shampoo(string name, string brand, decimal price, GenderType gender, uint milliliters, UsageType usage)
            : base(name, brand, price, gender)
        {
            this.Milliliters = milliliters;
            this.Usage = usage;
        }

        public override decimal Price
        {
            get
            {
                return base.Price * this.Milliliters;
            }
        }

        public uint Milliliters
        {
            get { return this.milliliters; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Shampoo must have a positive volume.");
                }
                this.milliliters = value;
            }
        }

        public UsageType Usage { get; private set; } // Value null can not be passed to an Enum, the code will not compile, because Enum is not a nullable type;
                                                     // Therefore - no need to check whether a value null is passed to the property;


        public override string Print()
        {
            var result = new StringBuilder();

            result.Append(base.Print());

            result.AppendFormat("{0}  * Quantity: {1} ml", Environment.NewLine, this.Milliliters);
            result.AppendFormat("{0}  * Usage: {1}", Environment.NewLine, this.Usage);

            return result.ToString();
        }
    }
}
