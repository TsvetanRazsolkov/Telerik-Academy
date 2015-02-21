using System;

/* Write a program that finds how many times a sub-string is contained in a given text
(perform case insensitive search).
Example:
The target sub-string is "in".
The text is as follows:
We are living in an yellow submarine. We don't have anything
else. inside the submarine is very tight. So we are drinking all the day. We will move
out of it in 5 days.
 * 
The result is: 9  */

class SubstringInText
{
    static void Main()
    {
        Console.WriteLine("Enter text:");
        string text = Console.ReadLine();
        Console.Write("Enter target sub-string: ");
        string targetString = Console.ReadLine();
        int substringOccurences = CountOccurences(text, targetString);
        Console.WriteLine("The sub-string \"{0}\" is contained in the text {1} times ", targetString, substringOccurences);
    }

    private static int CountOccurences(string text, string targetString)
    {
        int result = 0;
        int index = 0;
        int found = 0;
        while(found >= 0)
        {
            found = text.IndexOf(targetString, index);
            if (found >= 0)
            {
                result++;
                index = found + 1;
            }
        }
        return result;
    }
}