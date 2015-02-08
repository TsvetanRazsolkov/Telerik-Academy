using System;
using System.Collections.Generic;
using System.Text;

class NumbersInIntervalDividableByGivenNumber
{
    static void Main()
    {
        // Write a program that reads two positive integer numbers and prints how many numbers p exist between them such that the reminder of the division by 5 is 0.

        Console.Write("Enter positive integer number and press ENTER:");
        int n;
        bool isIntN = int.TryParse(Console.ReadLine(), out n);
        Console.Write("Enter another positive integer number and press ENTER:");
        int m;
        bool isIntM = int.TryParse(Console.ReadLine(), out m);
        int count = 0;
        if (isIntM && isIntN)
        {
            StringBuilder comments = new StringBuilder(); 
            for (int i = n; i <= m; i++)
            {
                if (i % 5 == 0)
                {
                    count++;
                    comments.Append(i.ToString());
                    comments.Append(", ");
                }
            }
            comments.Remove(comments.Length - 2, 2);
            Console.WriteLine("p[{0},{1}] = {2}", n, m, count);
            Console.Write("Comments: {0}", comments);
            Console.WriteLine();           
        }
        else
        {
            Console.WriteLine("Invalid input");
        }
    }
}