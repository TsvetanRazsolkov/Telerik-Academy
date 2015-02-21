using System;

/* We are given a string containing a list of forbidden words and a text containing
some of these words. Write a program that replaces the forbidden words with asterisks.
Example text: Microsoft announced its next generation PHP compiler today. It is based
on .NET Framework 4.0 and is implemented as a dynamic language in CLR.
Forbidden words: PHP, CLR, Microsoft
The expected result: ********* announced its next generation *** compiler today. It is
based on .NET Framework 4.0 and is implemented as a dynamic language in ***.
*/

class ForbiddenWords
{
    static void Main()
    {
        // Console.Write("Enter some text: ");
        // string text = Console.ReadLine();
        string text = "Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.";
        //Console.Write("Enter forbidden words on a single line separated by SPACE: ");
        // string forbiddenWords = Console.ReadLine();
        string forbiddenWords = "PHP, CLR, Microsoft";

        char[] separators = { '.', ',', '!', '?', ';', ' ', '-' };

        string[] forbidden = forbiddenWords.Split(separators, StringSplitOptions.RemoveEmptyEntries);

        int index;
        foreach (var word in forbidden)
        {
            index = 0;
            while (true)
            {
                index = text.IndexOf(word, index);
                if (index >= 0)
                {
                    text = text.Replace(word, new string('*', word.Length));
                    index++;
                }
                else
                {
                    break;
                }
            }
        }

        Console.WriteLine(text);
    }
}