﻿using System;

class IntDoubleString
{
    static void Main()
    {
        /* Write a program that, depending on the user’s choice, inputs an int, double or string variable.
        If the variable is int or double, the program increases it by one.
        If the variable is a string, the program appends * at the end.
        Print the result at the console. Use switch statement. */

        Console.WriteLine(" Please choose a type: \n1-->int \n2-->double \n3-->string");
        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                Console.Write("Please enter an int and press ENTER: ");
                int integerNumber = int.Parse(Console.ReadLine());
                Console.WriteLine(integerNumber + 1);
                break;
            case 2:
                Console.Write("Please enter a double and press ENTER: ");
                double realNumber = double.Parse(Console.ReadLine());
                Console.WriteLine(realNumber + 1);
                break;
            case 3:
                Console.Write("Please enter a string and press ENTER: ");
                string userInput = Console.ReadLine();
                Console.WriteLine(userInput + "*");
                break;
            default:
                break;
        }
    }
}

