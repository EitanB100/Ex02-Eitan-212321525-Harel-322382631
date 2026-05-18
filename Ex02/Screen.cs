using System;

namespace Ex02
{
    public class Screen
    {
        private Game m_game;

        public Screen(Game i_Game)
        {
            m_game = i_Game;
        }

        public void GameRun()
        {
            while(m_game.GameState != eGameState.Quit)
            {
                m_game.ResetBoard();

                while (m_game.GameState == eGameState.InProgress)
                {
                    ConsoleUtils.Screen.Clear();
                    printPlayersScore();
                    string boardString = m_game.Board.BuildBoardString();
                    Console.WriteLine(boardString);

                    GetValidPlayerMove(out int chosenRow, out int chosenColumn);

                    if (m_game.GameState == eGameState.Quit)
                    {
                        break;
                    }

                    m_game.MakeMoveAndUpdateResult(chosenRow, chosenColumn);

                    if (m_game.endOfSession() == true)
                    {
                        ConsoleUtils.Screen.Clear();
                        printPlayersScore();
                        Console.WriteLine(m_game.Board.BuildBoardString());
                        Console.WriteLine("Round Over");
                        Console.WriteLine("press Q to quit else you will play another round");
                        string UserInput = Console.ReadLine();
                        if (UserInput.ToUpper() == "Q")
                        {
                            m_game.QuitCurrentGame();
                        }
                    }
                }
            }   
        }

        public void printPlayersScore()
        {
            Console.WriteLine("Score: {0}-{1} | {2}-{3} ", m_game.Players[0].Name, m_game.Players[0].Score, m_game.Players[1].Name, m_game.Players[1].Score);
        }

        public string[] UserInput()
        {
            Console.WriteLine("Player {0}'s turn. Please enter your move (row and column) like this: 1,2", m_game.CurrentPlayer.Name);
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
            bool ValidInput = false;
            while (ValidInput == false)
            {
                string[] userCommand = UserInput();

                if (userCommand.Length == 1 && userCommand[0].ToUpper() == "Q")
                {
                    m_game.QuitCurrentGame();
                    ValidInput = true;
                }

                if (userCommand.Length == 2)
                {
                    bool isValid = ValidateUserInput(userCommand[0], userCommand[1]);
                
                    if (isValid == true)
                    {
                        o_Row = int.Parse(userCommand[0]) - 1; // tile number starts from 1 and array starts from 0
                        o_Column = int.Parse(userCommand[1]) - 1;
                        if (m_game.Board.IsValidCellForWriting(o_Row, o_Column) == true)
                        {

                        }
                        ValidInput = true;
                    }
                }
                if (ValidInput == false)
                {
                    Console.WriteLine("Invalid input. Please enter your move (row and column) like this: 1,2 , make sure it is empty cell");
                }
            }
        }
    }
}
