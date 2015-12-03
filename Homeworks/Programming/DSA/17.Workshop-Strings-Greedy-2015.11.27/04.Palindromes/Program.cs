using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Palindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int index = 0;
            int backwardsIndex = 0;
            while (!IsPalindrome(input))
            {
                input = input.Insert(input.Length - backwardsIndex, input[index].ToString());
                index++;
                backwardsIndex++;
            }

            Console.WriteLine(input);
        }

        static bool IsPalindrome(string word)
        {
            for (int i = 0; i < word.Length / 2; i++)
            {
                if (word[i] != word[word.Length - 1 - i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
