namespace Minesweeper
{
    using System;
    using System.Collections.Generic;

    public class PlayfieldManager
    {    
        public void RevealCell(char[,] initialField, char[,] fieldWithMines, int row, int column)
        {
            char numberOfNeighbouringMines = this.GetNumberOfNeighbouringMines(fieldWithMines, row, column);
            fieldWithMines[row, column] = numberOfNeighbouringMines;
            initialField[row, column] = numberOfNeighbouringMines;
        }

        public char[,] CreatePlayfield(char fillingSymbol = MessageAndSymbolConstants.HiddenCellSymbol)
        {
            int rows = MinesweeperEngine.BoardRows;
            int cols = MinesweeperEngine.BoardColumns;
            char[,] board = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    board[i, j] = fillingSymbol;
                }
            }

            return board;
        }

        public char[,] PositionMines()
        {
            int rows = MinesweeperEngine.BoardRows;
            int cols = MinesweeperEngine.BoardColumns;
            char[,] mineField = this.CreatePlayfield(MessageAndSymbolConstants.EmptyCellSymbol);

            List<int> randomCellNumbers = new List<int>();
            int numberOfMines = (int)MinesweeperEngine.DifficultyLevel;
            int numberOfCells = rows * cols;

            while (randomCellNumbers.Count < numberOfMines)
            {
                Random random = new Random();
                int randomCellNumber = random.Next(numberOfCells);
                if (!randomCellNumbers.Contains(randomCellNumber))
                {
                    randomCellNumbers.Add(randomCellNumber);
                }
            }

            foreach (int randomCellNumber in randomCellNumbers)
            {
                int minePositionRow = randomCellNumber / cols;
                int minePositionCol = randomCellNumber % cols;
                if (minePositionCol == 0 && randomCellNumber != 0)
                {
                    minePositionRow--;
                    minePositionCol = cols;
                }
                else
                {
                    minePositionCol++;
                }

                mineField[minePositionRow, minePositionCol - 1] = MessageAndSymbolConstants.MineSymbol;
            }

            return mineField;
        }        

        public char GetNumberOfNeighbouringMines(char[,] fieldWithMines, int row, int column)
        {
            int minesCount = 0;
            int rows = fieldWithMines.GetLength(0);
            int colums = fieldWithMines.GetLength(1);

            if (row - 1 >= 0)
            {
                if (fieldWithMines[row - 1, column] == MessageAndSymbolConstants.MineSymbol)
                {
                    minesCount++;
                }
            }

            if (row + 1 < rows)
            {
                if (fieldWithMines[row + 1, column] == MessageAndSymbolConstants.MineSymbol)
                {
                    minesCount++;
                }
            }

            if (column - 1 >= 0)
            {
                if (fieldWithMines[row, column - 1] == MessageAndSymbolConstants.MineSymbol)
                {
                    minesCount++;
                }
            }

            if (column + 1 < colums)
            {
                if (fieldWithMines[row, column + 1] == MessageAndSymbolConstants.MineSymbol)
                {
                    minesCount++;
                }
            }

            if ((row - 1 >= 0) && (column - 1 >= 0))
            {
                if (fieldWithMines[row - 1, column - 1] == MessageAndSymbolConstants.MineSymbol)
                {
                    minesCount++;
                }
            }

            if ((row - 1 >= 0) && (column + 1 < colums))
            {
                if (fieldWithMines[row - 1, column + 1] == MessageAndSymbolConstants.MineSymbol)
                {
                    minesCount++;
                }
            }

            if ((row + 1 < rows) && (column - 1 >= 0))
            {
                if (fieldWithMines[row + 1, column - 1] == MessageAndSymbolConstants.MineSymbol)
                {
                    minesCount++;
                }
            }

            if ((row + 1 < rows) && (column + 1 < colums))
            {
                if (fieldWithMines[row + 1, column + 1] == MessageAndSymbolConstants.MineSymbol)
                {
                    minesCount++;
                }
            }

            return char.Parse(minesCount.ToString());
        }
    }
}
