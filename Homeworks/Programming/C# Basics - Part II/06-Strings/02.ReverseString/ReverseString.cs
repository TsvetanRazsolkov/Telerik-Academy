using System;
using System.Text;

/* Write a program that reads a string, reverses it and prints the result at the
console.
Example:
input	    output
sample	    elpmas  */

class ReverseString
{
    static void Main()
    {
        Console.Write("Enter some string: ");
        string inputString = Console.ReadLine();
        string outputString = Reverse(inputString);
        Console.WriteLine(outputString);
    }

    static string Reverse(string inputString)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = inputString.Length - 1; i >= 0; i--)
        {
            sb.Append(inputString[i]);
        }
        return sb.ToString();
    }
}