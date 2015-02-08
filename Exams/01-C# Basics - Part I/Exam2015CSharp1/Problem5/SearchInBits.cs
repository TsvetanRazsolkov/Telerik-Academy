using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Numerics;
using System.Threading;
using System.Globalization;

class SearchInBits
{
    static void Main()
    {
        int s = int.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());
        int count = 0;
        int num = 0;
        int firstBit = s & 1;
        int secondBit = (s & 2) >> 1;
        int thirdBit = (s & 4) >> 2;
        int fourthBit = (s & 8) >> 3;
        int mask = 0;
        for (int i = 0; i < n; i++)
        {
            num = int.Parse(Console.ReadLine());
            for (int j = 0; j < 27; j++)
            {
                mask = 1 << j;
                if (((num & (1 << j)) >> j) == firstBit &&
                    ((num & (1 << j + 1)) >> j + 1) == secondBit &&
                    ((num & (1 << j + 2)) >> j + 2) == thirdBit &&
                    ((num & (1 << j + 3)) >> j + 3) == fourthBit)
                {
                    count++;
                }
            }
        }
        Console.WriteLine(count);
    }
}
