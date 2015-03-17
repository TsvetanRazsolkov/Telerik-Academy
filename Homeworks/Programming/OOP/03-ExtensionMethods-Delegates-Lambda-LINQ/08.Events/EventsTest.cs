namespace Events
{
    using System;

    public class EventsTest
    {
        static void HandleEvent(object sender, IntervalElapsedEventArgs e)
        {
            Console.WriteLine(e.Message);
        }

        static void Main()
        {
            // The event is every elapsed second in the timer, the handling is writing stupid message on the console:)
            Timer someTimer = new Timer(1);
            someTimer.RaiseElapsedTimeEvent += HandleEvent;
            someTimer.Tick();
        }
    }
}
