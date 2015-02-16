using System;

/* Write a method that counts how many times given number appears in given array.
Write a test program to check if the method is workings correctly. */

public class AppearanceCount
{
    static void Main()
    {
        int[] arrayOfNumbers = { 1, 1, 2, 5, 5, 5, 4, 4, 5, 5, 21, 1, 2, 5, 21 };
        int numberToCheck = 5;

        int appearances = CountAppearances(arrayOfNumbers, numberToCheck);

        Console.WriteLine("Appearances of {0} --> {1} times", numberToCheck, 
            appearances);
    }

    public static int CountAppearances(int[] arrayOfNumbers, int numberToCheck)
    {
        int count = 0;
        for (int i = 0; i < arrayOfNumbers.Length; i++)
        {
            if (arrayOfNumbers[i] == numberToCheck)
            {
                count++;
            }
        }
        return count;
    }
}