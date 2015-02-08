using System;

class FloatOrDouble
{
    static void Main()
    {
        /* Which of the following values can be assigned to a variable of type float and which to a variable of type double: 34.567839023, 12.345, 8923.1234857, 3456.091? */

        double number1 = 34.567839023;
        double number2 = 8923.1234857;
        float number3 = 12.345f;
        float number4 = 3456.091f;
        Console.WriteLine("{0}\n{1}\n{2}\n{3}", number1, number2, number3, number4);
    }
}