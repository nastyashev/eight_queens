using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eight_queens
{
    internal class TreeNode
    {
        private List<ChessBoard> children;
        private ChessBoard board;
        //private int childrenNum;

        public TreeNode(ChessBoard board)
        {
            this.board = board;
            children = new List<ChessBoard>();

            for (int i = 0; i < board.Size; i++)
            {
                for (int j = i + 1; j < board.Size; j++)
                {
                    ChessBoard tmpBoard = this.board;
                    for (int k = 0; k < board.Size; k++)
                    {
                        BoardCell tmpCell = tmpBoard.Grid[i, k];
                        tmpBoard.Grid[i, k] = tmpBoard.Grid[j, k];
                        tmpBoard.Grid[j, k] = tmpCell;
                    }
                    children.Add(tmpBoard);
                }
            }
        }

        public ChessBoard Board { get { return board; } }

        public ChessBoard GetBoard(int index)
        {
            return children[index];
        }

        /*public List<ChessBoard> MakeSuccessorsList(ChessBoard board)
        {
            this.board = board;
            children = new List<ChessBoard>();

            for (int i = 0; i < board.Size; i++)
            {
                for (int j = i + 1; j < board.Size; j++)
                {
                    ChessBoard tmpBoard = this.board;
                    for (int k = 0; k < board.Size; k++)
                    {
                        BoardCell tmpCell = tmpBoard.Grid[i, k];
                        tmpBoard.Grid[i, k] = tmpBoard.Grid[j, k];
                        tmpBoard.Grid[j, k] = tmpCell;
                    }
                    children.Add(tmpBoard);
                }
            }

            return children;
        }*/


    }
}
