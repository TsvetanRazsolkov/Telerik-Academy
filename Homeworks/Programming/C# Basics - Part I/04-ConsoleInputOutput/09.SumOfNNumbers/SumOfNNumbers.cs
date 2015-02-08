using System;

class SumOfNNumbers
{
    static void Main()
    {
        // Write a program that enters a number n and after that enters more n numbers and calculates and prints their sum.

        Console.Write("Enter positive integer n and press ENTER: ");
        double n = double.Parse(Console.ReadLine());
        int counter = 0;
        double sum = 0;
        do
        {
            counter++;
            Console.Write("Enter a number and press ENTER: ");
            double num = double.Parse(Console.ReadLine());
            sum += num;
        } while (counter < n);
        Console.WriteLine("Sum = {0}", sum);
    }
}
