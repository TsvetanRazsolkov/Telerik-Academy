using System;
using System.Collections.Generic;

/* A dictionary is stored as a sequence of text lines containing words and their explanations.
Write a program that enters a word and translates it by using the dictionary.
Sample dictionary:
input   	output
.NET    	platform for applications from Microsoft
CLR     	managed execution environment for .NET
namespace	hierarchical organization of classes
*/

class WordDictionary
{
    static void Main()
    {
        string dictionary = @".NET - platform for applications from Microsoft.
CLR - managed execution environment for .NET.
namespace - hierarchical organization of classes.";
        Console.Write("Enter word to search for in dictionary: ");
        string targetWord = Console.ReadLine().ToUpper();

        string[] separateLines = dictionary.Split(new char[] { '\n', '\r' },
                                     StringSplitOptions.RemoveEmptyEntries);

        Dictionary<string, string> dict = new Dictionary<string, string>();
        foreach (string line in separateLines)
        {
            string[] wordAndExplanation = line.Split(new char[] { '-' },
                              StringSplitOptions.RemoveEmptyEntries);

            dict.Add(wordAndExplanation[0].ToUpper().Trim(), wordAndExplanation[1].Trim());
        }
        if (!dict.ContainsKey(targetWord))
        {
            Console.WriteLine("There is no such word in the dictionary.");
            return;
        }
        Console.WriteLine("{0} - {1}", targetWord, dict[targetWord]);
    }
}