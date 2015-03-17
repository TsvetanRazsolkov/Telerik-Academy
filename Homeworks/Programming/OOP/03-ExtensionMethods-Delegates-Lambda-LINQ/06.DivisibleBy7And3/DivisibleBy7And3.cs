namespace DivisibleBy7And3
{
    using System;
    using System.Linq;

    class DivisibleBy7And3
    {
        static void Main()
        {
            int[] array = new int[100];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i;
            }
            Console.WriteLine("Array: ");
            Console.WriteLine(string.Join(", ", array));

            Console.WriteLine("Numbers in array divisible by 7 and 3");  

            // Using lambda and LINQ extension methods:                      
            var result = array.Where(x => x % 7 == 0 && x % 3 == 0);
            Console.Write("With ext methods and lambda expressions: ");
            Console.WriteLine(string.Join(", ", result));

            // Using LINQ query:
            var queryResult = from number in array
                              where number % 7 == 0 && number % 3 == 0
                              select number;
            Console.Write("With LINQ query: ");
            Console.WriteLine(string.Join(", ", queryResult));
        }
    }
}
