namespace Ex02
{
    public class Game
    {
        private GameBoard m_Board;
        private const int k_AmountOfPlayersInGame = 2;
        private Player[] m_Players = new Player[k_AmountOfPlayersInGame];
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

        //these are for UI interaction later on
        public Player CurrentPlayer
        {
            get
            {
                return m_Players[m_CurrentPlayerIndex];
            }
        }

        public GameBoard Board
        {
            get
            {
                return m_Board;
            }
        }

        public Player[] Players
        {
            get
            {
                return m_Players;
            }
        }

        public eGameState GameState
        {
            get
            {
                return m_GameState;
            }
        }

        public eGameState MakeMoveAndUpdateResult(int i_RequestedRow, int i_RequestedColumn)
        {
            if (m_Board.IsValidCellForWriting(i_RequestedRow, i_RequestedColumn)) 
            {
                m_Board.PlaceSymbol(i_RequestedRow, i_RequestedColumn, m_Players[m_CurrentPlayerIndex].Symbol);

                if (m_Board.CheckLosingCondition())
                {
                    m_GameState = eGameState.Winner;
                    m_Players[1 - m_CurrentPlayerIndex].AddPoint();
                }
                else if (m_Board.IsBoardFull())
                {
                    m_GameState = eGameState.Draw;
                }
                else
                {
                    switchTurn();
                }
            }

            return m_GameState;
        }

        public void ResetBoard()
        {
            m_GameState = eGameState.InProgress;
            m_Board = new GameBoard(m_Board.BoardSize);
        }

        public void QuitCurrentGame()
        {
            m_GameState = eGameState.Quit;
        }

        private void switchTurn()
        {
            m_CurrentPlayerIndex = 1 - m_CurrentPlayerIndex;
        }

        public bool endOfSession()
        {
            return m_GameState == eGameState.Winner || m_GameState == eGameState.Draw;
        }
    }
}
