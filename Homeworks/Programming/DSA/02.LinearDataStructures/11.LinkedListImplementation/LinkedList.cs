/*Implement the data structure linked list.

Define a class ListItem<T> that has two fields: value (of type T) and NextItem (of type ListItem<T>).
Define additionally a class LinkedList<T> with a single field FirstElement (of type ListItem<T>).*/
namespace _11.LinkedListImplementation
{
    using System;

    public class LinkedList<T> where T : IComparable
    {
        private ListItem<T> firstItem;

        public LinkedList()
        {
            this.firstItem = null;
            this.Count = 0;
        }

        public ListItem<T> FirstItem
        {
            get
            { 
                return this.firstItem;
            }

            private set
            {
                this.firstItem = value;
            }
        }

        public int Count { get; private set; }

        public bool Contains(T value)
        {
            var currentItem = this.FirstItem;
            while (currentItem != null)
            {
                if (currentItem.Value.CompareTo(value) == 0)
                {
                    return true;
                }

                currentItem = currentItem.Next;
            }

            return false;
        }

        public void AddLast(T value)
        {
            if (this.FirstItem == null)
            {
                this.firstItem = new ListItem<T>(value);
            }
            else
            {
                var currentItem = this.FirstItem;
                while (currentItem.Next != null)
                {
                    currentItem = currentItem.Next;
                }

                currentItem.Next = new ListItem<T>(value);
            }

            this.Count++;
        }

        public void Remove(T value)
        {
            if (this.FirstItem == null)
            {
                return;
            }

            var currentItem = this.FirstItem;
            if (currentItem.Value.CompareTo(value) == 0)
            {
                this.RemoveFirst();
                return;
            }

            while (currentItem.Next != null)
            {
                if (currentItem.Next.Value.CompareTo(value) == 0)
                {
                    currentItem.Next = currentItem.Next.Next;
                    this.Count--;
                    return;
                }

                currentItem = currentItem.Next;
            }
        }

        public void AddFirst(T value)
        {
            var newFirst = new ListItem<T>(value);
            newFirst.Next = this.FirstItem;
            this.FirstItem = newFirst;
            this.Count++;
        }

        public void RemoveFirst()
        {
            if (this.FirstItem == null)
            {
                return;
            }

            this.FirstItem = this.FirstItem.Next;
            this.Count--;
        }
    }
}
