
/*Write a program that counts how many times each word from given text file words.txt appears in it. 
 The character casing differences should be ignored. 
 The result words should be ordered by their number of occurrences in the text. 
 Example:

This is the TEXT. Text, text, text – THIS TEXT! Is this the text?

is -> 2

the -> 2

this -> 3

text -> 6*/
namespace _03.OccurencesOfWordsInTextFile
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main()
        {
            string filePath = "..\\..\\words.txt";

            // Considering that a word is consisted only of letters and '
            var separator = new Regex("[^A-Za-z']");

            string text = File.ReadAllText(filePath);

            var occurenceCounter = separator.Split(text.ToLower())
                                            .Where(w => !string.IsNullOrEmpty(w))
                                            .GroupBy(w => w)
                                            .ToDictionary(gr => gr.Key, gr => gr.Count())
                                            .OrderBy(pair => pair.Value);

            Console.WriteLine(text);
            foreach (var pair in occurenceCounter)
            {
                Console.WriteLine("{0} -> {1}", pair.Key, pair.Value);
            }
        }
    }
}
