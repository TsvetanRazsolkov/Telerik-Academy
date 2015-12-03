using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepeatingPattern
{
    class Program
    {
        static void Main(string[] args)
        {

            //Naive();

            KMP();
        }

        private static void KMP()
        {
            string input = Console.ReadLine();
            string textToSearchIn = input + input;

            int[] fl = new int[input.Length + 1];
            fl[0] = -1;
            fl[1] = 0;

            for (int i = 1; i < input.Length; i++)
            {
                int j = fl[i];
                while (j >= 0 && input[i] != input[j])
                {
                    j = fl[j];
                }

                fl[i + 1] = j + 1;
            }

            int matched = 0;
            for (int i = 1; i < textToSearchIn.Length; i++)
            {
                while (matched >= 0 && textToSearchIn[i] != textToSearchIn[matched])
                {
                    matched = fl[matched];
                }

                matched++;
                if (matched == input.Length)
                {
                    Console.WriteLine(input.Substring(0, i - (input.Length - 1)));
                }
            }
        }

        private static void Naive()
        {
            string input = Console.ReadLine();

            for (int i = 1; i <= input.Length; i++)
            {
                if (input.Length % i != 0)
                {
                    continue;
                }

                string pattern = input.Substring(0, i);

                bool isNotSolution = false;
                for (int j = i; j + i <= input.Length; j += i)
                {
                    if (pattern != input.Substring(j, i))
                    {
                        isNotSolution = true;
                        break;
                    }
                }

                if (!isNotSolution)
                {
                    Console.WriteLine(pattern);
                    break;
                }
            }
        }
    }
}
