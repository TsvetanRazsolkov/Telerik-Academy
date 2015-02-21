using System;

/* Write a method ReadNumber(int start, int end) that enters an integer number in a given range
[start…end]. If an invalid number or non-number text is entered, the method should throw an 
exception. Using this method write a program that enters 10 numbers: a1, a2, … a10, such that
1 < a1 < … < a10 < 100  */

class EnterNumbers
{
    const int start = 2;
    const int end = 200;

    static void Main()
    {
        int[] numbers = new int[10];

        try
        {
            numbers[0] = ReadNumber(start, end);
            for (int i = 1; i < 10; i++)
            {
                numbers[i] = ReadNumber(start, end);
                if (numbers[i] <= numbers[i - 1])
                {
                    throw new ArgumentException("The entered number was not bigger than the previous one.");
                }
            }
        }
        catch (ArgumentOutOfRangeException arOutRange)
        {
            Console.WriteLine(arOutRange.ParamName);
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }
        catch (FormatException fe)
        {
            Console.WriteLine(fe.Message);
        }
        catch (OverflowException oe)
        {
            Console.WriteLine(oe.Message);
        }
        catch (Exception)
        {
            Console.WriteLine("Unknown error!");
        }
    }

    static int ReadNumber(int start, int end)
    {
        Console.Write("Enter integer number in the interval[{0},{1}]: ", start, end);
        int number = int.Parse(Console.ReadLine());
        if (number < start || number > end)
        {
            throw new ArgumentOutOfRangeException("The number is not in the specified interval.");
        }
        return number;
    }
}