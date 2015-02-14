using System;

/* Write a program that finds the largest area of equal neighbour elements in a rectangular matrix and prints its size.
Example:

matrix	                     result
1	3	2	2	2	4        13
3	3	3	2	4	4
4	3	1	2	3	3
4	3	1	3	3	1
4	3	3	3	1	1  
Hint: you can use the algorithm Depth-first search or Breadth-first search. */

class LargestAreaInMatrix
{
    static int?[,] matrix = 
        {
            {1, 3, 2, 2, 2, 4},
            {3, 3, 3, 2, 4, 4},
            {4, 3, 1, 2, 3, 3},
            {4, 3, 1, 3, 3, 1},
            {4, 3, 3, 3, 1, 1}
        };
    //static int[,] matrix = ReadMatrixFromConsole();
    static int currentArea = 0;
    static int largestArea = 0;
    static int? element = 0;

    static void Main()
    {        
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                element = matrix[row, col];
                currentArea = 0;
                FindArea(row, col);
                if (currentArea > largestArea)
                {
                    largestArea = currentArea;
                }
            }
        }

        Console.WriteLine("The size of the largest area of equal elements is {0}.",
            largestArea);
    }

    private static void FindArea(int row, int col)
    {
        if (row < 0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix.GetLength(1)
            || matrix[row,col] == null)
        {
            return;
        }
        else
        {
            if (matrix[row, col] == element)
            {
                matrix[row, col] = null;
                currentArea++;
                // Call FindArea() for all neighboring cells:
                FindArea(row, col + 1);
                FindArea(row - 1, col);
                FindArea(row + 1, col);
                FindArea(row, col - 1);
            }
        }
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
}