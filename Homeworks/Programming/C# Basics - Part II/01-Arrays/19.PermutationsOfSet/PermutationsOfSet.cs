using System;

/* Write a program that reads a number N and generates and prints all the permutations
of the numbers [1 … N].
Example:
N	   result
3	   {1, 2, 3} 
       {1, 3, 2} 
       {2, 1, 3} 
       {2, 3, 1} 
       {3, 1, 2} 
       {3, 2, 1} */

class PermutationsOfSet
{
    static void Main()
    {
        Console.Write("N = ");
        int n = int.Parse(Console.ReadLine());

        int[] permutations = new int[n];
        for (int i = 0; i < n; i++)
        {
            permutations[i] = i + 1;
        }

        GetPermutations(permutations, n - 1, n);
    }

    private static void GetPermutations(int[] permutations, int currentPosition, int n)
    {
        if (currentPosition == 0)
        {
            PrintArray(permutations);
            return;
        }

        for (int i = 0; i <= currentPosition; i++)
        {
           
                int temp = permutations[i];
                permutations[i] = permutations[currentPosition];
                permutations[currentPosition] = temp; ;
                GetPermutations(permutations, currentPosition - 1, n);
                temp = permutations[i];
                permutations[i] = permutations[currentPosition];
                permutations[currentPosition] = temp;            
        }
    }

    private static void PrintArray(int[] permutations)
    {
        Console.WriteLine("{" + string.Join(", ", permutations) + "}");
    }
}