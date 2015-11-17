using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Songs
{
    class Program
    {
        static long inversions;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            inversions = 0;

            int[] array1 = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            int[] array2 = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

            var rename = new int[n + 1];
            for (int i = 0; i < n; i++)
            {
                rename[array1[i]] = i;
            }

            for (int i = 0; i < n; i++)
            {
                array2[i] = rename[array2[i]];
            }

            Console.WriteLine(CountInversions(array2, 0, n));

        }

        private static long CountInversions(int[] array, int left, int right)
        {
            if (left + 1 == right)
            {
                return 0;
            }

            int middle = (left + right) / 2;

            long inversions = CountInversions(array, left, middle) + CountInversions(array, middle, right);

            int[] sorted = new int[right - left];
            int i = left;
            int j = middle;
            int k = 0;

            while (i < middle && j < right)
            {
                if (array[i] < array[j]) // check
                {
                    sorted[k] = array[i];
                    i++;
                    k++;
                }
                else
                {
                    inversions += middle - i;
                    sorted[k] = array[j];
                    j++;
                    k++;
                }
            }

            while (i < middle)
            {
                sorted[k] = array[i];
                i++;
                k++;
            }

            while (j < right)
            {
                sorted[k] = array[j];
                j++;
                k++;
            }

            for ( k = 0; k < sorted.Length; k++)
            {
                array[left + k] = sorted[k];
            }

            return inversions;
        }
    }
}
