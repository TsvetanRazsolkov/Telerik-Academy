using System;

/*  We are given a matrix of strings of size N x M. Sequences in the matrix we define as sets of several neighbour
elements located on the same line, column or diagonal.
Write a program that finds the longest sequence of equal strings in the matrix.
Example:
matrix	                 result		     matrix	       result
ha	fifi	ho	hi     ha, ha, ha         s qq	s	   s, s, s 
fo	  ha	hi	xx                       pp pp	s
xxx	  ho	ha	xx	                     pp qq	s      */

class SequenceNMatrix
{
    static void Main()
    {
        //string[,] matrix = 
        //{
        //    {"ha", "fifi", "ho", "hi"},
        //    {"fo", "ha", "hi", "xx"},
        //    {"xxx", "ho", "ha", "xx"}
        //};
        string[,] matrix = ReadMatrixFromConsole();

        string direction = string.Empty;
        int maxSequence = 0;
        int bestRowIndex = 0;
        int bestColIndex = 0;
        int currentRowIndex = 0;
        int currentColIndex = 0;
        int currentSequence;
        // Checking for horizontal sequences:
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            currentSequence = 1;
            currentRowIndex = row;
            currentColIndex = 0;
            for (int col = 1; col < matrix.GetLength(1); col++)
            {
                if (matrix[row, col] == matrix[row, col - 1])
                {
                    currentSequence++;
                }
                else
                {
                    if (currentSequence > maxSequence)
                    {
                        maxSequence = currentSequence;
                        bestRowIndex = currentRowIndex;
                        bestColIndex = currentColIndex;
                        direction = "horizontal";
                    }
                    currentColIndex++;
                }
                if (col == matrix.GetLength(1) - 1)
                {
                    if (currentSequence > maxSequence)
                    {
                        maxSequence = currentSequence;
                        bestRowIndex = currentRowIndex;
                        bestColIndex = currentColIndex;
                        direction = "horizontal";
                    }
                }                
            }            
        }
        // Checking for vertical sequences:
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            currentSequence = 1;
            currentRowIndex = 0;
            currentColIndex = col;
            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                if (matrix[row, col] == matrix[row - 1, col])
                {
                    currentSequence++;
                }
                else
                {
                    if (currentSequence > maxSequence)
                    {
                        maxSequence = currentSequence;
                        bestRowIndex = currentRowIndex;
                        bestColIndex = currentColIndex;
                        direction = "vertical";
                    }
                    currentRowIndex++;
                }
                if (row == matrix.GetLength(0) - 1)
                {
                    if (currentSequence > maxSequence)
                    {
                        maxSequence = currentSequence;
                        bestRowIndex = currentRowIndex;
                        bestColIndex = currentColIndex;
                        direction = "vertical";
                    }
                }
            }            
        }
        // Checking for left diagonal sequences:
        for (int row = 1; row < matrix.GetLength(0); row++)
        {
            currentSequence = 1;
            currentRowIndex = row - 1;
            currentColIndex = 0;
            int index = row;
            for (int col = 1; col < matrix.GetLength(1); col++)
            {
                if (index < matrix.GetLength(0))
                {
                    if (matrix[index, col] == matrix[index - 1, col - 1])
                    {
                        currentSequence++;
                        index++;
                    }
                    else
                    {
                        if (currentSequence > maxSequence)
                        {
                            maxSequence = currentSequence;
                            bestRowIndex = currentRowIndex;
                            bestColIndex = currentColIndex;
                            direction = "left diagonal";
                        }
                        currentColIndex++;
                    }
                }
            }
            
        }
        // Checking for right diagonal sequences:
        for (int row = 1; row < matrix.GetLength(0); row++)
        {
            currentSequence = 1;
            currentRowIndex = row - 1;
            currentColIndex = matrix.GetLength(1) - 1;
            int index = row;
            for (int col = matrix.GetLength(1) - 2; col >= 0; col--)
            {
                if (index < matrix.GetLength(0))
                {
                    if (matrix[index, col] == matrix[index - 1, col + 1])
                    {
                        currentSequence++;
                        index++;
                    }
                    else
                    {
                        if (currentSequence > maxSequence)
                        {
                            maxSequence = currentSequence;
                            bestRowIndex = currentRowIndex;
                            bestColIndex = currentColIndex;
                            direction = "right diagonal";
                        }
                        currentColIndex--;
                    }
                }
            }            
        }
        if (direction == "horizontal")
        {
            for (int col = bestColIndex; col < bestColIndex + maxSequence; col++)
            {
                Console.Write(matrix[bestRowIndex, col] + " ");
            }
            Console.WriteLine();
        }
        else if (direction == "vertical")
        {
            for (int row = bestRowIndex; row < bestRowIndex + maxSequence; row++)
            {
                Console.Write(matrix[row, bestColIndex] + " ");
            }
            Console.WriteLine();
        }
        else if (direction == "left diagonal")
        {
            for (int i = 0; i < maxSequence; i++)
            {

                Console.Write(matrix[bestRowIndex + i, bestColIndex + i] + " ");
            }
            Console.WriteLine();
        }
        else if (direction == "right diagonal")
        {
            for (int i = 0; i < maxSequence; i++)
            {

                Console.Write(matrix[bestRowIndex + i, bestColIndex - i] + " ");
            }
            Console.WriteLine();
        }
    }
    private static string[,] ReadMatrixFromConsole()
    {
        Console.Write("Enter number of rows: ");
        int rows = int.Parse(Console.ReadLine());
        Console.Write("Enter number of columns: ");
        int cols = int.Parse(Console.ReadLine());

        string[,] matrix = new string[rows, cols];
        for (int row = 0; row < rows; row++)
        {
            Console.Write("Enter the elements on row {0} separated by a SPACE: ", row);
            string matrixRow = Console.ReadLine();
            string[] elementsOnRow = matrixRow.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int col = 0; col < elementsOnRow.Length; col++)
            {
                if (col >= matrix.GetLength(1))
                {
                    break;
                }
                matrix[row, col] = elementsOnRow[col];
            }
        }
        return matrix;
    }
}