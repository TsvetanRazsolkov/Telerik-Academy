using System;

/* Write a program that can solve these tasks:
-Reverses the digits of a number
-Calculates the average of a sequence of integers
-Solves a linear equation a * x + b = 0
Create appropriate methods.
Provide a simple text-based menu for the user to choose which task to solve.
Validate the input data:
-The decimal number should be non-negative
-The sequence should not be empty
-a should not be equal to 0  */

class SolveTasks
{
    static void Main()
    {
        char taskChoice = ChooseTask();
        switch (taskChoice)
        {
            case '1':
                Console.Write("Enter positive number in decimal format and press ENTER: ");
                string input = Console.ReadLine();
                bool isValid = ValidateInput(input, taskChoice);
                if (isValid)
                {
                    int number = int.Parse(input);
                    Console.Write("Number = {0}\nNumber reversed = " , input);
                    ReverseNumber(number);
                }
                else
                {
                    Console.WriteLine("Enter positive integer number in decimal format.");
                }
                break;
            case '2':
                Console.Write("Enter sequence of integers on a single line separated by SPACE and press ENTER: ");
                string arrayAsString = Console.ReadLine();
                isValid = ValidateInput(arrayAsString, taskChoice);
                if (isValid)
                {
                    int[] numberSequence = ReadArrayFromConsole(arrayAsString);
                    Console.Write("Average = ");
                    GetAverage(numberSequence);
                }
                else
                {
                    Console.WriteLine("Enter a non-empty number sequence.");
                }
                break;
            case '3':
                Console.Write("Enter a = ");
                string a = Console.ReadLine();
                isValid = ValidateInput(a, taskChoice);
                if (isValid)
                {
                    Console.Write("Enter b = ");
                    string b = Console.ReadLine();
                    Console.Write("{0}x + {1} = 0 ---> x = ", a, b);
                    SolveEquation(a, b);
                }
                else
                {
                    Console.WriteLine("a should be different than 0");
                }
                break;
            default:
                Console.WriteLine("Invalid task choice.");
                break;
        }
    }

    static void SolveEquation(string a, string b)
    {
        double first = int.Parse(a);
        double second = int.Parse(b);
        double result = (-second) / first;
        Console.WriteLine(result);
    }


    static void GetAverage(int[] numberSequence)
    {
        double sum = 0;
        for (int i = 0; i < numberSequence.Length; i++)
        {
            sum += numberSequence[i];
        }
        double average = sum / numberSequence.Length;
        Console.WriteLine(average);
    }

    static int[] ReadArrayFromConsole(string input)
    {        
        string[] numbersAsString = input.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
        int[] result = new int[numbersAsString.Length];
        for (int i = 0; i < numbersAsString.Length; i++)
        {

            result[i] = int.Parse(numbersAsString[i]);
        }
        return result;
    }

    static void ReverseNumber(int number)
    {        
        while (number != 0)
        {
            Console.Write(number % 10);
            number /= 10;
        }
        Console.WriteLine();
    }

    static bool ValidateInput(string input, char choice)
    {
        int number;
        if (choice == '1')
        {
            if (int.TryParse(input, out number))
            {
                if (number > 0)
                {
                    return true;
                }
                return false;
            }
            return false;
        }
        else if (choice == '2')
        {
            if (input.Length > 0)
            {
                return true;
            }
            return false;
        }
        else
        {
            if (int.TryParse(input, out number))
            {
                if (number != 0)
                {
                    return true;
                } return false;
            }
            return false;
        }
    }

    static char ChooseTask()
    {
        
        Console.WriteLine("1 - Reverse the digits of a number.");
        Console.WriteLine("2 - Calculates the average of a sequence of integers.");
        Console.WriteLine("3 - Solve a linear equation a * x + b = 0");
        Console.Write("Choose a task to perform (by pressing 1, 2 or 3): ");
        ConsoleKeyInfo pressedKey = Console.ReadKey();
        Console.WriteLine();
        return pressedKey.KeyChar;
    }
}