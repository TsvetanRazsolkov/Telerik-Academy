using System;

// Testing program for the SayHello method:

class TestMethod
{
    static void Main()
    {
        Console.WriteLine("Testing SayHello - " + TestGreeting());
    }

    static string TestGreeting()
    {
        if (SayHello.PrintHello("Peter") != "Hello, Peter!")
        {
            return "Failure!";
        }
        return "Success!";
    }
}