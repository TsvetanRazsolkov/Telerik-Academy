using System;

class SumOfFiveNumbers
{
    static void Main()
    {
        // Write a program that enters 5 numbers (given in a single line, separated by a space), calculates and prints their sum.

        Console.Write("Enter 5 integers separated by a space and then press ENTER: ");
        string input = Console.ReadLine();
        string [] numbersAsStrings = input.Split(' ');
        double[] numbers = new double[5];
        for (int i = 0; i < numbersAsStrings.Length; i++ )
        {
            numbers[i] = double.Parse(numbersAsStrings[i]);
        }
        double sum = 0;
        foreach (var number in numbers)
        {
            sum += number;
        }
        Console.WriteLine("Sum = {0}",sum);
    }
}
