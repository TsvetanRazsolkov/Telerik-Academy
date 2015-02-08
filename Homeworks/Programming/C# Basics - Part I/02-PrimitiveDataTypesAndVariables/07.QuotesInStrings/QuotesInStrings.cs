using System;

class QuotesInStrings
{
    static void Main()
    {
        // Declare two string variables and assign them with following value: The "use" of quotations causes difficulties. Do the above in two different ways - with and without using quoted strings. Print the variables to ensure that their value was correctly defined.

        string someString = @"The ""use"" of quotations causes difficulties.";
        string anotherString = "The \"use\" of quotations causes difficulties.";
        Console.WriteLine("{0}\n{1}", someString, anotherString);
    }
}