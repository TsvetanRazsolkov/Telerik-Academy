using System;

/* We are given an array of integers and a number S.
Write a program to find if there exists a subset of the elements of the array that has a sum S.
Example:
input array	                    S	     result
2, 1, 2, 4, 3, 5, 2, 6         	14	     yes */

    class SubsetWithSumS
    {
        static void Main()
        {
            //int[] arrayOfIntegers = { 2, 1, 2, 4, 3, 5, 2, 6 };
            //int s = 14;
            Console.Write("Enter the length of the array and press ENTER: ");
            int length = int.Parse(Console.ReadLine());
            int[] arrayOfIntegers = new int[length];
            for (int i = 0; i < arrayOfIntegers.Length; i++)
            {
                Console.Write("arrayOfIntegers[{0}] = ", i);
                arrayOfIntegers[i] = int.Parse(Console.ReadLine());
            }
            Console.Write("Enter the sum S you seek and press ENTER: ");
            int s = int.Parse(Console.ReadLine());

            int subsetCounter = 0;
            int numberOfCombinations = (int)Math.Pow(2, arrayOfIntegers.Length);

            for (int i = 1; i < numberOfCombinations; i++)
            {
                int tempSum = 0;
                for (int j = 0; j < arrayOfIntegers.Length; j++)
                {
                    int mask = 1 << j;
                    int bit = (i & mask) >> j;
                    if (bit == 1)
                    {
                        tempSum += arrayOfIntegers[j];
                    }
                }
                if (tempSum == s)
                {
                    subsetCounter++;
                }
            }
            if (subsetCounter >  0)
            {
                Console.WriteLine("Yes.");
            }
            else
            {
                Console.WriteLine("No.");
            }
        }
    }