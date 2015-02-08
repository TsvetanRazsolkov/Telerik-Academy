using System;

class NumbersFromOneToN
{
    static void Main()
    {
        // Write a program that reads an integer number n from the console and prints all the numbers in the interval [1..n], each on a single line.

        Console.Write("Enter an integer number: ");
            int n;
            bool isInt = int.TryParse(Console.ReadLine(), out n);

            if (isInt)
            {
                if (n > 0)
                {
                    for (int i = 1; i <= n; i++)
                    {
                        Console.WriteLine(i);
                    }                    
                }
                else if (n <= 0)
                {
                    for (int i = 1; i >= n; i--)
                    {
                        Console.WriteLine(i);
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
    }
}