namespace Ex02
{
    internal class GameManager
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
            screen.GameRun();
        }
    }
}
