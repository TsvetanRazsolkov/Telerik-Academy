using System;
using System.Collections.Generic;

/* Write a program that reads three integer numbers N, K and S and an array of N elements
from the console. Find in the array a subset of K elements that have sum S or indicate
about its absence. */

class SubsetKWithSumS
{
    static void Main()
    {
        //int[] arrayOfIntegers = { 2, 1, 2, 4, 3, 2, 6, 9 };
        //int s = 14;
        //int k = 3;
        Console.Write("Enter the length of the array N and press ENTER: ");
        int length = int.Parse(Console.ReadLine());
        int[] arrayOfIntegers = new int[length];
        for (int i = 0; i < arrayOfIntegers.Length; i++)
        {
            Console.Write("arrayOfIntegers[{0}] = ", i);
            arrayOfIntegers[i] = int.Parse(Console.ReadLine());
        }
        Console.Write("Enter the sum S you seek and press ENTER: ");
        int s = int.Parse(Console.ReadLine());
        Console.Write("Enter the number of elements in a subset K and press ENTER: ");
        int k = int.Parse(Console.ReadLine());

        int subsetCounter = 0;
        int numberOfCombinations = (int)Math.Pow(2, arrayOfIntegers.Length);

        for (int i = 1; i < numberOfCombinations; i++)
        {
            int tempSum = 0;
            int subsetElements = 0;
            List<int> subset = new List<int>();
            
            for (int j = 0; j < arrayOfIntegers.Length; j++)
            {
                int mask = 1 << j;
                int bit = (i & mask) >> j;
                if (bit == 1)
                {
                    tempSum += arrayOfIntegers[j];
                    subset.Add(arrayOfIntegers[j]);
                    subsetElements++;
                }
            }
            if (tempSum == s && subsetElements == k)
            {
                Console.WriteLine(string.Join(", ", subset));
                subsetCounter++;
                break;
            }
        }
        if (subsetCounter == 0)
        {
            Console.WriteLine("No.");
        }        
    }
}