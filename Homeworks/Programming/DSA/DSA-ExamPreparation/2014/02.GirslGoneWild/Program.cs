using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.GirslGoneWild
{
    class Program
    {
        static SortedSet<string> results = new SortedSet<string>();
        static int[] shirts;
        static int n;
        static int k;
        static bool[] used;
        static char[] skirts;
        static char[] inputSkirts;

        static void Main(string[] args)
        {
            k = int.Parse(Console.ReadLine());
            inputSkirts = Console.ReadLine().ToCharArray();
            n = int.Parse(Console.ReadLine());

            shirts = new int[n];
            skirts = new char[n];
            used = new bool[inputSkirts.Length];

            GenerateCombinations(0, 0);

            Console.WriteLine(results.Count);
            foreach (var item in results)
            {
                Console.WriteLine(item);
            }
        }

        static void GenerateCombinations(int index, int start)
        {
            if (index >= n)
            {
                GenerateVariationsNoReps(0, shirts);

                return;
            }
            else
            {
                for (int i = start; i < k; i++)
                {
                    shirts[index] = i;
                    GenerateCombinations(index + 1, i + 1);
                }
            }
        }

        static void GenerateVariationsNoReps(int index, int[] shirts)
        {
            if (index >= n)
            {
                var sb = new StringBuilder();
                for (int i = 0; i < n; i++)
                {
                    sb.Append(string.Format("{0}{1}-", shirts[i], skirts[i]));
                }

                sb.Length--;
                string result = sb.ToString();
                results.Add(result);

                return;
            }
            else
            {
                for (int i = 0; i < inputSkirts.Length; i++)
                    if (!used[i])
                    {
                        used[i] = true;
                        skirts[index] = inputSkirts[i];
                        GenerateVariationsNoReps(index + 1, shirts);
                        used[i] = false;
                    }
            }
        }

    }
}
