using System;

class SumOfThreeNumbers
{
    static void Main()
    {
        // Write a program that reads 3 real numbers from the console and prints their sum.

        Console.Write("Please, enter a real number and press ENTER: ");
        double firstNumber;
        bool isDoubleFirst = double.TryParse(Console.ReadLine(), out firstNumber);
        Console.Write("Please, enter a real number and press ENTER: ");
        double secondNumber;
        bool isDoubleSecond = double.TryParse(Console.ReadLine(), out secondNumber);
        Console.Write("Please, enter a real number and press ENTER: ");
        double thirdNumber;
        bool isDoubleThird = double.TryParse(Console.ReadLine(), out thirdNumber);
        if (isDoubleFirst && isDoubleSecond && isDoubleThird)
        {
            Console.WriteLine("The sum {0} + {1} + {2} = {3}", firstNumber, secondNumber, thirdNumber, (firstNumber + secondNumber + thirdNumber));
        }
        else
        {
            Console.WriteLine("Invalid input.");
        }
    }
}