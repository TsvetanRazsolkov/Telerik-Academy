using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guitar
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] volumeChanges = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                        .Select(int.Parse)
                                        .ToArray();

            int start = int.Parse(Console.ReadLine());
            int max = int.Parse(Console.ReadLine());

            var dp = new bool[volumeChanges.Length + 1, max + 1];

            /* This is the test case with input 
             * 5, 3, 7
             * 5
             * 10
             
                   |   0   |   1   |   2   |   3   |   4   |   5   |   6   |   7   |   8   |   9   |   10  |
             start | false | false | false | false | false |  TRUE | false | false | false | false | false |
             5     |  TRUE | false | false | false | false | false | false | false | false | false |  TRUE |
             3     | false | false | false |  TRUE | false | false | false |  TRUE | false | false | false | 
             7     |  TRUE | false | false | false | false | false | false | false | false | false |  TRUE | 
             
             */

            // on the first line there will be only the start value of the volume
            dp[0, start] = true;
            for (int i = 1; i < dp.GetLength(0); i++)
            {
                for (int j = 0; j < dp.GetLength(1); j++)
                {
                    if (dp[i - 1, j])
                    {
                        var volumeChange = volumeChanges[i - 1];

                        if (j - volumeChange >= 0)
                        {
                            dp[i, j - volumeChange] = true;
                        }

                        if (j + volumeChange <= max)
                        {
                            dp[i, j + volumeChange] = true;
                        }
                    }
                }
            }

            for (int i = dp.GetLength(1) - 1; i >= 0; i--)
            {
                if (dp[dp.GetLength(0) - 1, i])
                {
                    Console.WriteLine(i);
                    return;
                }
            }

            Console.WriteLine(-1);
        }
    }
}
