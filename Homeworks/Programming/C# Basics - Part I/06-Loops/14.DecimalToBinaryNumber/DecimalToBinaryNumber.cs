using System;
using System.Text;

class DecimalToBinaryNumber
{
    static void Main()
    {

        // Using loops write a program that converts an integer number to its binary representation. The input is entered as long. The output should be a variable of type string. Do not use the built-in .NET functionality.

        Console.Write("Enter positive integer and press ENTER: ");
        long number = long.Parse(Console.ReadLine());
        if (number == 0)
        {
            Console.WriteLine(number);
        }
        else if (number > 0)
        {
            StringBuilder binaryNumber = new StringBuilder();
            for (long i = number; i > 0; i /= 2)
            {
                long digit = i % 2;
                binaryNumber.Insert(0, digit);
            }
            Console.Write("Decimal = {0}\nBinary = {1}", number, binaryNumber);
            Console.WriteLine();
        }
        else if (number < 0)
        {            
            Console.WriteLine("Enter positive integer.");
        }
    }
}
