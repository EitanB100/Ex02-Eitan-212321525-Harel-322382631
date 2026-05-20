using System;
using System.Collections.Generic;

namespace Ex02
{
    public class CPU
    {
        private Player m_CpuInfo;
        private Game m_CpuGamePosition;
        private Random m_CellPicker;

        public CPU(Player i_PlayerInfo, Game i_GamePositionRightNow)
        {
            m_CpuInfo = i_PlayerInfo;
            m_CpuGamePosition = i_GamePositionRightNow;
            m_CellPicker = new Random();
        }

        public Player PlayerInfo
        {
            get
            {
                return m_CpuInfo;
            }
        }

        public void GetMove(GameBoard i_Board, out int o_Row, out int o_Column)
        {
            o_Row = 0;
            o_Column = 0;
            int searchSize = 2;
            int randomIndex;

            while (searchSize <= i_Board.BoardSize)
            {
                List<(int, int)> nonDiagonalCellsToPickFrom = new List<(int, int)>();
                List<(int, int)> diagonalCellsToPickFrom = new List<(int, int)>();
                List<(int, int)> badMovesForCpu = new List<(int, int)>();

                for (int i = 0; i < searchSize; i++)
                {
                    for (int j = 0; j < searchSize; j++)
                    {
                        if (!i_Board.IsCellEmpty(i, j))
                        {
                            continue;
                        }

                        if (isLosingMove(i_Board, i, j, searchSize))
                        {
                            badMovesForCpu.Add((i, j));
                            continue;
                        }

                        if (m_CpuGamePosition.Board.DiagonalCell(i, j))
                        {
                            diagonalCellsToPickFrom.Add((i, j)); // tile number starts from 1 and array starts from 0
                        }
                        else
                        {
                            nonDiagonalCellsToPickFrom.Add((i, j));
                        }
                    }
                }

                if (nonDiagonalCellsToPickFrom.Count > 0)
                {
                    randomIndex = m_CellPicker.Next(nonDiagonalCellsToPickFrom.Count);
                    (o_Row, o_Column) = nonDiagonalCellsToPickFrom[randomIndex];

                    break;
                }
                else if (diagonalCellsToPickFrom.Count > 0)
                {
                    randomIndex = m_CellPicker.Next(diagonalCellsToPickFrom.Count);
                    (o_Row, o_Column) = diagonalCellsToPickFrom[randomIndex];

                    break;
                }
                else if (searchSize == i_Board.BoardSize && badMovesForCpu.Count > 0)
                {
                    randomIndex = m_CellPicker.Next(badMovesForCpu.Count);
                    (o_Row, o_Column) = badMovesForCpu[randomIndex];

                    break;
                }
                else
                {
                    searchSize++;
                }
            }
        }

        private bool isLosingMove(GameBoard i_Board, int i_Row, int i_Column, int i_BorderOfMiniBoard)
        {
            GameBoard simulatedBoard = copyGameBoardToSmallerOrSameSizeGameBoard(i_Board, i_BorderOfMiniBoard);
            simulatedBoard.PlaceSymbol(i_Row, i_Column, m_CpuInfo.Symbol);

            return simulatedBoard.CheckLosingCondition();
        }

        private GameBoard copyGameBoardToSmallerOrSameSizeGameBoard(GameBoard i_Board, int i_BorderOfMiniBoard)
        {
            GameBoard simulatedBoard = new GameBoard(i_BorderOfMiniBoard);

            for (int i = 0; i < i_BorderOfMiniBoard; i++)
            {
                for (int j = 0; j < i_BorderOfMiniBoard; j++)
                {
                    simulatedBoard.PlaceSymbol(i, j, i_Board.GetCell(i, j));
                }
            }

            return simulatedBoard;
        }
    }
}