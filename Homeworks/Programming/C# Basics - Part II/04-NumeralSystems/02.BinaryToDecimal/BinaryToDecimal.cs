using System;

// Write a program to convert binary numbers to their decimal representation.

    class BinaryToDecimal
    {
        static void Main()
        {
            Console.WriteLine("Enter positive integer number in binary representation: ");
            string binNumber = Console.ReadLine();

            Console.WriteLine("Decimal representation: {0}", BinToDecimal(binNumber));
        }

        static long BinToDecimal(string binNumber)
        {
            long decNumber = 0;
            for (int i = 0; i < binNumber.Length; i++)
            {
                decNumber += (binNumber[i] - '0') * BaseByPower(2,binNumber.Length - 1 - i);
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