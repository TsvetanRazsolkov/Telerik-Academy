using System;

class PrimeNumberCheck
{
    static void Main()
    {
        // Write an expression that checks if given positive integer number n (n <= 100) is prime (i.e. it is divisible without remainder only to itself and 1).

        Console.Write("Enter a positive integer number n<=100: ");

        byte number;
        bool result = byte.TryParse(Console.ReadLine(), out number);

        if (result && number > 0 && number <= 100)
        {
            byte divider = 2;
            byte maxDivider = (byte)Math.Sqrt(number);
            bool isPrime = true;
            while (isPrime && (divider <= maxDivider))
            {

                if (number % divider == 0)
                {
                    isPrime = false;
                }

                divider++;
            }

            if (isPrime)
            {
                Console.WriteLine("The number {0} is prime.", number);
            }
            else
            {
                Console.WriteLine("The number {0} is NOT prime.", number);
            }

        }
        else
        {
            Console.WriteLine("This number is not within the specified interval or of the specified type.");
        }
    }
}