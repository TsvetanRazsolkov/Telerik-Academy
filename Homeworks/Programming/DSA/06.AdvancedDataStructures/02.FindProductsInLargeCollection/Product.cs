namespace _02.FindProductsInLargeCollection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    public class Product : IComparable<Product>
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int CompareTo(Product other)
        {
            if (other == null)
            {
                return 1;
            }

            return this.Price.CompareTo(other.Price);
        }

        public override string ToString()
        {
            return this.Name + " -> " + this.Price;
        }
    }
}
