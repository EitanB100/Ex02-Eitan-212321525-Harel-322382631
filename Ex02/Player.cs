using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    internal class Player
    {
        private string m_Name = string.Empty;
        private char m_Symbol = ' ';
        private int m_Score = 0;
        private bool m_IsCPU = false;

        public Player(string i_Name, char i_Symbol, bool i_IsCPU)
        {
            m_Name = i_Name;
            m_Symbol = i_Symbol;
            m_IsCPU = i_IsCPU;
        }

        public void AddPoint()
        {
            m_Score++;
        }
    }
}
