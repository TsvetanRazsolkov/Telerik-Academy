using System;

// Write a program to convert decimal numbers to their binary representation.

class DecimalToBinary
{
    static void Main()
    {
        Console.WriteLine("Enter positive integer number in decimal representation: ");
        string decNumber = Console.ReadLine();

        Console.WriteLine("Binary representation: {0}", DecToBinary(decNumber));
    }

    static string DecToBinary(string decNumber)
    {
        string binary = "";
        long decNum = long.Parse(decNumber);
        long remainder;
        if (decNum == 0)
        {
            return "0";
        }
        while (decNum > 0)
        {
            remainder = decNum % 2;
            binary = remainder + binary;
            decNum /= 2;
        }
        return binary;
    }
}