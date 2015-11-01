
/*Implement the data structure linked list.

Define a class ListItem<T> that has two fields: value (of type T) and NextItem (of type ListItem<T>).
Define additionally a class LinkedList<T> with a single field FirstElement (of type ListItem<T>).*/
namespace _11.LinkedListImplementation
{
    using System;

    public class ListItem<T> where T : IComparable
    {
        private T value;
        private ListItem<T> next;

        public ListItem(T value)
        {
            this.Value = value;
            this.Next = null;
        }

        public T Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public ListItem<T> Next
        {
            get { return this.next; }
            set { this.next = value; }
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}
