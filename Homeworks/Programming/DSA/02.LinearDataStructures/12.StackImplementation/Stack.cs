/*Implement the ADT stack as auto-resizable array.

Resize the capacity on demand (when no space is available to add / insert a new element).*/
namespace _12.StackImplementation
{
    using System;

    public class Stack<T> where T : IComparable
    {
        private const int InitialCapacity = 4;
        private const double ResizeRatio = 0.75;

        private T[] values;
        private int index;

        public Stack()
        {
            this.values = new T[InitialCapacity];
            this.index = 0;
            this.Count = 0;
        }

        public int Count { get; private set; }

        public bool Contains(T value)
        {
            for (int i = 0; i < this.Count; i++)
			{
                if (this.values[i].CompareTo(value) == 0)
                {
                    return true;
                }
			}

            return false;
        }

        public void Push(T value)
        {
            if (this.Count > ResizeRatio * this.values.Length)
            {
                this.Resize();
            }

            this.values[index] = value;
            this.index++;
            this.Count++;
        }

        public T Peek()
        {
            if (this.index == 0)
            {
                throw new InvalidOperationException("Stack contains no elements.");
            }

            return this.values[this.index - 1];
        }

        public T Pop()
        {
            if (this.index == 0)
            {
                throw new InvalidOperationException("Stack contains no elements.");
            }

            this.index--;
            this.Count--;
            return this.values[this.index];
        }

        public void Clear()
        {
            this.index = 0;
            this.Count = 0;

            // Or to save(perhaps) a little memory:
            // this.index = 0;
            // this.Count = 0;
            // this.values = new T[InitialCapacity];
        }

        private void Resize()
        {
            var newValues = new T[this.values.Length * 2];
            Array.Copy(this.values, newValues, this.values.Length);
            this.values = newValues;
        }
    }
}
