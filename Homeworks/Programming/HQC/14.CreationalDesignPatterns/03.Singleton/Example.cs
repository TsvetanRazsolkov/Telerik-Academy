namespace _03.Singleton
{
    using System;

    public class Example
    {
        public static void Main()
        {
            Singleton s1 = Singleton.Instance;
            Singleton s2 = Singleton.Instance;

            if (s1 == s2)
            {
                Console.WriteLine("Objects are the same instance");
            }
        }
    }
}
