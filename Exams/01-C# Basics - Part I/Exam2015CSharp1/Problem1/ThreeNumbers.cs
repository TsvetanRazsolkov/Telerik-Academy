using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Numerics;
using System.Threading;
using System.Globalization;

class ThreeNumbers
{
    static void Main()
    {        

        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int c = int.Parse(Console.ReadLine());

        double mean = (a + b + c) / 3.0;

        int biggest = a;
        if (b >= a)
        {
            biggest = b;
            if (c >= b)
            {
                biggest = c;
            }
        }
        else if (b < a)
        {
            if (c >= a)
            {
                biggest = c;
            }
        }
        Console.WriteLine(biggest);

        int smallest = a;
        if (b <= a)
        {
            smallest = b;
            if (c <= b)
            {
                smallest = c;
            }
        }
        else if (b > a)
        {
            if (c <= a)
            {
                smallest = c;
            }
        }
        Console.WriteLine(smallest);
        Console.WriteLine("{0:F2}", mean);
    }
}
