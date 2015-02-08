using System;

/* Write a program that finds the most frequent number in an array.
Example:
input	                                    result
4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3	    4 (5 times)
*/

class FrequentNumber
{
    static void Main()
    {
        //int[] integerArray = { 4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3 };
        Console.Write("Enter the length of the array and press ENTER: ");
        int length = int.Parse(Console.ReadLine());
        int[] integerArray = new int[length];
        for (int i = 0; i < integerArray.Length; i++)
        {
            Console.Write("integerArray[{0}] = ", i);
            integerArray[i] = int.Parse(Console.ReadLine());
        }

        Array.Sort(integerArray);

        int mostFrequent = 0;
        int currentNumber = integerArray[0];
        int mostFrequentCount = 0;
        int currentCount = 0;        
        for (int i = 0; i < integerArray.Length; i++)
        {
            if (integerArray[i] == currentNumber)
            {
                currentCount++;
                if (currentCount >= mostFrequentCount)
                {
                    mostFrequentCount = currentCount;
                    mostFrequent = currentNumber;
                }
            }
            if (integerArray[i] != currentNumber)
            {
                currentNumber = integerArray[i];
                currentCount = 1;
            }
        }

        Console.WriteLine("{0}({1} times).", mostFrequent, mostFrequentCount);
    }
}