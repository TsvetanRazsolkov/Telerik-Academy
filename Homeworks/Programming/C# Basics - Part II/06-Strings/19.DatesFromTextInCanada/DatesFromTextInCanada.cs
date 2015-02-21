using System;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Threading;

/* Write a program that extracts from a given text all dates that match the format DD.MM.YYYY.
Display them in the standard date format for Canada.  */

class DatesFromTextInCanada
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");

        string text = "I was born at 14.06.1980. My sister was born at 3.7.1984. In 5/1999 I graduated my high school. The law says (see section 7.3.12) that we are allowed to do this (section 7.4.2.9).";

        Regex dateRegex = new Regex("[0-3]{0,1}[0-9]\\.[0-1]{0,1}[0-9]\\.[0-9]{4}");

        Match m = dateRegex.Match(text);
        if (!m.Success)
        {
            Console.WriteLine("No dates in text.");
            return;
        }
        
        while (m.Success)
        {            
            DateTime date = DateTime.ParseExact(m.ToString(), "d.M.yyyy", CultureInfo.InvariantCulture);
            Console.WriteLine(date.ToShortDateString());
            m = m.NextMatch();
        }
    }
}