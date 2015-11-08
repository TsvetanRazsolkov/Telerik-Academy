
/*Write a recursive program to solve the "8 Queens Puzzle" with backtracking.*/
namespace _12.QueensPuzzle
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        private const int Size = 8;
        static int[,] board = new int[Size, Size];
        static int countOfSolutions = 0;

        public static void Main(string[] args)
        {
            Queens(board, 0);
            Console.WriteLine("Count of possible solutions = {0}", countOfSolutions);
        }

        static void Queens(int[,] board, int columnIndex)
        {
            if (columnIndex == Size)
            {
                countOfSolutions++;
                return;
            }

            for (int rowIndex = 0; rowIndex < board.GetLength(0); rowIndex++)
            {
                if (board[rowIndex, columnIndex] == 0) // Check if current cell is occupied
                {
                    board[rowIndex, columnIndex] += 1;
                    MarkOccupied(board, 1, rowIndex, columnIndex);
                    Queens(board, columnIndex + 1);
                    board[rowIndex, columnIndex] -= 1; // remove the queen from where it has been placed for next placement;
                    MarkOccupied(board, -1, rowIndex, columnIndex);
                }
            }
        }

        static void MarkOccupied(int[,] board, int value, int rowIndex, int columnIndex)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                board[i, columnIndex] += value;
                board[rowIndex, i] += value;

                if (columnIndex + i < board.GetLength(0) && rowIndex + i < board.GetLength(0))
                {
                    board[rowIndex + i, columnIndex + i] += value;
                }

                if (columnIndex + i < board.GetLength(0) && rowIndex - i >= 0)
                {
                    board[rowIndex - i, columnIndex + i] += value;
                }
            }
        }
    }
}
