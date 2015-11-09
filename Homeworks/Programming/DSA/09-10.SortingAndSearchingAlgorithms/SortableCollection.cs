namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private readonly IList<T> items;

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public bool LinearSearch(T item)
        {
            for (int i = 0; i < this.Items.Count; i++)
            {
                if (this.Items[i].CompareTo(item) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public bool BinarySearch(T item)
        {
            int indexMin = 0;
            int indexMax = this.Items.Count - 1;
            while (indexMax >= indexMin)
            {
                int midIndex = indexMin + (indexMax - indexMin) / 2;
                if (this.Items[midIndex].CompareTo(item) == 0)
                {
                    return true;
                }
                else if (this.Items[midIndex].CompareTo(item) < 0)
                {
                    indexMin = midIndex + 1;
                }
                else
                {
                    indexMax = midIndex - 1;
                }
            }

            return false;
        }

        public void Shuffle()
        {
            for (int i = this.Items.Count - 1; i >= 0; i--)
            {
                int swapIndex = RandomProvider.Instance.Next(0, i + 1);

                T tempValue = this.Items[i];
                this.Items[i] = this.Items[swapIndex];
                this.Items[swapIndex] = tempValue;
            }
        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }
    }
}
