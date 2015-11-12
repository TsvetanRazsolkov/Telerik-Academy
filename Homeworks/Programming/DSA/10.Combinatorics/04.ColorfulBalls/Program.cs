using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _04.ColorfulBalls
{
    class Program
    {
        static HashSet<string> permutations = new HashSet<string>();

        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var balls = input.ToCharArray();

            // This gives 30 points and time limits on the rest of the tests;
            //Solve(balls, 0);

            BigInteger result = DoItTheFastWayWithAFormula(balls, balls.Length);

            //Console.WriteLine(permutations.Count);
            Console.WriteLine(result);
        }

        private static BigInteger DoItTheFastWayWithAFormula(char[] balls, int p)
        {
            BigInteger result = CalculateFactorial(p);
            var occurences = new Dictionary<char, int>();
            for (int i = 0; i < balls.Length; i++)
            {
                if (!occurences.ContainsKey(balls[i]))
                {
                    occurences.Add(balls[i], 0);
                }

                occurences[balls[i]]++;
            }

            foreach (var item in occurences)
            {
                result /= CalculateFactorial(item.Value);
            }

            return result;
        }

        private static BigInteger CalculateFactorial(int p)
        {
            BigInteger result = 1;
            for (int i = 1; i <= p; i++)
            {
                result *= i;
            }

            return result;
        }

        static void Solve(char[] arr, int k)
        {
            // Generate all permutations and add them to a hashset to save the unique ones. Slow.
            if (k >= arr.Length)
            {
                permutations.Add(string.Join(", ", arr));
            }
            else
            {
                Solve(arr, k + 1);
                for (int i = k + 1; i < arr.Length; i++)
                {
                    Swap(ref arr[k], ref arr[i]);
                    Solve(arr, k + 1);
                    Swap(ref arr[k], ref arr[i]);
                }
            }
        }

        private static void Swap(ref char p1, ref char p2)
        {
            char temp = p1;
            p1 = p2;
            p2 = temp;
        }
    }
}
