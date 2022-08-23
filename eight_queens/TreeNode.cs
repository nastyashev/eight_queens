using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eight_queens
{
    internal class TreeNode
    {
        private TreeNode[] successors;
        private ChessBoard board;
        private int successorsNum;

        public TreeNode() { }
        public TreeNode(ChessBoard board, int successorsNum)
        {
            this.board = board;
            successors = new TreeNode[successorsNum];
            for (int i = 0; i < successorsNum; i++)
            {
                successors[i] = null;
            }
            this.successorsNum = successorsNum;
        }

        public ChessBoard Board { get { return board; } }
        public int ChildCount { get { return successorsNum; } }

        public TreeNode GetBoard(int index)
        {
            return successors[index];
        }

        public TreeNode Add(ChessBoard board, int position)
        {
            successors[position] = new TreeNode(board, successorsNum);
            return successors[position];
        }
    }
}
