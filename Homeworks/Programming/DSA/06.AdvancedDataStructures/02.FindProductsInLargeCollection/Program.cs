
/*Write a program to read a large collection of products (name + price) and efficiently find the first 20 products in the price range [a…b].
Test for 500 000 products and 10 000 price searches.
Hint: you may use OrderedBag<T> and sub-ranges.*/
namespace _02.FindProductsInLargeCollection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Wintellect.PowerCollections;

    public class Program
    {
        public static void Main()
        {
            OrderedBag<Product> products = new OrderedBag<Product>();

            for (int i = 0; i < 500000; i++)
            {
                products.Add(new Product 
                {
                    Name = "Product" + i,
                    Price = i
                });
            }

            decimal startOfInterval = 50M;
            decimal endOfInterval = 500M;
            var output = new StringBuilder();
            for (int i = 0; i < 10000; i++)
            {
                var result = products.Range(
                    new Product { Name = "", Price = startOfInterval }, true, new Product { Name = "", Price = endOfInterval }, true)
                                     .Take(20);

                output.AppendLine(string.Join(", ", result));

                startOfInterval += 10;
                endOfInterval += 10;
            }

            Console.WriteLine(output.ToString());
        }
    }
}
