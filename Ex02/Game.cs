namespace Ex02
{
    public class Game
    {
        private GameBoard m_Board;
        private const int k_AmountOfPlayersInGame = 2;
        private Player[] m_Players = new Player[2];
        private int m_CurrentPlayerIndex;
        private eGameState m_GameState;

        public Game(int i_BoardSize, Player i_Player1, Player i_Player2, int i_StartingPlayerIndex)
        {
            m_Board = new GameBoard(i_BoardSize);
            m_Players[0] = i_Player1;
            m_Players[1] = i_Player2;
            m_CurrentPlayerIndex = i_StartingPlayerIndex;
            m_GameState = eGameState.InProgress;
        }
    }
}
