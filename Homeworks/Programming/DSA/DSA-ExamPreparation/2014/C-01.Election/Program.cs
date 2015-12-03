using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace C_01.Election
{
    class Program
    {
        static BigInteger countOfPossibleSums = 0;
        static int targetSum;

        static void Main(string[] args)
        {
            // Classical subset sum problem, we need to find all possible sums of subsets
            // and count each one that is greater or equal to the one we search for;
            // At 01:35:00 from http://telerikacademy.com/Courses/LectureResources/Video/4595/%D0%92%D0%B8%D0%B4%D0%B5%D0%BE-5-%D1%81%D0%B5%D0%BF%D1%82%D0%B5%D0%BC%D0%B2%D1%80%D0%B8-2014-%D0%94%D0%BE%D0%BD%D1%87%D0%BE-%D0%9C%D0%B8%D0%BD%D0%BA%D0%BE%D0%B2 
            targetSum = int.Parse(Console.ReadLine());

            int n = int.Parse(Console.ReadLine());

            int[] numbers = new int[n];
            for (int i = 0; i < n; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            CalculateSums(numbers);

            Console.WriteLine(countOfPossibleSums);
        }

        private static void CalculateSums(int[] numbers)
        {
            int maxSum = numbers.Sum();

            BigInteger[] possibleSums = new BigInteger[maxSum + 1];
            possibleSums[0] = 1;

            foreach (var number in numbers)
            {
                for (int i = maxSum; i >= 0; i--)
                {
                    if (possibleSums[i] > 0)
                    {
                        possibleSums[i + number] += possibleSums[i];
                    }
                }
            }

            for (int i = targetSum; i <= maxSum; i++)
            {
                countOfPossibleSums += possibleSums[i];
            }
        }
    }
}
