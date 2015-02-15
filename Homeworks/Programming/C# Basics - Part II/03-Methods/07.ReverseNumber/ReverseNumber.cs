using System;

/* Write a method that reverses the digits of given decimal number.
Example:
input	    output
256	        652  */

class ReverseNumber
{
    static void Main()
    {
        Console.Write("Enter an integer number: ");
        int number = int.Parse(Console.ReadLine());

        NumberReverse(number);
    }

    static void NumberReverse(int number)
    {
        if (number == 0)
        {
            Console.WriteLine(0);
            return;
        }
        while (number != 0)
        {
            Console.Write(number % 10);
            number /= 10;
        }
        Console.WriteLine();
    }
}