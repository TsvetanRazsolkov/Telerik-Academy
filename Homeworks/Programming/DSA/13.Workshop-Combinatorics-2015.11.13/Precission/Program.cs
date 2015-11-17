using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Precission
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxDenominator = int.Parse(Console.ReadLine());
            var fraction = Console.ReadLine().Split('.')[1];

            int bestNom = 0;
            int bestDenom = 1;
            int bestPrecission = 0;
            for (int denom = 1; denom <= maxDenominator; denom++)
            {
                int left = 0;
                int right = denom;

                while (left < right)
                {
                    int middle = (left + right) / 2;
                    if (Compare(fraction, middle, denom))
                    {
                        right = middle;
                    }
                    else
                    {
                        left = middle + 1;
                    }
                }


                int current = Divide(fraction, left - 1, denom);
                if (current > bestPrecission)
                {
                    bestNom = left - 1;
                    bestDenom = denom;
                    bestPrecission = current;
                }

                current = Divide(fraction, left, denom);
                if (current > bestPrecission)
                {
                    bestNom = left;
                    bestDenom = denom;
                    bestPrecission =current;
                }

            }

            Console.WriteLine("{0}/{1}\r\n{2}", bestNom, bestDenom, bestPrecission + 1);
        }

        static int Divide(string fraction, int a, int b)
        {
            a *= 10;
            int i;
            for (i = 0; i < fraction.Length; i++)
            {
                int digit = a / b;
                if (digit != fraction[i] - '0')
                {
                    break;
                }

                a = a % b * 10;
            }

            return i;
        }

        static bool Compare(string fraction, int a, int b)
        {
            a *= 10;
            int i;
            for (i = 0; i < fraction.Length; i++)
            {
                int digit = a / b;
                if (digit < fraction[i] - '0')
                {
                    return false; // means smaller
                }
                else if(digit > fraction[i] - '0')
                {
                    return true; // means bigger
                }

                a = a % b * 10;
            }

            return true;
        }
    }
}
