namespace _13.QueueImplementation
{
    using System;
    using System.Collections.Generic;

    public class Queue<T> where T : IComparable
    {
        private LinkedList<T> values;

        public Queue()
        {
            this.values = new LinkedList<T>();
        }

        public int Count
        {
            get
            {
                return this.values.Count;
            }
        }

        public bool Contains(T value)
        {
            return this.values.Contains(value);
        }

        public void Enqueue(T value)
        {
            this.values.AddLast(value);
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            return this.values.First.Value;
        }

        public T Dequeue()
        {
            var element = this.Peek();
            this.values.RemoveFirst();
            return element;
        }
    }
}
