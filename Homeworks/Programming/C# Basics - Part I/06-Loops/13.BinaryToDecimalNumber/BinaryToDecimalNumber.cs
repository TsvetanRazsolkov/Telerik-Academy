using System;

class BinaryToDecimalNumber
{
    static void Main()
    {
        // Using loops write a program that converts a binary integer number to its decimal form. The input is entered as string. The output should be a variable of type long. Do not use the built-in .NET functionality.

        Console.Write("Enter a number in binary format and press ENTER: ");
        string input = Console.ReadLine();

        long sum = 0L;
        for (int i = input.Length - 1; i >= 0; i--)
        {
            long number = Convert.ToInt64(input[i].ToString(), 10);
            sum += (number * (1 << input.Length - i - 1));
        }
        Console.Write("Binary: {0}\nDecimal: {1}", input, sum);
        Console.WriteLine();
    }
}