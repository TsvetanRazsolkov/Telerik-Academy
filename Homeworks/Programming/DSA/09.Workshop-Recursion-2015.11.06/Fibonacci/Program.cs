using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
{  
    class Program
    {
        private const int Mod = 1000000007;

        static int[] memo;

        static void Main(string[] args)
        {
            // For bgcoder - put the matriz class in this namespace

            //Console.WriteLine(PowModNumbers(2, 10));
            long n = long.Parse(Console.ReadLine());
            //memo = new int[n + 1];

            //Console.WriteLine(RecursiveMemoizationFibonacci(n));

            Console.WriteLine(FastFibonacci(n));
        }

        static long FastFibonacci(long n)
        {
            var matrix = new Matrix(1, 1, 1, 0);
            return PowModMatrices(matrix, n).Table[0, 1];
        }

        static Matrix PowModMatrices(Matrix matrix, long power)
        {
            // bottom
            if (power == 1)
            {
                return matrix;
            }

            // case - odd
            if (power % 2 == 1)
            {
                return new Matrix(PowModMatrices(matrix, power - 1), matrix);
            }

            // case - even
            matrix = PowModMatrices(matrix, power / 2);

            return new Matrix(matrix, matrix);
        }

        static long PowModNumbers(long number, long power)
        {
            // bottom
            if (power == 0)
            {
                return 1;
            }

            // case - odd
            if (power % 2 == 1)
            {
                return PowModNumbers(number, power - 1) * number % Mod;
            }

            // case - even
            number = PowModNumbers(number, power / 2);

            return number * number % Mod;
        }

        static int RecursiveMemoizationFibonacci(int n)
        {
            if (n == 1 || n == 2)
            {
                return 1;
            }

            if (memo[n] != 0)
            {
                return memo[n];
            }

            int number = RecursiveMemoizationFibonacci(n - 1) + RecursiveMemoizationFibonacci(n - 2);
            number %= Mod;

            memo[n] = number;

            return number;
        }
    }

    class Matrix
    {
        private const int Mod = 1000000007;

        public Matrix(Matrix first, Matrix second)
        {
            this.Table = new long[2, 2];
            this.Table[0, 0] = first.Table[0, 0] * second.Table[0, 0] + first.Table[0, 1] * second.Table[1, 0];
            this.Table[0, 1] = first.Table[0, 0] * second.Table[0, 1] + first.Table[0, 1] * second.Table[1, 1];
            this.Table[1, 0] = first.Table[1, 0] * second.Table[0, 0] + first.Table[1, 1] * second.Table[1, 0];
            this.Table[1, 1] = first.Table[1, 0] * second.Table[0, 1] + first.Table[1, 1] * second.Table[1, 1];

            this.Table[0, 0] %= Mod;
            this.Table[0, 1] %= Mod;
            this.Table[1, 0] %= Mod;
            this.Table[1, 1] %= Mod;
        }

        public Matrix(long a, long b, long c, long d)
        {
            this.Table = new long[2, 2];
            this.Table[0, 0] = a;
            this.Table[0, 1] = b;
            this.Table[1, 0] = c;
            this.Table[1, 1] = d;
        }

        public long[,] Table { get; set; }
    }
}
