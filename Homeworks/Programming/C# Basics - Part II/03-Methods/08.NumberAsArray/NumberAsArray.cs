using System;
using System.Collections.Generic;

/* Write a method that adds two positive integer numbers represented as arrays of 
digits (each array element arr[i] contains a digit; the last digit is kept in arr[0]).
Each of the numbers that will be added could have up to 10 000 digits.  */

class NumberAsArray
{
    static void Main()
    {
        int[] firstNumber = ReadNumberFromConsole();
        int[] secondNumber = ReadNumberFromConsole();

        List<int> result = AddNumbers(firstNumber, secondNumber);

        Print(result);
    }

    static void Print(List<int> result)
    {
        Console.Write("First number + second number = ");
        for (int i = result.Count - 1; i >= 0; i--)
        {
            Console.Write(result[i]);
        }
        Console.WriteLine();
    }

    static List<int> AddNumbers(int[] firstNumber, int[] secondNumber)
    {
        List<int> sum = new List<int>();
        int remainder = 0;
        if (firstNumber.Length == secondNumber.Length)
        {                        
            for (int i = 0; i < firstNumber.Length; i++)
            {
                sum.Add((firstNumber[i] + secondNumber[i] + remainder) % 10);
                remainder = (firstNumber[i] + secondNumber[i] + remainder) / 10;
            }
            if (remainder != 0)
            {
                sum.Add(remainder);
            }
            return sum;
        }
        else
        {
            int smallerNumberLength = Math.Min(firstNumber.Length,secondNumber.Length);
            int biggerNumberLength = Math.Max(firstNumber.Length, secondNumber.Length);
            for (int i = 0; i < smallerNumberLength; i++)
            {
                sum.Add((firstNumber[i] + secondNumber[i] + remainder) % 10);
                remainder = (firstNumber[i] + secondNumber[i] + remainder) / 10;
            }
            for (int i = smallerNumberLength; i < biggerNumberLength; i++)
            {
                if (firstNumber.Length > secondNumber.Length)
                {
                    sum.Add(firstNumber[i] + remainder);
                    remainder = 0;
                }
                else
                {
                    sum.Add(secondNumber[i] + remainder);
                    remainder = 0;
                }
            }
            return sum;
        }        
    }

    static int[] ReadNumberFromConsole()
    {
        Console.Write("Enter positive number with up to 10 000 digits: ");
        string number = Console.ReadLine();
        int[] digits = new int[number.Length];
        for (int i = 0; i < number.Length; i++)
        {
            digits[number.Length - 1 - i] = number[i] - '0';
        }
        return digits;
    }
}