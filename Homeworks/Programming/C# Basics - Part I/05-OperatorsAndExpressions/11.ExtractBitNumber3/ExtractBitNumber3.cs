using System;

class ExtractBitNumber3
{
    static void Main()
    {
        // Using bitwise operators, write an expression for finding the value of the bit #3 of a given unsigned integer. The bits are counted from right to left, starting from bit #0. The result of the expression should be either 1 or 0.

        Console.Write("Enter an integer number i and press ENTER: ");
        int i;
        bool checkI = int.TryParse(Console.ReadLine(), out i);
        
        if (checkI && i >= 0)
        {

            int mask = 1 << 3;
            int iANDmask = i & mask;
            int bit = iANDmask >> 3;

            Console.WriteLine("Your number: {0}", i);
            string iBinary = Convert.ToString(i, 2); 
            Console.WriteLine("Binary representation: {0}", iBinary.PadLeft(16, '0'));
            Console.WriteLine("Bit #3 = {0}", bit);

        }
        else
        {
            Console.WriteLine("The input is incorrect.");
        }
    }
}