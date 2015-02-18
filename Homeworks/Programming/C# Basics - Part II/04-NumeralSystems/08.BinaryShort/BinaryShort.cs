using System;

// Write a program that shows the binary representation of given 16-bit signed integer
// number (the C# type short).

class BinaryShort
{
    static void Main()
    {
        Console.WriteLine("Enter integer number in the range[-32768,32767]: ");
        short number = short.Parse(Console.ReadLine());

        Console.Write("Binary representation: ");
        if (number < 0)
        {
            string result = ShortToBinary(number);
            result = result.Remove(0,1);
            Console.WriteLine(1 + result);
        }
        else
        {
            Console.WriteLine(ShortToBinary(number));
        }        
    }

    static string ShortToBinary(short number)
    {
        if (number == 0)
        {
            return "0";
        }
        else if (number < 0)
        {
            // If the input number is negative this gives the same binary representation
            // with only the leftmost bit changed from 1 to 0. On line 17 we change it back
            // to 1 if the input number is < 0;
            number ^= short.MinValue;
        }
        string result = string.Empty;
        int remainder = 0;
        while (number > 0)
        {
            remainder = (int)number % 2;
            result = remainder + result;
            number /= 2;
        }
        result = result.PadLeft(16, '0');
        return result;
    }
}