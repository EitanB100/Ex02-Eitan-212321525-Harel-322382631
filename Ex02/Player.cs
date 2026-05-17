namespace Ex02
{
    public class Player
    {
        private string m_Name = string.Empty;
        private ePlayerSymbol m_Symbol = ePlayerSymbol.None;
        private int m_Score = 0;
        private bool m_IsCPU = false;

        public Player(string i_Name, ePlayerSymbol i_Symbol, bool i_IsCPU)
        {
            m_Name = i_Name;
            m_Symbol = i_Symbol;
            m_IsCPU = i_IsCPU;
        }

        public string Name
        {
            get
            {
                return m_Name;
            }
        }

        public ePlayerSymbol Symbol
        {
            get
            {
                return m_Symbol;
            }
        }

        public int Score
        {
            get
            {
                return m_Score;
            }
            set
            {
                m_Score++;
            }
        }
        
        public bool IsCPU
        {
            get
            {
                return m_IsCPU;
            }
            set
            {
                m_IsCPU = value;
            }
        }

    }
}
