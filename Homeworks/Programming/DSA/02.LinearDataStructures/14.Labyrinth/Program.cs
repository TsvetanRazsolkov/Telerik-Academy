
/*We are given a labyrinth of size N x N.

Some of its cells are empty (0) and some are full (x).
We can move from an empty cell to another empty cell if they share common wall.
Given a starting position (*) calculate and fill in the array the minimal distance 
from this position to any other cell in the array.
Use "u" for all unreachable cells.*/
namespace _14.Labyrinth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        // We will use -1 for X and -2 for *, because it is cheaper :)
        private static int[,] labyrinth = new int[,]
            {
                {0, 0, 0, -1, 0, -1},
                {0, -1, 0, -1, 0, -1},
                {0, -2, -1, 0, -1, 0},
                {0, -1, 0, 0, 0, 0},
                {0, 0, 0, -1, -1, 0},
                {0, 0, 0, -1, 0, -1}
            };

        public static void Main()
        {
            int startRow = 0;
            int startCol = 0;
            bool isSolved = false;

            PrintLabyrinth(labyrinth, isSolved);
            Console.WriteLine();

            FindStart(ref startRow, ref startCol);

            Solve(startRow, startCol);
            isSolved = true;

            PrintLabyrinth(labyrinth, isSolved);
        }

        private static void Solve(int startRow, int startCol)
        {
            var visited = new Queue<Cell>();
            var startCell = new Cell(startRow, startCol, 0);
            visited.Enqueue(startCell);

            while (visited.Count > 0)
            {
                var cell = visited.Dequeue();

                // check left
                if (cell.Col - 1 >= 0 && labyrinth[cell.Row, cell.Col - 1] == 0)
                {
                    labyrinth[cell.Row, cell.Col - 1] = cell.Value + 1;
                    var leftCell = new Cell(cell.Row, cell.Col - 1, cell.Value + 1);
                    visited.Enqueue(leftCell);
                }

                // check right
                if (cell.Col + 1 < labyrinth.GetLength(1) && labyrinth[cell.Row, cell.Col + 1] == 0)
                {
                    labyrinth[cell.Row, cell.Col + 1] = cell.Value + 1;
                    var rightCell = new Cell(cell.Row, cell.Col + 1, cell.Value + 1);
                    visited.Enqueue(rightCell);
                }

                // check up
                if (cell.Row - 1 >= 0 && labyrinth[cell.Row - 1, cell.Col] == 0)
                {
                    labyrinth[cell.Row - 1, cell.Col] = cell.Value + 1;
                    var upCell = new Cell(cell.Row - 1, cell.Col, cell.Value + 1);
                    visited.Enqueue(upCell);
                }

                // check down
                if (cell.Row + 1 < labyrinth.GetLength(0) && labyrinth[cell.Row + 1, cell.Col] == 0)
                {
                    labyrinth[cell.Row + 1, cell.Col] = cell.Value + 1;
                    var downCell = new Cell(cell.Row + 1, cell.Col, cell.Value + 1);
                    visited.Enqueue(downCell);
                }
            }
        }

        private static void FindStart(ref int startRow, ref int startCol)
        {
            for (int row = 0; row < labyrinth.GetLength(0); row++)
            {
                for (int col = 0; col < labyrinth.GetLength(1); col++)
                {
                    if (labyrinth[row, col] == -2)
                    {
                        startRow = row;
                        startCol = col;

                        return;
                    }
                }
            }
        }

        private static void PrintLabyrinth(int[,] labyrinth, bool isSolved)
        {
            for (int row = 0; row < labyrinth.GetLength(0); row++)
            {
                for (int col = 0; col < labyrinth.GetLength(1); col++)
                {
                    if (isSolved && labyrinth[row, col] == 0)
                    {
                        Console.Write("{0,5}", "U");
                        continue;
                    }

                    if (labyrinth[row, col] == -2)
                    {
                        Console.Write("{0,5}", "*");
                    }
                    else if (labyrinth[row, col] == -1)
                    {
                        Console.Write("{0,5}", "X");
                    }
                    else
                    {
                        Console.Write("{0,5}", labyrinth[row, col]);
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
