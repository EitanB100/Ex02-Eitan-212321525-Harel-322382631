using System;

namespace Ex02
{
    public class Screen
    {
        private Game m_Game;

        public Screen(Game i_Game)
        {
            m_Game = i_Game;
        }

        public void GameRun()
        {
            while (m_Game.GameState != eGameState.Quit)
            {
                m_Game.ResetBoard();

                while (m_Game.GameState == eGameState.InProgress)
                {

                    Console.WriteLine(boardString);
                    printCurrentGameState();
                    GetValidPlayerMove(out int chosenRow, out int chosenColumn);

                    if (m_Game.GameState == eGameState.Quit)
                    {
                        break;
                    }

                    m_Game.MakeMoveAndUpdateResult(chosenRow, chosenColumn);

                    if (m_Game.EndOfSession())
                    {
                        printCurrentGameState();
                        Console.WriteLine("Round Over");
                        Console.WriteLine("press Q to quit else you will play another round");
                        string userInput = Console.ReadLine();
                        if (userInput.ToUpper() == "Q")
                        {
                            m_Game.QuitCurrentGame();
                        }
                    }
                }
            }
        }

        public void printPlayersScore()
        {
            Console.WriteLine("Score: {0}-{1} | {2}-{3} ", m_Game.Players[0].Name, m_Game.Players[0].Score, m_Game.Players[1].Name, m_Game.Players[1].Score);
        }

        public string[] UserInput()
        {
            Console.WriteLine("Player {0}'s turn. Please enter your move (row and column) like this: 1,2", m_Game.CurrentPlayer.Name);
            Console.WriteLine("you can also press Q to quit");
            string locationChoosenToPlaceOnBoard = Console.ReadLine();
            string[] splitInput = locationChoosenToPlaceOnBoard.Split(',');
            return splitInput;
        }

        public bool ValidateUserInput(string i_LineChosenString, string i_ColumnChosenString)
        {
            bool isLineValid = int.TryParse(i_LineChosenString, out int DummyPlaceHolder);
            bool isColumnValid = int.TryParse(i_ColumnChosenString, out int DummyPlaceHolder2);
            return isLineValid && isColumnValid;
        }

        public void GetValidPlayerMove(out int o_Row, out int o_Column)
        {
            o_Row = 0;
            o_Column = 0;
            bool validInput = false;
            while (!validInput)
            {
                string[] userCommand = UserInput();

                if (userCommand.Length == 1 && userCommand[0].ToUpper() == "Q")
                {
                    m_Game.QuitCurrentGame();
                    validInput = true;
                }

                if (userCommand.Length == 2)
                {
                    bool isValid = ValidateUserInput(userCommand[0], userCommand[1]);

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

        private void printCurrentGameState()
        {
            ConsoleUtils.Screen.Clear();
            printPlayersScore();
            string boardString = m_Game.Board.BuildBoardString();
        }
    }
}
