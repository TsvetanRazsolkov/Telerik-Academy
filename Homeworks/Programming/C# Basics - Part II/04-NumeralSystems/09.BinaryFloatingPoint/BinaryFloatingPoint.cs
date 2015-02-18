using System;

/* Write a program that shows the internal binary representation of given 32-bit signed floating-point number in IEEE 754 format (the C# type float).
Example:
number	    sign	exponent	mantissa
-27,25	    1	    10000011	10110100000000000000000   */
class BinaryFloatingPoint
{
    static void Main()
    {
        Console.WriteLine("Enter 32-bit signed floating point number: ");
        float number = float.Parse(Console.ReadLine());

        string numberAsBinary = ConvertFloatToBinary(number);
        Console.WriteLine("Binary representation: {0}", numberAsBinary);
    }

    static string ConvertFloatToBinary(float number)
    {
        string endResult = string.Empty;
        if (number == 0)
        {
            return "0";
        }
        // Get the sign bit:
        endResult = GetSignBit(number) + endResult;
        if (endResult == "1")
        {
            number *= -1;
        }
        //Convert the integral part of the number to binary:
        string integralPart = IntegralPartToBinary((int)number);
        integralPart += ".";
        // Convert the decimal part of the number to binary:
        string decimalPart = DecimalPartToBinary(number - (int)number, integralPart.Length);
        // Get the mantissa bits(not normalized mantissa):
        string mantissa = integralPart + decimalPart;
        // To get the exponent as a decimal representation:
        int exponent = 0;
        if (integralPart[0] == '1')
        {
            exponent = mantissa.IndexOf(".", 0) - 1;
        }
        else if (integralPart[0] == '0')
        {
            int indexOfDot = mantissa.IndexOf('.', 0);
            exponent = indexOfDot - mantissa.IndexOf('1', indexOfDot);
        }
        // Get the exponent bits:
        string exponentBinary = ExponentToBinary(exponent);
        endResult += exponentBinary;
        // Normalize the mantissa and get its bits:
        mantissa = MantissaToBinary(mantissa, exponent);
        endResult += mantissa;
        return endResult;
    }

    static string MantissaToBinary(string mantissa, int exponent)
    {
        if (exponent < 0)
        {
            mantissa = mantissa.Remove(mantissa.IndexOf('.'), 1);
            char[] mantissaAsArray = mantissa.ToCharArray();
            for (int i = 0; i < mantissaAsArray.Length; i++)
            {
                if (mantissaAsArray[i] == '1')
                {
                    mantissaAsArray[i] = '.';
                    break;
                }
            }
            mantissa = string.Empty;
            for (int i = 0; i < mantissaAsArray.Length; i++)
            {
                mantissa += mantissaAsArray[i];
            }
            mantissa = mantissa.TrimStart('0');
            mantissa = mantissa.Remove(mantissa.IndexOf('.'), 1);
        }
        else
        {
            mantissa = mantissa.Remove(0, 1);
            mantissa = mantissa.Remove(mantissa.IndexOf('.'), 1);
        } 
        mantissa = mantissa.PadRight(23, '0');
        return mantissa;
    }

    static string ExponentToBinary(int exponent)
    {
        string result = string.Empty;
        exponent += 127;
        result = IntegralPartToBinary(exponent);
        result = result.PadLeft(8, '0');
        return result;
    }

    static string DecimalPartToBinary(float number, int length)
    {
        string decPart = string.Empty;
        while (decPart.Length <= (23 - length + 2))
        {
            number *= 2;
            if (number == 1.0)
            {
                decPart += "1";
                break;
            }
            if (number < 1.0)
            {
                decPart += "0";
            }
            else 
            {
                number -= 1;
                decPart += "1";
            }
        }
        return decPart;
    }

    static string IntegralPartToBinary(int num)
    {
        string binary = "";
        int remainder;
        if (num == 0)
        {
            return "0";
        }
        while (num > 0)
        {
            remainder = num % 2;
            binary = remainder + binary;
            num /= 2;
        }
        return binary;
    }

    static string GetSignBit(float number)
    {
        string sign = string.Empty;
        if (number < 0)
        {
            sign = "1" + sign;
        }

        else
        {
            sign = "0" + sign;
        }
        return sign;
    }
}