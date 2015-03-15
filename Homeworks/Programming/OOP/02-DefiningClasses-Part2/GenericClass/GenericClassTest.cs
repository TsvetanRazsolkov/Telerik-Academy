namespace GenericClass
{
    using System;

    class GenericClassTest
    {
        static void Main()
        {
            GenericList<int> list = new GenericList<int>(8);
            //GenericList<char> list = new GenericList<char>(8);

            Console.WriteLine("Initial list capacity: {0}\n", list.Capacity);

            for (int i = 0; i < 10; i++)
            {
                list.Add(i);
                //list.Add((char)('A' + i));                  
            }
            Console.WriteLine("List with 10 added elements and new capacity = {0}:", list.Capacity);
            Console.WriteLine(list + Environment.NewLine);
                        
            list.InsertAt(4, 20);
            //list.InsertAt(4, 'Z');
            Console.WriteLine("List with an element insserted at position [4]:");
            Console.WriteLine(list + Environment.NewLine);

            list.RemoveAt(0);
            Console.WriteLine("List with an element removed from position [0]:");
            Console.WriteLine(list + Environment.NewLine);

            int max = list.Max();
            int min = list.Min();
            //char max = list.Max();
            //char min = list.Min();
            int indexOfMax = list.IndexOf(max);
            int indexOfMin = list.IndexOf(min);
            Console.WriteLine("Index of max = {0} is: {1}", max, indexOfMax);
            Console.WriteLine("Index of min = {0} is: {1}", min, indexOfMin);
            Console.WriteLine();

            list.Clear();
            Console.WriteLine("Cleared list:");
            Console.WriteLine(list);
        }
    }
}
