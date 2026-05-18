namespace Ex02
{
    public class GameManager
    {
        public void Run()
        {
            Menu gameMenu = new Menu();
            GameSettings settings = gameMenu.Run();
            const bool v_IsPlayer1CPU = false;
            bool isPlayer2CPU = (settings.GameMode == eGameMode.PlayerVsCPU);

            Player player1 = new Player(settings.Player1Name, ePlayerSymbol.X, v_IsPlayer1CPU);
            Player player2 = new Player(settings.Player2Name, ePlayerSymbol.O, isPlayer2CPU);

            Game game = new Game(settings.BoardSize, player1, player2, 0);
            Screen screen = new Screen(game);

            runGameSession(game, screen);
        }

        private void playRound(Game i_Game, Screen i_Screen)
        {
            while (i_Game.GameState == eGameState.InProgress)
            {
                i_Screen.PrintCurrentGameState();

                bool playerContinues = i_Screen.GetValidPlayerMove(out int chosenRow, out int chosenColumn);

                if (playerContinues)
                {
                    i_Game.MakeMoveAndUpdateResult(chosenRow, chosenColumn);
                }
                else
                {
                    i_Game.QuitCurrentGame();
                }
            }
        }

        private void runGameSession(Game i_Game, Screen i_Screen)
        {
            bool playAgain = true;

            while (playAgain)
            {
                i_Game.ResetBoard();
                playRound(i_Game, i_Screen);

                playAgain = i_Screen.DoesUserWantToContinue();
            }
        }
    }
}
