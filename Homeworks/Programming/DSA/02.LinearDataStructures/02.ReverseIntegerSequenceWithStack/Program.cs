/*Write a program that reads N integers from the console and reverses them using a stack.
Use the Stack<int> class.*/
namespace _02.ReverseIntegerSequenceWithStack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var integersStack = new Stack<int>();

            Console.WriteLine("Enter several integers separated by a coma and then press Enter: ");

            string input = Console.ReadLine();
            string[] numbers = input.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine("Initial sequence:");
            foreach (var numberString in numbers)
            {
                Console.Write(numberString + ' ');

                int number = int.Parse(numberString);
                integersStack.Push(number);
            }
            Console.WriteLine();
            Console.WriteLine("Reversed collection:");

            while (integersStack.Count > 0)
            {
                int num = integersStack.Pop();
                Console.Write(num);
                Console.Write(" ");
            }

            Console.WriteLine();
        }
    }
}
