using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eight_queens
{
    class Queens
    {
        private readonly int _numQueens = 8;
        private int[,] board = new int[8, 8];

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



        
        
        //print solution
        public void PrintBoard()
        {
            for (int i = 0; i < _numQueens; i++)
            {
                for (int j = 0; j < _numQueens; j++)
                {
                    Console.WriteLine(" " + board[i, j] + " ");
                }
                Console.WriteLine();
            }
        }




    }
}
