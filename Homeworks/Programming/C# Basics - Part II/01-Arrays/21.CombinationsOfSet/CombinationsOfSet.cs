using System;

/* Write a program that reads two numbers N and K and generates all the combinations
of K distinct elements from the set [1..N].
Example:
N	K	result
5	2	{1, 2} 
        {1, 3} 
        {1, 4} 
        {1, 5} 
        {2, 3} 
        {2, 4} 
        {2, 5} 
        {3, 4} 
        {3, 5} 
        {4, 5}  */

class CombinationsOfSet
{
    static void Main()
    {
        Console.Write("N = ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("K = ");
        int k = int.Parse(Console.ReadLine());

        int[] combinations = new int[k];

        GetCombinations(combinations, 0, n, k, 1);
    }

    private static void GetCombinations(int[] combinations, int position, int n, int k,
        int start)
    {
        if (position == k)
        {
            PrintCombination(combinations);
            return;
        }
        else
        {
            for (int i = start; i <= n; i++)
            {
                combinations[position] = i;
                GetCombinations(combinations, position + 1, n, k, i + 1);
            }
        }
    }

    private static void PrintCombination(int[] combinations)
    {
        Console.WriteLine("{" + string.Join(", ", combinations) + "}");
    }
}