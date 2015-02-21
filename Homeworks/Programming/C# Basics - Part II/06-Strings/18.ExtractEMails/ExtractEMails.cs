using System;
using System.Text.RegularExpressions;

/* Write a program for extracting all email addresses from given text.
All sub-strings that match the format <identifier>@<host>…<domain> should be recognized as 
emails.  */

class ExtractEMails
{
    static void Main()
    {
        string text = "Please contact us by phone (+001 222 222 222) or by email at example@gmail.com or at test.user@yahoo.co.uk. This is not email: test@test. This also: @gmail.com.";

        Regex emailRegex = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*",
            RegexOptions.IgnoreCase);

        MatchCollection emailMatches = emailRegex.Matches(text);               

        foreach (Match emailMatch in emailMatches)
        {
            Console.WriteLine(emailMatch);
        }
    }
}