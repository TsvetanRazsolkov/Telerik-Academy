using System;
using System.Text;
using System.Globalization;
using System.Threading;

/* Write a program that reads a date and time given in the format: day.month.year 
hour:minute:second and prints the date and time after 6 hours and 30 minutes (in the same
format) along with the day of week in Bulgarian.  */

class DateInBulgarian
{
    static void Main()
    {
        Console.WriteLine("Enter date and time in this format[day.month.year hour:minute:second]: ");
        DateTime inputDate = DateTime.ParseExact(Console.ReadLine(), "d.M.yyyy H:m:s",
            CultureInfo.GetCultureInfo("bg-BG"));

        DateTime outputDate = inputDate.AddHours(6.5);

        Console.WriteLine(outputDate.ToString("d.M.yyyy H:mm:ss dddd", 
                         CultureInfo.CreateSpecificCulture("bg-BG")));
    }
}