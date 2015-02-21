using System;

/* Write a program that reads a number and prints it as a decimal number, hexadecimal number, 
percentage and in scientific notation.
Format the output aligned right in 15 symbols.
*/

class FormatNumber
{
    static void Main()
    {
        Console.Write("Enter integer number: ");
        long number = long.Parse(Console.ReadLine());
        Console.WriteLine("{0,15:D}", number);
        Console.WriteLine("{0,15:X}", number);
        Console.WriteLine("{0,15:P}", number/100.0);
        Console.WriteLine("{0,15:E}", number);
    }
}