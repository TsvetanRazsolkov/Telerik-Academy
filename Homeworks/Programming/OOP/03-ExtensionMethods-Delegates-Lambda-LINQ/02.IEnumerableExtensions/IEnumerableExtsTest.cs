/* Implement a set of extension methods for IEnumerable<T> that implement the following group
functions: sum, product, min, max, average. */
namespace IEnumerableExtensions
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class IEnumerableExtsTest
    {
        public static readonly string separator = new string('-', Console.WindowWidth);

        static void Main()
        {
            Console.WriteLine("Test Sum(): ");
            int[] integerCollection = new int[]{1, 2, 3, 4, 5};
            int integerSum = integerCollection.Sum();
            Console.Write("Integer collection: ");
            PrintCollection(integerCollection);
            Console.WriteLine("Sum = {0}", integerSum);

            string[] stringCollection = new string[] { "lo", "ko", "mo", "tiv" };            
            string strSum = stringCollection.Sum();
            Console.Write("String collection: ");
            PrintCollection(stringCollection);
            Console.WriteLine("Sum = {0}", strSum);
            Console.WriteLine(separator);

            Console.WriteLine("Test Product(): ");
            long integerProduct = integerCollection.Product();
            Console.Write("Integer collection: ");
            PrintCollection(integerCollection);
            Console.WriteLine("Product = {0}", integerProduct);
            Console.WriteLine(separator);

            Console.WriteLine("Test Min(): ");
            Console.Write("Integer collection: ");
            PrintCollection(integerCollection);
            int integerMin = integerCollection.Min();
            Console.WriteLine("Min = {0}", integerMin);

            Console.Write("String collection: ");
            PrintCollection(stringCollection);
            string strMin = stringCollection.Min();
            Console.WriteLine("Min = {0}", strMin);
            Console.WriteLine(separator);

            Console.WriteLine("Test Max(): ");
            Console.Write("Integer collection: ");
            PrintCollection(integerCollection);
            int integerMax = integerCollection.Max();
            Console.WriteLine("Max = {0}", integerMax);

            Console.Write("String collection: ");
            PrintCollection(stringCollection);
            string strMax = stringCollection.Max();
            Console.WriteLine("Max = {0}", strMax);
            Console.WriteLine(separator);

            Console.WriteLine("Test Average(): ");
            Console.Write("Integer collection: ");
            PrintCollection(integerCollection);
            int integerAverage = integerCollection.Average();
            Console.WriteLine("Average = {0}", integerAverage);
            Console.WriteLine(separator);
        }

        static void PrintCollection(IEnumerable collection)
        {
            foreach (var item in collection)
            {
                Console.Write("{0, -5}", item);
            }
        }
    }
}
