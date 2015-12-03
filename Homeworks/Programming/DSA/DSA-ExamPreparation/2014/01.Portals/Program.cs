using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Portals
{
    class Program
    {
        static int[,] labyrinth;
        static int maxPath = 0;
        static int currentPath = 0;

        static void Main(string[] args)
        {
            var startCoords = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int x = startCoords[0];
            int y = startCoords[1];

            var sizes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int r = sizes[0];
            int c = sizes[1];

            labyrinth = new int[r, c];
            for (int i = 0; i < r; i++)
            {
                var line = Console.ReadLine().Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < line.Length; j++)
                {
                     labyrinth[i, j] = char.IsDigit(line[j][0]) ? line[j][0] - '0' : -1;
                }
            }

            Solve(x, y);

            Console.WriteLine(maxPath);
        }

        private static void Solve(int x, int y)
        {
            if (!ValidCell(x, y))
            {
                return;
            }

            int temp = labyrinth[x, y];
            currentPath += temp;
            labyrinth[x, y] = -2;

            Solve(x - temp, y); // up
            Solve(x + temp, y); // down
            Solve(x, y - temp); // left
            Solve(x, y + temp); // right

            labyrinth[x, y] = temp;

            // We get to here when we no longer have available teleportations to a free cell.
            // Now to check if the last visited portal will be added to the sum.
            // If we can only teleport outside of the labyrinth or to a cell with frogs and
            // cannot teleport to a previously used cell we don't add the value of the last portal cube to the sum(subtract it in this case).
            if ((x - temp < 0 || labyrinth[x - temp, y] != -2)
                && (x + temp >= labyrinth.GetLength(0) || labyrinth[x + temp, y] != -2)
                && (y - temp < 0 || labyrinth[x, y - temp] != -2)
                && (y + temp >= labyrinth.GetLength(1) || labyrinth[x, y + temp] != -2))
            {
                if (maxPath < currentPath - temp)
                {
                    maxPath = currentPath - temp;
                }
            }
            else
            {
                if (maxPath < currentPath)
                {
                    maxPath = currentPath;
                }
            }           

            currentPath -= temp;
        }

        private static bool ValidCell(int row, int col)
        {
            if (row < 0 || row >= labyrinth.GetLength(0)
                || col < 0 || col >= labyrinth.GetLength(1))
            {
                return false;
            }
            if (labyrinth[row, col] < 0)
            {
                return false;
            }

            return true;
        }
    }
}
