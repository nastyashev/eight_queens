using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eight_queens
{
    class Queens
    {
        private readonly int _numQueens = 8; // кількість ферзів
        private int[,] _board = new int[8, 8]; // шахова дошка
        public int VertexNum { get; set; } // номер вершини

        // конструктор
        public Queens(int[,] board, int vertexNum)
        {
            this._board = board;
            VertexNum = vertexNum;
        }

        public int GetNumQueens() { return _numQueens; }

        public int[,] GetBoard() { return _board; }


        // заповнення дошки нулями
        public void FillBoard()
        {
            for (int i = 0; i < _board.GetLength(0); i++)
            {
                for (int j = 0; j < _board.GetLength(1); j++)
                {
                    _board[i, j] = 0;
                }
            }
        }
        
        // перевіряє чи атакований ферзь
        public bool IsSafe(int row, int col)
        {
            int i, j;

            for (i = 0; i < col; i++)
            {
                if (_board[row, i] == 1) 
                    return false;
            }

            for (i = row, j = col; i >= 0 && j >= 0; i--, j--)
            {
                if (_board[i, j] == 1)
                    return false;
            }

            for (i = row, j = col; j >= 0 && i < _numQueens; i++, j--)
            {
                if (_board[i, j] == 1)
                    return false;
            }

            return true;
        }



        
        
        // вивід дошки
        public void PrintBoard()
        {
            for (int i = 0; i < _board.GetLength(0); i++)
            {
                for (int j = 0; j < _board.GetLength(1); j++)
                {
                    Console.WriteLine(" " + _board[i, j] + " ");
                }
                Console.WriteLine();
            }
        }




    }
}
