using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.OnlineMarket
{
    class Program
    {
        static Dictionary<string, List<Product>> productsByType = new Dictionary<string, List<Product>>();
        static Dictionary<double, List<Product>> productsByPrice = new Dictionary<double, List<Product>>();
        static HashSet<string> names = new HashSet<string>();
        static StringBuilder result = new StringBuilder();

        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            while (command != "end")
            {
                ProcessCommand(command);

                command = Console.ReadLine();
            }
            Console.WriteLine(result.ToString());
        }

        private static void ProcessCommand(string command)
        {
            var commandParts = command.Split(' ');

            switch (commandParts[0])
            {
                case "add":
                    ProcessAddCommand(commandParts);
                    break;
                case "filter":
                    ProcessFilterCommand(commandParts);
                    break;
            }
        }

        private static void ProcessFilterCommand(string[] commandParts)
        {
            if (commandParts.Length == 4)
            {
                FilterByType(commandParts[3]);
            }
            else if (commandParts.Length == 5)
            {
                FilterByPrice(commandParts);
            }
            else
            {
                FilterByRange(commandParts[4], commandParts[6]);
            }
        }

        private static void FilterByRange(string from, string to)
        {
            double fromPrice = double.Parse(from);
            double toPrice = double.Parse(to);

            var bla = productsByPrice.Where(p => p.Key >= fromPrice && p.Key <= toPrice)
                .SelectMany(p => p.Value)
                .OrderBy(p => p.Price)
                .ThenBy(p => p.Name)
                .ThenBy(p => p.Type)
                .Take(10);

            result.AppendLine(string.Format("Ok: {0}", string.Join(", ", bla)));
        }

        private static void FilterByPrice(string[] commandParts)
        {
            double price = double.Parse(commandParts[4]);
            if (commandParts[3] == "from")
            {
                var bla = productsByPrice.Where(p => p.Key >= price)
                .SelectMany(p => p.Value)
                .OrderBy(p => p.Price)
                .ThenBy(p => p.Name)
                .ThenBy(p => p.Type)
                .Take(10);

                result.AppendLine(string.Format("Ok: {0}", string.Join(", ", bla)));
            }
            else
            {
                var bla = productsByPrice.Where(p => p.Key <= price)
                .SelectMany(p => p.Value)
                .OrderBy(p => p.Price)
                .ThenBy(p => p.Name)
                .ThenBy(p => p.Type)
                .Take(10);

                result.AppendLine(string.Format("Ok: {0}", string.Join(", ", bla)));
            }
        }

        private static void FilterByType(string type)
        {
            if (!productsByType.ContainsKey(type))
            {
                result.AppendLine(string.Format("Error: Type {0} does not exists", type));
                return;
            }
            var bla = productsByType[type]
                .OrderBy(p => p.Price)
                .ThenBy(p => p.Name)
                .ThenBy(p => p.Type)
                .Take(10);

            result.AppendLine(string.Format("Ok: {0}", string.Join(", ", bla)));
        }

        private static void ProcessAddCommand(string[] commandParts)
        {
            string name = commandParts[1];
            string type = commandParts[3];
            double price = double.Parse(commandParts[2]);

            if (names.Contains(name))
            {
                result.AppendLine(string.Format("Error: Product {0} already exists", commandParts[1]));
                return;
            }

            if (!productsByType.ContainsKey(type))
            {
                productsByType.Add(type, new List<Product>());
            }

            if (!productsByPrice.ContainsKey(price))
            {
                productsByPrice.Add(price, new List<Product>());
            }

            var productToAdd = new Product
            {
                Name = name,
                Price = price,
                Type = type
            };

            names.Add(name);
            productsByType[type].Add(productToAdd);
            productsByPrice[price].Add(productToAdd);

            result.AppendLine(string.Format("Ok: Product {0} added successfully", name));
        }
    }

    class Product
    {
        public string Type { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public override string ToString()
        {
            return string.Format("{0}({1})", this.Name, this.Price);
        }
    }
}
