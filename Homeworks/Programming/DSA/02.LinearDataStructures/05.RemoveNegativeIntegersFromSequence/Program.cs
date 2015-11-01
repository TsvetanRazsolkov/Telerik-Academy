/*Write a program that removes from given sequence all negative numbers.*/
namespace _05.RemoveNegativeIntegersFromSequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var sequence = new List<int> { 1, -1, 2, -2, 3, -3, 4, -4};
            Console.WriteLine(string.Join(", ", sequence));

            sequence.RemoveAll(n => n < 0);

            Console.WriteLine(string.Join(", ", sequence));
        }
    }
}
