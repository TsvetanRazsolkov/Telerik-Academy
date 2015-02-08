using System;

class OddOrEvenIntegers
{
    static void Main()
    {
        // Write an expression that checks if given integer is odd or even.

        Console.Write("Enter an integer number: ");
        int number;
        bool result = int.TryParse(Console.ReadLine(), out number);
        if (result)
        {
            if (number % 2 == 0)
            {
                Console.WriteLine("The number {0} is even.", number);

            }
            else
            {
                Console.WriteLine("The number {0} is odd.", number);
            }
        }
        else
        {
            Console.WriteLine("This is not an integer number of type Int32.");
        }
    }
}