using System;

/* Write a method that returns the index of the first element in array that is larger
than its two neighbours simultaneously, or -1, if there’s no such element.
Use the method from the previous exercise.  */

class FirstLargerThanNeighbours
{
    static void Main()
    {
        int[] arrayOfNumbers = { 1, 2, 3, 1};
        int indexOfLarger = CheckLargerElement(arrayOfNumbers);

        if (indexOfLarger == -1)
        {
            Console.WriteLine("There is no such element in the array.");
        }
        else
        {
            Console.WriteLine(indexOfLarger);
        }
    }

    static int CheckLargerElement(int[] arr)
    {
        int index;
        if (arr.Length < 3)
        {
            return -1;
        }
        for (index = 1; index < arr.Length - 1; index++)
        {
            if (arr[index] > arr[index - 1] && arr[index] > arr[index + 1])
            {
                return index;
            }
        }
        return -1;
    }
}