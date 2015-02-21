using System;

// Write a program that generates and prints to the console 10 random values in the range [100, 200].

class RandomNumbers
{
    static void Main()
    {
        Random randomGenerator = new Random();
        int randomNumber;
        for (int i = 0; i < 10; i++)
        {
            randomNumber = randomGenerator.Next(100, 201);
            Console.WriteLine(randomNumber);
        }
    }
}