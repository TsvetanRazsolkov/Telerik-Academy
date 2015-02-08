using System;

class OddAndEvenProduct
{
    static void Main()
    {
        // You are given n integers (given in a single line, separated by a space). Write a program that checks whether the product of the odd elements is equal to the product of the even elements. Elements are counted from 1 to n, so the first element is odd, the second is even, etc.
        Console.Write("Enter integer n and press ENTER: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter {0} integers separated by a space and then press ENTER: ", n);
        string input = Console.ReadLine();
        string[] numbersAsStrings = input.Split(' ');
        int[] numbers = new int[n];
        for (int i = 0; i < numbersAsStrings.Length; i++)
        {
            numbers[i] = int.Parse(numbersAsStrings[i]);
        }
        int oddProduct = 1;
        int evenProduct = 1;
        for (int j = 0; j < numbers.Length; j++)
        {
            if (j % 2 != 0)
            {
                evenProduct *= numbers[j];
            }
            else
            {
                oddProduct *= numbers[j];
            }
        }
        if (oddProduct == evenProduct)
        {
            Console.WriteLine("Yes.  Product = {0}", oddProduct);
        }
        else
        {
            Console.WriteLine("No.\nOdd Product = {0}\nEven product = {1}", oddProduct, evenProduct);
        }
    }
}