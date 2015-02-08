using System;

class ExtractBitFromInteger
{
    static void Main()
    {
        // Write an expression that extracts from given integer n the value of given bit at index p.

        Console.Write("Enter an integer number n and press ENTER: ");
        int n;
        bool checkN = int.TryParse(Console.ReadLine(), out n);

        Console.Write("Enter a bit position p and press ENTER: ");
        int bitPosition;
        bool checkBitPosition = int.TryParse(Console.ReadLine(), out bitPosition);

        if (checkN && checkBitPosition && ((0 <= bitPosition) && (bitPosition < 32)))
        {

            int mask = 1 << bitPosition;
            int nANDmask = n & mask;
            int bit = nANDmask >> bitPosition;

            Console.WriteLine("Number n = {0}", n);
            string nBinary = Convert.ToString(n, 2);
            Console.WriteLine("Binary representation: {0}", nBinary.PadLeft(16, '0'));
            Console.WriteLine("p = {0}", bitPosition);
            Console.WriteLine("Bit @ p = {0}", bit);
        }
        else
        {
            Console.WriteLine("The input is incorrect.");
        }
    }
}