namespace RefactorLoop
{
    using System;

    public class RefactorLoop
    {
        public static void Main()
        {
            // Loop to refactor:
            // int i = 0;
            // for (i = 0; i < 100; )
            // {
            //     if (i % 10 == 0)
            //     {
            //         Console.WriteLine(array[i]);
            //         if (array[i] == expectedValue)
            //         {
            //             i = 666;
            //         }
            //         i++;
            //     }
            //     else
            //     {
            //         Console.WriteLine(array[i]);
            //         i++;
            //     }
            // }
            // // More code here
            // if (i == 666)
            // {
            //     Console.WriteLine("Value Found");
            // }
            int[] numbers = new int[100];
            int expectedValue = 10;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (i % 10 == 0)
                {
                    Console.WriteLine(numbers[i]);
                    if (numbers[i] == expectedValue)
                    {
                        Console.WriteLine("Value Found");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine(numbers[i]);
                }
            }
        }
    }
}
