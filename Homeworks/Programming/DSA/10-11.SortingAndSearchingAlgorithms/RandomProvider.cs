namespace SortingHomework
{
    using System;

    public class RandomProvider
    {
        private static Random instance;

        private RandomProvider() { }

        public static Random Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Random();
                }

                return instance;
            }
        }
    }
}
