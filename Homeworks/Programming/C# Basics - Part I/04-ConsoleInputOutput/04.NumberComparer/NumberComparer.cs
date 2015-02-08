using System;
using System.Globalization;
using System.Threading;

class NumberComparer
{
    static void Main()
    {
        // Write a program that gets two numbers from the console and prints the greater of them.Try to implement this without if statements.

        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        Console.Write("Enter number and press ENTER: ");
        string input = Console.ReadLine();
        input = input.Replace(',', '.');
        double firstNum = double.Parse(input);

        Console.Write("Enter number and press ENTER: ");
        string secondInput = Console.ReadLine();
        secondInput = secondInput.Replace(',', '.');
        double secondNum = double.Parse(secondInput);

        Console.WriteLine("Greater: {0}",Math.Max(firstNum, secondNum));
    }
}