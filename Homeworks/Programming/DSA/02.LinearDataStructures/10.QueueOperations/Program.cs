/*We are given numbers N and M and the following operations:

N = N+1
N = N+2
N = N*2

Write a program that finds the shortest sequence of operations from the list above that starts from N and finishes in M.

Hint: use a queue.
Example: N = 5, M = 16
Sequence: 5 → 7 → 8 → 16*/

namespace _10.QueueOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int n = 5;
            int m = 16;

            var queue = new Queue<int>();

            // This way the algorithm is successfully implemented, but with a queue, list, stack - it's all the same;
            // There must be a strictly queue kind of way, which evades me very successfully now :)
            // If you have any idea, please put it in the comment.
            while (n <= m)
            {
                queue.Enqueue(m);

                if (m / 2 >= n)
                {
                    if (m % 2 == 0)
                    {
                        m /= 2;
                    }
                    else
                    {
                        m--;
                    }
                }
                else
                {
                    if (m - 2 >= n)
                    {
                        m -= 2;
                    }
                    else
                    {
                        m--;
                    }
                }
            }

            Console.WriteLine(string.Join(" -> ", queue.Reverse()));
        }
    }
}
