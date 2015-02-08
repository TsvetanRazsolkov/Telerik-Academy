using System;

/* Write a program that finds the sequence with maximal sum in given array.
Example:
input	                              result
2, 3, -6, -1, 2, -1, 6, 4, -8, 8	  2, -1, 6, 4
Can you do it with only one loop (with single scan through the elements of the array)?
*/

class MaximalSum
{
    static void Main()
    {
        //int[] array = { 2, 3, -6, -1, 2, -1, 6, 4, -8, 8 };
        Console.Write("Enter the length of the array and press ENTER: ");
        int length = int.Parse(Console.ReadLine());
        int[] integerArray = new int[length];
        for (int i = 0; i < integerArray.Length; i++)
        {
            Console.Write("integerArray[{0}] = ", i);
            integerArray[i] = int.Parse(Console.ReadLine());
        }

        int bestStartIndex = 0;
        int bestEndIndex = 0;
        int currentIndex = 0;
        int bestSum = int.MinValue;
        int sum = 0;
        for (int i = 0; i < integerArray.Length; i++)
        {
            if (sum <= 0)
            {
                currentIndex = i;
                sum = 0;
            }
            sum += integerArray[i];            
            if (sum > bestSum)
            {
                bestSum = sum;
                bestStartIndex = currentIndex;
                bestEndIndex = i;
            } 

        }
        for (int i = bestStartIndex; i <= bestEndIndex; i++)
        {
            Console.Write("{0} ", integerArray[i]);
        }
        Console.WriteLine();
    }
}