using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eight_queens
{
    //клас для клітини на дошці
    internal class BoardCell
    {
        //номер по рядку
        public int RowNumber { get; set; }
        //номер по стовпцю
        public int ColumnNumber { get; set; }
        //чи є ферзь в цій клвтинці
        public bool IsOccupied { get; set; }
        //конструктор
        public BoardCell(int x, int y)
        {
            RowNumber = x;
            ColumnNumber = y;
        }
    }
}
