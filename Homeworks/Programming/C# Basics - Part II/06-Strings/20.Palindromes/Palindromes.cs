using System;

// Write a program that extracts from a given text all palindromes, e.g. ABBA, lamal, exe.

class Palindromes
{
    static char[] separators = { ' ', ',', '?', '.', '!', ';', '\t', '\r', '\n' };
    static void Main()
    {
        string text = "ABBA, lamal, exe, asd, 3443, 1234. !!11dffd11?? ;;";
        Console.WriteLine("Initial text:\n" + text + "\n");

        string[] textAsArray = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

        Console.WriteLine("Palindromes:");
        foreach (string word in textAsArray)
        {
            if (IsPalindrome(word))
            {
                Console.Write(word + " ");
            }
        }
        Console.WriteLine();
    }

    static bool IsPalindrome(string word)
    {
        bool validPalindrome = true;
        for (int i = 0; i < word.Length/2; i++)
        {
            if (word[i] != word[word.Length - 1 - i])
            {
                validPalindrome = false;
            }
        }
        return validPalindrome;
    }
}