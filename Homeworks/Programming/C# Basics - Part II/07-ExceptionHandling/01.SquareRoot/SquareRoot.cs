using System;

/* Write a program that reads an integer number and calculates and prints its square root.
If the number is invalid or negative, print Invalid number.
In all cases finally print Good bye.
Use try-catch-finally block.   */

class SquareRoot
{
    static void Main()
    {
        try
        {
            Console.Write("Enter integer number: ");
            int number = int.Parse(Console.ReadLine());
            if (number < 0)
            {
                throw new ArgumentException();
            }
            double result = Math.Sqrt(number);
            Console.WriteLine(result);
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid number!");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("Invalid number!");
        }
        catch (OverflowException)
        {
            Console.WriteLine("Invalid number!");
        }
        catch (Exception)
        {
            Console.WriteLine("Invalid number!");
        }
        finally
        {
            Console.WriteLine("Good bye.");
        }
    }
}