using System;

/* Write a program to check if in a given expression the brackets are put correctly.
Example of correct expression: ((a+b)/5-d). Example of incorrect expression: )(a+b)).
*/
class CorrectBrackets
{
    static void Main()
    {
        Console.Write("Enter expression(e.g. ((a+b)/5-d)): ");
        string expression = Console.ReadLine();

        bool correctBrackets = CheckBrackets(expression);
        if (correctBrackets)
        {
            Console.WriteLine("Correct expression: " + expression);
        }
        else
        {
            Console.WriteLine("Incorrect expression: " + expression);
        }
    }

    static bool CheckBrackets(string expression)
    {
        int brackets = 0;
        foreach (var item in expression)
        {
            if (item == '(')
            {
                brackets++;
            }
            else if (item == ')')
            {
                brackets--;
            }
            if (brackets < 0)
            {
                return false;
            }
        }
        if (brackets != 0)
        {
            return false;
        }
        return true;
    }    
}