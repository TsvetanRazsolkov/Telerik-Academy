using System;
using System.Globalization;

/* Write a program that reads two dates in the format: day.month.year and calculates the number of days between them.
Example:
Enter the first date: 27.02.2006
Enter the second date: 3.03.2006
Distance: 4 days  */

class DateDifference
{
    static void Main()
    {
        Console.Write("Enter first date: ");
        DateTime firstDate =  DateTime.ParseExact(Console.ReadLine(), "d.M.yyyy", 
                                                     CultureInfo.InvariantCulture);
        Console.Write("Enter second date: ");
        DateTime secondDate = DateTime.ParseExact(Console.ReadLine(), "d.M.yyyy",
                                                     CultureInfo.InvariantCulture);
        if (firstDate > secondDate)
        {
            DateTime temp = firstDate;
            firstDate = secondDate;
            secondDate = temp;
        }
        TimeSpan dateDifference = secondDate.Subtract(firstDate);
        int difference = (int)dateDifference.TotalDays;
        Console.WriteLine("Distance: {0} days.", difference);
    }
}