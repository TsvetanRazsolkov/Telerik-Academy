using System;
using System.Collections.Generic;

// Write a method that calculates the number of workdays between today and given date, passed as parameter.
// Consider that workdays are all days from Monday to Friday except a fixed list of public holidays 
// specified preliminary as array.

class Workdays
{
    static List<DateTime> officialHolidays = new List<DateTime>(){ new DateTime(2015, 3, 3), new DateTime(2015, 05, 24),
           new DateTime(2015, 9, 9), new DateTime(2015, 12, 24), new DateTime(2016, 1, 1), new DateTime(2015, 05, 24) };

    static void Main()
    {        
        DateTime endDate = new DateTime(2015,5,25);

        int workDays = CalculateWorkDays(endDate);

        Console.WriteLine("Workdays in the given period: {0}", workDays);
    }

    static int CalculateWorkDays(DateTime endDate)
    {
        int workDays = 0;

        DateTime start = DateTime.Today;
        while (start <= endDate)
        {
            if ((int)start.DayOfWeek != 0 && (int)start.DayOfWeek != 6)
            {
                if (!officialHolidays.Contains(start))
                {
                    workDays++;
                }
            }
            start = start.AddDays(1);
        }
        return workDays;
    }
}