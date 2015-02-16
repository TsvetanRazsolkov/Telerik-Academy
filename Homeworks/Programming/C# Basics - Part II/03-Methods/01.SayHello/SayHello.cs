using System;

/* Write a method that asks the user for his name and prints “Hello, <name>”
Write a program to test this method.
Example:
input	    output
Peter	    Hello, Peter!  */

public class SayHello
{
    static void Main()
    {
        Console.Write("Enter your name and press ENTER: ");
        string name = Console.ReadLine();
        Console.WriteLine(PrintHello(name));
    }

    public static string PrintHello(string name)
    {       
        return "Hello, " + name + "!";
    }
}