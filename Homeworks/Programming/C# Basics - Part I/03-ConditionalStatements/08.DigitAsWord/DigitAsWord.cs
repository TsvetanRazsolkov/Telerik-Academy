using System;

class DigitAsWord
{
    static void Main()
    {
        // Write a program that asks for a digit (0-9), and depending on the input, shows the digit as a word (in English).
        // Print “not a digit” in case of invalid input.

        Console.Write("Enter a digit in the range [0...9]:");

        int digit;
        bool isInteger = int.TryParse(Console.ReadLine(), out digit);

        if (isInteger)
        {
            
            switch (digit)
            {
                case 0:
                    Console.WriteLine("{0} zero", digit);
                    break;
                case 1:
                    Console.WriteLine("{0} one", digit);
                    break;
                case 2:
                    Console.WriteLine("{0} two", digit);
                    break;
                case 3:
                    Console.WriteLine("{0} three", digit);
                    break;
                case 4:
                    Console.WriteLine("{0} four", digit);
                    break;
                case 5:
                    Console.WriteLine("{0} five", digit);
                    break;
                case 6:
                    Console.WriteLine("{0} six", digit);
                    break;
                case 7:
                    Console.WriteLine("{0} seven", digit);
                    break;
                case 8:
                    Console.WriteLine("{0} eight", digit);
                    break;
                case 9:
                    Console.WriteLine("{0} nine", digit);
                    break;
                default:
                    Console.WriteLine("not a digit");
                    break;
            }
        }
        else
        {
            Console.WriteLine("not a digit");
        }
    }
}
