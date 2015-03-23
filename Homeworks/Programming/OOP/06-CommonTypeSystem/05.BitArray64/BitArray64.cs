namespace BitArray64
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class BitArray64 : IEnumerable<int>
    {
        public const uint BitsCount = 64;

        private ulong numValue;

        public BitArray64(ulong number)
        {
            this.numValue = number;
        }

        public ulong NumValue
        {
            get { return this.numValue; }
            private set { this.numValue = value; }
        }

        public int this[int index]
        {
            get
            {
                if ((index >= 0) && (index < BitsCount))
                {
                    if ((this.NumValue & ((ulong)1 << index)) == 0)
                    {
                        return 0;
                    }
                    else
                    {
                        return 1;
                    }
                }
                else
                {
                    throw new IndexOutOfRangeException("Invalid index.");
                }
            }

            set
            {
                if ((index < 0) || (index > BitsCount - 1))
                {
                    throw new IndexOutOfRangeException("Invalid index.");
                }
                if ((value < 0) || (value > 1))
                {
                    throw new ArgumentException("Invalid value - bit value should be 0 or 1.");
                }

                this.NumValue &= ~((ulong)1 << index);
                this.NumValue |= ((ulong)value << index);
            }
        }

        public static bool operator ==(BitArray64 first, BitArray64 second)
        {
            return object.Equals(first, second);
        }

        public static bool operator !=(BitArray64 first, BitArray64 second)
        {
            return !object.Equals(first, second);
        }

        public override bool Equals(object obj)
        {
            var otherBitArray = obj as BitArray64;
            if (otherBitArray == null)
            {
                throw new ArgumentException("Object is not BitArray64");
            }
            return this.NumValue.Equals(otherBitArray.NumValue);
        }

        public override int GetHashCode()
        {
            return this.NumValue.GetHashCode();
        }        

        public IEnumerator<int> GetEnumerator()
        {
            for (int index = 0; index < BitsCount; index++)
            {
                yield return this[index];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
