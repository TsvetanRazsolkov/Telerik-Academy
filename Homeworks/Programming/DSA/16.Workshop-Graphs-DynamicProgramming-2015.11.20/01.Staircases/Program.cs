namespace Staircases
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static long[,] count;

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            count = new long[n + 1, n + 1];

            //dynamic
            count[0, 0] = 1;
            count[1, 1] = 1;
            count[2, 2] = 1;

            for (int i = 3; i <= n; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    for (int k = 0; k < j && i - j >= k; k++)
                    {
                        count[i, j] += count[i - j, k];
                    }
                }
            }

            long result = 0;
            for (int i = 1; i < n; i++)
            {
                result += count[n, i];
            }

            //long result = 0;
            //for(int i = 1; i < n; i++)
            //{
            //    result += StairsRecursion(n,i);
            //}

            Console.WriteLine(result);

        }

        static long StairsRecursion(int n, int k)
        {
            if (n < 3 && n == k)
            {
                return 1;
            }

            if (count[n, k] > 0)
            {
                return count[n, k];
            }

            for (int i = 0; i < k; i++)
            {
                if (n - k <= i)
                {
                    continue;
                }

                count[n, k] += StairsRecursion(n - k, i);
            }

            return count[n, k];
        }
    }
}
