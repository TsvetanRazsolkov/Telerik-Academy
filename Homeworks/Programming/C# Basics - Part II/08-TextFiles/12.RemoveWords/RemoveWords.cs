using System;
using System.IO;

// Write a program that removes from a text file all words listed in given another text file.
// Handle all possible exceptions in your methods.

class RemoveWords
{
    const string filePath = "..\\..\\sampleText.txt";
    const string wordsToRemovePath = "..\\..\\targetWords.txt";

    static void Main()
    {
        try
        {
            string[] text = File.ReadAllLines(filePath);
            string wordsToRemove = File.ReadAllText(wordsToRemovePath);
            string[] words = wordsToRemove.Split(new char[] { ' ', ',', '\n', '\r', '\t' },
                                                    StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < text.Length; i++)
            {
                foreach (string word in words)
                {
                    RemoveTargetWord(ref text[i], word);
                }
            }
            File.WriteAllLines(filePath, text);
        }
        catch (ArgumentNullException ane)
        {
            Console.WriteLine(ane.Message);
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }
        catch (FileNotFoundException fne)
        {
            Console.WriteLine(fne.Message);
        }
        catch (FileLoadException fle)
        {
            Console.WriteLine(fle.Message);
        }
        catch (PathTooLongException ptle)
        {
            Console.WriteLine(ptle.Message);
        }
        catch (DirectoryNotFoundException dnfe)
        {
            Console.WriteLine(dnfe.Message);
        }
        catch (UnauthorizedAccessException uae)
        {
            Console.WriteLine(uae.Message);
        }
        catch (NotSupportedException nse)
        {
            Console.WriteLine(nse.Message);
        }
        catch (System.Security.SecurityException se)
        {
            Console.WriteLine(se.Message);
        }
        catch (IOException ioe)
        {
            Console.WriteLine(ioe.Message);
        }
        catch (Exception)
        {
            Console.WriteLine("Unknown error!");
        }
    }

    static void RemoveTargetWord(ref string line, string word)
    {
        try
        {
            int index = 0;
            while (true)
            {
                if (index >= line.Length)
                {
                    break;
                }
                index = line.IndexOf(word, index);
                if (index == -1)
                {
                    break;
                }
                if (index == 0 || char.IsWhiteSpace(line[index - 1])
                               || char.IsPunctuation(line[index - 1]))
                {
                    if (!IsPrefix(line, index, word))
                    {                        
                        line = line.Remove(index, word.Length);
                    }
                }
                index++;
            }
        }
        catch (ArgumentOutOfRangeException aore)
        {
            Console.WriteLine(aore.Message);
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }
    }

    static bool IsPrefix(string line, int index, string word)
    {
        try
        {
            if (index + word.Length < line.Length && (char.IsWhiteSpace(line[index + word.Length])
              || char.IsPunctuation(line[index + word.Length])))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        catch (ArgumentOutOfRangeException aore)
        {
            Console.WriteLine(aore.Message);
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }
        return true;
    }
}