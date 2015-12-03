using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Towns
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] sequence = new int[n];

            int[] left = new int[n];
            int[] right = new int[n];

            for (int i = 0; i < n; i++)
            {
                sequence[i] = int.Parse(Console.ReadLine().Split(' ')[0]);
            }

            // searching for longest increasing subsequence left-to-right
            for (var i = 0; i < n; i++)
            {
                left[i] = 1;
                for (var j = 0; j <= i - 1; j++)
                {
                    if (sequence[j] < sequence[i])
                    {
                        if (left[j] + 1 > left[i])
                        {
                            left[i] = left[j] + 1;
                        }
                    }
                }
            }

            // searching for longest increasing subsequence right-to-left
            for (var i = n - 1; i >= 0; i--)
            {
                right[i] = 1;
                for (var j = n - 1; j >= i + 1; j--)
                {
                    if (sequence[j] < sequence[i])
                    {
                        if (right[j] + 1 > right[i])
                        {
                            right[i] = right[j] + 1;
                        }
                    }
                }
            }

            // combining the two longest subsequences to find the maximal path
            int max = 0;
            for (int i = 0; i < n; i++)
            {
                max = Math.Max(max, left[i] + right[i]);
            }

            Console.WriteLine(max - 1);
        }
    }
}
