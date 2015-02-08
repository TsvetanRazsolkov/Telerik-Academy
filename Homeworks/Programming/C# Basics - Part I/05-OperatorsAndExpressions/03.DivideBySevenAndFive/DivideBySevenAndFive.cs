using System;

class DivideBySevenAndFive
{
    static void Main()
    {
        // Write a Boolean expression that checks for given integer if it can be divided (without remainder) by 7 and 5 at the same time.

        Console.Write("Enter an integer number: ");
        int number;
        bool isInteger = int.TryParse(Console.ReadLine(), out number);
        bool isDividable = (number % 7 == 0) && (number % 5 == 0);
        if (isInteger)
        {
            if (isDividable)
            {
                Console.WriteLine("The number {0} can be divided by 7 and 5 at the same time.", number);
            }
            else
            {
                Console.WriteLine("This number can't be divided by 7 and 5 at the same time.");
            }
        }
        else
        {
            Console.WriteLine("This is not an integer number of type Int32.");
        }
    }
}
