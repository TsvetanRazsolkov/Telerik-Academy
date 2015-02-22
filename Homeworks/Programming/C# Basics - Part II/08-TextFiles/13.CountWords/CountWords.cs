using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

/* Write a program that reads a list of words from the file words.txt and finds how many times
each of the words is contained in another file test.txt.
The result should be written in the file result.txt and the words should be sorted by the number 
of their occurrences in descending order. Handle all possible exceptions in your methods. */

class CountWords
{
    static char[] separators = { ' ', ',', '\r', '\n', '\t', '.', '?', '!', '-' };

    static void Main()
    {
        string testFilePath = "..\\..\\test.txt";
        string wordsFilePath = "..\\..\\words.txt";
        string resultFilePath = "..\\..\\result.txt";

        Dictionary<string, int> dictionary = new Dictionary<string, int>();

        try
        {
            StreamReader wordsReader = new StreamReader(wordsFilePath);
            StreamReader testReader = new StreamReader(testFilePath);
            StreamWriter resultWriter = new StreamWriter(resultFilePath);
            using (wordsReader)
            using (testReader)
            using (resultWriter)
            {
                // Adding all searched words in a dictionary as keys and as values - their 
                // appearances(initialy 0);
                string[] targetWords =
                    wordsReader.ReadToEnd().ToLower().Split(separators,                                    StringSplitOptions.RemoveEmptyEntries);
                foreach (string word in targetWords)
                {
                    dictionary.Add(word, 0);
                }
                // Reading the test.txt file and splitting it into single words.
                string[] allWords = testReader.ReadToEnd().ToLower().Split(separators,                                        StringSplitOptions.RemoveEmptyEntries); 
                // Count target words appearances in the test.txt:
                for (int i = 0; i < allWords.Length; i++)
                {
                    if (dictionary.ContainsKey(allWords[i]))
                    {
                        dictionary[allWords[i]]++;
                    }
                }
                // Sorting the dictionary in descending order by value(number of appearances):
                List<KeyValuePair<string, int>> wordsAppearances = dictionary.ToList();
                wordsAppearances.Sort((x, y) => y.Value.CompareTo(x.Value));

                foreach (var pair in wordsAppearances)
                {
                    resultWriter.Write("{0} --> {1} time(s)", pair.Key, pair.Value);
                    resultWriter.WriteLine();
                }
            }
            
            
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }
        catch (PathTooLongException ptle)
        {
            Console.WriteLine(ptle.Message);
        }
        catch (System.IO.FileNotFoundException fne)
        {
            Console.WriteLine(fne.Message);
        }
        catch (System.IO.DirectoryNotFoundException dnfe)
        {
            Console.WriteLine(dnfe.Message);
        }
        catch (System.IO.DriveNotFoundException drnfe)
        {
            Console.WriteLine(drnfe.Message);
        }
        catch (System.IO.IOException ioe)
        {
            Console.WriteLine(ioe.Message);
        }
        catch (UnauthorizedAccessException uae)
        {
            Console.WriteLine(uae.Message);
        }
        catch (OutOfMemoryException ome)
        {
            Console.WriteLine(ome.Message);
        }
        catch (Exception)
        {
            Console.WriteLine("Unknown error!");
        }
    }
}