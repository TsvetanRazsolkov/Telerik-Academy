using System;

/* Write a method that adds two polynomials.
Represent them as arrays of their coefficients.
Example:
x^2 + 5 = 1x^2 + 0x + 5 => {5, 0, 1}  */

class AddingPolynomials
{
    static void Main()
    {
        Console.WriteLine("Enter first polynom.");
        decimal[] firstPolynom = ReadPolynomFromConsole();
        Console.WriteLine("Enter second polynom.");
        decimal[] secondPolynom = ReadPolynomFromConsole();

        PrintPolynom(firstPolynom);
        Console.WriteLine("+");
        PrintPolynom(secondPolynom);
        Console.WriteLine("=");
        PrintPolynom(AddPolynoms(firstPolynom, secondPolynom));
    }

    static decimal[] AddPolynoms(decimal[] firstPolynom, decimal[] secondPolynom)
    {
        if (firstPolynom.Length >= secondPolynom.Length)
        {
            decimal[] result = new decimal[firstPolynom.Length];
            for (int i = 0; i < secondPolynom.Length; i++)
            {
                result[i] = firstPolynom[i] + secondPolynom[i];
            }
            for (int i = secondPolynom.Length; i < firstPolynom.Length; i++)
            {
                result[i] = firstPolynom[i];
            }
            return result;
        }
        else
        {
            decimal[] result = new decimal[secondPolynom.Length];
            for (int i = 0; i < firstPolynom.Length; i++)
            {
                result[i] = firstPolynom[i] + secondPolynom[i];
            }
            for (int i = firstPolynom.Length; i < secondPolynom.Length; i++)
            {
                result[i] = secondPolynom[i];
            }
            return result;
        }
    }

    static void PrintPolynom(decimal[] polynomial)
    {
        if (polynomial.Length == 1)
        {
            Console.Write("{0}", polynomial[polynomial.Length - 1]
            );
        }
        else
        {
            Console.Write("{0}x^{1}", polynomial[polynomial.Length - 1]
            , polynomial.Length - 1);
        }        
        for (int i = polynomial.Length - 2; i >= 0; i--)
        {
            if (i == 0)
            {
                if (polynomial[i] == 0)
                {
                    Console.Write("");
                }
                else if (polynomial[i] < 0)
                {
                    Console.Write(" {0}", polynomial[i]);
                }
                else
                {
                    Console.Write(" + {0}", polynomial[i]);
                }
            }
            else
            {
                if (polynomial[i] == 0)
                {
                    Console.Write("");
                }
                else if (polynomial[i] < 0)
                {
                    Console.Write(" {0}x^{1}", polynomial[i], i);
                }
                else
                {
                    Console.Write(" + {0}x^{1}", polynomial[i], i);
                }     
            }                   
        }
        Console.WriteLine();
    }

    static decimal[] ReadPolynomFromConsole()
    {
        Console.Write("Enter polynomial degree = ");
        int degree = int.Parse(Console.ReadLine());

        decimal[] polynom = new decimal[degree + 1];
        for (int i = 0; i < polynom.Length; i++)
        {
            Console.Write("Enter coefficient for x^{0}: ", i);
            polynom[i] = decimal.Parse(Console.ReadLine());
        }

        return polynom;
    }
}