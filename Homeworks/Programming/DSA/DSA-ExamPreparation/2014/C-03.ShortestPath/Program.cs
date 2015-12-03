using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_03.ShortestPath
{
    class Program
    {
        static int counter = 0;
        static char[] letters = new char[] { 'R', 'L', 'S' };
        static char[] arr;
        static char[] result;
        static SortedSet<string> kartof = new SortedSet<string>();

        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '*' )
                {
                    counter++;
                }
            }

            arr = new char[counter];

            result = input.ToCharArray();

            Console.WriteLine(Math.Pow(3, counter));

            GenerateVariations(0);

            foreach (var obelka in kartof)
            {
                Console.WriteLine(obelka);
            }
        }

        static void GenerateVariations(int index)
        {
            if (index >= counter)
            {
                var newArr = new char[result.Length];
                Array.Copy(result, newArr, result.Length);

                int previousInd = 0;
                for (int i = 0; i < result.Length; i++)
                {
                    if (newArr[i] == '*')
                    {
                        newArr[i] = arr[previousInd];
                        previousInd++;
                    }
                }

                kartof.Add(string.Join("", newArr));
                return;
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    arr[index] = letters[i];
                    GenerateVariations(index + 1);
                    arr[index] = '*';
                }
            }
        }
    }
}
