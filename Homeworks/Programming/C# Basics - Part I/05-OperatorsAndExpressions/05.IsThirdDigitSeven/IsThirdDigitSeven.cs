using System;

class IsThirdDigitSeven
{
    static void Main()
    {
        // Write an expression that checks for given integer if its third digit from right-to-left is 7.

        Console.Write("Enter an integer number: ");
        int number;
        bool result = int.TryParse(Console.ReadLine(), out number);
        if (result)
        {
            if (((number % 1000 >= 700) && (number % 1000 < 800)) || ((number % 1000 <= -700) && (number % 1000 > -800)))
            {
                Console.WriteLine("Third digit 7? {0} -> true.", number);

            }
            else
            {
                Console.WriteLine("Third digit 7? {0} -> false.", number);
            }
        }
        else
        {
            Console.WriteLine("This is not an integer number of type Int32.");
        }
    }
}