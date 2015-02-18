using System;

// Write a program to convert decimal numbers to their hexadecimal representation.

class DecimalToHexadecimal
{
    static void Main()
    {
        Console.WriteLine("Enter positive integer number in decimal representation: ");
        string decNumber = Console.ReadLine();

        Console.WriteLine("Hexadecimal representation: {0}", DecToHex(decNumber));
    }

    static string DecToHex(string decNumber)
    {
        string hex = string.Empty;
        long decNum = long.Parse(decNumber);
        int remainder;
        if (decNum == 0)
        {
            return "0";
        }
        while (decNum > 0)
        {
            remainder = (int)(decNum % 16);
            if (remainder >= 0 && remainder <= 9)
            {
                hex = (char)(remainder + '0') + hex;
            }
            else if (remainder > 9 && remainder <= 15)
            {
                hex = (char)(remainder - 10 + 'A') + hex;
            }
            decNum /= 16;
        }
        return hex;
    }
}