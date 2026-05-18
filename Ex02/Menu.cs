using System;

namespace Ex02
{
    public class Menu
    {
        private const string k_TwoPlayersChoice = "1";
        private const string k_VsCPUChoice = "2";

        private eGameMode m_IsAgainstCPU;
        private int m_BoardSize;


        private void requestBoardSizeFromUser()
        {
            Console.WriteLine("Please enter board size (3-9 inclusive):");

            int requestedSize;
            bool isValidInput = int.TryParse(Console.ReadLine(), out requestedSize);

            while (!isValidInput || !GameBoard.IsValidBoardSize(requestedSize))
            {
                Console.WriteLine("Invalid size. Please enter a value between 3-9:");
                isValidInput = int.TryParse(Console.ReadLine(), out requestedSize);
            }

            m_BoardSize = requestedSize;
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

            m_IsAgainstCPU = (userGameModeChoice == k_TwoPlayersChoice) ? eGameMode.TwoPlayers : eGameMode.PlayerVsCPU;
        }

        private void printGameModeOptions()
        {
            Console.WriteLine("2 Players or Vs CPU?");
            Console.WriteLine("1 - 2 Players");
            Console.WriteLine("2 - Vs CPU");
        }
    }
}
