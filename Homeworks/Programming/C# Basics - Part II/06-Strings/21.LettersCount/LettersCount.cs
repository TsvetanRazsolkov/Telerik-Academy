using System;

// Write a program that reads a string from the console and prints all different letters in the
// string along with information how many times each letter is found.

class LettersCount
{
    static void Main()
    {
        Console.Write("Enter some text: ");
        string someText = Console.ReadLine();

        char[] textAsArray = someText.ToCharArray();

        PrintLetters(textAsArray);
    }

    static void PrintLetters(char[] textAsArray)
    {
        int letterCount = 0;
        char currentLetter;
        for (int i = 0; i < textAsArray.Length; i++)
        {
            if (char.IsLetter(textAsArray[i]))
            {
                currentLetter = textAsArray[i];
                letterCount = CountAppearances(textAsArray, currentLetter);
                Console.WriteLine("{0} -> {1} time(s).", currentLetter, letterCount);
                MarkFoundLetters(textAsArray, currentLetter);
            }
        }
        
    }

    static void MarkFoundLetters(char[] textAsArray, char currentLetter)
    {
        for (int i = 0; i < textAsArray.Length; i++)
        {
            if (textAsArray[i] == currentLetter)
            {
                textAsArray[i] = '*';
            }
        }
    }

    static int CountAppearances(char[] textAsArray, char currentLetter)
    {
        int count = 0;
        for (int i = 0; i < textAsArray.Length; i++)
        {
            if (textAsArray[i] == currentLetter)
            {
                count++;
            }
        }
        return count;
    }
}
