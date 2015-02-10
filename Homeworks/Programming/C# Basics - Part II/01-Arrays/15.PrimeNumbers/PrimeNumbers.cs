using System;
using System.Collections.Generic;

// Write a program that finds all prime numbers in the range [1...10 000 000].
// Use the Sieve of Eratosthenes algorithm.

class PrimeNumbers
{
    static void Main()
    {
        // Try with smaller value of n, because printing several million numbers on
        // the console is very slow. 
        int n = 10000000; 
        bool[] numbers = new bool[n+1];
        for (int i = 2; i < numbers.Length; i++)
        {
            numbers[i] = true;
        }
       
        for (int i = 2; i <= (int)Math.Sqrt(n); i++)
        {
            if (numbers[i] == true)
            {
                
                for (int j = i*i; j <= n; j += i)
                {
                    numbers[j] = false;                    
                }
            }
        }

        Console.Write("1, ");
        List<int> primes = new List<int>();        
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] == true)
            {
                primes.Add(i);
            }
        }
        Console.Write(string.Join(", ", primes));
        Console.WriteLine();
    }
}