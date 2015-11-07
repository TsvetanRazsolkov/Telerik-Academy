
/*We are given a matrix of passable and non-passable cells.
Write a recursive program for finding all areas of passable cells in the matrix.*/
namespace _10.AllAreasOfPassableCellsInMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        static int[,] matrix = new int[,]{
        {0, 0, 1, 1, 0, 0, 0},
        {1, 1, 1, 1, 0, 1, 0},
        };

        static int[,] originalMatrix = new int[,]{
        {0, 0, 1, 1, 0, 0, 0},
        {1, 1, 1, 1, 0, 1, 0},
        };

        static List<Stack<Cell>> paths = new List<Stack<Cell>>();

        static Stack<Cell> currentPath = new Stack<Cell>();

        public static void Main()
        {
            FindAreas(0, 0);

            // Not really sure if this is what the task is about :)
            PrintPassableAreasMatrix(originalMatrix);
        }

        private static void PrintPassableAreasMatrix(int[,] printMatrix)
        {
            bool containsCell = false;
            for (int row = 0; row < printMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < printMatrix.GetLength(1); col++)
                {
                    for (int i = 0; i < paths.Count; i++)
                    {
                        if (paths[i].Contains(new Cell(row, col)))
                        {
                            containsCell = true;
                            break;
                        }                        
                    }

                    Console.ForegroundColor = containsCell ? ConsoleColor.Red : ConsoleColor.White;
                    Console.Write("{0, 2}", printMatrix[row, col]);
                    containsCell = false;
                }
                Console.WriteLine();
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void FindAreas(int row, int col)
        {
            if (!ValidCell(row, col))
            {
                return;
            }

            if (matrix[row, col] == 2)
            {
                return;
            }

            matrix[row, col] = 2;
            FindAreas(row - 1, col);
            FindAreas(row + 1, col);
            FindAreas(row, col - 1);
            FindAreas(row, col + 1);
            matrix[row, col] = 1;
            currentPath.Push(new Cell(row, col));

            if (!ValidCell(row - 1, col) && !ValidCell(row + 1, col) && !ValidCell(row, col - 1) && !ValidCell(row, col + 1))
            {
                var pathToAdd = new Stack<Cell>(currentPath);
                paths.Add(pathToAdd);

                currentPath = new Stack<Cell>();
                Cell emptyCell = FindUnoccupiedCell();
                if (emptyCell == null)
                {
                    return;
                }

                FindAreas(emptyCell.Row, emptyCell.Col);
            }
        }

        private static Cell FindUnoccupiedCell()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] != 1)
                    {
                        return new Cell(i, j);
                    }
                }
            }

            return null;
        }

        private static bool ValidCell(int row, int col)
        {
            if (row < 0 || row >= matrix.GetLength(0)
                || col < 0 || col >= matrix.GetLength(1))
            {
                return false; ;
            }
            if (matrix[row, col] == 1)
            {
                return false;
            }

            return true;
        }
    }
}
