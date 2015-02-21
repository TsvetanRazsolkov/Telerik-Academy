using System;

/* Write a program that converts a string to a sequence of C# Unicode character literals.
Use format strings.
Example:
input	    output
Hi!	        \u0048\u0069\u0021     */

class UnicodeCharacters
{
    static void Main()
    {
        Console.Write("Enter some string: ");
        string textInput = Console.ReadLine();

        foreach (char symbol in textInput)
        {            
            Console.Write("\\u{0:x4}", (int)symbol);
        }
        Console.WriteLine();
    }
}