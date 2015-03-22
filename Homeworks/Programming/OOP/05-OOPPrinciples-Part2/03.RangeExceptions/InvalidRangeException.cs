namespace RangeExceptions
{
    using System;

    public class InvalidRangeException<T> : ApplicationException
        where T : IComparable<T>
    {
        private T start;
        private T end;

        public InvalidRangeException(string message, T start, T end) : base(message)
        {
            this.Start = start;
            this.End = end;
        }

        public T Start 
        { 
            get { return this.start; } 
            set { this.start = value; }
        }

        public T End
        {
            get { return this.end; }
            set
            {
                if (this.Start.CompareTo(value) > 0)
                {
                    throw new ArgumentException("Start of range can not be bigger than end of range.");
                }
                this.end = value;
            }
        }
    }
}
