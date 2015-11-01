/*Implement the data structure linked list.

Define a class ListItem<T> that has two fields: value (of type T) and NextItem (of type ListItem<T>).
Define additionally a class LinkedList<T> with a single field FirstElement (of type ListItem<T>).*/
namespace _11.LinkedListImplementation
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var rubish = new LinkedList<int>();

            Console.WriteLine("Adding two elements");
            rubish.AddLast(6);
            rubish.AddLast(12);
            Console.WriteLine("First element -> {0}", rubish.FirstItem);

            Console.WriteLine("Adding first element:");
            rubish.AddFirst(3);
            Console.WriteLine("First element -> {0}", rubish.FirstItem);

            rubish.AddLast(25);
            Console.WriteLine("Removing the first element:");
            rubish.RemoveFirst();
            Console.WriteLine("First element -> {0}", rubish.FirstItem);

            Console.WriteLine("Count of elements -> {0}", rubish.Count);
            Console.WriteLine("Contains 12 -> {0}", rubish.Contains(12));
            Console.WriteLine("Removing 12");
            rubish.Remove(12);
            Console.WriteLine("Count of elements -> {0}", rubish.Count);
            Console.WriteLine("Contains 12 -> {0}", rubish.Contains(12));

            rubish.AddLast(15);
            rubish.AddLast(50);
            Console.WriteLine("Added 2 elements and then removing 6 which is first element:");
            rubish.Remove(6);
            Console.WriteLine("Count of elements -> {0}", rubish.Count);
            Console.WriteLine("First element -> {0}", rubish.FirstItem);
        }
    }
}
