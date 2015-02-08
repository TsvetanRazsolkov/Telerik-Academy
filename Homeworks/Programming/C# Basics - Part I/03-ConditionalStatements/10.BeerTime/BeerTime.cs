using System;
using System.Globalization;

class BeerTime
{
    static void Main()
    {
        /* A beer time is after 1:00 PM and before 3:00 AM. Write a program that enters a time in format “hh:mm tt” (an hour in range [01...12], a minute in range [00…59] and AM / PM designator) and prints beer time or non-beer time according to the definition above or invalid time if the time cannot be parsed. */

        DateTime timeOfDay;
        Console.Write("Enter time of day in the designated format: ");
        bool isTime = DateTime.TryParseExact(Console.ReadLine(), "h:mm tt", CultureInfo.InvariantCulture,
                                    DateTimeStyles.None, out timeOfDay);

        DateTime startBeerTime = DateTime.Parse("1:00 PM");
        DateTime endBeerTime = DateTime.Parse("3:00 AM");

        if (isTime)
        {
            if (timeOfDay > startBeerTime || timeOfDay < endBeerTime)
            {
                Console.WriteLine("beer time");
            }
            else
            {
                Console.WriteLine("non-beer time");
            }
        }
        else
        {
            Console.WriteLine("invalid time");
        }
    }
}
