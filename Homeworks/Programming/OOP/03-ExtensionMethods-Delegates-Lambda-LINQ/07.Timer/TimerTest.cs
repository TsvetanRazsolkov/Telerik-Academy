namespace Timer
{
    using System;
    using System.Threading;

    public class TimerTest
    {
        static void Main()
        {
            TimerAction act1 = new TimerAction(PrintEvery3Secs);
            Timer firstTimer = new Timer(3, act1);
            Thread firstThread = new Thread(new ThreadStart(firstTimer.Tick));
            firstThread.Start();

            TimerAction act2 = new TimerAction(PrintEverySecond);
            Timer secondTimer = new Timer(1, act2);
            Thread secondThread = new Thread(new ThreadStart(secondTimer.Tick));
            secondThread.Start();

            TimerAction act3 = new TimerAction(delegate() { Console.WriteLine("Honestly, I have no idea what I'm doing :)"); });
            Timer thirdTimer = new Timer(2, act3);
            Thread thirdThread = new Thread(new ThreadStart(thirdTimer.Tick));
            thirdThread.Start();
        }               

        public static void PrintEverySecond()
        {
            Console.WriteLine("String printed every second. Press Ctrl+C to stop.");
        }

        public static void PrintEvery3Secs()
        {
            Console.WriteLine("String printed every 3 seconds. Press Ctrl+C to stop.");
        }
    }
}
