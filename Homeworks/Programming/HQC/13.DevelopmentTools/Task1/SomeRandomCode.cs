namespace Task1
{
    using System;

    /// <summary>
    /// Static class from somewhere else that does not belong here
    /// </summary>
    public static class RotatingMatrixWalkSolver
    {
        private static readonly int[] RowMovements = { 1, 1, 1, 0, -1, -1, -1, 0 };
        private static readonly int[] ColMovements = { 1, 0, -1, -1, -1, 0, 1, 1 };

        private static int directionIndex;

        /// <summary>
        /// Fills square matrix with increasing values in a circular fashion
        /// </summary>
        /// <param name="matrix">
        /// Empty matrix to fill
        /// </param>
        public static void SolveRotatingMatrixWalk(int[,] matrix)
        {
            directionIndex = 0;

            FillMatrix(matrix);
        }

        private static void FillMatrix(int[,] matrix)
        {
            int nextRowToUse = 0;
            int nextColToUse = 0;
            int nextValueToFill = 1;

            while (nextValueToFill <= matrix.GetLength(0) * matrix.GetLength(1))
            {
                matrix[nextRowToUse, nextColToUse] = nextValueToFill;

                if (NextDirectionIsAvailable(matrix, nextRowToUse, nextColToUse))
                {
                    nextRowToUse += RowMovements[directionIndex];
                    nextColToUse += ColMovements[directionIndex];
                }
                else
                {
                    FindFirstEmptyCell(matrix, out nextRowToUse, out nextColToUse);
                }

                nextValueToFill++;
            }
        }

        private static void FindFirstEmptyCell(int[,] matrix, out int rowToUse, out int colToUse)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 0)
                    {
                        rowToUse = row;
                        colToUse = col;
                        directionIndex = 0;
                        return;
                    }
                }
            }

            rowToUse = 0;
            colToUse = 0;
        }

        private static void ChangeDirection()
        {
            directionIndex++;
            if (directionIndex == RowMovements.Length)
            {
                directionIndex = 0;
            }
        }

        private static bool IsStuck(int[,] matrix, int row, int col)
        {
            bool rowIndexIsInsideTheArray = (row + RowMovements[directionIndex] >= 0) && (row + RowMovements[directionIndex] < matrix.GetLength(0));
            bool colIndexIsInsideTheArray = (col + ColMovements[directionIndex] >= 0) && (col + ColMovements[directionIndex] < matrix.GetLength(1));
            if (rowIndexIsInsideTheArray && colIndexIsInsideTheArray)
            {
                bool nextCellToFillIsOccupied = matrix[row + RowMovements[directionIndex], col + ColMovements[directionIndex]] != 0;

                return nextCellToFillIsOccupied;
            }
            else
            {
                return true;
            }
        }

        private static bool NextDirectionIsAvailable(int[,] matrix, int row, int col)
        {
            int directionChangeTimes = 0;
            while (IsStuck(matrix, row, col))
            {
                ChangeDirection();
                directionChangeTimes++;

                if (directionChangeTimes == RowMovements.Length)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
