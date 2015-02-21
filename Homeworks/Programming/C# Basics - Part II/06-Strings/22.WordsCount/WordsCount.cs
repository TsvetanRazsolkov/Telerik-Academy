using System;

// Write a program that reads a string from the console and lists all different words in the 
// string along with information how many times each word is found.

class WordsCount
{
    static char[] separators = { ' ', ',', '?', '.', '!', ';', '\t', '\r', '\n', '*', '-', '/',
                                   ':', '(', ')', '_', '<', '>', '\\'};
    static void Main()
    {
        Console.Write("Enter some text: ");
        string someText = Console.ReadLine();
        someText = someText.ToLower();

        PrintWords(someText);
    }

    static void PrintWords(string someText)
    {
        string[] textArray = someText.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                
        int wordCount = 0;
        string currentWord;

        for (int i = 0; i < textArray.Length; i++)
        {
            if (textArray[i] != string.Empty && IsNotNumber(textArray[i]))
            {
                currentWord = textArray[i];
                wordCount = CountWords(textArray, currentWord, i);
                Console.WriteLine("{0} --> {1} time(s).", currentWord, wordCount);
                MarkFoundWords(textArray, currentWord);
            }
        }
    }

    static bool IsNotNumber(string currentWord)
    {
        int digitCount = 0;
        for (int i = 0; i < currentWord.Length; i++)
        {
            if (char.IsDigit(currentWord[i]))
            {
                digitCount++;
            }
        }
        if (digitCount == currentWord.Length)
        {
            return false;
        }
        return true;
    }

    static void MarkFoundWords(string[] textArray, string currentWord)
    {
        string marker = string.Empty;
        for (int i = 0; i < textArray.Length; i++)
        {
            if (textArray[i] == currentWord)
            {
                textArray[i] = marker;
            }
        }
    }

    static int CountWords(string[] textArray, string currentWord, int index)
    {
        int count = 0;
        for (int i = index; i < textArray.Length; i++)
        {
            if (textArray[i] == currentWord)
            {
                count++;
            }
        }
        return count;
    }
}