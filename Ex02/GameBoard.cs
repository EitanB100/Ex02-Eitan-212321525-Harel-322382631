namespace Ex02
{
    public class GameBoard
    {
        private readonly int m_BoardSize = 3;
        private ePlayerSymbol[,] m_Board;

        public GameBoard(int i_BoardSize)
        {
            m_BoardSize = i_BoardSize;
            m_Board = new ePlayerSymbol[i_BoardSize, i_BoardSize];

            fillBoardAtGameInit();
        }

        public int BoardSize
        {
            get
            {
                return m_BoardSize;
            }
        }

        public ePlayerSymbol GetCell(int i_Row, int i_Col)
        {
            return m_Board[i_Row, i_Col];
        }

        public void PlaceSymbol(int i_Row, int i_Col, ePlayerSymbol i_Symbol)
        {
            bool isRequestedCellValid = IsCellEmpty(i_Row, i_Col); // and input is in borders

            if (isRequestedCellValid)
            {
                m_Board[i_Row, i_Col] = i_Symbol;
            }
        }

        public bool IsCellEmpty(int i_Row, int i_Col)
        {
            bool isRequestedCellEmpty = (m_Board[i_Row, i_Col] == ePlayerSymbol.None);

            return isRequestedCellEmpty;
        }

        public bool IsBoardFull()
        {
            bool isBoardFull = true;

            for (int i = 0; i < m_BoardSize && isBoardFull; i++)
            {
                for (int j = 0; j < m_BoardSize && isBoardFull; j++)
                {
                    if (m_Board[i, j] == ePlayerSymbol.None)
                    {
                        isBoardFull = false;
                    }
                }
            }

            return isBoardFull;
        }

        public bool CheckLosingCondition()
        {
            bool isLosingConditionMet = false;

            isLosingConditionMet = (checkRowsForLosingCondition() ||
                                    checkColumnsForLosingCondition() ||
                                    checkMainDiagonalForLosingCondition() ||
                                    checkSecondaryDiagonalForLosingCondition());

            return isLosingConditionMet;
        }

        private void fillBoardAtGameInit()
        {
            for (int i = 0; i < m_BoardSize; i++)
            {
                for (int j = 0; j < m_BoardSize; j++)
                {
                    m_Board[i, j] = ePlayerSymbol.None;
                }
            }
        }

        private bool checkRowsForLosingCondition()
        {
            bool isLosingRowFound = false;

            for (int i = 0; i < m_BoardSize && !isLosingRowFound; i++)
            {
                bool isCurrentRowLosingRow = true;
                ePlayerSymbol firstSymbolInCurrentRow = m_Board[i, 0];

                for (int j = 0; j < m_BoardSize && isCurrentRowLosingRow; j++)
                {
                    isCurrentRowLosingRow = !((m_Board[i, j] == ePlayerSymbol.None)
                       || (m_Board[i, j] != firstSymbolInCurrentRow));
                }

                isLosingRowFound = isCurrentRowLosingRow;
            }

            return isLosingRowFound;
        }

        private bool checkColumnsForLosingCondition()
        {
            bool isLosingColumnFound = false;

            for (int i = 0; i < m_BoardSize && !isLosingColumnFound; i++)
            {
                bool isCurrentColumnLosingColumn = true;
                ePlayerSymbol firstSymbolInCurrentColumn = m_Board[0, i];

                for (int j = 0; j < m_BoardSize && isCurrentColumnLosingColumn; j++)
                {
                    isCurrentColumnLosingColumn = !((m_Board[j, i] == ePlayerSymbol.None)
                        || (m_Board[j, i] != firstSymbolInCurrentColumn));
                }

                isLosingColumnFound = isCurrentColumnLosingColumn;
            }

            return isLosingColumnFound;
        }

        private bool checkMainDiagonalForLosingCondition()
        {
            bool isDiagonalLosing = false;
            ePlayerSymbol firstDiagonalSymbol = m_Board[0, 0];

            if (firstDiagonalSymbol != ePlayerSymbol.None)
            {
                isDiagonalLosing = true;

                for (int i = 1; i < m_BoardSize && isDiagonalLosing; i++)
                {
                    isDiagonalLosing = (firstDiagonalSymbol == m_Board[i, i]);
                }
            }

            return isDiagonalLosing;
        }

        private bool checkSecondaryDiagonalForLosingCondition()
        {
            bool isDiagonalLosing = false;
            ePlayerSymbol firstDiagonalSymbol = m_Board[0, m_BoardSize - 1];

            if (firstDiagonalSymbol != ePlayerSymbol.None)
            {
                isDiagonalLosing = true;

                for (int i = 1; i < m_BoardSize && isDiagonalLosing; i++)
                {
                    isDiagonalLosing = (firstDiagonalSymbol == m_Board[i, m_BoardSize - i - 1]);
                }
            }

            return isDiagonalLosing;
        }
    }
}
