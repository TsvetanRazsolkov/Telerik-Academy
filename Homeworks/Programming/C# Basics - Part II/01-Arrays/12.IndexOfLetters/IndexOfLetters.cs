using System;

/* Write a program that creates an array containing all letters from the alphabet (A-Z).
Read a word from the console and print the index of each of its letters in the array. */

class IndexOfLetters
{
    static void Main()
    {
        char[] alphabet = new char[26];
        for (int i = 0; i < alphabet.Length; i++)
        {
            alphabet[i] = (char)('a' + i);
        }
        Console.Write("Type in a word and press ENTER: ");
        string word = Console.ReadLine().ToLower();

        for (int i = 0; i < word.Length; i++)
        {
            for (int j = 0; j < alphabet.Length; j++)
            {
                if (word[i] == alphabet[j])
                {
                    Console.WriteLine(" {0} --> {1}", word[i], j);
                }
            }
        }
    }
}