namespace Ex02
{
    public class GameSettings
    {
        private readonly eGameMode r_GameMode;
        private readonly string r_Player1Name;
        private readonly string r_Player2Name;
        private readonly int r_BoardSize;

        public GameSettings(eGameMode i_GameMode, string i_Player1Name, string i_Player2Name, int i_BoardSize)
        {
            r_GameMode = i_GameMode;
            r_Player1Name = i_Player1Name;
            r_Player2Name = i_Player2Name;
            r_BoardSize = i_BoardSize;
        }

        public eGameMode GameMode
        {
            get
            {
                return r_GameMode;
            }
        }

        public string Player1Name
        {
            get
            {
                return r_Player1Name;
            }
        }

        public string Player2Name
        {
            get
            {
                return r_Player2Name;
            }
        }

        public int BoardSize
        {
            get
            {
                return r_BoardSize;
            }
        }
    }
}
