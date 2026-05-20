namespace Ex02
{
    public class GameBoard
    {
        internal const int k_MinimumBoardSize = 3;
        internal const int k_MaximumBoardSize = 9;

        private readonly int r_BoardSize = 3;
        private ePlayerSymbol[,] m_Board;

        public GameBoard(int i_BoardSize)
        {
            r_BoardSize = i_BoardSize;
            m_Board = new ePlayerSymbol[i_BoardSize, i_BoardSize];

            fillBoardAtGameInit();
        }

        public static int GetMinimumBoardSize()
        {
            return k_MinimumBoardSize;
        }

        public static int GetMaximumBoardSize()
        {
            return k_MaximumBoardSize;
        }

        public int BoardSize
        {
            get
            {
                return r_BoardSize;
            }
        }

        public static bool IsValidBoardSize(int i_Size)
        {
            bool isValidBoardSize = (i_Size >= k_MinimumBoardSize
                                    && i_Size <= k_MaximumBoardSize);

            return isValidBoardSize;
        }

        public ePlayerSymbol GetCell(int i_Row, int i_Col)
        {
            return m_Board[i_Row, i_Col];
        }

        public void PlaceSymbol(int i_Row, int i_Col, ePlayerSymbol i_Symbol)
        {
            bool isRequestedCellValid = IsValidCellForWriting(i_Row, i_Col);

            if (isRequestedCellValid)
            {
                m_Board[i_Row, i_Col] = i_Symbol;
            }
        }

        public bool IsValidCellForWriting(int i_RequestedRow, int i_RequestedColumn)
        {
            bool isValidCoordinate = (IsCellInsideLimit(i_RequestedRow, i_RequestedColumn)
                                      && IsCellEmpty(i_RequestedRow, i_RequestedColumn));

            return isValidCoordinate;
        }

        public bool IsCellInsideLimit(int i_RequestedRow, int i_RequestedColumn)
        {
            bool isValidCoordinate = (i_RequestedColumn < BoardSize
                                     && i_RequestedColumn >= 0
                                     && i_RequestedRow < BoardSize
                                     && i_RequestedRow >= 0);
            return isValidCoordinate;
        }

        public bool IsCellEmpty(int i_Row, int i_Col)
        {
            bool isRequestedCellEmpty = (m_Board[i_Row, i_Col] == ePlayerSymbol.None);

            return isRequestedCellEmpty;
        }

        public bool IsBoardFull()
        {
            bool isBoardFull = true;

            for (int i = 0; i < r_BoardSize && isBoardFull; i++)
            {
                for (int j = 0; j < r_BoardSize && isBoardFull; j++)
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

        public bool DiagonalCell(int i_Row, int i_Col)
        {
            bool isDiagonalCell = (i_Row == i_Col) || (i_Row == r_BoardSize - i_Col - 1);

            return isDiagonalCell;
        }

        private void fillBoardAtGameInit()
        {
            for (int i = 0; i < r_BoardSize; i++)
            {
                for (int j = 0; j < r_BoardSize; j++)
                {
                    m_Board[i, j] = ePlayerSymbol.None;
                }
            }
        }

        private bool checkRowsForLosingCondition()
        {
            bool isLosingRowFound = false;

            for (int i = 0; i < r_BoardSize && !isLosingRowFound; i++)
            {
                bool isCurrentRowLosingRow = true;
                ePlayerSymbol firstSymbolInCurrentRow = m_Board[i, 0];

                for (int j = 0; j < r_BoardSize && isCurrentRowLosingRow; j++)
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

            for (int i = 0; i < r_BoardSize && !isLosingColumnFound; i++)
            {
                bool isCurrentColumnLosingColumn = true;
                ePlayerSymbol firstSymbolInCurrentColumn = m_Board[0, i];

                for (int j = 0; j < r_BoardSize && isCurrentColumnLosingColumn; j++)
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

                for (int i = 1; i < r_BoardSize && isDiagonalLosing; i++)
                {
                    isDiagonalLosing = (firstDiagonalSymbol == m_Board[i, i]);
                }
            }

            return isDiagonalLosing;
        }

        private bool checkSecondaryDiagonalForLosingCondition()
        {
            bool isDiagonalLosing = false;
            ePlayerSymbol firstDiagonalSymbol = m_Board[0, r_BoardSize - 1];

            if (firstDiagonalSymbol != ePlayerSymbol.None)
            {
                isDiagonalLosing = true;

                for (int i = 1; i < r_BoardSize && isDiagonalLosing; i++)
                {
                    isDiagonalLosing = (firstDiagonalSymbol == m_Board[i, r_BoardSize - i - 1]);
                }
            }

            return isDiagonalLosing;
        }
    }
}
