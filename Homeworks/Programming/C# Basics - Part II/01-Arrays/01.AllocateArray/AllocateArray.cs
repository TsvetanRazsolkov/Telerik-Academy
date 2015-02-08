using System;

class AllocateArray
{
    static void Main()
    {
       // Write a program that allocates array of 20 integers and initializes each element by its index multiplied by 5. Print the obtained array on the console.

        int[] arrayOfIntegers = new int[20];

        for (int i = 0; i < arrayOfIntegers.Length; i++)
        {
            arrayOfIntegers[i] = i * 5;
        }
        foreach (int number in arrayOfIntegers)
        {
            Console.Write("{0, -3}",number);
        }
        Console.WriteLine();
    }
}
