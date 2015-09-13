namespace _03.Singleton
{
    using System;

    public class Singleton
    {
        private static readonly Lazy<Singleton> Lazy =
        new Lazy<Singleton>(() => new Singleton());
        
        private Singleton()
        {
        }

        public static Singleton Instance 
        { 
            get
            { 
                return Lazy.Value;
            }
        }
    }
}
