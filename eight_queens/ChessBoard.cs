using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eight_queens
{
    class ChessBoard
    {
        private const int _size = 8; // кількість ферзів
        public BoardCell[,] Grid { get; set; }// шахова дошка
        public int VertexNum { get; set; } // номер вершини
        public List<ChessBoard> Successors { get; set; } // дошки-нащадки

        // конструктор
        public ChessBoard()
        {
            Grid = new BoardCell[_size, _size];

            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    Grid[i, j] = new BoardCell(i, j);
                }
            }
        }

        public int Size { get => _size; }



        // заповнення дошки нулями
        public void FillBoard()
        {
            for (int i = 0; i < Grid.GetLength(0); i++)
            {
                for (int j = 0; j < Grid.GetLength(1); j++)
                {
                    Grid[i, j] = null;
                }
            }
        }
        
        // перевіряє чи можна розмістити ферзь
        public bool IsSafe(int row, int col)
        {
            int i, j;

            for (i = 0; i < col; i++)
            {
                if (Grid[row, i].IsOccupied) 
                    return false;
            }

            for (i = row, j = col; i >= 0 && j >= 0; i--, j--)
            {
                if (Grid[i, j].IsOccupied)
                    return false;
            }

            for (i = row, j = col; j >= 0 && i < _size; i++, j--)
            {
                if (Grid[i, j].IsOccupied)
                    return false;
            }

            return true;
        }



        
        
        /* вивід дошки
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
        }*/




    }
}
