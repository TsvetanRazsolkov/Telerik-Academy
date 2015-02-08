using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Numerics;
using System.Threading;
using System.Globalization;

class ConsoleApplication1
{
    static void Main()
    {
        int counter = 0;
        string num = string.Empty;

        BigInteger firstResult = 1;
        BigInteger secondResult = 1;
        while (num != "END")
        {
            num = Console.ReadLine();
            if (counter < 10 && counter % 2 == 1)
            {
                BigInteger result = 1;
                if (num == "0")
                {
                    result = 1;
                    firstResult *= result;
                }
                else if (num != "END")
                {
                    num = num.Replace('-', '1');
                    num = num.Replace('0', '1');
                    for (int i = 0; i < num.Length; i++)
                    {
                        result *= (num[i] - '0');
                    }
                    firstResult *= result;
                }

            }
            else if (counter >= 10 && counter % 2 == 1)
            {
                BigInteger result = 1;
                if (num == "0")
                {
                    result = 1;
                    secondResult *= result;
                }
                else if (num != "END")
                {
                    num = num.Replace('-', '1');
                    num = num.Replace('0', '1');
                    for (int i = 0; i < num.Length; i++)
                    {
                        result *= (num[i] - '0');
                    }
                    secondResult *= result;
                }
            }
            counter++;
        }
        Console.WriteLine(firstResult);
        if (counter >= 10)
        {
            Console.WriteLine(secondResult);
        }
    }

}
