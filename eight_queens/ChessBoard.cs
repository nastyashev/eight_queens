﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eight_queens
{
    //клас для шахової дошки
    internal class ChessBoard
    {
        //кількість ферзів
        private const int _size = 8;
        // шахова дошка
        public BoardCell[,] Grid { get; set; }

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
            Grid = new BoardCell[_size, _size];
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    Grid[i, j] = new BoardCell(i, j);
                    Grid[i, j] = previousBoard.Grid[i, j];
                }
            }
        }

        //конструктор для створення списку нащадків
        public ChessBoard(ChessBoard previousBoard, int position1, int position2 = -1, int orientation = 0)
        {
            Grid = new BoardCell[_size, _size];
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    Grid[i, j] = new BoardCell(i, j);
                    Grid[i, j] = previousBoard.Grid[i, j];
                }
            }
            position1 %= _size;

            if (position2 == -1)
                position2 = (position1 + 1) % _size;
            else
                position2 %= _size;
            BoardCell tmp;

            if(orientation == 0)
            {
                for (int i = 0; i < _size; i++)
                {
                    tmp = Grid[i, position1];
                    Grid[i, position1] = Grid[i, position2];
                    Grid[i, position2] = tmp;
                }
            }
            if(orientation == 1)
            {
                for (int i = 0; i < _size; i++)
                {
                    tmp = Grid[position1, i];
                    Grid[position1, i] = Grid[position2, i];
                    Grid[position2, i] = tmp;
                }
            }
        }

        //розмір дошки
        public int Size { get => _size; }

        //перевіряє чи є дана розстановка відповіддю
        public bool IsResult()
        {
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    if (Grid[i, j].IsOccupied)
                        if (IsQueenDiagonal(i, j))
                            return false;
                }
            }
            return true;
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

        //створення масиву нащадків дошки
        public List<ChessBoard> MakeSuccessorsList()
        {
            int numOfTreats = _size;
            int maxSuccessorsNum = (_size * _size) - _size;
            int position = 0;
            ChessBoard[] tmpArr = new ChessBoard[maxSuccessorsNum];
            List<ChessBoard> resList = new List<ChessBoard>();

            for (int orientation = 0; orientation <= 1; orientation++)
            {
                for (int i = 0; i < _size - 1; i++)
                {
                    for (int j = i + 1; j < _size; j++)
                    {
                        tmpArr[position] = new ChessBoard(this, i, j, orientation);
                        if (numOfTreats >= tmpArr[position].NumOfTreats())
                        {
                            numOfTreats = tmpArr[position].NumOfTreats();
                        }
                        position++;
                    }
                }
            }

            for (int i = 0; i < maxSuccessorsNum; i++)
            {
                if (tmpArr[i].NumOfTreats() == numOfTreats)
                {
                    resList.Add(tmpArr[i]);
                }
            }

            return resList;
        }
    }
}
