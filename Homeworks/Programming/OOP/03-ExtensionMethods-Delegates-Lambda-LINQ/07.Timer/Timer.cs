namespace Timer
{
    using System;
    using System.Threading;

    public delegate void TimerAction();

    public class Timer
    {
        private int interval;
        private TimerAction tAction;

        public Timer(int interval, TimerAction someAction)
        {
            this.Interval = interval;
            this.TAction = someAction;
        }

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

        public TimerAction TAction
        {
            get { return this.tAction; }
            private set { this.tAction = value; }
        }

        public void Tick()
        {
            while (true)
            {
                Thread.Sleep(this.Interval);
                tAction();
            }
        }


    }
}
