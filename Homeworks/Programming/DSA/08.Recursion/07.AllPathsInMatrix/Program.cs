
/*We are given a matrix of passable and non-passable cells.
Write a recursive program for finding all paths between two cells in the matrix.*/
namespace _07.AllPathsInMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        static char[,] matrix = new char[,]{
        {' ', ' ', ' ', '*', ' ', ' ', ' '},
        {'*', '*', ' ', '*', ' ', '*', ' '},
        {' ', ' ', ' ', ' ', ' ', ' ', ' '},
        {' ', '*', '*', '*', '*', '*', ' '},
        {' ', ' ', ' ', ' ', ' ', ' ', ' '},
        };

        static Stack<Cell> path = new Stack<Cell>();

        public static void Main()
        {
            Console.WriteLine("Enter coords for starting cell separated by a SPACE:");
            var startCoords = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                                .Select(x => int.Parse(x))
                                                .ToArray();

            if (!ValidCell(startCoords[0], startCoords[1]))
            {
                Console.WriteLine("No possible paths");
                return;
            }

            Console.WriteLine("Enter coords for ending cell separated by a SPACE:");
            var endCoords = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                                .Select(x => int.Parse(x))
                                                .ToArray();

            if (!ValidCell(startCoords[0], startCoords[1]))
            {
                Console.WriteLine("No possible paths");
                return;
            }

            matrix[endCoords[0], endCoords[1]] = 'T';

            PrintPaths(startCoords[0], startCoords[1]);
        }

        private static void PrintPaths(int row, int col)
        {
            if (!ValidCell(row, col))
            {
                return;
            }

            if (matrix[row, col] == 'T')
            {
                path.Push(new Cell(row, col));
                Console.WriteLine(string.Join(" -> ", path.Reverse()));
                path.Pop();

                return;
            }

            matrix[row, col] = '*';
            path.Push(new Cell(row, col));
            PrintPaths(row - 1, col);
            PrintPaths(row + 1, col);
            PrintPaths(row, col - 1);
            PrintPaths(row, col + 1);
            matrix[row, col] = ' ';
            path.Pop();
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
