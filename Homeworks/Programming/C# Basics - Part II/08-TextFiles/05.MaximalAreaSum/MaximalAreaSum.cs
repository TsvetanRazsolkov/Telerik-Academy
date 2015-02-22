using System;
using System.IO;

/*Write a program that reads a text file containing a square matrix of numbers.
Find an area of size 2 x 2 in the matrix, with a maximal sum of its elements.
The first line in the input file contains the size of matrix N.
Each of the next N lines contain N numbers separated by space.
The output should be a single number in a separate text file.
Example:
input	   output
4 
2 3 3 4    
0 2 3 4    17
3 7 1 2 
4 3 3 2	           */

class MaximalAreaSum
{
    const string inputFilePath = "..\\..\\input.txt";
    const string outputFilePath = "..\\..\\output.txt";
    const int platformSize = 2;

    static void Main()
    {
        int[,] squareMatrix = ReadMatrixFromFile();

        long maxSum = CalculateMaxSum(squareMatrix);

        StreamWriter writer = new StreamWriter(outputFilePath);
        using (writer)
        {
            writer.WriteLine(maxSum);
        }
    }

    static long CalculateMaxSum(int[,] squareMatrix)
    {
        long maxSum = long.MinValue;

        for (int row = 0; row < (squareMatrix.GetLength(0) - (platformSize - 1)); row++)
        {
            for (int col = 0; col < (squareMatrix.GetLength(1) - (platformSize - 1)); col++)
            {
                long currentSum = 0;
                for (int i = 0; i < platformSize; i++)
                {
                    for (int j = 0; j < platformSize; j++)
                    {
                        currentSum += squareMatrix[row + i, col + j];
                    }
                }
                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                }
            }
        }
        return maxSum;
    }

    static int[,] ReadMatrixFromFile()
    {
        StreamReader reader = new StreamReader(inputFilePath);
        int[,] squareMatrix;
        int squareMatrixSize = 0;
        using (reader)
        {
            squareMatrixSize = int.Parse(reader.ReadLine());
            squareMatrix = new int[squareMatrixSize, squareMatrixSize];

            while (!reader.EndOfStream)
            {
                for (int row = 0; row < squareMatrixSize; row++)
                {
                    string matrixRow = reader.ReadLine();
                    string[] rowElements = matrixRow.Split(new char[] { ' ' },
                                       StringSplitOptions.RemoveEmptyEntries);
                    for (int col = 0; col < squareMatrixSize; col++)
                    {
                        if (col >= squareMatrix.GetLength(1))
                        {
                            break;
                        }
                        squareMatrix[row, col] = int.Parse(rowElements[col]);
                    }
                }
            }
        }
        return squareMatrix;
    }
}
