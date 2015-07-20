namespace Assertions_Homework
{
    using System;
    using System.Diagnostics;
    using System.Linq;

    using Assertions_Homework.Utils;

    public class AssertionsHomework
    {
        public static void Main()
        {
            int[] arr = new int[] { 3, -1, 15, 4, 17, 2, 33, 0 };
            Console.WriteLine("arr = [{0}]", string.Join(", ", arr));
            SortUtils.SelectionSort(arr);
            Console.WriteLine("sorted = [{0}]", string.Join(", ", arr));

            // SortUtils.SelectionSort(new int[0]); // Test sorting empty array
            SortUtils.SelectionSort(new int[1]); // Test sorting single element array
                        
            Console.WriteLine(SearchUtils.BinarySearch(arr, -1000));
            Console.WriteLine(SearchUtils.BinarySearch(arr, 0));
            Console.WriteLine(SearchUtils.BinarySearch(arr, 17));
            Console.WriteLine(SearchUtils.BinarySearch(arr, 10));
            Console.WriteLine(SearchUtils.BinarySearch(arr, 1000));
        }
    }
}