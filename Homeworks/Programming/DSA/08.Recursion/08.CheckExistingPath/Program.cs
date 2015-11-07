/*Modify the above program to check whether a path exists between two cells without finding all possible paths.
Test it over an empty 100 x 100 matrix.*/
namespace _08.CheckExistingPath
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        static int[,] lab = new int[100, 100];

        static bool isPathFound = false;

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

            lab[endCoords[0], endCoords[1]] = 1;

            //// Example with non existing path
            //lab[99, 98] = 2;
            //lab[98, 99] = 2;

            CheckPaths(startCoords[0], startCoords[1]);

            Console.WriteLine("Path found -> {0}", isPathFound);
        }

        private static void CheckPaths(int row, int col)
        {
            if (isPathFound == true)
            {
                return;
            }
            if (!ValidCell(row, col))
            {
                return;
            }

            if (lab[row, col] == 1)
            {
                isPathFound = true;
                return;
            }

            lab[row, col] = 2;
            CheckPaths(row - 1, col);
            CheckPaths(row + 1, col);
            CheckPaths(row, col - 1);
            CheckPaths(row, col + 1);
            //lab[row, col] = 0;
        }

        private static bool ValidCell(int row, int col)
        {
            if (row < 0 || row >= lab.GetLength(0)
                || col < 0 || col >= lab.GetLength(1))
            {
                return false; ;
            }
            if (lab[row, col] == 2)
            {
                return false;
            }

            return true;
        }
    }
}
