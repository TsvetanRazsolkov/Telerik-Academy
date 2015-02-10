using System;

/* Write a program that reads two numbers N and K and generates all the variations
of K elements from the set [1..N].
Example:
N	K	result
3	2	{1, 1} 
        {1, 2} 
        {1, 3} 
        {2, 1} 
        {2, 2} 
        {2, 3} 
        {3, 1} 
        {3, 2} 
        {3, 3}  */

class VariationsOfSet
{
    static void Main()
    {
        Console.Write("N = ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("K = ");
        int k = int.Parse(Console.ReadLine());

        int[] variations = new int[k];

        GetVariations(variations, 0, k, n);
    }

    private static void GetVariations(int[] variations, int position, int k, int n)
    {
        if (position == k)
        {
            PrintVariation(variations);
            return;
        }
        for (int i = 1; i <= n; i++)
        {
            variations[position] = i;
            GetVariations(variations, position + 1, k, n);
        }
    }

    private static void PrintVariation(int[] variations)
    {
        Console.WriteLine("{" + string.Join(", ", variations) + "}");
    }
}