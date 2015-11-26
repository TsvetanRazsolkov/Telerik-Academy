namespace _02.Salaries
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static long salariesSum = 0;
        static List<int>[] employeesTree;
        static long[] salaries;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            employeesTree = new List<int>[n];
            salaries = new long[n];

            for (int i = 0; i < n; i++)
            {
                employeesTree[i] = new List<int>();

                string inputLine = Console.ReadLine();
                for (int j = 0; j < inputLine.Length; j++)
                {
                    // The employee j is subordinate to employee i
                    if (inputLine[j] == 'Y')
                    {
                        employeesTree[i].Add(j);
                    }
                }

                // If employee has no subordinates
                if (employeesTree[i].Count == 0)
                {
                    salaries[i] = 1;
                    salariesSum += salaries[i];
                }
            }

            for (int i = 0; i < n; i++)
            {
                if (salaries[i] == 0)
                {
                    salaries[i] = CalculateSalary(i);
                }
            }

            Console.WriteLine(salariesSum);
        }

        private static long CalculateSalary(int employee)
        {
            long empSalary = 0;

            foreach (var subordinate in employeesTree[employee])
            {
                if (salaries[subordinate] == 0)
                {
                    salaries[subordinate] = CalculateSalary(subordinate);
                }

                empSalary += salaries[subordinate];
            }

            salaries[employee] = empSalary;
            salariesSum += empSalary;

            return empSalary;
        }
    }
}
