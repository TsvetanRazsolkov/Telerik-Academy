using System;

/* Write a program that fills and prints a matrix of size (n, n) as shown below:
Example for n=4:

a)            b)	      c)	        d)*
1  5  9	13    1	8 9	 16   7 11 14 16    1 12 11 10
2  6 10 14    2	7 10 15   4 8  12 15    2 13 16  9
3  7 11	15    3	6 11 14   2 5  9  13    3 14 15  8
4  8 12	16    4	5 12 13   1 3  6  10    4  5  6  7  */

class FillTheMatrix
{
    static void Main()
    {
        int n = 4;//int.Parse(Console.ReadLine());
        int[,] matrix = new int[n, n];
        string separator = new string('-', 40);

        // a):
        for (int aRow = 0; aRow < n; aRow++)
        {
            int aElement = aRow + 1;
            for (int aCol = 0; aCol < n; aCol++)
            {
                matrix[aRow, aCol] = aElement;
                aElement += 4;
            }
        }

        Console.WriteLine("case a)");
        Console.WriteLine(separator);
        PrintMatrix(matrix);
        // b):
        int bElement = 1;
        for (int bCol = 0; bCol < n; bCol++)
        {
            if (bCol % 2 == 0)
            {
                for (int bRow = 0; bRow < n; bRow++)
                {
                    matrix[bRow, bCol] = bElement;
                    bElement++;

                }
            }
            else
            {
                for (int bRow = n - 1; bRow >= 0; bRow--)
                {
                    matrix[bRow, bCol] = bElement;
                    bElement++;
                }
            }
        }
        Console.WriteLine("case b)");
        Console.WriteLine(separator);
        PrintMatrix(matrix);
        // c):
        int cElement = 1;
        int j = 0;
        for (int i = n - 1; i >= 0; i--)
        {
            for (int k = i; k < n; k++)
            {
                if (k != i)
                {
                    matrix[k, j + (k - i)] = cElement;
                    cElement++;
                }
                else
                {
                    matrix[k, j] = cElement;
                    cElement++;
                }
            }
        }
        j = n - 1;
        cElement = n * n;
        for (int i = 0; i < n - 1; i++)
        {
            for (int k = i; k >= 0; k--)
            {
                if (k != i)
                {
                    matrix[k, j + (k - i)] = cElement;
                    cElement--;
                }
                else
                {
                    matrix[k, j] = cElement;
                    cElement--;
                }
            }
        }
        Console.WriteLine("case c)");
        Console.WriteLine(separator);
        PrintMatrix(matrix);
        // d):
        int currentRow;
        int currentColumn;
        for (currentRow = 0; currentRow < matrix.GetLength(0); currentRow++)
        {
            for (currentColumn = 0; currentColumn < matrix.GetLength(1); currentColumn++)
            {
                matrix[currentRow, currentColumn] = 0;
            }
        }
        currentRow = 0;
        currentColumn = 0;
        string direction = "down";
        int dElement = 1;
        while (matrix[currentRow, currentColumn] == 0)
        {
            while (direction == "down" && (currentRow < matrix.GetLength(0) - currentColumn) && dElement <= n * n)
            {
                matrix[currentRow, currentColumn] = dElement;
                currentRow++;
                dElement++;
            }
            direction = "right";
            currentRow--;
            currentColumn++;
            while (direction == "right" && currentColumn <= currentRow && dElement <= n * n)
            {
                matrix[currentRow, currentColumn] = dElement;
                currentColumn++;
                dElement++;
            }
            direction = "up";
            currentRow--;
            currentColumn--;
            while (direction == "up" && (currentRow >= matrix.GetLength(0) - 1 - currentColumn) && dElement <= n * n)
            {
                matrix[currentRow, currentColumn] = dElement;
                currentRow--;
                dElement++;
            }
            direction = "left";
            currentColumn--;
            currentRow++;
            while (direction == "left" && (currentColumn >= currentRow + 1) && dElement <= n * n)
            {
                matrix[currentRow, currentColumn] = dElement;
                currentColumn--;
                dElement++;
            }
            direction = "down";
            currentColumn++;
            currentRow++;
        }
        Console.WriteLine("case d)");
        Console.WriteLine(separator);
        PrintMatrix(matrix);
    }

    private static void PrintMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write("{0,3}", matrix[i, j]);
            }
            Console.WriteLine();
        }
    }
}