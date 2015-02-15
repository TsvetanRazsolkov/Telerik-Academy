using System;

/* Write a method that return the maximal element in a portion of array of integers
starting at given index. Using it write another method that sorts an array in 
ascending / descending order.  */

class SortingArray
{
    static void Main()
    {
        int[] arrayOfNumbers = ReadArrayFromConsole();
        //int[] arrayOfNumbers = { 1, 45, 25, 22, 5, 6, 7, 77, 4, 44, 2, 8, 2, 6 };
        Console.Write("Your array: ");
        PrintArray(arrayOfNumbers);
        Console.WriteLine("For sorting in descending order - type 0 and press ENTER,");
        Console.Write("for sorting in ascending order - type 1 and press ENTER: ");
        string choice = Console.ReadLine();

        SortArray(arrayOfNumbers, choice);

        Console.Write("Sorted array: ");
        PrintArray(arrayOfNumbers);
    }

    static int[] ReadArrayFromConsole()
    {
        Console.Write("Enter array elements on a single line separated by SPACE: ");
        string input = Console.ReadLine();
        string[] numbersAsStrings = input.Split(new char[]{' ', ','},
            StringSplitOptions.RemoveEmptyEntries);
        int[] arrayOfIntegers = new int[numbersAsStrings.Length];
        for (int i = 0; i < arrayOfIntegers.Length; i++)
        {
            arrayOfIntegers[i] = int.Parse(numbersAsStrings[i]);
        }
        return arrayOfIntegers;
    }

    static void PrintArray(int[] arrayOfNumbers)
    {
        for (int i = 0; i < arrayOfNumbers.Length; i++)
        {
            Console.Write(arrayOfNumbers[i] + " ");
        }
        Console.WriteLine();
    }

    static void SortArray(int[] arrayOfNumbers, string choice)
    {        
        int swap;
        int indexOfLarger;
        if (choice == "0")
        {
            for (int i = 0; i < arrayOfNumbers.Length; i++)
            {
                indexOfLarger = FindLargest(arrayOfNumbers, i, arrayOfNumbers.Length - 1);
                swap = arrayOfNumbers[i];
                arrayOfNumbers[i] = arrayOfNumbers[indexOfLarger];
                arrayOfNumbers[indexOfLarger] = swap;
            }
        }
        else if (choice == "1")
        {

            for (int i = arrayOfNumbers.Length - 1; i >= 0; i--)
            {
                indexOfLarger = FindLargest(arrayOfNumbers, 0, i);
                swap = arrayOfNumbers[i];
                arrayOfNumbers[i] = arrayOfNumbers[indexOfLarger];
                arrayOfNumbers[indexOfLarger] = swap;
            }
        }
        
    }

    static int FindLargest(int[] arrayOfNumbers, int startIndex, int EndIndex)
    {
        int largest = int.MinValue;
        int bestIndex = 0;
        for (int i = startIndex; i <= EndIndex; i++)
        {
            if (arrayOfNumbers[i] >= largest)
            {
                largest = arrayOfNumbers[i];
                bestIndex = i;
            }
        }
        return bestIndex;
    }
}