using System;
using System.Linq;

/* Write a program that reads two integer arrays from the console and compares them
element by element.
*/

class CompareArrays
{
    static void Main()
    {                
        Console.Write("Enter the length of the first array and press ENTER: ");
        int firstLength = int.Parse(Console.ReadLine());
        int[] firstIntegerArray = new int[firstLength];
        
        for (int i = 0; i < firstIntegerArray.Length; i++)
        {
            Console.Write("firstIntegerArray[{0}] = ", i);
            firstIntegerArray[i] = int.Parse(Console.ReadLine());
        }

        Console.Write("Enter the length of the second array and press ENTER: ");
        int secondLength = int.Parse(Console.ReadLine());
        int[] secondIntegerArray = new int[secondLength];

        for (int i = 0; i < secondIntegerArray.Length; i++)
        {
            Console.Write("secondIntegerArray[{0}] = ", i);
            secondIntegerArray[i] = int.Parse(Console.ReadLine());
        }

        /* Using Sytem.Linq 
        // Console.WriteLine("The two arrays are equal ==> {0}",firstArray.SequenceEqual
         (secondArray));
        Else: */

        if (firstLength != secondLength)
        {
            Console.WriteLine("The two arrays are not equal.");
        }
        else
        {
            bool areEqual = true;
            for (int i = 0; i < firstLength; i++)
            {
                if (firstIntegerArray[i] != secondIntegerArray[i])
                {
                    areEqual = false;
                }
            }
            if (areEqual)
            {
                Console.WriteLine("The two arrays are equal.");
            }
            else
            {
                Console.WriteLine("The two arrays are not equal.");
            }
        }
        
    }
}