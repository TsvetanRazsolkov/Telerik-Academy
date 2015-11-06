namespace _02.TradeCompany
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Wintellect.PowerCollections;

    public class Program
    {
        public static void Main()
        {
            var articles = new OrderedMultiDictionary<decimal, Article>(true);

            Console.WriteLine("Start adding 2 000 000 elements(Will take some time):");
            for (int i = 0; i < 2000000; i++)
            {
                if (i % 100000 == 0)
                {
                    Console.Write(".");
                }
                articles.Add(i, new Article { Price = i, BarCode = i.ToString(), Title = "Article" + i, Vendor = "John" + i });
            }

            Console.WriteLine("Elements added.");

            Console.WriteLine("Getting elements in price range 20 000 - 450 000:");
            var articlesInRange = articles.Range(20000, true, 450000, true).Values;
            Console.WriteLine("{0} elements in this price range.", articlesInRange.Count);
        }
    }
}
