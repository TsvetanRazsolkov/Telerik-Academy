using System;

// Write a program that reads a year from the console and checks whether it is a leap one.
// Use System.DateTime.

class LeapYear
{
    static void Main()
    {
        Console.Write("Enter year and press ENTER: ");
        int someYear = int.Parse(Console.ReadLine());

        bool isLeapYear = DateTime.IsLeapYear(someYear);
        if (isLeapYear)
        {
            Console.WriteLine("The year {0} is leap.", someYear);
        }
        else
        {
            Console.WriteLine("The year {0} is NOT leap.", someYear);
        }
    }
}