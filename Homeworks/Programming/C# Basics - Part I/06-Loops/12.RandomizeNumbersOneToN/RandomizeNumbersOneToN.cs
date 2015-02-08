using System;

class RandomizeNumbersOneToN
{
    static void Main()
    {
        // Write a program that enters in integer n and prints the numbers 1, 2, …, n in random order.

        Console.Write("Enter an integer n and press ENTER: ");
        int n = int.Parse(Console.ReadLine());
        int[] numbers = new int[n];
        int counter = 0;
        while (counter < n)
        {
            Console.Write("Enter an integer and press ENTER: ");
            numbers[counter] = int.Parse(Console.ReadLine());
            counter++;
        }
        foreach (var number in numbers)
        {
            Console.Write("{0} ", number);
        }
        Console.WriteLine();

        //  Fisher–Yates shuffle:
        Random randomGenerator = new Random();
        for (int i = numbers.Length - 1; i > 0; i--)
        {
            int j = randomGenerator.Next(i + 1);
            // Variable swap:
            int temp = numbers[j];
            numbers[j] = numbers[i];
            numbers[i] = temp;
        }
        foreach (var number in numbers)
        {
            Console.Write("{0} ", number);
        }
        Console.WriteLine();
    }
}