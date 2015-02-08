using System;

/* Write a program that reads two integer numbers N and K and an array of N elements from
the console. Find in the array those K elements that have maximal sum.
*/

class MaximalKSum
{
    static void Main()
    {
        Console.Write("Enter number of elements K and press ENTER: ");
        int k = int.Parse(Console.ReadLine());
        Console.Write("Enter length of the array N and press ENTER: ");
        int length = int.Parse(Console.ReadLine());
        if (k > length || k <= 0 )
        {
            Console.WriteLine("Invalid input. K should be less or equal to the array length and bigger than 0.");
            return;
        }
        int[] integerArray = new int[length];
        for (int i = 0; i < integerArray.Length; i++)
        {
            Console.Write("integerArray[{0}] = ", i);
            integerArray[i] = int.Parse(Console.ReadLine());
        }

        Console.WriteLine("The input array is: " + string.Join(", ", integerArray));

        Array.Sort(integerArray);
        int maximalSum = 0;
        for (int i = integerArray.Length - 1; i > integerArray.Length - 1 - k; i--)
        {
            maximalSum += integerArray[i];
        }
        
        Console.WriteLine("The maximal sum of {0} elements in the array is: {1}", k, maximalSum);
    }
}