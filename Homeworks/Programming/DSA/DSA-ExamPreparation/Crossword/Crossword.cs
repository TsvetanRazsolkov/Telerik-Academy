using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossword
{
    class Crossword
    {
        static List<string> words = new List<string>();
        static HashSet<string> allWords = new HashSet<string>();
        static string[] arr;
        static int n;
        static bool isFound = false;

        static void Main(string[] args)
        {
            n = int.Parse(Console.ReadLine());
            arr = new string[n];

            for (int i = 0; i < 2 * n; i++)
            {
                string word = Console.ReadLine();
                words.Add(word);
                allWords.Add(word);
            }

            words.Sort();
            
            Solve(0);
            if (!isFound)
            {
                Console.WriteLine("NO SOLUTION!");
            }
        }

        private static void Solve(int index)
        {
            if (index >= n)
            {
                if (IsValidCrossword())
                {
                    isFound = true;
                    PrintCrossword();
                    Environment.Exit(0);
                }

                return;
            }
            else
            {
                foreach(var word in words)
                {
                    arr[index] = word;
                    Solve(index + 1);
                }
            }

        }

        private static void PrintCrossword()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }

        private static bool IsValidCrossword()
        {
            var potentialWord = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    potentialWord.Append(arr[j][i]);
                }

                if (!allWords.Contains(potentialWord.ToString()))
                {
                    return false;
                }
                potentialWord.Clear();
            }

            return true;
        }
    }
}
