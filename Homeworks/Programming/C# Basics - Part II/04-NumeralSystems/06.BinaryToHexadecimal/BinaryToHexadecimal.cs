using System;

// Write a program to convert binary numbers to hexadecimal numbers (directly).

class BinaryToHexadecimal
{
    static void Main()
    {
        Console.WriteLine("Enter positive integer number in binary representation: ");
        string binNumber = Console.ReadLine();        
        if (binNumber.Length % 4 != 0)
        {
            binNumber = binNumber.PadLeft((binNumber.Length + 4 - binNumber.Length % 4), '0');
        }

        Console.WriteLine("Hexadecimal representation: {0}", BinToHex(binNumber));
    }

    static string BinToHex(string binNumber)
    {
        string hex = string.Empty;
        int digit;
        // For every symbol in the hexadecimal representation there are 4 bits in the binary
        // so we will split the binary representation into chunks of 4 bits and derive 
        // hexadecimal symbols from each one.
        for (int i = binNumber.Length - 1; i >= 0 ; i-=4)
        {
            digit = 0;
            for (int j = i - 3; j <= i; j++)
            {
                digit += (binNumber[j] - '0') * BaseByPower(2, i - j);                
            }
            if (digit >= 0 && digit <= 9)
            {
                hex = (char)(digit + '0') + hex;
            }
            else if (digit >= 10 && digit <= 15)
            {
                hex = (char)(digit - 10 + 'A') + hex;
            }
        }
        return hex;
    }

    static int BaseByPower(int numberBase, int power)
    {
        int result = 1;
        for (int i = 0; i < power; i++)
        {
            result *= numberBase;
        }
        return result;
    }
}