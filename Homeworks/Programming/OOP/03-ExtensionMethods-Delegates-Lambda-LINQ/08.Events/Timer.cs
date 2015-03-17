namespace Events
{
    using System;
    using System.Threading;

    public class Timer
    {
        private int interval;

        public Timer(int interval)
        {
            this.Interval = interval;
        }

        public event EventHandler<IntervalElapsedEventArgs> RaiseElapsedTimeEvent;

        public int Interval
        {
            get { return this.interval; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Interval cannot be negative.");
                }
                this.interval = value * 1000;
            }
        }

        public void Tick()
        {
            while (true)
            {
                Thread.Sleep(this.Interval);
                OnRaiseElapsedTimeEvent(new IntervalElapsedEventArgs("Absolutely no idea what I'm doing :D Press Ctrl+C to stop."));                
            }
        }

        protected virtual void OnRaiseElapsedTimeEvent(IntervalElapsedEventArgs e)
        {
            if (RaiseElapsedTimeEvent != null)
            {
                RaiseElapsedTimeEvent(this, e);
            }
        }
    }
}
