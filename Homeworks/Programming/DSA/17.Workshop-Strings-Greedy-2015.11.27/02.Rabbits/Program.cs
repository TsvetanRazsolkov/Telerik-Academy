using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Rabbits
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var rabbitAnswers = input.Split(' ').Select(int.Parse).ToList();
            rabbitAnswers.RemoveAt(rabbitAnswers.Count - 1);

            int minRabbotsCount = FindMinRabbitsCount(rabbitAnswers);
            Console.WriteLine(minRabbotsCount);
        }

        private static int FindMinRabbitsCount(List<int> rabbitAnswers)
        {
            // Key - group size
            // Value - count of rabbits in a group
            var groups = new Dictionary<int, int>();
            foreach (var answer in rabbitAnswers)
            {
                if (!groups.ContainsKey(answer + 1))
                {
                    groups.Add(answer + 1, 0);

                }

                groups[answer + 1]++;
            }

            var rabbits = 0;

            foreach (var group in groups)
            {
                int groupSize = group.Key;
                int rabbitsInGroupCount = group.Value;

                if (rabbitsInGroupCount <= groupSize)
                {
                    rabbits += groupSize;
                }
                else
                {
                    int minNumberOfGroupsToContainTheRabbits = (int)Math.Ceiling(rabbitsInGroupCount / (double)groupSize);
                    rabbits += minNumberOfGroupsToContainTheRabbits * groupSize;
                }
            }

            return rabbits;
        }
    }
}
