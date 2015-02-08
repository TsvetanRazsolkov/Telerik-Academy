using System;

class HexadecimalToDecimalNumber
{
    static void Main()
    {
        // Using loops write a program that converts a hexadecimal integer number to its decimal form. The input is entered as string. The output should be a variable of type long. Do not use the built-in .NET functionality.

        Console.Write("Enter a number in hexadecimal format and press ENTER: ");
        string input = Console.ReadLine().ToUpper();

        long sum = 0L;
        int count = 0;
        long number = 0L;

        for (int i = input.Length - 1; i >= 0; i--)
        {            
            if (input[i] == 'A')
            {
                number = 10;
            }
            else if (input[i] == 'B')
            {
                number = 11;
            }
            else if (input[i] == 'C')
            {
                number = 12;
            }
            else if (input[i] == 'D')
            {
                number = 13;
            }
            else if (input[i] == 'E')
            {
                number = 14;
            }
            else if (input[i] == 'F')
            {
                number = 15;
            }
            else if (Char.IsDigit(input[i]))
            {
                number = Convert.ToInt64(input[i].ToString(), 10);
            }

            long powerOfSixteen = 1L;
            sum += (number * (powerOfSixteen << count));
            count += 4;
        }

        Console.Write("Hexadecimal: {0}\nDecimal: {1}", input, sum);
        Console.WriteLine();
    }
}