namespace Ex02
{
    public class Player
    {
        private readonly string r_Name = string.Empty;
        private readonly ePlayerSymbol r_Symbol = ePlayerSymbol.None;
        private readonly bool r_IsCPU = false;
        private int m_Score = 0;

        public Player(string i_Name, ePlayerSymbol i_Symbol, bool i_IsCPU)
        {
            r_Name = i_Name;
            r_Symbol = i_Symbol;
            r_IsCPU = i_IsCPU;
        }

        public string Name
        {
            get
            {
                return r_Name;
            }
        }

        public ePlayerSymbol Symbol
        {
            get
            {
                return r_Symbol;
            }
        }

        public int Score
        {
            get
            {
                return m_Score;
            }
        }

        public bool IsCPU
        {
            get
            {
                return r_IsCPU;
            }
        }

        public void AddPoint()
        {
            m_Score++;
        }
    }
}
