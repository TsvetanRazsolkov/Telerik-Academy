using System;

class BiggestOfFiveNumbers
{
    static void Main()
    {
        // Write a program that finds the biggest of five numbers by using only five if statements.

        Console.WriteLine("Enter 5 real numbers on separate lines:");

        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double c = double.Parse(Console.ReadLine());
        double d = double.Parse(Console.ReadLine());
        double e = double.Parse(Console.ReadLine());

        double biggestNumber = 0;

        if (biggestNumber < a)
        {
            biggestNumber = a;
        }
        if (biggestNumber < b)
        {
            biggestNumber = b;
        }
        if (biggestNumber < c)
        {
            biggestNumber = c;
        }
        if (biggestNumber < d)
        {
            biggestNumber = d;
        }
        if (biggestNumber < e)
        {
            biggestNumber = e;
        }

        Console.WriteLine("The biggest number is: {0}", biggestNumber);
    }
}
