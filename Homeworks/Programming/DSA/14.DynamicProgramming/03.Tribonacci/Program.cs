using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Tribonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ')
                                            .Select(x => int.Parse(x))
                                            .ToArray();

            int n = input[3];
            long t1 = input[0];
            long t2 = input[1];
            long t3 = input[2];
            long current = 0;

            if (n <= 3)
            {
                Console.WriteLine(input[n - 1]);
            }
            else
            {
                for (int i = 3; i < n; i++)
                {
                    current = t1 + t2 + t3;
                    t1 = t2;
                    t2 = t3;
                    t3 = current;
                }

                Console.WriteLine(current);
            }
        }
    }
}
