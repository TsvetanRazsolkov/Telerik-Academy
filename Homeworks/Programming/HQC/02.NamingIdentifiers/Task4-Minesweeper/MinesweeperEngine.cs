namespace Minesweeper
{
    using System;
    using System.Collections.Generic;

    public class MinesweeperEngine
	{
        public const int BoardRows = 5;
        public const int BoardColumns = 10;
        public const int MaxScore = 35;
        public const Difficulty DifficultyLevel = Difficulty.Medium;

		public static void Main()
		{
            ConsoleRenderer renderer = new ConsoleRenderer();
            PlayfieldManager playfieldManager = new PlayfieldManager();
            char[,] initialPlayField = playfieldManager.CreatePlayfield();
            char[,] playFieldWithMines = playfieldManager.PositionMines();
            int row = 0;
            int column = 0;
			int scoreCounter = 0;			
			List<Player> topPlayerScores = new List<Player>();	
			bool gameNotStarted = true;
            bool steppedOnMine = false;
            bool minesAreCleared = false;
            string command = string.Empty;

			do
			{
				if (gameNotStarted)
				{
					Console.WriteLine(MessageAndSymbolConstants.WelcomeMessage + MessageAndSymbolConstants.CommandsMessage);
					renderer.PrintField(initialPlayField);
					gameNotStarted = false;
				}

                Console.Write(MessageAndSymbolConstants.CommandPromptMessage);
				command = Console.ReadLine().Trim();

				if (command.Length >= 3)
				{
					if (int.TryParse(command[0].ToString(), out row) &&
					int.TryParse(command[2].ToString(), out column) &&
						row <= initialPlayField.GetLength(0) && column <= initialPlayField.GetLength(1))
					{
						command = "turn";
					}
				}

				switch (command)
				{
					case "top":
                        renderer.PrintTopScores(topPlayerScores);
						break;
					case "restart":
                        initialPlayField = playfieldManager.CreatePlayfield();
                        playFieldWithMines = playfieldManager.PositionMines();
                        renderer.PrintField(initialPlayField);
						steppedOnMine = false;
						gameNotStarted = false;
						break;
					case "exit":
						Console.WriteLine(MessageAndSymbolConstants.GoodbyeMessage);
						break;
					case "turn":
                        if (playFieldWithMines[row, column] != MessageAndSymbolConstants.MineSymbol)
						{
                            if (playFieldWithMines[row, column] == MessageAndSymbolConstants.EmptyCellSymbol)
							{
                                playfieldManager.RevealCell(initialPlayField, playFieldWithMines, row, column);
								scoreCounter++;
							}

							if (MaxScore == scoreCounter)
							{
								minesAreCleared = true;
							}
							else
							{
                                renderer.PrintField(initialPlayField);
							}
						}
						else
						{
							steppedOnMine = true;
						}

						break;
					default:
						Console.WriteLine(MessageAndSymbolConstants.InvalidCommandMessage);
						break;
				}

				if (steppedOnMine)
				{
                    renderer.PrintField(playFieldWithMines);
					Console.Write(MessageAndSymbolConstants.GameOverMessage + MessageAndSymbolConstants.PlayerNamePromptMessage, scoreCounter);

                    WriteScoreInTopScores(topPlayerScores, scoreCounter);
                    renderer.PrintTopScores(topPlayerScores);

                    initialPlayField = playfieldManager.CreatePlayfield();
                    playFieldWithMines = playfieldManager.PositionMines();
					scoreCounter = 0;
					steppedOnMine = false;
					gameNotStarted = true;
				}

				if (minesAreCleared)
				{
					Console.WriteLine(MessageAndSymbolConstants.VictoryMessage);
                    renderer.PrintField(playFieldWithMines);
					Console.WriteLine(MessageAndSymbolConstants.PlayerNamePromptMessage);

                    WriteScoreInTopScores(topPlayerScores, scoreCounter);
                    renderer.PrintTopScores(topPlayerScores);

                    initialPlayField = playfieldManager.CreatePlayfield();
                    playFieldWithMines = playfieldManager.PositionMines();
					scoreCounter = 0;
					minesAreCleared = false;
					gameNotStarted = true;
				}
			}
			while (command != "exit");

			Console.WriteLine(MessageAndSymbolConstants.CreditsMessage);
            Console.WriteLine(MessageAndSymbolConstants.GoatHerderNoiseMessage);
			Console.Read();
		}

        private static void WriteScoreInTopScores(List<Player> topPlayerScores, int currentPlayerScore)
        {
            string playerName = Console.ReadLine();
            Player player = new Player(playerName, currentPlayerScore);

            if (topPlayerScores.Count < 5)
            {
                topPlayerScores.Add(player);
            }
            else
            {
                for (int i = 0; i < topPlayerScores.Count; i++)
                {
                    if (topPlayerScores[i].Points < player.Points)
                    {
                        topPlayerScores.Insert(i, player);
                        topPlayerScores.RemoveAt(topPlayerScores.Count - 1);
                        break;
                    }
                }
            }

            topPlayerScores.Sort((Player x, Player y) => y.Name.CompareTo(x.Name));
            topPlayerScores.Sort((Player x, Player y) => y.Points.CompareTo(x.Points));
        }
	}
}