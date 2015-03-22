namespace RangeExceptions
{
    using System;

    public class RangeExceptionsTest
    {
        public const int StartNum = 1;
        public const int EndNum = 100;
        public static readonly DateTime StartDate = new DateTime(1980, 1, 1);
        public static readonly DateTime EndDate = new DateTime(2013, 12, 31);

        public static void Main()
        {
            try
            {
                Console.WriteLine("Attempting integer outside the specified range: ");
                int invalidNum = 102;
                if (invalidNum < StartNum || invalidNum > EndNum)
                {
                    throw new InvalidRangeException<int>("Integer should be in the specified range.",
                                                         StartNum, EndNum);
                }                
            }
            catch (InvalidRangeException<int> ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Value should be in the range [{0}...{1}]", ex.Start, ex.End);
            }
            Console.Write(new string('-', Console.WindowWidth));

            try
            {
                Console.WriteLine("Attempting date outside the specified range: ");
                DateTime invalidDate = DateTime.Now.Date;
                if (invalidDate < StartDate || invalidDate > EndDate)
                {
                    throw new InvalidRangeException<DateTime>("Date should be in the specified range.",
                                                              StartDate, EndDate);
                }
            }
            catch (InvalidRangeException<DateTime> ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Value should be in the range [{0}...{1}]", ex.Start, ex.End);
            }
            
        }
    }
}
