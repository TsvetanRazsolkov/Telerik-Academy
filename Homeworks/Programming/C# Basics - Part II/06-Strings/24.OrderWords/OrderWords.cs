using System;

// Write a program that reads a list of words, separated by spaces and prints the list in an 
// alphabetical order.

class OrderWords
{
    static void Main()
    {
        Console.Write("Enter list of words separated by SPACE: ");
        string text = Console.ReadLine();

        string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        Array.Sort(words);

        foreach (string word in words)
        {
            Console.Write(word + " ");
        }
        Console.WriteLine();
    }
}