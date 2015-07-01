namespace Minesweeper
{
    using System;
    using System.Collections.Generic;

    public class ConsoleRenderer
    {
        private const string Separator = "   ---------------------";

        public void PrintField(char[,] field)
        {
            int rows = field.GetLength(0);
            int cols = field.GetLength(1);
            Console.Write("\n   ");
            for (int i = 0; i < MinesweeperEngine.BoardColumns; i++)
            {
                Console.Write(" " + i);
            }

            Console.WriteLine("\n" + Separator);
            for (int i = 0; i < rows; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(string.Format("{0} ", field[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine(Separator + "\n");
        }

        public void PrintTopScores(List<Player> topScorers)
        {
            Console.WriteLine("\nTop Scores:");
            if (topScorers.Count > 0)
            {
                for (int i = 0; i < topScorers.Count; i++)
                {
                    Console.WriteLine(MessageAndSymbolConstants.ScoreMessage, i + 1, topScorers[i].Name, topScorers[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine(MessageAndSymbolConstants.EmptyTopScoresMessage);
            }
        }
    }
}
