using System;

/* You are given a sequence of positive integer values written into a string, separated by spaces.
Write a function that reads these values from given string and calculates their sum.
Example:
input	            output
"43 68 9 23 318"	461    */

class SumIntegers
{
    static void Main()
    {
        Console.Write("Enter sequence of positive integers separated by SPACE: ");
        string input = Console.ReadLine();

        long sum = SummingIntegers(input);

        Console.WriteLine("Sum = {0}", sum);
    }

    static long SummingIntegers(string input)
    {        
        string[] numbersAsStrings = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        long sum = 0;
        foreach (var number in numbersAsStrings)
        {
            sum += int.Parse(number);
        }
        return sum;
    }
}