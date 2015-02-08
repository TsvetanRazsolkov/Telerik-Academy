using System;

// Sorting an array means to arrange its elements in increasing order. Write a program to sort an array. Use the Selection sort algorithm: Find the smallest element, move it at the first position, find the smallest from the rest, move it at the second position,   etc.

class SelectionSort
{
    static void Main()
    {
        int[] arrayOfIntegers = { 2, 5, 2, 4, 1, 9, 6, 5, 8, 7, 12, 11, 9, 19 };
        Console.WriteLine("The input array is: " + string.Join(", ", arrayOfIntegers));

        int indexMin;
        int temp; 
        for (int i = 0; i < arrayOfIntegers.Length - 1; i++)
        {
            indexMin = i;
            for (int j = i + 1 ; j < arrayOfIntegers.Length; j++)
            {
                if (arrayOfIntegers[j] < arrayOfIntegers[indexMin])
                {
                    indexMin = j;
                }
            }
            if (i != indexMin)
            {
                temp = arrayOfIntegers[i];
                arrayOfIntegers[i] = arrayOfIntegers[indexMin];
                arrayOfIntegers[indexMin] = temp;
            }
        }

        Console.WriteLine("The sorted array is: " + string.Join(", ", arrayOfIntegers));
    }
}