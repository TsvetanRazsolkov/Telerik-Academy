using System;

// Write a program that reads a rectangular matrix of size N x M and finds in it the square 3 x 3 
// that has maximal sum of its elements.

class MaximalSum
{
    static void Main()
    {
        int[,] matrix = 
        {
            {1, 12, 5, 4, 9, 6},
            {4, 13, 5, 20, 2, 6},
            {1, 4, 14, 2, 11, 12},
            {1, 4, 8, 1, 10, 2},
        };
        //int[,] matrix = ReadMatrixFromConsole();
        int platformSize = 3;//int.Parse(Console.ReadLine());

        int maxSum = int.MinValue;
        int maxSumRow = 0;
        int maxSumCol = 0;
        for (int row = 0; row < (matrix.GetLength(0) - (platformSize - 1)); row++)
        {
            for (int col = 0; col < (matrix.GetLength(1) - (platformSize - 1)); col++)
            {
                int currentSum = 0;
                for (int i = 0; i < platformSize; i++)
                {
                    for (int j = 0; j < platformSize; j++)
                    {
                        currentSum += matrix[row + i, col + j];
                    }
                }
                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                    maxSumRow = row;
                    maxSumCol = col;
                }
            }
        }

        Console.WriteLine("The initial matrix:");
        PrintMatrix(matrix, 0, 0, matrix.GetLength(0), matrix.GetLength(1));
        Console.WriteLine("Maximal sum of square {0}x{0} = {1}", platformSize, maxSum);
        PrintMatrix(matrix, maxSumRow, maxSumCol, maxSumRow + platformSize, maxSumCol + platformSize);
    }

    private static int[,] ReadMatrixFromConsole()
    {
        Console.Write("Enter number of rows: ");
        int rows = int.Parse(Console.ReadLine());
        Console.Write("Enter number of columns: ");
        int cols = int.Parse(Console.ReadLine());

        int[,] matrix = new int[rows, cols];
        for (int row = 0; row < rows; row++)
        {
            Console.Write("Enter the elements on row {0} separated by a SPACE: ", row);
            string matrixRow = Console.ReadLine();
            string[] numbersAsString = matrixRow.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int col = 0; col < numbersAsString.Length; col++)
            {
                if (col >= matrix.GetLength(1))
                {
                    break;
                }
                matrix[row, col] = int.Parse(numbersAsString[col]);
            }
        }
        return matrix;
    }

    static void PrintMatrix(int[,] matrix, int row, int col, int maxRow, int maxCol)
    {
        for (int i = row; i < maxRow; i++)
        {
            for (int j = col; j < maxCol; j++)
            {
                Console.Write("{0, 3}", matrix[i, j]);
            }
            Console.WriteLine();
        }
    }
}
