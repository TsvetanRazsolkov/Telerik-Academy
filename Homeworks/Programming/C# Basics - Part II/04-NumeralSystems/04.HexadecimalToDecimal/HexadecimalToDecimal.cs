using System;

// Write a program to convert hexadecimal numbers to their decimal representation.

class HexadecimalToDecimal
{
    static void Main()
    {
        Console.WriteLine("Enter positive integer number in hexadecimal representation: ");
        string hexNumber = Console.ReadLine().ToUpper();


        Console.WriteLine("Decimal representation: {0}", HexToDecimal(hexNumber));
    }

    static long HexToDecimal(string hexNumber)
    {
        long decNumber = 0;
        for (int i = 0; i < hexNumber.Length; i++)
        {
            if (hexNumber[i] >= 'A' && hexNumber[i] <= 'F')
            {
                decNumber += 
                    (hexNumber[i] - 'A' + 10) * BaseByPower(16, hexNumber.Length - 1 - i);
            }
            else if (hexNumber[i] >= '0' && hexNumber[i] <= '9')
            {
                decNumber +=
                (hexNumber[i] - '0') * BaseByPower(16, hexNumber.Length - 1 - i);
            }            
        }
        return decNumber;
    }

    static long BaseByPower(int numberBase, int power)
    {
        long result = 1;
        for (int i = 0; i < power; i++)
        {
            result *= numberBase;
        }
        return result;
    }
}