using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eight_queens
{
    internal class BoardCell
    {
        public int RowNumber { get; set; } // номер по ряду
        public int ColumnNumber { get; set; } // номер по стовпцю
        public bool IsOccupied { get; set; } // чи є ферзь в цій клвтинці

        public BoardCell(int x, int y) // конструктор
        {
            RowNumber = x;
            ColumnNumber = y;
        }
    }
}
