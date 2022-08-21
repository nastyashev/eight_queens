using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eight_queens
{
    internal class ChessBoard
    {
        private const int _size = 8; // кількість ферзів
        public BoardCell[,] Grid { get; set; }// шахова дошка
        //public int VertexNum { get; set; } // номер вершини
        //public List<ChessBoard> Successors { get; set; } // дошки-нащадки

        // конструктор за замовчуванням
        public ChessBoard()
        {
            Grid = new BoardCell[_size, _size];

            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    Grid[i, j] = new BoardCell(i, j);
                    Grid[i, j].IsOccupied = false;
                }
            }
        }

        //конструктор копіювання
        public ChessBoard(ChessBoard previousBoard)
        {
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    Grid[i, j] = previousBoard.Grid[i, j];
                }
            }
        }

        //розмір дошки
        public int Size { get => _size; }
  
        // перевіряє чи можна розмістити ферзь
        public bool IsSafe(int row, int col)
        {
            if (!IsQueenRowCol(row, col))
                if (!IsQueenDiagonal(row, col))
                    return true;
            return false;
        }

        //перевіряє чи є дана розстановка відповіддю
        public static bool IsResult(ChessBoard board)
        {
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    if (board.IsSafe(i, j))
                        return true;
                }
            }
            return false;
        }

        //перевіряє дошку для подальшого вирішення задачі
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
        
        //перевіряє чи може даний фезь бути атакованим по горизонталі та вертикалі
        private bool IsQueenRowCol(int row, int col)
        {
            for (int i = 0; i < col; i++)
            {
                if (Grid[row, i].IsOccupied)
                    return true;
            }

            for (int i = col + 1; i < _size; i++)
            {
                if (Grid[row, i].IsOccupied)
                    return true;
            }

            for (int i = 0; i < row; i++)
            {
                if (Grid[i, col].IsOccupied)
                    return true;
            }

            for (int i = row + 1; i < _size; i++)
            {
                if (Grid[i, col].IsOccupied)
                    return true;
            }

            return false;
        }

        //перевіряє чи може даний фезь бути атакованим по побічній та основній діагоналям
        private bool IsQueenDiagonal(int row, int col)
        {
            int i, j;

            for (i = row - 1, j = col - 1; i >= 0 && j >= 0; i--, j--)
            {
                if (Grid[i, j].IsOccupied)
                    return true;
            }

            for (i = row + 1, j = col + 1; i < _size && j < _size; i++, j++)
            {
                if (Grid[i, j].IsOccupied)
                    return true;
            }

            for (i = row + 1, j = col - 1; i < _size && j >= 0; i++, j--)
            {
                if (Grid[i, j].IsOccupied)
                    return true;
            }

            for (i = row  - 1, j = col + 1; i >=0 && j < _size; i--, j++)
            {
                if (Grid[i, j].IsOccupied)
                    return true;
            }

            return false;
        }

        
        
        //кількість ферзів, що погрожують один одному
        public int NumOfTreats()
        {
            int num = 0;
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    if (Grid[i, j].IsOccupied)
                    {
                        if(IsQueenDiagonal(i, j))
                            num++;
                    }
                }
            }
            return num;
        }



    }
}
