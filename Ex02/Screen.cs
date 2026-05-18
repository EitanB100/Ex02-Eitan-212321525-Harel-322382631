using System;

namespace Ex02
{
    public class Screen
    {
        private const string k_QuitButton = "Q";

        private Game m_Game;

        public Screen(Game i_Game)
        {
            m_Game = i_Game;
        }

        public void GameRun()
        {
            bool playAgain = true;

            while (playAgain)
            {
                m_Game.ResetBoard();
                playRound();

                playAgain = doesUserWantToContinue();
            }
        }

        private void playRound()
        {
            while (m_Game.GameState == eGameState.InProgress)
            {
                printCurrentGameState();
                getValidPlayerMove(out int chosenRow, out int chosenColumn);

                if (m_Game.GameState == eGameState.Quit)
                {
                    m_Game.MakeMoveAndUpdateResult(chosenRow, chosenColumn);
                }
            }
        }

        private bool doesUserWantToContinue()
        {
            printCurrentGameState();
            Console.WriteLine("Round over! press {0} to quit, or any other key to continue to the next round", k_QuitButton);

            string userInput = Console.ReadLine();
            bool doesUserWantToContinue = (userInput.ToUpper() != k_QuitButton);

            return doesUserWantToContinue;
        }

        private void printCurrentGameState()
        {
            ConsoleUtils.Screen.Clear();
            printPlayersScore();
            Console.WriteLine();
            Console.WriteLine(m_Game.Board.BuildBoardString());
        }

        private void printPlayersScore()
        {
            Console.WriteLine("Score: {0} - {1} | {2} - {3} ", m_Game.Players[0].Name, m_Game.Players[0].Score, m_Game.Players[1].Name, m_Game.Players[1].Score);
        }

        private string[] getUserInput()
        {
            Console.WriteLine("{0}'s turn. Please enter your move (row and column) like this: 1,2", m_Game.CurrentPlayer.Name);
            Console.WriteLine("you can also press {0} to quit", k_QuitButton);

            string locationChoosenToPlaceOnBoard = Console.ReadLine();
            string[] splitInput = locationChoosenToPlaceOnBoard.Split(',');

            return splitInput;
        }

        private bool validateUserInput(string i_LineChosenString, string i_ColumnChosenString)
        {
            bool isLineValid = int.TryParse(i_LineChosenString, out int dummyPlaceHolder);
            bool isColumnValid = int.TryParse(i_ColumnChosenString, out int dummyPlaceHolder2);
            return isLineValid && isColumnValid;
        }

        private void getValidPlayerMove(out int o_Row, out int o_Column)
        {
            o_Row = 0;
            o_Column = 0;
            bool validInput = false;

            while (!validInput)
            {
                string[] userCommand = getUserInput();

                if (userCommand.Length == 1 && userCommand[0].ToUpper() == k_QuitButton)
                {
                    m_Game.QuitCurrentGame();
                    validInput = true;
                }

                if (userCommand.Length == 2)
                {
                    bool isValid = validateUserInput(userCommand[0], userCommand[1]);

                    if (isValid)
                    {
                        o_Row = int.Parse(userCommand[0]) - 1; // tile number starts from 1 and array starts from 0
                        o_Column = int.Parse(userCommand[1]) - 1;

                        if (m_Game.Board.IsValidCellForWriting(o_Row, o_Column))
                        {
                            validInput = true;
                        }
                        else
                        {
                            Console.WriteLine("Cell is already occupied. Choose another cell!");
                        }

                    }
                }

                if (!validInput)
                {
                    Console.WriteLine("Invalid input. Please enter your move (row and column) like this: 1,2 , make sure it is empty cell");
                }
            }
        }
    }
}
