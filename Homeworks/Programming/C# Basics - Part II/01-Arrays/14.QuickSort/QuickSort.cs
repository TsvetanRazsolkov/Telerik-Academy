using System;

// Write a program that sorts an array of integers using the Quick sort algorithm.

class QuickSort
{
    static void Main()
    {
        //int[] arrayOfIntegers = { 3, 7, 8, 5, 2, 1, 9, 5, 4 };
        Console.Write("Enter the length of the array and press ENTER: ");
        int length = int.Parse(Console.ReadLine());
        int[] arrayOfIntegers = new int[length];
        for (int i = 0; i < arrayOfIntegers.Length; i++)
        {
            Console.Write("arrayOfIntegers[{0}] = ", i);
            arrayOfIntegers[i] = int.Parse(Console.ReadLine());
        }

        arrayOfIntegers = Quick_Sort(arrayOfIntegers, 0, arrayOfIntegers.Length - 1);
        Console.WriteLine(string.Join(", ", arrayOfIntegers));
    }

    private static int[] Quick_Sort(int[] arr, int start, int end)
    {
        if (start < end)
        {
            int pivotIndex = Partition(arr, start, end);
            Quick_Sort(arr, start, pivotIndex -1);
            Quick_Sort(arr, pivotIndex + 1, end);
            return arr;
        }
        else
        {
            return arr;
        }
    }

    private static int Partition(int[] arr, int start, int end)
    {
        // Choosing a pivot is optimized by looking for the median of three values:
        //the starting element, the end element and the middle element. Therefore the
        //use of the method ChoosePivot(). This helps in case an array is already sorted.
        int pivotIndex = ChoosePivot(arr, start, end); // Or could choose random index;
        int pivotValue = arr[pivotIndex];
        // Putting the chosen pivot at position with index end(last in the array),
        // if it's not already there.
        if (pivotIndex != end)
        {
            arr[pivotIndex] = arr[pivotIndex] ^ arr[end];
            arr[end] = arr[pivotIndex] ^ arr[end];
            arr[pivotIndex] = arr[pivotIndex] ^ arr[end];
            
        }        

        int storePivotIndex = start;        
        // Compare remaining array elements against pivotValue.
        for (int i = start; i < end; i++)
        {
            if (arr[i] <= pivotValue)
            {
                if (i != storePivotIndex)
                {
                    arr[i] = arr[i] ^ arr[storePivotIndex];
                    arr[storePivotIndex] = arr[i] ^ arr[storePivotIndex];
                    arr[i] = arr[i] ^ arr[storePivotIndex];
                }
                storePivotIndex++;
            }
        }
        // Putting the chosen pivot at its final position, if it's not already there.
        if (storePivotIndex != end)
        {
            arr[storePivotIndex] = arr[storePivotIndex] ^ arr[end];
            arr[end] = arr[storePivotIndex] ^ arr[end];
            arr[storePivotIndex] = arr[storePivotIndex] ^ arr[end];
        }        
        return storePivotIndex;
    }

    private static int ChoosePivot(int[] arr, int start, int end)
    {
        // Sorting the left most element, the right most element and the middle 
        // element of the array. Then choosing for a pivot the element which is 
        // the median of the three.

        int middle = start + (end - start) / 2;
        
        if (arr[start] > arr[middle])
        {
            if (arr[middle] > arr[end])
            {
                return middle;
            }
            else
            {
                return end;
            }
        }
        else
        {
            if (arr[middle] > arr[end])
            {
                if (arr[start] > arr[end])
                {
                    return start;
                }
                else
                {
                    return end;
                }
            }
            else
            {
                return middle;
            }
        }
    }
}