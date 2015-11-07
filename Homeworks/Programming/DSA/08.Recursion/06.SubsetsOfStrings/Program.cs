
/*Write a program for generating and printing all subsets of k strings from given set of strings.
Example: s = {test, rock, fun}, k=2 → (test rock), (test fun), (rock fun)*/
namespace _06.SubsetsOfStrings
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

        public static void Main()
        {
            words = new string[] { "test", "rock", "fun"};

            k = int.Parse(Console.ReadLine());
            result = new string[k];

            GenerateVariatons(0, 0);
        }

        private static void GenerateVariatons(int index, int start)
        {
            if (index == 2)
            {
                Console.WriteLine(string.Join(", ", result));
                return;
            }

            for (int i = start; i < words.Length; i++)
            {
                result[index] = words[i];
                GenerateVariatons(index + 1, i + 1);
            }
        }
    }
}
