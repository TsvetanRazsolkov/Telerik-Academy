namespace WorkshopDSA
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class HashSet<T> : IEnumerable<T>
    {
        private const double ResizeRatio = 0.75;

        private LinkedList<T>[] values;

        public HashSet()
        {
            this.Count = 0;
            this.Capacity = 16;
            this.values = new LinkedList<T>[16];
        }

        public int Count { get; set; }

        public int Capacity { get; set; }

        public bool Contains(T element)
        {
            var index = this.GetIndex(element);
            if (this.values[index] == null)
            {
                return false;
            }

            return this.values[index].Contains(element);
        }

        public void Add(T element)
        {
            if (this.Contains(element))
            {
                return;
            }

            var index = this.GetIndex(element);
            if (this.values[index] == null)
            {
                this.values[index] = new LinkedList<T>();
            }

            if (this.Count > ResizeRatio * this.Capacity)
            {
                this.ResizeAndReadd();
            }

            this.values[index].AddLast(element);
            this.Count++;
        }

        public void Remove(T element)
        {
            if (!this.Contains(element))
            {
                throw new ArgumentException("No such element to delete.");
            }

            var index = this.GetIndex(element);

            this.values[index].Remove(element);
        }

        private void ResizeAndReadd()
        {
            this.Capacity *= 2;
            this.Count = 0;

            var oldValues = (LinkedList<T>[])this.values.Clone();
            this.values = new LinkedList<T>[this.Capacity];

            foreach (var valuesList in oldValues)
            {
                if (valuesList != null)
                {
                    foreach (var value in valuesList)
                    {
                        this.Add(value);
                    }
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var valuesList in this.values)
            {
                if (valuesList == null)
                {
                    continue;
                }

                foreach (var value in valuesList)
                {
                    yield return value;
                }
            }
        }

        private int GetIndex(T value)
        {
            var hash = value.GetHashCode();
            if (hash < 0)
            {
                hash *= -1;
            }

            int index = hash % this.values.Length;

            return index;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}