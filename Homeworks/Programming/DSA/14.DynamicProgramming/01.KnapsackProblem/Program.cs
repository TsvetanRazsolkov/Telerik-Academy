
/*Write a program based on dynamic programming to solve the "Knapsack Problem":
you are given N products, each has weight Wi and costs Ci
and a knapsack of capacity M 
and you want to put inside a subset of the products with highest cost and weight ≤ M. 
The numbers N, M, Wi and Ci are integers in the range [1..500].

Example: M=10kg, N=6, products:
beer – weight=3, cost=2
vodka – weight=8, cost=12
cheese – weight=4, cost=5
nuts – weight=1, cost=4
ham – weight=2, cost=3
whiskey – weight=8, cost=13
Optimal solution:
nuts + whiskey
weight = 9
cost = 17*/
namespace _01.KnapsackProblem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        private static int N;
        private static int M;
        private static Product[] products;
        private static int[,] costsTable;

        public static void Main()
        {
            products = new Product[]{
                new Product("beer", 3, 2),
                new Product("vodka", 8, 12),
                new Product("cheese", 4, 5),
                new Product("nuts", 1, 4),
                new Product("ham", 2, 3),
                new Product("whiskey", 8, 13)
            };

            N = 6;
            M = 10;

            // Or your input
            // products = GetProductsFromConsole();

            // N + 1 and M + 1 to avoid checks for leaving the bounds of the array
            costsTable = new int[N + 1, M +1];
            for (int product = 1; product < N + 1; product++)
            {
                for (int capacity = 1; capacity < M + 1; capacity++)
                {
                    int upper = costsTable[product - 1, capacity];
                    int current = CalculateCostForCapacity(product, capacity);
                    costsTable[product, capacity] = Math.Max(upper, current);
                }
            }

            var usedProducts = new List<Product>();
            int unusedCapacity = M;
            for (int productIndex = N; productIndex > 0; productIndex--)
            {
                if (costsTable[productIndex, unusedCapacity] != costsTable[productIndex - 1, unusedCapacity])
                {
                    // we have used this item, so:
                    usedProducts.Add(products[productIndex - 1]);
                    unusedCapacity -= products[productIndex - 1].Weight;
                }
            }

            int usedCapacity = usedProducts.Sum(p => p.Weight);
            int bestCost = costsTable[N, M];

            Console.WriteLine("Optimal solution:");
            Console.WriteLine(string.Join(" + ", usedProducts));
            Console.WriteLine("weight = {0}", usedCapacity);
            Console.WriteLine("cost = {0}", bestCost);
        }

        private static int CalculateCostForCapacity(int product, int capacity)
        {
            int productIndex = product - 1;
            int productWeight = products[productIndex].Weight;
            if (productWeight <= capacity)
            {
                int cost = products[productIndex].Cost + costsTable[product - 1, capacity - productWeight];

                return cost;
            }

            return 0;
        }

        private static Product[] GetProductsFromConsole()
        {
            Console.WriteLine("Enter capacity of the knapsack:");
            M = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter number of products:");
            N = int.Parse(Console.ReadLine());
            var products = new List<Product>();

            for (int i = 0; i < N; i++)
            {
                Console.WriteLine("Write product in the format N-W-C, where N is name, W is weight, C is cost(example : nuts-1-20) and press ENTER:");
                string inputLine = Console.ReadLine();
                var tokens = inputLine.Split('-');

                products.Add(new Product(tokens[0], int.Parse(tokens[1]), int.Parse(tokens[2])));
            }

            return products.ToArray();
        }
    }
}
