using System;

class BitsExchange
{
    static void Main()
    {
        // Write a program that exchanges bits 3, 4 and 5 with bits 24, 25 and 26 of given 32-bit unsigned integer.

        Console.Write("Enter a positive 32-bit integer number and press ENTER:");
        uint number;
        bool numberCheck = uint.TryParse(Console.ReadLine(), out number);

        if (numberCheck)
        {
            string numberBinary = Convert.ToString(number, 2).PadLeft(32, '0');
            char bit26 = numberBinary[5];
            char bit25 = numberBinary[6];
            char bit24 = numberBinary[7];
            char bit5 = numberBinary[26];
            char bit4 = numberBinary[27];
            char bit3 = numberBinary[28];

            char[] bitNumbers = numberBinary.ToCharArray();
            bitNumbers[28] = bit24;
            bitNumbers[27] = bit25;
            bitNumbers[26] = bit26;
            bitNumbers[7] = bit3;
            bitNumbers[6] = bit4;
            bitNumbers[5] = bit5;
            string newNumberBinary = new string(bitNumbers);
            uint newNumber = Convert.ToUInt32(newNumberBinary, 2);

            Console.WriteLine("Number n = {0}", number);
            Console.WriteLine("Binary representation of n: {0}", numberBinary);
            Console.WriteLine("Binary result: {0}", newNumberBinary);
            Console.WriteLine("result = {0}", newNumber);
        }
        else
        {
            Console.WriteLine("Your input is incorrect.Please enter a positive 32-bit integer number.");
        }
    }
}