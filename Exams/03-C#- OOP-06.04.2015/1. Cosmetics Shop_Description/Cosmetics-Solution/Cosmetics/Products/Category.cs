
namespace Cosmetics.Products
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Cosmetics.Common;
    using Cosmetics.Contracts;

    public class Category : ICategory
    {
        private const int MinCategoryNameLength = 2;
        private const int MaxCategoryNameLength = 15;

        private string name;
        private IList<IProduct> productList;

        public Category(string name)
        {
            this.Name = name;
            this.productList = new List<IProduct>();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                Validator.CheckIfStringIsNullOrEmpty(value, string.Format(GlobalErrorMessages.StringCannotBeNullOrEmpty, "Category name"));
                Validator.CheckIfStringLengthIsValid(value, MaxCategoryNameLength, MinCategoryNameLength,
                    string.Format(GlobalErrorMessages.InvalidStringLength,"Category name", MinCategoryNameLength, MaxCategoryNameLength));

                this.name = value;
            }
        }

        public IList<IProduct> ProductList
        {
            get { return new List<IProduct>(this.productList); }
        }

        public void AddCosmetics(IProduct cosmetics)
        {
            Validator.CheckIfNull(cosmetics, string.Format(GlobalErrorMessages.ObjectCannotBeNull, "Cosmetics to add"));
            this.productList.Add(cosmetics);
        }

        public void RemoveCosmetics(IProduct cosmetics)
        {
            if (!this.ProductList.Contains(cosmetics))
            {
                throw new InvalidOperationException(string.Format("Product {0} does not exist in category {1}!",
                                                                    cosmetics.Name, this.Name));
            }
            this.productList.Remove(cosmetics);
        }

        public string Print()
        {
            var result = new StringBuilder();

            string categoryName = this.Name;
            string numberOfProductsInCategory = this.ProductList.Count.ToString();
            string wordToUseForProductsQuantity = this.ProductList.Count == 1 ? "product" : "products";

            result.AppendFormat("{0} category - {1} {2} in total", categoryName, numberOfProductsInCategory, wordToUseForProductsQuantity);

            var sortedProducts = this.ProductList.OrderBy(p => p.Brand)
                                                 .ThenByDescending(p => p.Price);
            foreach (Product  cosmetics in sortedProducts)
            {
                result.Append(cosmetics.Print());
            }

            return result.ToString();
        }
    }
}
