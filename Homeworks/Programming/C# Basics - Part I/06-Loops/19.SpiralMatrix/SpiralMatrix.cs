using System;

class SpiralMatrix
{
    static void Main()
    {
        /* Write a program that reads from the console a positive integer number n (1 = n = 20) and prints a matrix holding the numbers from 1 to n*n in the form of square spiral like in the examples below.
          Examples:

        n = 2   matrix      n = 3   matrix      n = 4   matrix
        1 2                 1 2 3               1  2  3  4
        4 3                 8 9 4               12 13 14 5
                            7 6 5               11 16 15 6
                                                10 9  8  7       */

        Console.Write("Enter positive integer n in the range[1...20] and press ENTER: ");
        int n = int.Parse(Console.ReadLine());
        
        if (n == 1)
        {
            Console.WriteLine(1);
        }
        else if (n <= 0 || n > 20)
        {
            Console.WriteLine("Invalid input.");
        }
        else
        {            
            Console.WindowHeight = 45;
            Console.WindowWidth = 100;

            int[,] matrix = new int[n, n];
            int currentRow = 0;
            int currentColumn = 0;
            string direction = "right";
            // Fill values in the matrix:
            int number = 1;
            while (matrix[currentRow, currentColumn] == 0)
            {
                while (direction == "right" && (currentColumn < matrix.GetLength(1) - currentRow) && number <= n * n)
                {
                    matrix[currentRow, currentColumn] = number;
                    currentColumn++;
                    number++;
                }
                direction = "down";
                currentColumn--;
                currentRow++;
                while (direction == "down" && currentRow <= currentColumn && number <= n * n)
                {
                    matrix[currentRow, currentColumn] = number;
                    currentRow++;
                    number++;
                }
                direction = "left";
                currentColumn--;
                currentRow--;
                while (direction == "left" && (currentColumn >= 0 + (matrix.GetLength(0) - currentRow - 1)) && number <= n * n)
                {
                    matrix[currentRow, currentColumn] = number;
                    currentColumn--;
                    number++;
                }
                direction = "up";
                currentRow--;
                currentColumn++;
                while (direction == "up" && (currentRow >= currentColumn + 1) && number <= n * n)
                {
                    matrix[currentRow, currentColumn] = number;
                    currentRow--;
                    number++;
                }
                direction = "right";
                currentRow++;
                currentColumn++;
            }
            // Print the matrix:
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0}", matrix[i, j].ToString().PadRight(5, ' '));
                }
                Console.WriteLine();
            }
        }
    }
}