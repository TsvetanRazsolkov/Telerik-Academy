using System;

// Write a program to convert hexadecimal numbers to binary numbers (directly).

class HexadecimalToBinary
{
    static void Main()
    {
        Console.WriteLine("Enter positive integer number in hexadecimal representation: ");
        string hexNumber = Console.ReadLine().ToUpper();

        Console.WriteLine("Binary representation: {0}", HexToBinary(hexNumber));
    }

    static string HexToBinary(string hexNumber)
    {
        string binary = string.Empty;
        string currentDigit = string.Empty;
        int digit;
        int remainder = 0;
        for (int i = hexNumber.Length - 1; i >= 0; i--)
        {
            if (hexNumber[i] == '0')
            {
                currentDigit = "0000";
                binary = currentDigit + binary;
                currentDigit = string.Empty;
            }
            else if (hexNumber[i] > '0' && hexNumber[i] <= '9')
            {
                digit = hexNumber[i] - '0';
                while (digit > 0)
                {
                    remainder = digit % 2;
                    currentDigit = remainder + currentDigit;
                    digit /= 2;
                }
                currentDigit = currentDigit.PadLeft(4,'0');
                binary = currentDigit + binary;
                currentDigit = string.Empty;
            }            
            else if (hexNumber[i] >= 'A' && hexNumber[i] <= 'F')
            {
                digit = hexNumber[i] - 'A' + 10;
                while (digit > 0)
                {
                    remainder = digit % 2;
                    binary = remainder + binary;
                    digit /= 2;
                }    
            }
        }
        binary = binary.TrimStart(new char[]{'0'});
        return binary;
    }
}