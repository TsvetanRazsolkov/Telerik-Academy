namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            for (int i = 0; i < collection.Count - 1; i++)
            {
                int minIndex = i;

                for (int j = i + 1; j < collection.Count; j++)
                {
                    if (collection[j].CompareTo(collection[i]) == -1)
                    {
                        minIndex = j;
                    }
                }

                if (minIndex != i)
                {
                    this.Swap(collection, i, minIndex);
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
