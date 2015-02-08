using System;

class NullValuesArithmetics
{
    static void Main()
    {
        // Create a program that assigns null values to an integer and to a double variable. Try to print these variables at the console. Try to add some number or the null literal to these variables and print the result.

        int? integerNumber = null;
        double? realNumber = null;
        Console.WriteLine("An integer number with value \"null\" is printed after the hyphen - " + integerNumber);
        Console.WriteLine("A real number with value \"null\" is printed after the hyphen - " + realNumber);

        Console.WriteLine(integerNumber + 10);
        Console.WriteLine(integerNumber + null);
        Console.WriteLine(realNumber + 15);
        Console.WriteLine(realNumber + null);

    }
}