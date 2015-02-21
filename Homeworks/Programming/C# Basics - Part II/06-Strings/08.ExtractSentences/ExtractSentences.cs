using System;

/* Write a program that extracts from a given text all sentences containing given word.
Example:
The word is: in
The text is: We are living in a yellow submarine. We don't have anything else. Inside
the submarine is very tight. So we are drinking all the day. We will move out of it in
5 days.
The expected result is: We are living in a yellow submarine. We will move out of it in
5 days.
Consider that the sentences are separated by . and the words – by non-letter symbols.
*/
class ExtractSentences
{
    static void Main()
    {
        // string textInput = Console.ReadLine();
        string textInput = "We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days. ";
        // string targetWord = Console.ReadLine();
        string targetWord = "in";

        string[] sentences = textInput.Split(new char[] { '.', '?', '!', ';' },
                                   StringSplitOptions.RemoveEmptyEntries);
        foreach (var sentence in sentences)
        {
            string[] words = sentence.Split(new char[] { ' ', ',', '\t', '\n' },
                                         StringSplitOptions.RemoveEmptyEntries);
            foreach (var word in words)
            {
                if (word == targetWord)
                {
                    Console.Write(sentence + '.');
                }
            }
        }
        Console.WriteLine();
    }
}