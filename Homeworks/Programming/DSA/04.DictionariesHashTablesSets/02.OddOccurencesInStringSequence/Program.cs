/* Write a program that extracts from a given sequence of strings all elements that present in it odd number of times. Example:

{C#, SQL, PHP, PHP, SQL, SQL } -> {C#, SQL}*/
namespace _02.OddOccurencesInStringSequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            string[] strings = new string[] { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" };

            var occurencesCounter = new Dictionary<string, int>();
            foreach (var word in strings)
            {
                if (occurencesCounter.ContainsKey(word))
                {
                    occurencesCounter[word]++;
                }
                else
                {
                    occurencesCounter.Add(word, 1);
                }
            }

            Console.Write("{ " + string.Join(", ", strings) + " }");
            Console.Write(" -> { ");
            foreach (var pair in occurencesCounter)
            {
                if (pair.Value % 2 == 1)
                {
                    Console.Write("{0}, ", pair.Key);
                }
            }
            Console.WriteLine("}");

            // Or with Linq:
            var result = strings.GroupBy(s => s)
                                .Where(gr => gr.Count() % 2 == 1)
                                .Select(gr => gr.Key);

            Console.WriteLine("{ " + string.Join(", ", strings) + " } -> { " + string.Join(", ", result) + " }");
        }
    }
}
