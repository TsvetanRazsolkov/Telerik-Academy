namespace Assertions_Homework.Utils
{
    using System;
    using System.Diagnostics;

    public static class SortUtils
    {
        public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
        {
            // All validation is done here in the public method.
            // It will pass correct parameters to the private method FindMinElementIndex<T>().
            Debug.Assert(arr != null, "Array to sort cannot be null.");
            Debug.Assert(arr.Length != 0, "Array is empty.");

            for (int index = 0; index < arr.Length - 1; index++)
            {
                int minElementIndex = FindMinElementIndex(arr, index, arr.Length - 1);
                Swap(ref arr[index], ref arr[minElementIndex]);
            }

            Debug.Assert(Validator.IsCollectionSortedAscending(arr), "Selection sorting is not correct.");
        }

        private static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex)
            where T : IComparable<T>
        {
            int minElementIndex = startIndex;
            for (int i = startIndex + 1; i <= endIndex; i++)
            {
                if (arr[i].CompareTo(arr[minElementIndex]) < 0)
                {
                    minElementIndex = i;
                }
            }

            return minElementIndex;
        }

        private static void Swap<T>(ref T x, ref T y)
        {
            T oldX = x;
            x = y;
            y = oldX;
        }
    }
}
