using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Numerics;
using System.Threading;
using System.Globalization;

class PersianRugs
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int d = int.Parse(Console.ReadLine());
        int sharpCount = 0;
        int dotCount = 2 * n - 2 * d - 3;;

        if (d <= 2 * n - 4)
        {
            
            while (dotCount > 0)
            {
                Console.WriteLine(new string('#', sharpCount) + '\\' + new string(' ', d) + '\\' + new string('.', dotCount) + '/' + new string(' ', d) + '/' + new string('#', sharpCount));
                sharpCount++;
                dotCount -= 2;
            }
            int spaceCount = 2 * n - 1 - 2 * sharpCount;
            int control = spaceCount;
            while (sharpCount <= (2 * n - 2) / 2)
            {
                Console.WriteLine(new string('#', sharpCount) + '\\' + new string(' ', spaceCount) + '/' + new string('#', sharpCount));
                spaceCount -= 2;
                sharpCount++;
            }
            Console.WriteLine(new string('#', sharpCount) + 'X' + new string('#', sharpCount));
            spaceCount += 2;            
            sharpCount--;
            if (d == 0)
            {
                while (sharpCount > (2*n - 3 - control)/2)
                {
                    Console.WriteLine(new string('#', sharpCount) + '/' + new string(' ', spaceCount) + '\\' + new string('#', sharpCount));
                    spaceCount += 2;
                    sharpCount--;
                }
            }
            else if (d > 0)
            {
                while (spaceCount <= control)
                {
                    Console.WriteLine(new string('#', sharpCount) + '/' + new string(' ', spaceCount) + '\\' + new string('#', sharpCount));
                    spaceCount += 2;
                    sharpCount--;
                }
            }
            
            dotCount += 2;
            while (sharpCount >= 0)
            {
                Console.WriteLine(new string('#', sharpCount) + '/' + new string(' ', d) + '/' + new string('.', dotCount) + '\\' + new string(' ', d) + '\\' + new string('#', sharpCount));
                sharpCount--;
                dotCount += 2;
            }


        }
        else
        {
            dotCount = 2 * n - 1;
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(new string('#', sharpCount) + '\\' + new string(' ', dotCount) + '/' + new string('#', sharpCount));
                sharpCount++;
                dotCount -= 2;
            }
            Console.WriteLine(new string('#', sharpCount) + 'X' + new string('#', sharpCount));
            dotCount += 2;
            sharpCount--;
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(new string('#', sharpCount) + '/' + new string(' ', dotCount) + '\\' + new string('#', sharpCount));
                sharpCount--;
                dotCount += 2;
            }
        }
    }
}

