using System;

// Test program for AppearanceCount method: 

class Program
{
    static void Main()
    {
        Console.WriteLine("Testing SayHello - " + TestGreeting());
    }
    static string TestGreeting()
    {
        if (AppearanceCount.CountAppearances(new int[] { 3, 2, 2, 5, 1, -8, 7, 2 }, 2) != 3)
        {
            return "Failure!";
        }
        return "Success!";
    }
}