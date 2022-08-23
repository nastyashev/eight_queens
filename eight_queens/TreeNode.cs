using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eight_queens
{
    //клас для вершини дерева
    internal class TreeNode
    {
        //масив нащадків
        private TreeNode[] successors;
        //шахова дошка
        private ChessBoard board;
        //кількість нащадків
        private int successorsNum;

        //конструктор за замовчуванням
        public TreeNode() { }
        //конструктор з параметрами
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

        //геттер для дошки
        public ChessBoard Board { get { return board; } }
        //геттер кількості нащадків
        public int SuccessorsNum { get { return successorsNum; } }

        //додавання дошки до дерева
        public TreeNode Add(ChessBoard board, int position)
        {
            successors[position] = new TreeNode(board, successorsNum);
            return successors[position];
        }
    }
}
