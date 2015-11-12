using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Dividers
{
    class Program
    {
        static Dictionary<int, int> dividersDictionary = new Dictionary<int, int>();

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] input = new int[n];
            for (int i = 0; i < n; i++)
            {
                input[i] = int.Parse(Console.ReadLine());
            }
            Array.Sort(input);
            Solve(input, 0, input.Length);

            int answer = int.MaxValue;
            int min = int.MaxValue;
            foreach (var item in dividersDictionary)
            {
                if (item.Value < min)
                {
                    min = item.Value;
                    answer = item.Key;
                }
                if (item.Value == min)
                {
                    answer = Math.Min(answer, item.Key);
                }
            }

            Console.WriteLine(answer);
        }

        static void Solve(int[] arr, int start, int n)
        {
            int number = GetNumber(arr);
            int dividers = GetDividers(number);
            dividersDictionary.Add(number, dividers);

            // Permutations with repetitions
            for (int left = n - 2; left >= start; left--)
            {
                for (int right = left + 1; right < n; right++)
                    if (arr[left] != arr[right])
                    {
                        Swap(ref arr[left], ref arr[right]);
                        Solve(arr, left + 1, n);
                    }
                var firstElement = arr[left];
                for (int i = left; i < n - 1; i++)
                    arr[i] = arr[i + 1];
                arr[n - 1] = firstElement;
            }
        }

        private static int GetDividers(int number)
        {
            int result = 0;
            for (int i = 1; i <= number; i++)
            {
                if (number % i == 0)
                {
                    result++;
                }
            }

            return result;
        }

        private static int GetNumber(int[] arr)
        {
            string numAsString = string.Empty;
            foreach (var digit in arr)
            {
                numAsString += digit;
            }

            return int.Parse(numAsString);
        }

        private static void Swap(ref int p1, ref int p2)
        {
            int temp = p1;
            p1 = p2;
            p2 = temp;
        }
    }
}
