using System;

class FormattingNumbers
{
    static void Main()
    {
        /* Write a program that reads 3 numbers:
        integer a (0 <= a <= 500)
        floating-point b
        floating-point c
        The program then prints them in 4 virtual columns on the console. Each column should have a width of 10 characters.
        The number a should be printed in hexadecimal, left aligned
        Then the number a should be printed in binary form, padded with zeroes
        The number b should be printed with 2 digits after the decimal point, right aligned
        The number c should be printed with 3 digits after the decimal point, left aligned. */
        Console.Write("Enter integer a in the range [0...500] and press ENTER: ");
        int a;
        bool isIntA = int.TryParse(Console.ReadLine(), out a);
        Console.Write("Enter real number b and press ENTER: ");
        double b;
        bool isDoubleB = double.TryParse(Console.ReadLine(), out b);
        Console.Write("Enter real number c and press ENTER: ");
        double c;
        bool isDoubleC = double.TryParse(Console.ReadLine(), out c);

        if (isIntA && isDoubleB && isDoubleC && ((a >= 0) && (a <= 500)))
        {
            string aBinary = Convert.ToString(a, 2).PadLeft(10, '0');
            Console.Write("{0,-10:X}", a);
            Console.Write("|");
            Console.Write("{0}", aBinary);
            Console.Write("|");
            Console.Write("{0,10:F2}", b);
            Console.Write("|");
            Console.Write("{0,-10:F3}", c);
            Console.Write("|");
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("Invalid input.");
        }
    }
}