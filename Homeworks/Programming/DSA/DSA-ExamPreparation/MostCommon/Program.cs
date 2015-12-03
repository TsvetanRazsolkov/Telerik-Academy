using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostCommon
{
    class Program
    {
        static Dictionary<string, int> firstNames = new Dictionary<string, int>();
        static Dictionary<string, int> lastNames = new Dictionary<string, int>();
        static Dictionary<string, int> birthYears = new Dictionary<string, int>();
        static Dictionary<string, int> hairs = new Dictionary<string, int>();
        static Dictionary<string, int> eyes = new Dictionary<string, int>();
        static Dictionary<string, int> heights = new Dictionary<string, int>();

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine()
                    .Split(new char[]{' ', ','}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (!firstNames.ContainsKey(tokens[0]))
                {
                    firstNames.Add(tokens[0], 0);
                } 
                if (!lastNames.ContainsKey(tokens[1]))
                {
                    lastNames.Add(tokens[1], 0);
                }
                if (!birthYears.ContainsKey(tokens[2]))
                {
                    birthYears.Add(tokens[2], 0);
                }
                if (!hairs.ContainsKey(tokens[3]))
                {
                    hairs.Add(tokens[3], 0);
                }
                if (!eyes.ContainsKey(tokens[4]))
                {
                    eyes.Add(tokens[4], 0);
                }
                if (!heights.ContainsKey(tokens[5]))
                {
                    heights.Add(tokens[5], 0);
                }

                firstNames[tokens[0]]++;
                lastNames[tokens[1]]++;
                birthYears[tokens[2]]++;
                hairs[tokens[3]]++;
                eyes[tokens[4]]++;
                heights[tokens[5]]++;
            }

            Console.WriteLine(FindMostCommon(firstNames));
            Console.WriteLine(FindMostCommon(lastNames));
            Console.WriteLine(FindMostCommon(birthYears));
            Console.WriteLine(FindMostCommon(hairs));
            Console.WriteLine(FindMostCommon(eyes));
            Console.WriteLine(FindMostCommon(heights));
        }

        static string FindMostCommon(Dictionary<string, int> dict)
        {
            string result = string.Empty;
            int max = 0;

            foreach (var item in dict)
            {
                if (item.Value > max)
                {
                    max = item.Value;
                    result = item.Key;
                }

                if (item.Value == max)
                {
                    if (result.CompareTo(item.Key) > 0)
                    {
                        result = item.Key;
                    }
                }
            }

            return result;
        }
    }
}
