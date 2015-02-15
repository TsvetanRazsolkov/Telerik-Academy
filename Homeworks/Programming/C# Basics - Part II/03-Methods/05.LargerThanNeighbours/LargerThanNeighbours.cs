using System;

/* Write a method that checks if the element at given position in given array of
integers is larger than its two neighbours (when such exist).  */

class LargerThanNeighbours
{
    static void Main()
    {
        int[] arrayOfNumbers = {1, 3, 2};
        int index = 1;

        string result = CheckLargerElement(arrayOfNumbers, index);

        Console.WriteLine(result);
    }

    static string CheckLargerElement(int[] arr, int index)
    {      
        if (arr.Length == 1)
        {
            return "There is only one element in the array.";
        }
        if (index > 0 && index < arr.Length - 1
            && arr[index] > arr[index - 1] 
            && arr[index] > arr[index + 1])
        {
            return "The number is bigger than its two neighbours.";
        }
        else if ((index == 0 && arr[index] > arr[index + 1])
            || (index == arr.Length - 1 && arr[index] > arr[index - 1]))
        {
            return "The number is larger than its only neighbour.";
        }
        else if (index < 0 || index >= arr.Length)
        {
            return "Index is outside the bounds of the array.";
        }        
        else
        {
            return "Element has no smaller neighbours.";
        }
    }
}