using System;

class ModifyBitAtGivenPosition
{
    static void Main()
    {
        // We are given an integer number n, a bit value v (v=0 or 1) and a position p. Write a sequence of operators (a few lines of C# code) that modifies n to hold the value v at the position p from the binary representation of n while preserving all other bits in n.

        Console.Write("Enter an integer number n and press ENTER: ");
        int n;
        bool checkN = int.TryParse(Console.ReadLine(), out n);

        Console.Write("Enter a bit position number p and press ENTER: ");
        byte p;
        bool checkP = byte.TryParse(Console.ReadLine(), out p);

        Console.Write("Enter a bit value v (1 or 0) and press ENTER: ");
        byte v;
        bool checkV = byte.TryParse(Console.ReadLine(), out v);

        if (checkN && checkP && checkV && ((0 <= p) && (p < 32)) && ((v == 0) || (v == 1)))
        {
            int result;

            if (v == 0)
            {
                int mask = ~(1 << p);
                result = mask & n;
                string nBinary = Convert.ToString(n, 2).PadLeft(16, '0');
                string resultBinary = Convert.ToString(result, 2).PadLeft(16, '0');

                Console.WriteLine("Number n = {0}", n);
                Console.WriteLine("Binary representation of n: {0}", nBinary);
                Console.WriteLine("p = {0}\nv = {1}", p, v);
                Console.WriteLine("Binary result: {0}", resultBinary);
                Console.WriteLine("result = {0}", result);
            }
            else if (v == 1)
            {
                int mask = 1 << p;
                result = mask | n;
                string nBinary = Convert.ToString(n, 2).PadLeft(16, '0');
                string resultBinary = Convert.ToString(result, 2).PadLeft(16, '0');

                Console.WriteLine("Number n = {0}", n);
                Console.WriteLine("Binary representation of n: {0}", nBinary);
                Console.WriteLine("p = {0}\nv = {1}", p, v);
                Console.WriteLine("Binary result: {0}", resultBinary);
                Console.WriteLine("result = {0}", result);
            }
        }
        else
        {
            Console.WriteLine("The input is incorrect.");
        }
    }
}