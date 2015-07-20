namespace CompareSortAlgorithms
{
    using System;

    public static class SortingAlgorithms
    {
        public static void SelectionSort(IComparable[] collection)
        {
            var indexOfMin = 0;
            var temp = collection[0];

            for (var i = 0; i < collection.Length - 1; i++)
            {
                indexOfMin = i;
                for (var j = i + 1; j < collection.Length; j++)
                {
                    if (collection[j].CompareTo(collection[indexOfMin]) < 0)
                    {
                        indexOfMin = j;
                    }
                }

                temp = collection[i];
                collection[i] = collection[indexOfMin];
                collection[indexOfMin] = temp;
            }
        }

        public static void InsertionSort(IComparable[] collection)
        {
            var index = collection[0];
            int j = 0;

            for (int i = 1; i < collection.Length; i++)
            {
                index = collection[i];
                j = i;
                while ((j > 0) && (collection[j - 1].CompareTo(index) > 0))
                {
                    collection[j] = collection[j - 1];
                    j = j - 1;
                }

                collection[j] = index;
            }
        }        

        public static void QuickSort(IComparable[] collection)
        {
            Quicksort(collection, 0, collection.Length - 1);
        }

        private static void Quicksort(IComparable[] collection, int left, int right)
        {
            int i = left, j = right;
            IComparable pivot = collection[(left + right) / 2];

            while (i <= j)
            {
                while (collection[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (collection[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    IComparable oldValue = collection[i];
                    collection[i] = collection[j];
                    collection[j] = oldValue;

                    i++;
                    j--;
                }
            }

            // Recursive calls
            if (left < j)
            {
                Quicksort(collection, left, j);
            }

            if (i < right)
            {
                Quicksort(collection, i, right);
            }
        }
    }
}
