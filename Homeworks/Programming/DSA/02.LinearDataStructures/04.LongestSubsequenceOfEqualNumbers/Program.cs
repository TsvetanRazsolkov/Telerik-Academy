/*Write a method that finds the longest subsequence of equal numbers in given List and returns the result as new List<int>.
Write a program to test whether the method works correctly.*/
namespace _04.LongestSubsequenceOfEqualNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var integers = new List<int> { 1, 2, 2, 3, 4, 4, 4, 4, 5, 5, 5, 6, 6 };
            var longestSequence = FindLongestSubsequenceOfEqualIntegers(integers);
            Console.WriteLine("Longest sequence of equal numbers in {0}: \r\n{1}", string.Join(", ", integers), string.Join(", ", longestSequence));

            var testSequence = new List<int>{1, 2, 3, 4, 5, 6};
            longestSequence = FindLongestSubsequenceOfEqualIntegers(testSequence);
            Console.WriteLine("Longest sequence of equal numbers in {0}: \r\n{1}", string.Join(", ", testSequence), string.Join(", ", longestSequence));

            var anotherTestSequence = new List<int> { 1, 1, 2, 3, 4, 5, 6 };
            longestSequence = FindLongestSubsequenceOfEqualIntegers(anotherTestSequence);
            Console.WriteLine("Longest sequence of equal numbers in {0}: \r\n{1}", string.Join(", ", anotherTestSequence), string.Join(", ", longestSequence));

            var lastTestSequence = new List<int> { 1, 2, 3, 4, 5, 6, 6 };
            longestSequence = FindLongestSubsequenceOfEqualIntegers(lastTestSequence);
            Console.WriteLine("Longest sequence of equal numbers in {0}: \r\n{1}", string.Join(", ", lastTestSequence), string.Join(", ", longestSequence));
        }

        private static List<int> FindLongestSubsequenceOfEqualIntegers(List<int> integers)
        {
            var longestSequence = new List<int>();

            int bestStartIndex = 0;
            int currentStartIndex = 0;
            int bestLength = 1;
            int currentLength = 1;

            for (int i = 1; i < integers.Count; i++)
            {
                if (integers[i] == integers[i - 1])
                {
                    currentLength++;
                }
                else
                {
                    if (currentLength > bestLength)
                    {
                        bestLength = currentLength;
                        bestStartIndex = currentStartIndex;
                    }

                    currentLength = 1;
                    currentStartIndex = i;
                }
            }

            if (currentLength > bestLength)
            {
                bestLength = currentLength;
                bestStartIndex = currentStartIndex;
            }

            for (int i = bestStartIndex; i < bestStartIndex + bestLength; i++)
            {
                longestSequence.Add(integers[i]);
            }

            return longestSequence;
        }
    }
}
