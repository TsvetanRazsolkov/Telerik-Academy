using System;

/* Write a program that reads from the console a string of maximum 20 characters. If 
the length of the string is less than 20, the rest of the characters should be filled
with *. Print the result string into the console.  */

class StringLength
{
    static void Main()
    {
        Console.Write("Enter some text with no more than 20 symbols: ");
        string textInput = Console.ReadLine();
        if (textInput.Length > 20)
        {
            Console.WriteLine("Invalid input. The text should be at most 20 chars.");
        }
        else
        {
            textInput = textInput.PadRight(20, '*');
            Console.WriteLine(textInput);
        }
    }
}