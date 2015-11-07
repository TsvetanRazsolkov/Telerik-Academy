namespace _01.PriorityQueueImplementation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class PriorityQueue<T> where T : IComparable
    {
        private readonly Heap<T> heap;

        public PriorityQueue()
        {
            this.heap = new Heap<T>();
        }

        public T Peek()
        {
            return this.heap.Peek();
        }

        public void Enqueue(T element)
        {
            this.heap.Add(element);
        }

        public T Dequeue()
        {
            var element = this.heap.Peek();
            this.heap.Delete();

            return element;
        }
    }
}
