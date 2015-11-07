
/*Write a recursive program to find the largest connected area of adjacent empty cells in a matrix.*/
namespace _09.LargestAreaOfAdjacentEmptyCells
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        static char[,] matrix = new char[,]{
        {' ', ' ', '*', '*', ' ', ' ', ' '},
        {'*', '*', '*', '*', ' ', '*', ' '},
        };

        //// With an empty matrix:
        //static char[,] matrix = new char[,]{
        //{' ', ' ', ' ', ' ', ' ', ' ', ' '},
        //{' ', ' ', ' ', ' ', ' ', ' ', ' '},
        //};

        static List<Stack<Cell>> paths = new List<Stack<Cell>>();

        static Stack<Cell> currentPath = new Stack<Cell>();

        public static void Main()
        {
            FindAreas(0, 0);

            var longestPath = paths.OrderByDescending(p => p.Count).FirstOrDefault();
            Console.WriteLine("Longest area of adjacent empty cells is consisted of {0} cells.", longestPath.Count);
            Console.WriteLine("Cells are: {0}", string.Join(" - ", longestPath));
        }

        private static void FindAreas(int row, int col)
        {    
            if (!ValidCell(row, col))
            {
                return;
            }            

            if (matrix[row, col] == '-')
            {
                return;
            }

            matrix[row, col] = '-';
            FindAreas(row - 1, col);
            FindAreas(row + 1, col);
            FindAreas(row, col - 1);
            FindAreas(row, col + 1);
            matrix[row, col] = '*';
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
                    if (matrix[i, j] != '*')
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
            if (matrix[row, col] == '*')
            {
                return false;
            }

            return true;
        }
    }
}
