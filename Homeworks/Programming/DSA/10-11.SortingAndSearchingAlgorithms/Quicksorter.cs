namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            collection = this.QuickSort(collection, 0, collection.Count - 1);
        }

        private IList<T> QuickSort(IList<T> collection, int start, int end)
        {
            if (start < end)
            {
                int pivotIndex = Partition(collection, start, end);
                this.QuickSort(collection, start, pivotIndex - 1);
                this.QuickSort(collection, pivotIndex + 1, end);
                return collection;
            }
            else
            {
                return collection;
            }
        }

        private int Partition(IList<T> collection, int start, int end)
        {
            // Choosing a pivot is optimized by looking for the median of three values:
            //the starting element, the end element and the middle element. Therefore the
            //use of the method ChoosePivot(). This helps in case an array is already sorted.
            int pivotIndex = ChoosePivot(collection, start, end); // Or could choose random index;
            T pivotValue = collection[pivotIndex];

            // Putting the chosen pivot at position with index end(last in the array),
            // if it's not already there.
            if (pivotIndex != end)
            {
                this.Swap(collection, end, pivotIndex);

            }

            int storePivotIndex = start;

            // Compare remaining array elements against pivotValue.
            for (int i = start; i < end; i++)
            {
                if (collection[i].CompareTo(pivotValue) <= 0)
                {
                    if (i != storePivotIndex)
                    {
                        this.Swap(collection, i, storePivotIndex);
                    }
                    storePivotIndex++;
                }
            }

            // Putting the chosen pivot at its final position, if it's not already there.
            if (storePivotIndex != end)
            {
                this.Swap(collection, end, storePivotIndex);
            }

            return storePivotIndex;
        }

        private int ChoosePivot(IList<T> collection, int start, int end)
        {
            // Sorting the left most element, the right most element and the middle 
            // element of the array. Then choosing for a pivot the element which is 
            // the median of the three.
            int middle = start + (end - start) / 2;

            if (collection[start].CompareTo(collection[middle]) > 0)
            {
                if (collection[middle].CompareTo(collection[end]) > 0)
                {
                    return middle;
                }
                else
                {
                    return end;
                }
            }
            else
            {
                if (collection[middle].CompareTo(collection[end]) > 0)
                {
                    if (collection[start].CompareTo(collection[end]) > 0)
                    {
                        return start;
                    }
                    else
                    {
                        return end;
                    }
                }
                else
                {
                    return middle;
                }
            }
        }

        private void Swap(IList<T> collection, int firstIndex, int secondIndex)
        {
            T tempValue = collection[firstIndex];
            collection[firstIndex] = collection[secondIndex];
            collection[secondIndex] = tempValue;
        }
    }
}
