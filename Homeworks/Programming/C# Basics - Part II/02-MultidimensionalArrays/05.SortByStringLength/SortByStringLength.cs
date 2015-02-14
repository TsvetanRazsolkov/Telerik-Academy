using System;
using System.Linq;

// You are given an array of strings. Write a method that sorts the array by the length
// of its elements (the number of characters composing them).
class SortByStringLength
{
    static void Main()
    {
        //string[] arrayOfStrings = {"gigi", "gigibigi", "gjm", "nylon", "a"};
        Console.Write("Enter array size: ");
        int n = int.Parse(Console.ReadLine());
        string[] arrayOfStrings = new string[n];
        for (int i = 0; i < arrayOfStrings.Length; i++)
        {
            Console.Write("arrayOfStrings[{0}] = ", i);
            arrayOfStrings[i] = Console.ReadLine();
        }

        SortByLengthOfStrings(arrayOfStrings);

        foreach (string element in arrayOfStrings)
        {
            Console.WriteLine(element);
        }
    }

    static void SortByLengthOfStrings(string[] arrayOfStrings)
    {
        Array.Sort(arrayOfStrings, (x, y) => x.Length.CompareTo(y.Length));
    }
}