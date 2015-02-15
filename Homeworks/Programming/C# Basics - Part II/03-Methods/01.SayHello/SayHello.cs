using System;

/* Write a method that asks the user for his name and prints “Hello, <name>”
Write a program to test this method.
Example:
input	    output
Peter	    Hello, Peter!  */

class SayHello
{
    static void Main()
    {
        PrintHello();
    }

    static void PrintHello()
    {
        Console.Write("Enter your name and press ENTER: ");
        string name = Console.ReadLine();
        
        Console.WriteLine("Hello, {0}!", name);
    }
}