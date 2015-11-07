
/*Write a recursive program for generating and printing all ordered k-element subsets from n-element set (variations Vkn).
Example: n=3, k=2, set = {hi, a, b} → (hi hi), (hi a), (hi b), (a hi), (a a), (a b), (b hi), (b a), (b b)*/
namespace _05.OrderedSubsets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        static string[] words;
        static string[] result;
        static int k;
        static int n;

        public static void Main()
        {
            n = int.Parse(Console.ReadLine());
            words = GenerateRandomStringArray(n);

            k = int.Parse(Console.ReadLine());
            result = new string[k];

            GenerateVariations(0);
        }

        private static string[] GenerateRandomStringArray(int length)
        {
            var array = new string[n];

            for (int i = 0; i < length; i++)
            {
                array[i] = ((char)('a' + i)).ToString();
            }

            return array;
        }

        private static void GenerateVariations(int index)
        {
            if (index == k)
            {
                Console.WriteLine(string.Join(", ", result));
                return;
            }

            for (int i = 0; i < words.Length; i++)
            {
                result[index] = words[i];
                GenerateVariations(index + 1);
            }
        }
    }
}
