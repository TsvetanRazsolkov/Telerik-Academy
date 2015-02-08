using System;

/* Write a program that finds the maximal increasing sequence in an array.
Example:
input	               result
3, 2, 3, 4, 2, 2, 4	   2, 3, 4
*/
class MaximalIncreasingSequence
{
    static void Main()
    {
        //int[] integerArray = { 3, 2, 3, 4, 2, 2, 4 };
        Console.Write("Enter the length of the array and press ENTER: ");
        int length = int.Parse(Console.ReadLine());
        int[] integerArray = new int[length];
        for (int i = 0; i < integerArray.Length; i++)
        {
            Console.Write("integerArray[{0}] = ", i);
            integerArray[i] = int.Parse(Console.ReadLine());
        }

        int start = integerArray[0];
        int currentLength = 0;
        int bestStart = 0;
        int bestLength = 0;

        for (int i = 0; i < integerArray.Length; i++)
        {
            if (integerArray[i] == start + 1)
            {
                start = integerArray[i];
                currentLength++;
            }
            else if (integerArray[i] != start)
            {
                start = integerArray[i];
                currentLength = 1;
            }
            if (currentLength >= bestLength)
            {
                bestLength = currentLength;
                bestStart = i - (bestLength - 1);
            }
        }

        Console.WriteLine("The input array is: " + string.Join(", ", integerArray));
        Console.Write("Longest sequence of increasing elements: ");
        for (int i = bestStart; i < bestStart + bestLength; i++)
        {
            Console.Write("{0} ", integerArray[i]);
        }
        Console.WriteLine();
    }
}
