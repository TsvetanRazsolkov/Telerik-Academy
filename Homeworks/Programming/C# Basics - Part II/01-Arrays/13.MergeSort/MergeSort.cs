using System;
using System.Collections.Generic;

// Write a program that sorts an array of integers using the Merge sort algorithm.

class MergeSort
{
    static void Main()
    {
        //List<int> listOfIntegers = new List<int>() { 6, 5, 3, 1, 8, 7, 2, 4 };
        Console.Write("Enter the length of the array and press ENTER: ");
        int length = int.Parse(Console.ReadLine());
        List<int> listOfIntegers = new List<int>();
        for (int i = 0; i < length; i++)
        {
            Console.Write("listOfIntegers[{0}] = ", i);
            listOfIntegers.Add(int.Parse(Console.ReadLine()));
        }        

        listOfIntegers = Merge_Sort(listOfIntegers);
        Console.WriteLine(string.Join(", ", listOfIntegers));
        
    }

    private static List<int> Merge_Sort(List<int> list)
    {        
        if (list.Count <= 1)
        {
            return list;
        }
        
        List<int> left = new List<int>();
        List<int> right = new List<int>();
        int middle = list.Count / 2;
        for (int i = 0; i < middle; i++)
        {
            left.Add(list[i]);
        }
        for (int i = middle; i < list.Count; i++)
        {
            right.Add(list[i]);
        }

        left = Merge_Sort(left);
        right = Merge_Sort(right);

        return Merge(left, right);
    }

    private static List<int> Merge(List<int> left, List<int> right)
    {
        List<int> result = new List<int>();
        int i = 0, j = 0;
        while (i < left.Count && j < right.Count)
        {
            if (left[i] <= right[j])
            {
                result.Add(left[i]);
                i++;
            }
            else
            {
                result.Add(right[j]);
                j++;
            }
        }
        while (i < left.Count)
        {
            result.Add(left[i]);
            i++;
        }
        while (j < right.Count)
        {
            result.Add(right[j]);
            j++;
        }
        return result;
    }
}