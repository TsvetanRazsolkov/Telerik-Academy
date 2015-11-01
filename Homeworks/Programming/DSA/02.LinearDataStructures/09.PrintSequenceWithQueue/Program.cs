
/*We are given the following sequence:
S1 = N;
S2 = S1 + 1;
S3 = 2*S1 + 1;
S4 = S1 + 2;
S5 = S2 + 1;
S6 = 2*S2 + 1;
S7 = S2 + 2;
...
Using the Queue<T> class write a program to print its first 50 members for given N.
Example: N=2 → 2, 3, 5, 4, 4, 7, 5, 6, 11, 7, 5, 9, 6, ...*/
namespace _09.PrintSequenceWithQueue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            //n = 2;
            int membersCount = 50;

            var sequence = new Queue<int>();

            sequence.Enqueue(n);

            for (int i = 0; i < membersCount; i++)
            {
                int currentNumber = sequence.Dequeue();
                Console.Write("{0}, ", currentNumber);

                // The following condition is set so that we generate exactly 50 numbers in the queue;
                // Without this condition we will fill 3 times the desired members count in the queue;
                // Which isn't really a problem with 50 members;
                if (i < membersCount/3 + 1)
                {
                    sequence.Enqueue(currentNumber + 1);
                    sequence.Enqueue(2 * currentNumber + 1);
                    sequence.Enqueue(currentNumber + 2);
                }                
            }
        }
    }
}
