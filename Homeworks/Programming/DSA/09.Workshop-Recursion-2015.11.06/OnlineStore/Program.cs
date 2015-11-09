namespace OnlineStore
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Wintellect.PowerCollections;

    // Solution for 80 points - two time limit tests fail.
    public class Program
    {
        private static Dictionary<string, Bag<Product>> productsByName = new Dictionary<string, Bag<Product>>();
        private static Dictionary<string, Bag<Product>> productsByProducer = new Dictionary<string, Bag<Product>>();
        private static Dictionary<string, Bag<Product>> productsByNameAndProducer = new Dictionary<string, Bag<Product>>();
        private static Dictionary<decimal, Bag<Product>> productsByPrice = new Dictionary<decimal, Bag<Product>>();
        private static StringBuilder output = new StringBuilder();

        public static void Main()
        {
            var commandsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < commandsCount; i++)
            {
                var line = Console.ReadLine().Trim();
                var indexOfWS = line.IndexOf(" ");
                var command = line.Substring(0, indexOfWS);
                var parameters = line.Substring(indexOfWS + 1).Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                if (command == "AddProduct")
                {
                    AddProduct(parameters);
                }
                else if (command == "DeleteProducts")
                {
                    DeleteProduct(parameters);
                }
                else if (command == "FindProductsByName")
                {
                    FindProductsByName(parameters);
                }
                else if (command == "FindProductsByPriceRange")
                {
                    FindProductsByPriceRange(parameters);
                }
                else
                {
                    FindProductsByProducer(parameters);
                }
            }

            Console.WriteLine(output.ToString());
        }

        private static void FindProductsByProducer(string[] parameters)
        {
            var producerKey = parameters[0];
            if (!productsByProducer.ContainsKey(producerKey) ||
                 productsByProducer[producerKey].Count == 0)
            {
                output.AppendLine("No products found");
            }
            else
            {
                var foundProducts = productsByProducer[producerKey].ToArray();
                Array.Sort(foundProducts);

                foreach (var item in foundProducts)
                {
                    output.AppendLine(item.ToString());
                }
            }
        }

        private static void FindProductsByPriceRange(string[] parameters)
        {
            var fromPrice = decimal.Parse(parameters[0]);
            var toPrice = decimal.Parse(parameters[1]);

            var foundProducts = productsByPrice
                .Where(d => fromPrice <= d.Key && d.Key <= toPrice)
                .SelectMany(x => x.Value)
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Producer)
                .ThenBy(p => p.Price);

            if (foundProducts.Count() == 0)
            {
                output.AppendLine("No products found");
            }
            else
            {
                foreach (var item in foundProducts)
                {
                    output.AppendLine(item.ToString());
                }
            }
        }

        private static void FindProductsByName(string[] parameters)
        {
            var name = parameters[0];
            if (!productsByName.ContainsKey(name) ||
                productsByName[name].Count == 0)
            {
                output.AppendLine("No products found");
            }
            else
            {
                var foundProducts = productsByName[name].ToArray();
                Array.Sort(foundProducts);

                foreach (var item in foundProducts)
                {
                    output.AppendLine(item.ToString());
                }
            }
        }

        private static void DeleteProduct(string[] parameters)
        {
            var countOfDeleted = 0;
            if (parameters.Length > 1)
            {
                // DeleteProducts name;producer 
                var nameAndProducerKey = parameters[0] + ";" + parameters[1];
                if (!productsByNameAndProducer.ContainsKey(nameAndProducerKey) ||
                    productsByNameAndProducer[nameAndProducerKey].Count == 0)
                {
                    output.AppendLine("No products found");
                }
                else
                {
                    var productsToRemove = productsByNameAndProducer[nameAndProducerKey];
                    countOfDeleted = productsToRemove.Count;

                    foreach (var product in productsToRemove)
                    {
                        productsByName[product.Name].Remove(product);
                        productsByPrice[product.Price].Remove(product);
                        productsByProducer[product.Producer].Remove(product);
                    }

                    productsByNameAndProducer.Remove(nameAndProducerKey);
                    output.AppendFormat("{0} products deleted", countOfDeleted);
                    output.AppendLine();
                }
            }
            else
            {
                // DeleteProducts producer
                var producerKey = parameters[0];
                if (!productsByProducer.ContainsKey(producerKey) ||
                    productsByProducer[producerKey].Count == 0)
                {
                    output.AppendLine("No products found");
                }
                else
                {
                    var productsToRemove = productsByProducer[producerKey];
                    countOfDeleted = productsToRemove.Count;

                    foreach (var product in productsToRemove)
                    {
                        productsByName[product.Name].Remove(product);
                        productsByNameAndProducer[product.Name + ";" + product.Producer].Remove(product);
                        productsByPrice[product.Price].Remove(product);
                    }

                    productsByProducer.Remove(producerKey);
                    output.AppendFormat("{0} products deleted", countOfDeleted);
                    output.AppendLine();
                }
            }
        }

        private static void AddProduct(string[] parameters)
        {
            var name = parameters[0];
            var price = decimal.Parse(parameters[1]);
            var producer = parameters[2];
            var nameAndProducerKey = parameters[0] + ";" + parameters[2];

            var newProduct = new Product(name, price, producer);

            if (!productsByName.ContainsKey(name))
            {
                productsByName.Add(name, new Bag<Product>());
            }

            productsByName[name].Add(newProduct);

            if (!productsByNameAndProducer.ContainsKey(nameAndProducerKey))
            {
                productsByNameAndProducer.Add(nameAndProducerKey, new Bag<Product>());
            }

            productsByNameAndProducer[nameAndProducerKey].Add(newProduct);

            if (!productsByPrice.ContainsKey(price))
            {
                productsByPrice.Add(price, new Bag<Product>());
            }

            productsByPrice[price].Add(newProduct);

            if (!productsByProducer.ContainsKey(producer))
            {
                productsByProducer.Add(producer, new Bag<Product>());
            }

            productsByProducer[producer].Add(newProduct);

            output.AppendLine("Product added");
        }

        internal class Product : IComparable<Product>
        {
            public Product(string name, decimal price, string producer)
            {
                this.Name = name;
                this.Price = price;
                this.Producer = producer;
            }

            public string Name { get; set; }

            public decimal Price { get; set; }

            public string Producer { get; set; }

            public int CompareTo(Product other)
            {
                return this.ToString().CompareTo(other.ToString());
            }

            public override string ToString()
            {
                return string.Format("{{{0};{1};{2}}}", this.Name, this.Producer, this.Price.ToString("F2"));
            }
        }
    }
}