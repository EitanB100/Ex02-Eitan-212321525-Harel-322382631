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

            CPU cpu = isPlayer2CPU ? new CPU() : null;

            Player player1 = new Player(settings.Player1Name, ePlayerSymbol.X, v_IsPlayer1CPU);
            Player player2 = new Player(settings.Player2Name, ePlayerSymbol.O, isPlayer2CPU);

            Game game = new Game(settings.BoardSize, player1, player2, 0);
            Screen screen = new Screen(game);

            runGameSession(game, screen, cpu);
        }

        private void playRound(Game i_Game, Screen i_Screen, CPU i_CPU)
        {
            while (i_Game.GameState == eGameState.InProgress)
            {
                i_Screen.PrintCurrentGameState();

                if (i_Game.CurrentPlayer.IsCPU)
                {
                    playCPUTurn(i_Game, i_CPU);
                }
                else
                {
                    playUserTurn(i_Game, i_Screen);
                }
            }
        }

        private void playCPUTurn(Game i_Game, CPU i_CPU)
        {
            i_CPU.GetMove(i_Game.Board, out int cpuRow, out int cpuColumn);
            i_Game.MakeMoveAndUpdateResult(cpuRow, cpuColumn);
        }

        private void playUserTurn(Game i_Game, Screen i_Screen)
        {
            bool userContinuesPlaying = i_Screen.GetValidPlayerMove(out int chosenRow, out int chosenColumn);

            if (userContinuesPlaying)
            {
                i_Game.MakeMoveAndUpdateResult(chosenRow, chosenColumn);
            }
            else
            {
                i_Game.QuitCurrentGame();
            }
        }

        private void runGameSession(Game i_Game, Screen i_Screen, CPU i_CPU)
        {
            bool playAgain = true;

            while (playAgain)
            {
                i_Game.ResetBoard();
                playRound(i_Game, i_Screen, i_CPU);

                playAgain = i_Screen.DoesUserWantToContinue();
            }
        }
    }
}
