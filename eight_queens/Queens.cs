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
        private int[,] board = new int[8, 8]; // шахова дошка
        public int VertexNum { get; set; } // номер вершини

        // конструктор
        public Queens(int[,] board, int vertexNum)
        {
            this.board = board;
            VertexNum = vertexNum;
        }



        // заповнення дошки нулями
        public void FillBoard()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = 0;
                }
            }
        }
        
        // перевіряє чи атакований ферзь
        public bool IsSafe(int row, int col)
        {
            int i, j;

            for (i = 0; i < col; i++)
            {
                if (board[row, i] == 1) 
                    return false;
            }

            for (i = row, j = col; i >= 0 && j >= 0; i--, j--)
            {
                if (board[i, j] == 1)
                    return false;
            }

            for (i = row, j = col; j >= 0 && i < _numQueens; i++, j--)
            {
                if (board[i, j] == 1)
                    return false;
            }

            return true;
        }



        
        
        // вивід дошки
        public void PrintBoard()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.WriteLine(" " + board[i, j] + " ");
                }
                Console.WriteLine();
            }
        }




    }
}
