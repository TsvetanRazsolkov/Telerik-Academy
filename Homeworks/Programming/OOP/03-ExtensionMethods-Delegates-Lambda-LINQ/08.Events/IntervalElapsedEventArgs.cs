namespace Events
{
    using System;

    public class IntervalElapsedEventArgs : EventArgs
    {
        public IntervalElapsedEventArgs(string message)
        {
            this.Message = message;
        }

        public string Message { get; set; }
    }
}
