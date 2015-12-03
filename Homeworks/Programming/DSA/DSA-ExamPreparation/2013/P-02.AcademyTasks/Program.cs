using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_02.AcademyTasks
{
    class Program
    {        
        static void Main(string[] args)
        {
            int[] tasks = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int variety = int.Parse(Console.ReadLine());

            int minPath = tasks.Length;

            for (int i = 0; i < tasks.Length; i++)
            {
                for (int j = i + 1; j < tasks.Length; j++)
                {
                    if (Math.Abs(tasks[j] - tasks[i]) >= variety)
                    {
                        // (i - 0 + 1)/2 - solved tasks from 0 to i, excluding i
                        // (j - i + 1) / 2 + 1 - solved tasks from i to j, including both
                        int currentPath = (i - 0 + 1) / 2 + (j - i + 1) / 2 + 1;
                        minPath = Math.Min(minPath, currentPath);
                    }
                }
            }

            Console.WriteLine(minPath);
        }        
    }
}
