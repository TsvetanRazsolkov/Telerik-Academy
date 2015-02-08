using System;

class FourDigitNumber
{
    static void Main()
    {
        /* Write a program that takes as input a four-digit number in format abcd (e.g. 2011) and performs the following:
        Calculates the sum of the digits (in our example 2 + 0 + 1 + 1 = 4).
        Prints on the console the number in reversed order: dcba (in our example 1102).
        Puts the last digit in the first position: dabc (in our example 1201).
        Exchanges the second and the third digits: acbd (in our example 2101).
        The number has always exactly 4 digits and cannot start with 0. */

        Console.Write("Enter four digit positive integer(e.g. 1948) and press ENTER: ");

        int number = int.Parse(Console.ReadLine());

        int firstDigit = number/1000;
        int secondDigit = (number / 100)%10;
        int thitdDigit = (number / 10)%10;
        int fourthDigit = number % 10;

        Console.WriteLine("Your number is:                    {0}", number);
        Console.WriteLine("Sum of digits:                     {0}", firstDigit + secondDigit + thitdDigit + fourthDigit);
        Console.WriteLine("Number reversed:                   {0}{1}{2}{3}", fourthDigit, thitdDigit, secondDigit, firstDigit);
        Console.WriteLine("Last digit in front:               {0}{1}{2}{3}", fourthDigit, firstDigit, secondDigit, thitdDigit);
        Console.WriteLine("Exchanged second and third digits: {0}{1}{2}{3}", firstDigit, thitdDigit, secondDigit, fourthDigit);

    }
}