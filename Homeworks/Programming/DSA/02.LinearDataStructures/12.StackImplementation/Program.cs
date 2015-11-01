/*Implement the ADT stack as auto-resizable array.

Resize the capacity on demand (when no space is available to add / insert a new element).*/
namespace _12.StackImplementation
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var beefSteak = new Stack<int>();

            Console.WriteLine("Adding 2 elements");
            beefSteak.Push(10);
            beefSteak.Push(20);

            Console.WriteLine("Count -> {0}", beefSteak.Count);
            Console.WriteLine("Peek -> {0}", beefSteak.Peek());

            Console.WriteLine("Pop -> {0}", beefSteak.Pop());
            Console.WriteLine("Count -> {0}", beefSteak.Count);
            Console.WriteLine("Pop -> {0}", beefSteak.Pop());
            Console.WriteLine("Count -> {0}", beefSteak.Count);

            Console.WriteLine("Pushing 6 elements:");
            beefSteak.Push(11);
            beefSteak.Push(20);
            beefSteak.Push(11);
            beefSteak.Push(20);
            beefSteak.Push(11);
            beefSteak.Push(20);
            Console.WriteLine("Count -> {0}", beefSteak.Count);

            Console.WriteLine("Contains 11 -> {0}", beefSteak.Contains(11));

            Console.WriteLine("Clearing:");
            beefSteak.Clear();
            Console.WriteLine("Count -> {0}", beefSteak.Count);
            Console.WriteLine("Contains 11 -> {0}", beefSteak.Contains(11));
        }
    }
}
