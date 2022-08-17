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


        
        // перевіряє чи можна розмістити ферзь
        public bool IsSafe(int row, int col)
        {
            if (!IsQueenRowCol(row, col))
                if (!IsQueenDiagonal(row, col))
                    return true;
            return false;
        }

        public bool IsSolvable()
        {
            int numQueens = 0;

            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    if (Grid[i, j].IsOccupied)
                    {
                        numQueens++;
                        if (IsQueenRowCol(i, j))
                            return false;
                    }
                }
            }
            if (numQueens == _size)
                return true;
            else return false;
        }
        
        private bool IsQueenRowCol(int row, int col)
        {
            for (int i = 1; i < _size; i++)
            {
                if (Grid[(row + i) % _size, col].IsOccupied)
                    return true;
                if (Grid[col, (row + i) % _size].IsOccupied)
                    return true;
            }
            return false;
        }

        private bool IsQueenDiagonal(int row, int col)
        {
            int i, j;

            for (i = row, j = col; i >= 0 && j >= 0; i--, j--)
            {
                if (Grid[i, j].IsOccupied)
                    return true;
            }

            for (i = row, j = col; i < _size && j < _size; i++, j++)
            {
                if (Grid[i, j].IsOccupied)
                    return true;
            }

            for (i = row, j = col; i < _size && j >= 0; i++, j--)
            {
                if (Grid[i, j].IsOccupied)
                    return true;
            }

            for (i = row, j = col; i >=0 && j < _size; i++, j--)
            {
                if (Grid[i, j].IsOccupied)
                    return true;
            }

            return false;
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
