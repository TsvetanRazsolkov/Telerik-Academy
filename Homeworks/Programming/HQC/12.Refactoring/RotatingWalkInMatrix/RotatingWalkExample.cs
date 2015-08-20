namespace RotatingWalkInMatrix
{
    using System;

    public class RotatingWalkExample
    {
        private static readonly ConsoleInteractionManager ConsoleManager = new ConsoleInteractionManager();

        public static void Main()
        {
            var matrix = InitializeMatrix();

            RotatingMatrixWalkSolver.SolveRotatingMatrixWalk(matrix);

            ConsoleManager.PrintMatrix(matrix);
        }

        private static int[,] InitializeMatrix()
        {
            var matrixSize = ConsoleManager.ReadMatrixSize();

            return new int[matrixSize, matrixSize];
        }
    }
}
