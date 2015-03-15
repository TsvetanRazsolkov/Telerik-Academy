namespace GenericClass
{
    using System;
    using System.Text;

    public class GenericList<T> where T : IComparable<T>
    {
        private T[] array;
        private int currentIndex;

        public GenericList(int capacity)
        {
            this.Capacity = capacity;
            this.array = new T[Capacity];
            this.currentIndex = 0;
        }

        public int Capacity { get; private set; }

        public T this[int index]
        {
            get
            {
                CheckIndex(index);
                return this.array[index];
            }
        }

        public void Add(T element)
        {
            if (currentIndex >= this.array.Length)
            {
                this.array = AutoGrow();
            }

            this.array[currentIndex] = element;
            this.currentIndex++;
        }        

        public void RemoveAt(int index)
        {
            CheckIndex(index);

            for (int i = index; i < this.currentIndex - 1; i++)
            {
                this.array[i] = this.array[i + 1];
            }
            this.currentIndex--;
        }

        public void InsertAt(int index, T element)
        {
            CheckIndex(index);
            if (currentIndex >= this.array.Length)
            {
                this.array = AutoGrow();
            }

            for (int i = this.currentIndex; i > index; i--)
            {
                this.array[i] = this.array[i - 1];
            }
            this.array[index] = element;
            this.currentIndex++;
        }

        public void Clear()
        {
            this.array = new T[Capacity];
            this.currentIndex = 0;
        }

        public int IndexOf(T element)
        {
            for (int i = 0; i < this.currentIndex; i++)
            {
                if (this.array[i].CompareTo(element) == 0)
                {
                    return i;
                }
            }
            return -1;
        } 

        public T Min()
        {
            T min = this.array[0];

            if (this.currentIndex > 0)
            {                
                for (int i = 0; i < this.currentIndex; i++)
                {
                    if (this.array[i].CompareTo(min) <= 0)
                    {
                        min = this.array[i];
                    }
                }
            }

            return min;
        }

        public T Max()
        {
            T max = this.array[0];

            if (this.currentIndex > 0)
            {
                for (int i = 0; i < this.currentIndex; i++)
                {
                    if (this.array[i].CompareTo(max) >= 0)
                    {
                        max = this.array[i];
                    }
                }
            }

            return max;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < this.currentIndex; i++)
            {
                result.AppendFormat("{0, -5}",this.array[i]);
            }
            return result.ToString().Trim();
        }

        private void CheckIndex(int index)
        {
            if (index >= this.currentIndex || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
        }

        private T[] AutoGrow()
        {
            this.Capacity *= 2;
            T[] newArray = new T[this.Capacity];
            for (int i = 0; i < this.currentIndex; i++)
            {
                newArray[i] = this.array[i];
            }

            return newArray;
        }
    }
}
