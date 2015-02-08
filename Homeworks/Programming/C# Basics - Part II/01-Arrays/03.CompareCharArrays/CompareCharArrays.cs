using System;

// Write a program that compares two char arrays lexicographically (letter by letter).

class CompareCharArrays
{
    static void Main()
    {
        Console.Write("Enter the first char array as string and press ENTER: ");
        char[] firstCharArray = Console.ReadLine().ToLower().ToCharArray();
        Console.Write("Enter the second char array as string and press ENTER: ");
        char[] secondCharArray = Console.ReadLine().ToLower().ToCharArray();
        int shorterArrayLength = 0;
        bool areEqual = true;

        if (firstCharArray.Length > secondCharArray.Length)
        {
            shorterArrayLength = secondCharArray.Length;
        }
        else 
        {
            shorterArrayLength = firstCharArray.Length;
        }
        for (int i = 0; i < shorterArrayLength; i++)
        {
            if (firstCharArray[i] < secondCharArray[i])
            {
                areEqual = false;
                Console.WriteLine("The first array comes before the second lexicographically.");
            }
            else if (firstCharArray[i] > secondCharArray[i])
            {
                areEqual = false;
                Console.WriteLine("The second array comes before the first lexicographically.");
            }
        }
        if (areEqual && firstCharArray.Length == secondCharArray.Length)
        {
            Console.WriteLine("The two arrays are equal.");
        }
        else if (areEqual && firstCharArray.Length > secondCharArray.Length)
        {
            Console.WriteLine("The second array comes before the first lexicographically.");
        }
        else if (areEqual && firstCharArray.Length < secondCharArray.Length)
        {
            Console.WriteLine("The first array comes before the second lexicographically.");
        }
    }
}
