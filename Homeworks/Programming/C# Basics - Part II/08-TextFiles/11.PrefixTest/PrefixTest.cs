using System;
using System.IO;
using System.Text;

/* Write a program that deletes from a text file all words that start with the prefix test.
Words contain only the symbols 0…9, a…z, A…Z, _.   */

class PrefixTest
{
    const string filePath = "..\\..\\sample.txt";
    const string prefix = "test";

    static void Main()
    {
        // Check sample.txt before running.

        string[] allLines = File.ReadAllLines(filePath);

        for (int i = 0; i < allLines.Length; i++)
        {
            RemoveTargetWords(ref allLines[i]);
        }

        File.WriteAllLines(filePath, allLines);
    }

    static void RemoveTargetWords(ref string line)
    {
        int index = 0;
        while (true)
        {
            if (index >= line.Length)
            {
                break;
            }
            index = line.IndexOf(prefix, index);
            if (index == -1)
            {
                break;
            }
            if (index == 0 || (!char.IsLetter(line[index - 1]) && !char.IsDigit(line[index - 1])
                 && line[index - 1] != '_'))
            {
                if (IsPrefix(line, index))
                {
                    int wordLength = GetWordLength(line, index);
                    line = line.Remove(index, wordLength);
                }
            }
            index++;
        }
    }

    static int GetWordLength(string line, int index)
    {
        int wordLength = prefix.Length;
        int wordInd = index + prefix.Length;
        while (true)
        {
            if (wordInd >= line.Length || (!char.IsLetter(line[wordInd])
               && !char.IsDigit(line[wordInd]) && line[wordInd] != '_'))
            {
                break;
            }
            wordInd++;
            wordLength++;
        }
        return wordLength;
    }


    static bool IsPrefix(string line, int index)
    {
        if (index + prefix.Length < line.Length && (char.IsLetter(line[index + prefix.Length])
          || char.IsDigit(line[index + prefix.Length]) || line[index + prefix.Length] == '_'))
        {
            return true;
        }
        return false;
    }
}