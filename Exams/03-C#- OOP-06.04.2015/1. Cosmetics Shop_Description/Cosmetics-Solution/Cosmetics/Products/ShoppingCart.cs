
namespace Cosmetics.Products
{
    using System.Collections.Generic;
    using Cosmetics.Common;
    using Cosmetics.Contracts;

    public class ShoppingCart : IShoppingCart
    {
        private IList<IProduct> productList;

        public ShoppingCart()
        {
            this.productList = new List<IProduct>();
        }

        public IList<IProduct> ProductList
        {
            get { return new List<IProduct>(this.productList); }
        }

        public void AddProduct(IProduct product)
        {
            Validator.CheckIfNull(product, string.Format(GlobalErrorMessages.ObjectCannotBeNull, "Product to add"));
            this.productList.Add(product);
        }

        public void RemoveProduct(IProduct product)
        {
            this.productList.Remove(product);
        }

        public bool ContainsProduct(IProduct product)
        {
            return this.productList.Contains(product);
        }

        public decimal TotalPrice()
        {
            decimal totalPrice = 0M;
            foreach (Product product in this.ProductList)
            {
                totalPrice += product.Price;
            }
            return totalPrice;
        }
    }
}
