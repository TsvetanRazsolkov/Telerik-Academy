using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02._3DLabyrinth
{
    class Program
    {
        static char[, ,] labyrinth;
        static bool[, ,] used;
        static int minPath = int.MaxValue;
        static int currentPath = 0;

        static void Main(string[] args)
        {
            var startCoords = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int startL = startCoords[0];
            int startR = startCoords[1];
            int startC = startCoords[2];

            var labSizes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            labyrinth = new char[labSizes[0], labSizes[1], labSizes[2]];
            used = new bool[labSizes[0], labSizes[1], labSizes[2]];

            for (int level = 0; level < labSizes[0]; level++)
            {
                for (int row = 0; row < labSizes[1]; row++)
                {
                    string labRow = Console.ReadLine();
                    for (int col = 0; col < labRow.Length; col++)
                    {
                        labyrinth[level, row, col] = labRow[col];
                    }
                }
            }

            FindMinPathBFS(startL, startR, startC);

            //FindMinPath(startL, startR, startC);
            //Console.WriteLine(minPath);
        }

        static void FindMinPathBFS(int l, int r, int c)
        {
            var visited = new Queue<Cell>();

            var startCell = new Cell(l, r, c, 1);
            visited.Enqueue(startCell);
            used[startCell.Level, startCell.Row, startCell.Col] = true;

            while (visited.Count > 0)
            {
                var cell = visited.Dequeue();

                if (labyrinth[cell.Level, cell.Row, cell.Col] == 'D')
                {
                    if (cell.Level == 0)
                    {
                        Console.WriteLine(cell.Path);
                        return;
                    }

                    if (labyrinth[cell.Level - 1, cell.Row, cell.Col] == '#')
                    {
                        continue;
                    }
                    var neighbour = new Cell(cell.Level - 1, cell.Row, cell.Col, cell.Path + 1);
                    visited.Enqueue(neighbour);
                    used[cell.Level - 1, cell.Row, cell.Col] = true;
                }

                if (labyrinth[cell.Level, cell.Row, cell.Col] == 'U')
                {
                    if (cell.Level + 1 >= labyrinth.GetLength(0))
                    {
                        Console.WriteLine(cell.Path);
                        return;
                    }

                    if (labyrinth[cell.Level + 1, cell.Row, cell.Col] == '#')
                    {
                        continue;
                    }
                    var neighbour = new Cell(cell.Level + 1, cell.Row, cell.Col, cell.Path + 1);
                    visited.Enqueue(neighbour);
                    used[cell.Level + 1, cell.Row, cell.Col] = true;
                }

                if (labyrinth[cell.Level, cell.Row, cell.Col] == '.')
                {
                    // down cell
                    if (cell.Row + 1 < labyrinth.GetLength(1)
                        && labyrinth[cell.Level, cell.Row + 1, cell.Col] != '#' 
                        && !used[cell.Level, cell.Row + 1, cell.Col])
                    {
                        visited.Enqueue(new Cell(cell.Level, cell.Row + 1, cell.Col, cell.Path + 1));
                        used[cell.Level, cell.Row + 1, cell.Col] = true;
                    }

                    // up cell
                    if (cell.Row - 1 >= 0
                        && labyrinth[cell.Level, cell.Row - 1, cell.Col] != '#'
                        && !used[cell.Level, cell.Row - 1, cell.Col])
                    {
                        visited.Enqueue(new Cell(cell.Level, cell.Row - 1, cell.Col, cell.Path + 1));
                        used[cell.Level, cell.Row - 1, cell.Col] = true;
                    }

                    // right cell
                    if (cell.Col + 1 < labyrinth.GetLength(2)
                        && labyrinth[cell.Level, cell.Row, cell.Col + 1] != '#'
                        && !used[cell.Level, cell.Row, cell.Col + 1])
                    {
                        visited.Enqueue(new Cell(cell.Level, cell.Row, cell.Col + 1, cell.Path + 1));
                        used[cell.Level, cell.Row, cell.Col + 1] = true;
                    }

                    // right cell
                    if (cell.Col - 1 >= 0
                        && labyrinth[cell.Level, cell.Row, cell.Col - 1] != '#'
                        && !used[cell.Level, cell.Row, cell.Col - 1])
                    {
                        visited.Enqueue(new Cell(cell.Level, cell.Row, cell.Col - 1, cell.Path + 1));
                        used[cell.Level, cell.Row, cell.Col - 1] = true;
                    }
                }
            }
        }

        class Cell
        {
            public Cell(int level, int row, int col, int path)
            {
                this.Path = path;
                this.Level = level;
                this.Row = row;
                this.Col = col;
            }

            //public char Value { get; set; }

            public int Path { get; set; }

            public int Level { get; set; }

            public int Row { get; set; }

            public int Col { get; set; }
        }

        private static void FindMinPath(int l, int r, int c)
        {
            if (currentPath >= minPath)
            {
                return;
            }

            if (IsExit(l, r, c))
            {
                if (minPath > currentPath)
                {
                    minPath = currentPath;
                }
            }

            if (!ValidCell(l, r, c))
            {
                return;
            }

            currentPath++;
            char temp = labyrinth[l, r, c];
            labyrinth[l, r, c] = '#';

            if (temp == '.')
            {
                FindMinPath(l, r - 1, c); // up
                FindMinPath(l, r + 1, c); // down
                FindMinPath(l, r, c - 1); // left
                FindMinPath(l, r, c + 1); // right
            }
            else if (temp == 'U')
            {
                FindMinPath(l + 1, r, c); // up
            }
            else if (temp == 'D')
            {
                FindMinPath(l - 1, r, c); // down
            }

            labyrinth[l, r, c] = temp;

            currentPath--;
        }

        private static bool IsExit(int l, int r, int c)
        {
            if (l >= labyrinth.GetLength(0) || l < 0)
            {
                return true;
            }

            return false;
        }

        private static bool ValidCell(int level, int row, int col)
        {
            if (level >= labyrinth.GetLength(0) || level < 0)
            {
                return false;
            }

            if (row < 0 || row >= labyrinth.GetLength(1)
                || col < 0 || col >= labyrinth.GetLength(2))
            {
                return false;
            }

            if (labyrinth[level, row, col] == '#')
            {
                return false;
            }

            return true;
        }
    }
}
