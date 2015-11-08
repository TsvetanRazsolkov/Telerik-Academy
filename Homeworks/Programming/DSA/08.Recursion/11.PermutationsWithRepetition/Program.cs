
/*Write a program to generate all permutations with repetitionsof given multi-set.
Example: the multi-set {1, 3, 5, 5} has the following 12 unique permutations:
  { 1, 3, 5, 5 }  { 1, 5, 3, 5 }
  { 1, 5, 5, 3 }  { 3, 1, 5, 5 }
  { 3, 5, 1, 5 }  { 3, 5, 5, 1 }
  { 5, 1, 3, 5 }  { 5, 1, 5, 3 }
  { 5, 3, 1, 5 }  { 5, 3, 5, 1 }
  { 5, 5, 1, 3 }  { 5, 5, 3, 1 }
Ensure your program efficiently avoids duplicated permutations.
Test it with { 1, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 }.
Hint: Permutations with repetition*/
namespace _11.PermutationsWithRepetition
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        public static HashSet<string> answer = new HashSet<string>();

        public static int[] multiSet = new int[] { 1, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 };

        public static void Main()
        {
            var sw = new Stopwatch();
            sw.Start();
            Permute(0);
            Console.WriteLine("Time: {0}", sw.Elapsed);

            Console.WriteLine(string.Join(Environment.NewLine, answer));
        }

        public static void Permute(int startingPosition = 0)
        {
            answer.Add(string.Join(", ", multiSet));
            if (startingPosition < multiSet.Length)
            {
                for (int i = multiSet.Length - 2; i >= startingPosition; i--)
                {
                    for (int j = i + 1; j < multiSet.Length; j++)
                    {
                        if (multiSet[i] != multiSet[j])
                        {
                            Swap(i, j, multiSet);
                            Permute(i + 1);
                        }
                    }

                    int temp = multiSet[i];
                    for (int k = i; k < multiSet.Length - 1; k++)
                    {
                        multiSet[k] = multiSet[k + 1];
                    }

                    multiSet[multiSet.Length - 1] = temp;
                }
            }
        }

        private static void Swap(int start, int end, int[] array)
        {
            var temp = array[end];
            array[end] = array[start];
            array[start] = temp;
        }
    }
}
