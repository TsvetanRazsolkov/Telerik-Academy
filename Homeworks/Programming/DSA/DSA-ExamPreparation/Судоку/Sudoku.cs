using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Судоку
{
    class Sudoku
    {
        static int[,] sudoku = new int[9, 9];
        static void Main(string[] args)
        {
            for (int i = 0; i < 9; i++)
            {
                string line = Console.ReadLine();
                for (int j = 0; j < 9; j++)
                {
                    if (line[j] == '-')
                    {
                        sudoku[i, j] = 0;
                    }
                    else
                    {
                        sudoku[i, j] = line[j] - '0';
                    }
                }
            }

            Solve(0, 0);
        }

        private static void Solve(int row, int col)
        {
            if (row == 9 && col == 0)
            {
                PrintSudoku();
                return;
            }

            if (sudoku[row, col] == 0)
            {
                for (int i = 1; i <= 9; i++)
                {
                    if (RowContainsNumber(row, i) || ColContainsNumber(col, i) || SquareContainsNumber(row, col, i))
                    {
                        continue;
                    }

                    sudoku[row, col] = i;
                    Solve(GetRow(row, col), GetCol(col));
                    sudoku[row, col] = 0;
                }
            }
            else
            {
                Solve(GetRow(row, col), GetCol(col));
            }

        }

        private static bool SquareContainsNumber(int row, int col, int number)
        {
            int startRow = row - (row % 3);
            int endRow = startRow + 3;

            int startCol = col - (col % 3);
            int endCol = startCol + 3;

            for (int i = startRow; i < endRow; i++)
            {
                for (int j = startCol; j < endCol; j++)
                {
                    if (sudoku[i, j] == number)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static bool ColContainsNumber(int col, int number)
        {
            for (int i = 0; i < 9; i++)
            {
                if (sudoku[i, col] == number)
                {
                    return true;
                }
            }

            return false;
        }

        private static bool RowContainsNumber(int row, int number)
        {
            for (int i = 0; i < 9; i++)
            {
                if (sudoku[row, i] == number)
                {
                    return true;
                }
            }

            return false;
        }

        private static int GetCol(int col)
        {
            if (col + 1 == 9)
            {
                return 0;
            }

            return col + 1;
        }

        private static int GetRow(int row, int col)
        {
            if (col + 1 == 9)
            {
                return row + 1;
            }

            return row;
        }

        private static void PrintSudoku()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(sudoku[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
