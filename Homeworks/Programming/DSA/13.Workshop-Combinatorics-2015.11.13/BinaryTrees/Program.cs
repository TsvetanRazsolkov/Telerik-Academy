using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTrees
{
    // Check with catalan numbers(maybe just for the count of trees)
    class Program
    {
        static long[] memo;

        static void Main(string[] args)
        {
            memo = new long[32];
            int[] occurences = new int[26];
            string input = Console.ReadLine();
            for (int i = 0; i < input.Length; i++)
            {
                occurences[input[i] - 'A']++;
            }

            int n = input.Length;

            var factorials = new long[n + 1];
            factorials[0] = 1;
            for (int i = 0; i < n; i++)
            {
                factorials[i + 1] = factorials[i] * (i + 1);
            }
            // all permutations of the balls
            BigInteger permutations = Factorial(n);
            foreach (var item in occurences)
            {
                // to find the variations we divide on factorial of occurences
                permutations /= factorials[item];
            }

            permutations *= Trees(n);
            Console.WriteLine(permutations);
        }

        static BigInteger Factorial(int num)
        {
            BigInteger result = 1;
            for (int i = 1; i <= num; i++)
            {
                result *= i;
            }

            return result;
        }

        static long Trees(int n)
        {
            if (n == 0)
            {
                return 1;
            }

            if (memo[n] > 0)
            {
                return memo[n];
            }

            long result = 0;
            for (int i = 0; i < n; i++)
            {
                // Left we can put Trees(i), on the right -  Trees(n - 1 - i)
                result += Trees(i) * Trees(n - 1 - i);
            }

            memo[n] = result;
            return result;
        }
    }
}
