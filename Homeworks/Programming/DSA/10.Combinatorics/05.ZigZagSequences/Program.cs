using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.ZigZagSequences
{
    class Program
    {
        static bool[] used;
        static int[] arr;
        static int n;
        static int k;
        static int result = 0;

        static void Main(string[] args)
        {
            var inputNumbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x)).ToArray();

            n = inputNumbers[0];
            k = inputNumbers[1];
            arr = new int[k];
            used = new bool[n];

            PutBigger(0, -1);

            Console.WriteLine(result);
        }

        static void PutBigger(int index, int currentValue)
        {
            if (index >= k)
            {
                result++;
                return;
            }
            if (currentValue == n - 1)
            {
                return;
            }
            else
            {
                for (int i = currentValue + 1; i < n; i++)
                    if (!used[i])
                    {
                        used[i] = true;
                        arr[index] = i;
                        PutSmaller(index + 1, i);
                        used[i] = false;
                    }
            }
        }

        private static void PutSmaller(int index, int currentValue)
        {
            if (index >= k)
            {
                result++;
                return;
            }
            if (currentValue == 0)
            {
                return;
            }
            else
            {
                for (int i = currentValue - 1; i >= 0; i--)
                    if (!used[i])
                    {
                        used[i] = true;
                        arr[index] = i;
                        PutBigger(index + 1, i);
                        used[i] = false;
                    }
            }
        }

        //// Solution for 80 points - this one is mine, the above is the author's solution written just for exercise:
        //static void Main(string[] args)
        //{
        //    var inputNumbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
        //        .Select(x => int.Parse(x)).ToArray();

        //    n = inputNumbers[0];
        //    k = inputNumbers[1];
        //    arr = new int[k];
        //    used = new bool[n];

        //    Solve(0);

        //    Console.WriteLine(result);
        //}

        //static void Solve(int index)
        //{
        //    if (index >= k)
        //    {
        //        if (CheckIfSequenceIsZigZaggy(arr))
        //        {
        //            result++;
        //        }
        //    }
        //    else
        //    {
        //        for (int i = 0; i < n; i++)
        //            if (!used[i])
        //            {
        //                used[i] = true;
        //                arr[index] = i;
        //                Solve(index + 1);
        //                used[i] = false;
        //            }
        //    }
        //}

        //private static bool CheckIfSequenceIsZigZaggy(int[] arr)
        //{
        //    if (arr.Length == 1)
        //    {
        //        return true;
        //    }

        //    if (arr.Length == 2 && arr[0] > arr[1])
        //    {
        //        return true;
        //    }

        //    else
        //    {
        //        for (int i = 0; i < arr.Length; i += 2)
        //        {
        //            if (i == 0)
        //            {
        //                if (arr[i] <= arr[i + 1])
        //                {
        //                    return false;                            
        //                }
        //            }
        //            else if (i == arr.Length - 1)
        //            {
        //                if (arr[i] <= arr[i - 1])
        //                {
        //                return false;                            
        //                }
        //            }
        //            else
        //            {
        //                if ((arr[i] <= arr[i - 1] || arr[i] <= arr[i + 1]))
        //                {
        //                    return false;
        //                }
        //            }
        //        }
        //    }

        //    return true;
        //}
    }
}
