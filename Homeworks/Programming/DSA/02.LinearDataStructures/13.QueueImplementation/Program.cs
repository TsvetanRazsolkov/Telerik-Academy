/*Implement the ADT queue as dynamic linked list.

Use generics (LinkedQueue<T>) to allow storing different data types in the queue.*/
namespace _13.QueueImplementation
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var ququ = new Queue<string>();

            Console.WriteLine("Adding 4 elements in the queue:");
            ququ.Enqueue("Sasho");
            ququ.Enqueue("Mustafa");
            ququ.Enqueue("Asen");
            ququ.Enqueue("I Az");
            Console.WriteLine("Count -> {0}", ququ.Count);
            Console.WriteLine("Peek -> {0}", ququ.Peek());
            Console.WriteLine("Dequeue -> {0}", ququ.Dequeue());
            Console.WriteLine("Count -> {0}", ququ.Count);
            Console.WriteLine("Peek -> {0}", ququ.Peek());
            Console.WriteLine("Contains Sasho -> {0}", ququ.Contains("Sasho"));
            Console.WriteLine("Contains Mustafa -> {0}", ququ.Contains("Mustafa"));
        }
    }
}
