using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Numerics;
using System.Threading;
using System.Globalization;

class Decoding
{
    static void Main()
    {
        int salt = int.Parse(Console.ReadLine()); 
        char[] text = Console.ReadLine().ToCharArray();
        double[] encodedText = new double[text.Length - 1];

        int i = 0;
        while (text[i] != '@')
        {
            if (Char.IsLetter(text[i]))
            {
                encodedText[i] = text[i]*salt + 1000;
            }
            else if (Char.IsDigit(text[i]))
            {
                encodedText[i] = text[i] + salt + 500;
            }
            else if (!Char.IsLetterOrDigit(text[i]))
            {
                encodedText[i] = text[i] - salt;
            }
            i++;
        }

        for (int j = 0; j < encodedText.Length; j++)
        {
            if (j % 2 == 0)
            {
                encodedText[j] /= 100;
                Console.WriteLine("{0:F2}", encodedText[j]);
            }
            else if (j % 2 != 0)
            {
                encodedText[j] *= 100;
                Console.WriteLine("{0:0}", encodedText[j]);
            }
        }
    }
}

