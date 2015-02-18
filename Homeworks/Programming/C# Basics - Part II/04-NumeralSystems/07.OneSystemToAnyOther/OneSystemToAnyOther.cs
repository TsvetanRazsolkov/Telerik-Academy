using System;

// Write a program to convert from any numeral system of given base s to any other numeral
// system of base d (2 ≤ s, d ≤ 16).

class OneSystemToAnyOther
{
    static void Main()
    {
        // Both 's' and 'd' should be >= 2 and <= 16, by task condition!        
        Console.Write("Enter base of numeral system s = ");
        int s = int.Parse(Console.ReadLine());
        if (!ValidateInput(s))
        {
            throw new ArgumentException("Incorrect input!");
        }
        Console.Write("Enter enter number in numeral system with base {0}: ", s);
        string number = Console.ReadLine().ToUpper();
        if (!ValidateInput(number, s))
        {
            throw new ArgumentException("Incorrect input!");
        }
        Console.Write("Enter base of target numeral system d = ");
        int d = int.Parse(Console.ReadLine());
        if (!ValidateInput(d))
        {
            throw new ArgumentException("Incorrect input!");
        }
        Console.WriteLine("Number's representation in base{0} system: {1}", d,
            ConvertToBase(number, s, d));
    }

    static bool ValidateInput(int baseOfSystem)
    {
        if (baseOfSystem <= 16 && baseOfSystem >= 2)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    static bool ValidateInput(string number, int baseOfSystem)
    {
        foreach (char digit in number)
        {
            if (baseOfSystem <= 10)
            {
                if (digit > (char)(baseOfSystem - 1 + '0') || digit < '0')
                {
                    return false;
                }
            }
            else
            {
                if (char.IsDigit(digit))
                {
                    if (digit > '9' || digit < '0')
                    {
                        return false;
                    }
                }
                else
                {
                    if (digit >= (char)(baseOfSystem - 10 + 'A') || digit < 'A')
                    {
                        return false;
                    }
                }                
            }
        }
        return true;
    }

    static string ConvertToBase(string number, int originalBase, int targetBase)
    {
        string result = string.Empty;
        long decNumber = ConvertToDecimal(number, originalBase);
        result = ConvertFromDecimal(decNumber, targetBase);
        return result;
    }

    static string ConvertFromDecimal(long decNumber, int targetBase)
    {
        string result = string.Empty;
        int remainder;
        if (decNumber == 0)
        {
            return "0";
        }
        while (decNumber > 0)
        {
            remainder = (int)(decNumber % targetBase);
            if (remainder >= 0 && remainder < targetBase)
            {
                result = (char)(remainder + '0') + result;
            }
            else if (remainder > 9 && remainder <= 15)
            {
                result = (char)(remainder - 10 + 'A') + result;
            }
            decNumber /= targetBase;
        }
        return result;
    }

    static long ConvertToDecimal(string number, int originalBase)
    {
        long decNumber = 0;
        for (int i = 0; i < number.Length; i++)
        {
            if (number[i] >= 'A' && number[i] <= 'F')
            {
                decNumber +=
                    (number[i] - 'A' + 10) * BaseByPower(originalBase, number.Length - 1 - i);
            }
            else if (number[i] >= '0' && number[i] <= (char)(originalBase - 1 + '0'))
            {
                decNumber +=
                (number[i] - '0') * BaseByPower(originalBase, number.Length - 1 - i);
            }
        }
        return decNumber;
    }

    static long BaseByPower(int numberBase, int power)
    {
        long result = 1;
        for (int i = 0; i < power; i++)
        {
            result *= numberBase;
        }
        return result;
    }
}