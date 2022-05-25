using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eight_queens
{
    class Queens
    {
        private readonly int numQueens = 8;

        //print solution
        public void PrintBoard(int[,] board)
        {
            for (int i = 0; i < numQueens; i++)
            {
                for (int j = 0; j < numQueens; j++)
                {
                    Console.WriteLine(" " + board[i, j] + " ");
                }
                Console.WriteLine();
            }
        }




    }
}
