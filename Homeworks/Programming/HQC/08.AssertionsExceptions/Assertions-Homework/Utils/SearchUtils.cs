namespace Assertions_Homework.Utils
{
    using System;
    using System.Diagnostics;

    public static class SearchUtils
    {
        public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
        {
            return BinarySearch(arr, value, 0, arr.Length - 1);
        }

        private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex)
            where T : IComparable<T>
        {
            Debug.Assert(arr != null, "Array to search cannot be null.");
            Debug.Assert(value != null, "Searched value cannot be null.");
            Debug.Assert(arr.Length != 0, "Array is empty.");
            Debug.Assert(Validator.IsIntegerInRange(startIndex, 0, arr.Length), "Start index is out of the bounds of the array.");
            Debug.Assert(Validator.IsIntegerInRange(endIndex, 0, arr.Length), "End index is out of the bounds of the array.");
            Debug.Assert(Validator.IsIntegerInRange(startIndex, 0, endIndex), "Start index must not be greater than end index.");
            Debug.Assert(Validator.IsCollectionSortedAscending(arr), "Array must be sorted for binary search.");

            while (startIndex <= endIndex)
            {
                int midIndex = (startIndex + endIndex) / 2;
                if (arr[midIndex].Equals(value))
                {
                    return midIndex;
                }

                if (arr[midIndex].CompareTo(value) < 0)
                {
                    startIndex = midIndex + 1;
                }
                else
                {
                    endIndex = midIndex - 1;
                }
            }

            // Searched value not found
            return -1;
        }
    }
}
