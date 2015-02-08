using System;

class NumberAsWords
{
    // Write a program that converts a number in the range [0…999] to words, corresponding to the English pronunciation.

    static string input = Console.ReadLine();
    static int number = int.Parse(input);

    static void Main()
    {

        if (number >= 0 && number < 10)
        {
            PrintDigit(number);
        }
        else if (number >= 10 && number < 20)
        {
            PrintTeens(number);
        }
        else if (number >= 20 && number < 100)
        {
            PrintScores(number);
        }
        else if (number >= 100 && number < 1000)
        {
            PrintHundreds(number);
        }
        else
        {
            Console.WriteLine("Invalid input.");
        }
        Console.WriteLine();
    }

    static void PrintDigit(int digit)
    {
        switch (digit)
        {
            case 0:
                Console.Write("zero");
                break;
            case 1:
                Console.Write("one");
                break;
            case 2:
                Console.Write("two");
                break;
            case 3:
                Console.Write("three");
                break;
            case 4:
                Console.Write("four");
                break;
            case 5:
                Console.Write("five");
                break;
            case 6:
                Console.Write("six");
                break;
            case 7:
                Console.Write("seven");
                break;
            case 8:
                Console.Write("eight");
                break;
            case 9:
                Console.Write("nine");
                break;
            default:
                Console.Write("not a digit");
                break;
        }
    }
    static void PrintTeens(int number)
    {
        switch (number)
        {
            case 10:
                Console.Write("ten");
                break;
            case 11:
                Console.Write("eleven");
                break;
            case 12:
                Console.Write("twelve");
                break;
            case 13:
                Console.Write("thirteen");
                break;
            case 14:
                Console.Write("fourteen");
                break;
            case 15:
                Console.Write("fifteen");
                break;
            case 16:
                Console.Write("sixteen");
                break;
            case 17:
                Console.Write("seventeen");
                break;
            case 18:
                Console.Write("eighteen");
                break;
            case 19:
                Console.Write("nineteen");
                break;
            default:
                break;
        }
    }
    static void PrintScores(int number)
    {
        if (input[1] == '0')
        {
            switch (number)
            {
                case 20:
                    Console.Write("twenty");
                    break;
                case 30:
                    Console.Write("thirty");
                    break;
                case 40:
                    Console.Write("fourty");
                    break;
                case 50:
                    Console.Write("fifty");
                    break;
                case 60:
                    Console.Write("sixty");
                    break;
                case 70:
                    Console.Write("seventy");
                    break;
                case 80:
                    Console.Write("eighty");
                    break;
                case 90:
                    Console.Write("ninety");
                    break;
                default:
                    break;
            }
        }
        else
        {
            string tenthsAsString = input[0].ToString();
            int tenths = Convert.ToInt32(tenthsAsString, 10);
            switch (tenths)
            {
                case 2:
                    Console.Write("twenty");
                    break;
                case 3:
                    Console.Write("thirty");
                    break;
                case 4:
                    Console.Write("fourty");
                    break;
                case 5:
                    Console.Write("fifty");
                    break;
                case 6:
                    Console.Write("sixty");
                    break;
                case 7:
                    Console.Write("seventy");
                    break;
                case 8:
                    Console.Write("eighty");
                    break;
                case 9:
                    Console.Write("ninety");
                    break;
                default:
                    break;
            }
            string digitAsString = input[1].ToString();
            int digits = Convert.ToInt32(digitAsString, 10);
            switch (digits)
            {
                case 1:
                    Console.Write(" one");
                    break;
                case 2:
                    Console.Write(" two");
                    break;
                case 3:
                    Console.Write(" three");
                    break;
                case 4:
                    Console.Write(" four");
                    break;
                case 5:
                    Console.Write(" five");
                    break;
                case 6:
                    Console.Write(" six");
                    break;
                case 7:
                    Console.Write(" seven");
                    break;
                case 8:
                    Console.Write(" eight");
                    break;
                case 9:
                    Console.Write(" nine");
                    break;
                default:
                    break;
            }
        }
    }
    static void PrintHundreds(int number)
    {
        string hundredsAsString = input[0].ToString();
        int hundreds = Convert.ToInt32(hundredsAsString, 10);
        string tenthsAsString = input[1].ToString();
        int tenths = Convert.ToInt32(tenthsAsString, 10);
        string digitAsString = input[2].ToString();
        int digits = Convert.ToInt32(digitAsString, 10);

        PrintDigit(hundreds);
        if (input[1] == '0' && input[2] == '0')
        {
            Console.Write(" hundred");
        }
        else if (input[1] == '0')
        {

            Console.Write(" hundred and ");
            PrintDigit(digits);
        }
        else if (input[1] == '1')
        {
            Console.Write(" hundred and ");
            switch (digits)
            {
                case 0:
                    Console.Write("ten");
                    break;
                case 1:
                    Console.Write("eleven");
                    break;
                case 2:
                    Console.Write("twelve");
                    break;
                case 3:
                    Console.Write("thirteen");
                    break;
                case 4:
                    Console.Write("fourteen");
                    break;
                case 5:
                    Console.Write("fifteen");
                    break;
                case 6:
                    Console.Write("sixteen");
                    break;
                case 7:
                    Console.Write("seventeen");
                    break;
                case 8:
                    Console.Write("eighteen");
                    break;
                case 9:
                    Console.Write("nineteen");
                    break;
                default:
                    break;
            }
        }

        else if (input[2] == '0')
        {
            Console.Write(" hundred and ");
            switch (tenths)
            {
                case 2:
                    Console.Write("twenty ");
                    break;
                case 3:
                    Console.Write("thirty ");
                    break;
                case 4:
                    Console.Write("fourty ");
                    break;
                case 5:
                    Console.Write("fifty ");
                    break;
                case 6:
                    Console.Write("sixty ");
                    break;
                case 7:
                    Console.Write("seventy ");
                    break;
                case 8:
                    Console.Write("eighty ");
                    break;
                case 9:
                    Console.Write("ninety ");
                    break;
                default:
                    break;
            }
        }
        else
        {
            Console.Write(" hundred and ");
            switch (tenths)
            {
                case 2:
                    Console.Write("twenty ");
                    break;
                case 3:
                    Console.Write("thirty ");
                    break;
                case 4:
                    Console.Write("fourty ");
                    break;
                case 5:
                    Console.Write("fifty ");
                    break;
                case 6:
                    Console.Write("sixty ");
                    break;
                case 7:
                    Console.Write("seventy ");
                    break;
                case 8:
                    Console.Write("eighty ");
                    break;
                case 9:
                    Console.Write("ninety ");
                    break;
                default:
                    break;
            }
            PrintDigit(digits);
        }
    }
}
