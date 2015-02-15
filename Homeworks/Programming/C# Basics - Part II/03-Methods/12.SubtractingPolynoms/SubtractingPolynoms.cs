using System;

// Extend the previous program to support also subtraction and multiplication of 
// polynomials.

class SubtractingPolynoms
{
    static void Main()
    {
        Console.WriteLine("Enter first polynom.");
        decimal[] firstPolynom = ReadPolynomFromConsole();
        Console.WriteLine("Enter second polynom.");
        decimal[] secondPolynom = ReadPolynomFromConsole();

        // Add polynomials:
        PrintPolynom(firstPolynom);
        Console.WriteLine("+");
        PrintPolynom(secondPolynom);
        Console.WriteLine("=");
        PrintPolynom(AddPolynoms(firstPolynom, secondPolynom));
        Console.WriteLine();

        // Subtract polynomials:
        PrintPolynom(firstPolynom);
        Console.WriteLine("-");
        PrintPolynom(secondPolynom);
        Console.WriteLine("=");
        PrintPolynom(SubtractPolynoms(firstPolynom, secondPolynom));
        Console.WriteLine();        

        // Multiply polynomials:
        PrintPolynom(firstPolynom);
        Console.WriteLine("*");
        PrintPolynom(secondPolynom);
        Console.WriteLine("=");
        PrintPolynom(MultiplyPolynoms(firstPolynom, secondPolynom));
        Console.WriteLine();
    }

    static decimal[] SubtractPolynoms(decimal[] firstPolynom, decimal[] secondPolynom)
    {
        for (int i = 0; i < secondPolynom.Length; i++)
        {
            secondPolynom[i] *= -1;
        }
        decimal[] result = AddPolynoms(firstPolynom, secondPolynom);
        for (int i = 0; i < secondPolynom.Length; i++)
        {
            secondPolynom[i] *= -1;
        }
        return result;
    }

    static decimal[] MultiplyPolynoms(decimal[] firstPolynom, decimal[] secondPolynom)
    {
        decimal[] result = new decimal[firstPolynom.Length + secondPolynom.Length - 1];

        for (int i = 0; i < firstPolynom.Length; i++)
        {
            for (int j = 0; j < secondPolynom.Length; j++)
            {
                result[i + j] += firstPolynom[i] * secondPolynom[j];
            }
        }
        return result;
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