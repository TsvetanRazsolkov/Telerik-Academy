namespace CompareSortAlgorithms
{
    using System;
    using System.Diagnostics;
    using System.Linq;

    public static class SortingAlgorithmsTester
    {
        private static readonly IComparable[] RandomValuesIntCollection = { 4, 2, 0, 3, 7, 5, 9, 1, 8, 6 };
        private static readonly IComparable[] SortedValuesIntCollection = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        private static readonly IComparable[] ReversedValuesIntCollection = { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };

        private static readonly IComparable[] RandomValuesDoubleCollection = { 4.1, 2.1, 3.1, 7.1, 5.1, 9.1, 1.1, 10.1, 8.1, 6.1 };
        private static readonly IComparable[] SortedValuesDoubleCollection = { 1.1, 2.1, 3.1, 4.1, 5.1, 6.1, 7.1, 8.1, 9.1, 10.1 };
        private static readonly IComparable[] ReversedValuesDoubleCollection = { 10.1, 9.1, 8.1, 7.1, 6.1, 5.1, 4.1, 3.1, 2.1, 1.1 };

        private static readonly IComparable[] RandomValuesStringCollection = { "d", "b", "c", "g", "e", "i", "a", "h", "f", "j" };
        private static readonly IComparable[] SortedValuesStringCollection = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j" };
        private static readonly IComparable[] ReversedValuesStringCollection = { "j", "i", "h", "g", "f", "e", "d", "c", "b", "a" };

        private static readonly Stopwatch StopWatch = new Stopwatch();

        public static void TestIntSortingPerformance()
        {
            Console.WriteLine("Int collections - 10 elements:");

            // Random order
            Console.WriteLine("Random order: ");
            var randomIntCollection = (IComparable[])RandomValuesIntCollection.Clone();
            TestSelectionSort(randomIntCollection);

            randomIntCollection = (IComparable[])RandomValuesIntCollection.Clone();
            TestInsertionSort(randomIntCollection);

            randomIntCollection = (IComparable[])RandomValuesIntCollection.Clone();
            TestQuickSort(randomIntCollection);

            // Sorted order
            Console.WriteLine("Sorted order: ");
            var sortedIntCollection = (IComparable[])SortedValuesIntCollection.Clone();
            TestSelectionSort(sortedIntCollection);

            sortedIntCollection = (IComparable[])SortedValuesIntCollection.Clone();
            TestInsertionSort(sortedIntCollection);

            sortedIntCollection = (IComparable[])SortedValuesIntCollection.Clone();
            TestQuickSort(sortedIntCollection);

            // Reversed order
            Console.WriteLine("Reversed order: ");
            var reversedIntCollection = (IComparable[])ReversedValuesIntCollection.Clone();
            TestSelectionSort(reversedIntCollection);

            reversedIntCollection = (IComparable[])ReversedValuesIntCollection.Clone();
            TestInsertionSort(reversedIntCollection);

            reversedIntCollection = (IComparable[])ReversedValuesIntCollection.Clone();
            TestQuickSort(reversedIntCollection);
        }

        public static void TestDoubleSortingPerformance()
        {
            Console.WriteLine("Double collections - 10 elements:");

            // Random order
            Console.WriteLine("Random order: ");
            var randomDoubleCollection = (IComparable[])RandomValuesDoubleCollection.Clone();
            TestSelectionSort(randomDoubleCollection);

            randomDoubleCollection = (IComparable[])RandomValuesDoubleCollection.Clone();
            TestInsertionSort(randomDoubleCollection);

            randomDoubleCollection = (IComparable[])RandomValuesDoubleCollection.Clone();
            TestQuickSort(randomDoubleCollection);

            // Sorted order
            Console.WriteLine("Sorted order: ");
            var sortedDoubleCollection = (IComparable[])SortedValuesDoubleCollection.Clone();
            TestSelectionSort(sortedDoubleCollection);

            sortedDoubleCollection = (IComparable[])SortedValuesDoubleCollection.Clone();
            TestInsertionSort(sortedDoubleCollection);

            sortedDoubleCollection = (IComparable[])SortedValuesDoubleCollection.Clone();
            TestQuickSort(sortedDoubleCollection);

            // Reversed order
            Console.WriteLine("Reversed order: ");
            var reversedDoubleCollection = (IComparable[])ReversedValuesDoubleCollection.Clone();
            TestSelectionSort(reversedDoubleCollection);

            reversedDoubleCollection = (IComparable[])ReversedValuesDoubleCollection.Clone();
            TestInsertionSort(reversedDoubleCollection);

            reversedDoubleCollection = (IComparable[])ReversedValuesDoubleCollection.Clone();
            TestQuickSort(reversedDoubleCollection);
        }

        public static void TestStringSortingPerformance()
        {
            Console.WriteLine("String collections - 10 elements:");

            // Random order
            Console.WriteLine("Random order: ");
            var randomStringCollection = (IComparable[])RandomValuesStringCollection.Clone();
            TestSelectionSort(randomStringCollection);

            randomStringCollection = (IComparable[])RandomValuesStringCollection.Clone();
            TestInsertionSort(randomStringCollection);

            randomStringCollection = (IComparable[])RandomValuesStringCollection.Clone();
            TestQuickSort(randomStringCollection);

            // Sorted order
            Console.WriteLine("Sorted order: ");
            var sortedStringCollection = (IComparable[])SortedValuesStringCollection.Clone();
            TestSelectionSort(sortedStringCollection);

            sortedStringCollection = (IComparable[])SortedValuesStringCollection.Clone();
            TestInsertionSort(sortedStringCollection);

            sortedStringCollection = (IComparable[])SortedValuesStringCollection.Clone();
            TestQuickSort(sortedStringCollection);

            // Reversed order
            Console.WriteLine("Reversed order: ");
            var reversedStringCollection = (IComparable[])ReversedValuesStringCollection.Clone();
            TestSelectionSort(reversedStringCollection);

            reversedStringCollection = (IComparable[])ReversedValuesStringCollection.Clone();
            TestInsertionSort(reversedStringCollection);

            reversedStringCollection = (IComparable[])ReversedValuesStringCollection.Clone();
            TestQuickSort(reversedStringCollection);
        }

        private static void TestSelectionSort(IComparable[] collection)
        {
            StopWatch.Reset();
            StopWatch.Start();
            SortingAlgorithms.SelectionSort(collection);
            StopWatch.Stop();
            Debug.Assert(IsSorted(collection), "Selection sort did not sort the array.");
            Console.WriteLine("Selection sort: {0}", StopWatch.Elapsed);
        }

        private static void TestInsertionSort(IComparable[] collection)
        {
            StopWatch.Reset();
            StopWatch.Start();
            SortingAlgorithms.InsertionSort(collection);
            StopWatch.Stop();
            Debug.Assert(IsSorted(collection), "Insertion sort did not sort the array.");
            Console.WriteLine("Insertion sort: {0}", StopWatch.Elapsed);
        }

        private static void TestQuickSort(IComparable[] collection)
        {
            StopWatch.Reset();
            StopWatch.Start();
            SortingAlgorithms.QuickSort(collection);
            StopWatch.Stop();
            Debug.Assert(IsSorted(collection), "Quick sort did not sort the array.");
            Console.WriteLine("Quick sort: {0}", StopWatch.Elapsed);
        }

        private static bool IsSorted(IComparable[] collection)
        {
            for (int i = 1; i < collection.Length; i++)
            {
                if (collection[i - 1].CompareTo(collection[i]) > 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
