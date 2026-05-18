namespace Ex02
{
    public class GameSettings
    {
        private readonly eGameMode r_GameMode;
        private readonly int r_BoardSize;

        public GameSettings(eGameMode i_GameMode, int i_BoardSize)
        {
            r_GameMode = i_GameMode;
            r_BoardSize = i_BoardSize;
        }

        public eGameMode GameMode
        {
            get
            {
                return r_GameMode;
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
