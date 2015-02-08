using System;

class CheckBitAtGivenPosition
{
    static void Main()
    {
        // Write a Boolean expression that returns if the bit at position p (counting from 0, starting from the right) in given integer number n, has value of 1.

        Console.Write("Enter an integer number n and press ENTER: ");
        int n;
        bool checkN = int.TryParse(Console.ReadLine(), out n);

        Console.Write("Enter a position number p and press ENTER: ");
        int p;
        bool checkP = int.TryParse(Console.ReadLine(), out p);

        if (checkN && checkP && ((0 <= p) && (p < 32)))
        {
            int mask = 1 << p;
            int vANDmask = n & mask;
            int bit = vANDmask >> p;
            bool isOne = (bit == 1);

            Console.WriteLine("Number n = {0}", n);
            string nBinary = Convert.ToString(n, 2);
            Console.WriteLine("Binary representation: {0}", nBinary.PadLeft(16, '0'));
            Console.WriteLine("p = {0}", p);
            Console.WriteLine("Bit @ p == 1 --> {0}", isOne);
        }
        else
        {
            Console.WriteLine("The input is incorrect.");
        }
    }
}