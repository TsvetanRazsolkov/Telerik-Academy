using System;

/*Write a program that finds the index of given element in a sorted array of integers by
using the Binary search algorithm. */

class BinarySearch
{
    static void Main()
    {
        //int[] arrayOfIntegers = { 1, 2, 3, 4, 5, 6, 8, 9, 11, 14, 15 };
        //int searchedValue = 6;        
        Console.Write("Enter the length of the array and press ENTER: ");
        int length = int.Parse(Console.ReadLine());
        int[] arrayOfIntegers = new int[length];
        for (int i = 0; i < arrayOfIntegers.Length; i++)
        {
            Console.Write("arrayOfIntegers[{0}] = ", i);
            arrayOfIntegers[i] = int.Parse(Console.ReadLine());
        }
        Console.Write("Enter the element you seek and press ENTER: ");
        int searchedValue = int.Parse(Console.ReadLine());

        int indexMin = 0;
        int indexMax = arrayOfIntegers.Length - 1;        

        // Non-recursive implementation:
        int foundIndex = -1;
        while (indexMax >= indexMin)
        {
            int midIndex = indexMin + (indexMax - indexMin) / 2;
            if (arrayOfIntegers[midIndex] == searchedValue)
            {
                foundIndex = midIndex;
                break;
            }
            else if (arrayOfIntegers[midIndex] < searchedValue)
            {
                indexMin = midIndex + 1;
            }
            else
            {
                indexMax = midIndex - 1;
            }
        }
        if (foundIndex >= 0)
        {
            Console.WriteLine("The element was found at index {0}", foundIndex);
        }
        else
        {
            Console.WriteLine("The number was NOT found.");
        }

        // Recursive implementation:
    //    int foundIndex = Binary_Search(arrayOfIntegers, searchedValue, indexMin,
    //    indexMax);
    //    if (foundIndex >= 0)
    //    {
    //        Console.WriteLine("The element was found at index {0}", foundIndex);
    //    }
    //    else
    //    {
    //        Console.WriteLine("The number was NOT found.");
    //    }
    //}
    //static int Binary_Search(int[] array, int key, int iMin, int iMax)
    //{
    //    if (iMax < iMin)
    //    {
    //        return -1;
    //    }
    //    else
    //    {
    //        int midIndex = iMin + (iMax - iMin) / 2;
    //        if (array[midIndex] < key)
    //        {
    //            return Binary_Search(array, key, midIndex + 1, iMax);
    //        }
    //        else if (array[midIndex] > key)
    //        {
    //            return Binary_Search(array, key, iMin, midIndex - 1);
    //        }
    //        else
    //        {
    //            return midIndex;
    //        }
    //    }
    }
}