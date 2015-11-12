using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _01.BinaryPasswords
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int asteriksCount = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '*')
                {
                    asteriksCount++;
                }
            }

            Console.WriteLine(PowFunction(2, asteriksCount));
        }

        private static BigInteger PowFunction(int baseNum, int power)
        {
            BigInteger result = 1;

            for (int i = 0; i < power; i++)
            {
                result *= baseNum;
            }

            return result;
        }
    }
}
