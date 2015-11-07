namespace _01.PriorityQueueImplementation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Heap<T> where T : IComparable
    {
        private const int InitialCapacity = 4;

        private T[] elements;
        private int nextIndex;

        public Heap()
        {
            this.elements = new T[InitialCapacity];
            this.nextIndex = 0;
        }

        public T Peek()
        {
            return this.elements[0];
        }

        public void Add(T element)
        {
            this.CheckCapacity();

            this.elements[nextIndex] = element;

            this.UpHeap(this.nextIndex);

            this.nextIndex++;
        }

        public void Delete()
        {
            var temp = this.elements[0];
            this.elements[0] = this.elements[this.nextIndex - 1];
            this.elements[this.nextIndex - 1] = temp;

            this.nextIndex--;

            this.DownHeap(0);
        }

        private void DownHeap(int index)
        {
            var left = index * 2 + 1;
            var right = left + 1;

            if (left < this.nextIndex)
            {
                if (this.elements[index].CompareTo(this.elements[left]) > 0)
                {
                    var temp = this.elements[index];
                    this.elements[index] = this.elements[left];
                    this.elements[left] = temp;

                    this.DownHeap(left);
                }
                else if (right < this.nextIndex)
                {
                    if (this.elements[index].CompareTo(this.elements[right]) > 0)
                    {
                        var temp = this.elements[index];
                        this.elements[index] = this.elements[right];
                        this.elements[right] = temp;

                        this.DownHeap(right);
                    }
                }
            }
        }

        private void UpHeap(int index)
        {
            int parentElementIndex = (index - 1) / 2;

            if (this.elements[index].CompareTo(this.elements[parentElementIndex]) < 0)
            {
                var temporaryArray = this.elements[index];
                this.elements[index] = this.elements[parentElementIndex];
                this.elements[parentElementIndex] = temporaryArray;

                this.UpHeap(parentElementIndex);
            }
        }

        private void CheckCapacity()
        {
            if (this.nextIndex == this.elements.Length)
            {
                var temporaryElements = new T[this.elements.Length * 2];
                for (int i = 0; i < this.elements.Length; i++)
                {
                    temporaryElements[i] = this.elements[i];
                }

                this.elements = temporaryElements;
            }
        }
    }
}
