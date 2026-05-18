using System;

namespace Ex02
{
    public class Menu
    {
        private const string k_TwoPlayersChoice = "1";
        private const string k_VsCPUChoice = "2";

        private eGameMode m_GameMode;
        private string m_Player1Name;
        private string m_Player2Name;
        private int m_BoardSize;

        public eGameMode GameMode
        {
            get
            {
                return m_GameMode;
            }
        }

        public int BoardSize
        {
            get
            {
                return m_BoardSize;
            }
        }

        public GameSettings Run()
        {
            printIntroMessage();
            requestGameModeFromUser();
            requestPlayerNames();
            requestBoardSizeFromUser();

            GameSettings requestedGameSettings = new GameSettings(m_GameMode, m_Player1Name, m_Player2Name, m_BoardSize);

            return requestedGameSettings;
        }

        private void printIntroMessage()
        {
            Console.WriteLine("WELCOME TO INVERTED TIC-TAC-TOE");
            Console.WriteLine("The rules are simple - you streak, you lose!");
            Console.WriteLine("Let's setup the game:");
        }

        private void requestPlayerNames()
        {
            string player1NameRequest = (m_GameMode == eGameMode.PlayerVsCPU) ? "Enter Player's name:" : "Enter Player 1's name:";
            
            Console.WriteLine(player1NameRequest);
            m_Player1Name = Console.ReadLine();

            if (m_GameMode == eGameMode.TwoPlayers)
            {
                Console.WriteLine("Enter Player 2's name:");
                m_Player2Name = Console.ReadLine();
            }
            else
            {
                m_Player2Name = "CPU";
            }
        }

        private void requestGameModeFromUser()
        {
            printGameModeOptions();
            string userGameModeChoice = Console.ReadLine();

            while (userGameModeChoice != k_TwoPlayersChoice && userGameModeChoice != k_VsCPUChoice)
            {
                Console.WriteLine("Invalid choice");
                printGameModeOptions();

                userGameModeChoice = Console.ReadLine();
            }

            m_GameMode = (userGameModeChoice == k_TwoPlayersChoice) ? eGameMode.TwoPlayers : eGameMode.PlayerVsCPU;
        }

        private void requestBoardSizeFromUser()
        {
            int minimumBoardSize = GameBoard.GetMinimumBoardSize();
            int maximumBoardSize = GameBoard.GetMaximumBoardSize();

            Console.WriteLine("Please enter board size ({0}-{1} inclusive):", minimumBoardSize, maximumBoardSize );

            int requestedSize;
            bool isValidInput = int.TryParse(Console.ReadLine(), out requestedSize);

            while (!isValidInput || !GameBoard.IsValidBoardSize(requestedSize))
            {
                Console.WriteLine("Invalid size. Please enter a value between {0}-{1}:", minimumBoardSize, maximumBoardSize);
                isValidInput = int.TryParse(Console.ReadLine(), out requestedSize);
            }

            m_BoardSize = requestedSize;
        }

        

        private void printGameModeOptions()
        {
            Console.WriteLine("2 Players or Vs CPU?");
            Console.WriteLine("{0} - 2 Players", k_TwoPlayersChoice);
            Console.WriteLine("{0} - Vs CPU", k_VsCPUChoice);
        }
    }
}
