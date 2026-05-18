using System;

namespace Ex02
{
    public class CPU 
    {
        private Random m_CellPicker = new Random();

        public void GetMove(GameBoard i_Board, out int o_Row, out int o_Column)
        {
            o_Row = 0;
            o_Column = 0;

        }
    }
}
