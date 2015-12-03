using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _05.Businessmen
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            // http://stackoverflow.com/questions/18076480/puzzle-n-persons-sitting-on-round-table-no-of-ways-of-handshakes-without-cross
            //BigInteger answer = Catalan(n / 2); // /2, because two people shake hands and n is even number

            BigInteger answer = SolveDynamicProgramming(n);

            Console.WriteLine(answer);
        }

        private static BigInteger SolveDynamicProgramming(int n)
        {
            BigInteger[] dp = new BigInteger[71];
            dp[0] = 1;

            for (int allPeople = 2; allPeople <= n; allPeople+=2)
            {
                for (int oneSidePeople = allPeople - 2; oneSidePeople >= 0; oneSidePeople-=2)
                {
                    dp[allPeople] +=
                        dp[oneSidePeople]
                        * dp[allPeople - oneSidePeople - 2];
                }
            }

            BigInteger result = dp[n];

            return result;
        }

        private static BigInteger Catalan(int number)
        {
            BigInteger result = (Factorial(number * 2) / Factorial(number + 1)) / Factorial(number);

            return result;
        }

        private static BigInteger Factorial(int num)
        {
            BigInteger result = 1;
            for (int i = 1; i <= num; i++)
            {
                result *= i;
            }

            return result;
        }
    }
}
