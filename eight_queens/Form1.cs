using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace eight_queens
{
    public partial class Form1 : Form
    {
        //конструктор форми
        public Form1()
        {
            InitializeComponent();
            ShowBtnGrid();
        }

        //булева шахова дошка
        private static ChessBoard _chessBoard = new ChessBoard();
        
        //масив кнопок для відовраження дошки
        private Button[,] btnGrid = new Button[_chessBoard.Size, _chessBoard.Size];

        //відображення дошки
        private void ShowBtnGrid()
        {
            int buttonSize = boardPnl.Width / _chessBoard.Size;
            boardPnl.Height = boardPnl.Width;

            Color clrDark = Color.Sienna;
            Color clrLight = Color.BlanchedAlmond;

            for (int i = 0; i < _chessBoard.Size; i++)
            {
                for (int j = 0; j < _chessBoard.Size; j++)
                {
                    btnGrid[i, j] = new Button();
                    btnGrid[i, j].Width = buttonSize;
                    btnGrid[i, j].Height = buttonSize;

                    btnGrid[i, j].Click += GridButton_Click;

                    boardPnl.Controls.Add(btnGrid[i, j]);
                    btnGrid[i, j].Location = new Point(i * buttonSize, j * buttonSize);

                    btnGrid[i, j].Tag = new Point(i, j);

                    if (i % 2 == 0)
                    {
                        btnGrid[i, j].BackColor = j % 2 != 0 ? clrDark : clrLight;
                        btnGrid[i, j].FlatAppearance.BorderColor = j % 2 != 0 ? clrDark : clrLight;
                    }
                    else
                    {
                        btnGrid[i, j].BackColor = j % 2 != 0 ? clrLight : clrDark;
                        btnGrid[i, j].FlatAppearance.BorderColor = j % 2 != 0 ? clrLight : clrDark;
                    }
                        
                    btnGrid[i, j].FlatStyle = FlatStyle.Flat;
                    
                }
            }
        }

        //подія натискання на кнопку на дошці
        private void GridButton_Click(object sender, EventArgs e)
        {
            Button clickedBtn = (Button)sender;
            Point location = (Point)clickedBtn.Tag;
            Image queenImg = Image.FromFile("C:\\Users\\nasty\\source\\repos\\eight_queens\\eight_queens\\queen-chess.png");
            int x = location.X;
            int y = location.Y;

            BoardCell currentCell = _chessBoard.Grid[x, y];
            
            if (!currentCell.IsOccupied)
            {
                btnGrid[x, y].BackgroundImage = queenImg;
                btnGrid[x, y].BackgroundImageLayout = ImageLayout.Zoom;
                currentCell.IsOccupied = true;
            }
            else
            {
                btnGrid[x, y].BackgroundImageLayout = ImageLayout.None;
                currentCell.IsOccupied = false;
            }
        }

        //кнопка для розв'язання задачі
        private void solveBtn_Click(object sender, EventArgs e)
        {
            if (_chessBoard.IsSolvable())
            {
                if (comboBoxAlgorithms.SelectedItem == null)
                    MessageBox.Show("Виберіть алгоритм!");

                if (comboBoxAlgorithms.SelectedIndex == 0)
                    MessageBox.Show("LDFS");

                if (comboBoxAlgorithms.SelectedIndex == 1)
                    MessageBox.Show("BFS");

                if (comboBoxAlgorithms.SelectedIndex == 2)
                    MessageBox.Show("IDS");
            }
            
            else
                MessageBox.Show("can`t solve");
        }

        //кнопка для збереження результату у файл
        private void saveResultBtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (StreamWriter file = 
                    new StreamWriter(@"C:\Users\nasty\source\repos\eight_queens\eight_queens\result.txt"))
                {
                    if (comboBoxAlgorithms.SelectedIndex == 0)
                        file.WriteLine("LDFS:");
                    if (comboBoxAlgorithms.SelectedIndex == 1)
                        file.WriteLine("BFS:");
                    if (comboBoxAlgorithms.SelectedIndex == 2)
                        file.WriteLine("IDS:");

                    for (int i = 0; i < _chessBoard.Size; i++)
                    {
                        for (int j = 0; j < _chessBoard.Size; j++)
                        {
                            if (!_chessBoard.Grid[j, i].IsOccupied)
                                file.Write("0 ");
                            if (_chessBoard.Grid[j, i].IsOccupied)
                                file.Write("1 ");
                        }
                        file.WriteLine();
                    }
                }

                MessageBox.Show("File successfully saved.");
            }
            catch(Exception exc)
            {
                MessageBox.Show("Exeption: " + exc.Message);
            }
        }

        //кнопка для відображення статистичних даних роботи алгоритму
        private void statsData_Click(object sender, EventArgs e)
        {
            MessageBox.Show("statistic");
        }

        
    }
}
