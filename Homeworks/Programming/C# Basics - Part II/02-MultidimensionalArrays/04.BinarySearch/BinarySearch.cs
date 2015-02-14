using System;

// Write a program, that reads from the console an array of N integers and an integer K,
// sorts the array and using the method Array.BinSearch() finds the largest number
// in the array which is ≤ K.

class BinarySearch
{
    static void Main()
    {
        Console.Write("Enter array length: ");
        int n = int.Parse(Console.ReadLine());
        int[] arrayOfIntegers = new int[n];
        for (int i = 0; i < arrayOfIntegers.Length; i++)
        {
            Console.Write("arrayOfIntegers[{0}] = ", i);
            arrayOfIntegers[i] = int.Parse(Console.ReadLine());
        }
        Console.Write("Enter number K: ");
        int k = int.Parse(Console.ReadLine());
        int number = k;

        Array.Sort(arrayOfIntegers);
        int positionOfNumber = Array.BinarySearch(arrayOfIntegers, number);
        while (positionOfNumber < 0)
        {
            number--;
            positionOfNumber = Array.BinarySearch(arrayOfIntegers, number);
        }
        Console.WriteLine("The largest number in the array, that is <= k is {0}",number);
    }
}