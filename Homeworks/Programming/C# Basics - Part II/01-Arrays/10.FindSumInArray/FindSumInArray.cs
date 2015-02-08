using System;

/* Write a program that finds in given array of integers a sequence of given 
sum S (if present).
Example:
array	                   S	       result
4, 3, 1, 4, 2, 5, 8	       11	       4, 2, 5
*/
    class FindSumInArray
    {
        static void Main()
        {
            //int[] integerArray = { 4, 3, 1, 4, 2, 5, 8 };
            //int s = 11;
            Console.Write("Enter the sum S and press ENTER: ");
            int s = int.Parse(Console.ReadLine());
            Console.Write("Enter the length of the array and press ENTER: ");
            int length = int.Parse(Console.ReadLine());
            int[] integerArray = new int[length];
            for (int i = 0; i < integerArray.Length; i++)
            {
                Console.Write("integerArray[{0}] = ", i);
                integerArray[i] = int.Parse(Console.ReadLine());
            }

            int startIndex = 0;
            int currIndex = 0;
            int currSum = 0;
            int endIndex = 0;
            for (int i = 0; i < integerArray.Length; i++)
            {
                if (currSum < s)
                {
                    currSum += integerArray[i];
                }
                if (currSum == s)
                {
                    startIndex = currIndex;
                    endIndex = i;
                    break;
                }
                if (currSum > s)
                {
                    i = currIndex;
                    currIndex++;
                    currSum = 0;
                }
                if (currSum != s && i == integerArray.Length - 1)
                {
                    Console.WriteLine("There is no sequence of elements with sum S = {0}", s);
                    return;
                }
            }
            Console.Write(integerArray[startIndex]);
            for (int i = startIndex + 1; i <= endIndex; i++)
            {
                Console.Write(", {0}", integerArray[i]);
            }
            Console.WriteLine();
        }
    }