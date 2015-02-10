using System;

/* Write a program that reads an array of integers and removes from it a minimal number
of elements in such a way that the remaining array is sorted in increasing order.
Print the remaining sorted array.
Example:
input	                       result
6, 1, 4, 3, 0, 3, 6, 4, 5	   1, 3, 3, 4, 5  */

class RemoveElementsFromArray
{
    static void Main()
    {
        //int[] arrayOfIntegers = { 6, 1, 4, 3, 0, 3, 6, 4, 5 };
        Console.Write("Enter the length of the array N and press ENTER: ");
        int length = int.Parse(Console.ReadLine());
        int[] arrayOfIntegers = new int[length];
        for (int i = 0; i < arrayOfIntegers.Length; i++)
        {
            Console.Write("arrayOfIntegers[{0}] = ", i);
            arrayOfIntegers[i] = int.Parse(Console.ReadLine());
        }

        arrayOfIntegers = RemoveElements(arrayOfIntegers);
        Console.WriteLine(string.Join(", ", arrayOfIntegers));
    }
    // Finding the longest increasing subsequence, filling it into an array and returning
    // this array as the result.
    // http://en.wikipedia.org/wiki/Longest_increasing_subsequence#Efficient_algorithms

    private static int[] RemoveElements(int[] arrayOfIntegers)
    {
        int[] topIndices = new int[arrayOfIntegers.Length + 1];
        int[] previousIndices = new int[arrayOfIntegers.Length];
        int sequenceLength = 0;
        for (int i = 0; i < arrayOfIntegers.Length; i++)
        {
            int start = 1;
            int end = sequenceLength;
            while (start <= end)
            {
                int middle = start + (end - start) / 2;
                if (arrayOfIntegers[topIndices[middle]] <= arrayOfIntegers[i])
                {
                    start = middle + 1;
                }
                else
                {
                    end = middle - 1;
                }
            }
            int newSequenceLength = start;
            previousIndices[i] = topIndices[newSequenceLength - 1];
            topIndices[newSequenceLength] = i;
            if (newSequenceLength > sequenceLength)
            {
                sequenceLength = newSequenceLength;
            }
        }
        int[] longestSubsequence = new int[sequenceLength];
        int k = topIndices[sequenceLength];
        for (int i = sequenceLength - 1; i >= 0; i--)
        {
            longestSubsequence[i] = arrayOfIntegers[k];
            k = previousIndices[k];
        }
        return longestSubsequence;
    }
}