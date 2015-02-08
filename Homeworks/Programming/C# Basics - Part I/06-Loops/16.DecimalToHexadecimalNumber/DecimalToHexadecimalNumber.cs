using System;
using System.Text;

class DecimalToHexadecimalNumber
{
    static void Main()
    {
        // Using loops write a program that converts an integer number to its hexadecimal representation. The input is entered as long. The output should be a variable of type string. Do not use the built-in .NET functionality.

        Console.Write("Enter positive integer and press ENTER: ");
        long number = long.Parse(Console.ReadLine());
        if (number == 0)
        {
            Console.WriteLine(number);
        }
        else if (number > 0)
        {
            StringBuilder hexadecimalNumber = new StringBuilder();
            for (long i = number; i > 0; i /= 16)
            {
                long digit = i % 16;
                if (digit < 10)
                {
                    hexadecimalNumber.Insert(0, digit);
                }
                else if (digit == 10)
                {
                    hexadecimalNumber.Insert(0, 'A');
                }
                else if (digit == 11)
                {
                    hexadecimalNumber.Insert(0, 'B');
                }
                else if (digit == 12)
                {
                    hexadecimalNumber.Insert(0, 'C');
                }
                else if (digit == 13)
                {
                    hexadecimalNumber.Insert(0, 'D');
                }
                else if (digit == 14)
                {
                    hexadecimalNumber.Insert(0, 'E');
                }
                else if (digit == 15)
                {
                    hexadecimalNumber.Insert(0, 'F');
                }                
            }
            Console.Write("Decimal = {0}\nHexadecimal = {1}", number, hexadecimalNumber);
            Console.WriteLine();
        }
        else if (number < 0)
        {
            Console.WriteLine("Enter positive integer.");
        }
    }
}
