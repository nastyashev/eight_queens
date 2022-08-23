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
        //змінна для збереження результату
        private AlgorithmStatistics _result;

        //масив кнопок для відображення дошки
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

        //відображення результату на дошці
        private void ShowSolution(ChessBoard board)
        {
            Image queenImg = Image.FromFile("C:\\Users\\nasty\\source\\repos\\eight_queens\\eight_queens\\queen-chess.png");

            for (int i = 0; i < _chessBoard.Size; i++)
            {
                for (int j = 0; j < _chessBoard.Size; j++)
                {
                    if (board.Grid[i, j].IsOccupied)
                    {
                        btnGrid[i, j].BackgroundImage = queenImg;
                        btnGrid[i, j].BackgroundImageLayout = ImageLayout.Zoom;
                    }
                    else
                    {
                        btnGrid[i, j].BackgroundImageLayout = ImageLayout.None;
                    }
                }
            }
        }

        //кнопка для розв'язання задачі
        private void solveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (_chessBoard.IsSolvable())
                {
                    if (comboBoxAlgorithms.SelectedItem == null)
                        MessageBox.Show("Виберіть алгоритм!");

                    if (comboBoxAlgorithms.SelectedIndex == 0)
                    {
                        _result = Algorithms.LDFS(_chessBoard);
                        ShowSolution(_result.ChessBoard);
                        if (_result.NumberOfCheckedVertices == 1)
                            MessageBox.Show("Дана розстановка є розв'язком.");
                    }

                    if (comboBoxAlgorithms.SelectedIndex == 1)
                    {
                        _result = Algorithms.BFS(_chessBoard);
                        ShowSolution(_result.ChessBoard);
                        if (_result.NumberOfCheckedVertices == 1)
                            MessageBox.Show("Дана розстановка є розв'язком.");
                    }

                    if (comboBoxAlgorithms.SelectedIndex == 2)
                    {
                        _result = Algorithms.IDS(_chessBoard);
                        ShowSolution(_result.ChessBoard);
                        if (_result.NumberOfCheckedVertices == 1)
                            MessageBox.Show("Дана розстановка є розв'язком.");
                    }

                }
                else
                    MessageBox.Show("Некоректна розстановка. Ферзів має бути 8. В кожному рядку та стовпці по 1 ферзі.");
            }
            catch(Exception exc)
            {
                MessageBox.Show("Exeption: " + exc.Message);
            }
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
                            if (!_result.ChessBoard.Grid[j, i].IsOccupied)
                                file.Write("0 ");
                            if (_result.ChessBoard.Grid[j, i].IsOccupied)
                                file.Write("1 ");
                        }
                        file.WriteLine();
                    }
                    
                    string numStr = "Кількість відвіданих вершин: " + _result.NumberOfCheckedVertices.ToString();
                    string timeStr = "Час роботи алгоритму: " + _result.OperationTime.ToString() + " мс";
                    file.WriteLine(numStr + "\n" + timeStr);

                    file.Close();
                }

                MessageBox.Show("Файл успішно збережено.");
            }
            catch(Exception exc)
            {
                MessageBox.Show("Exeption: " + exc.Message);
            }
        }

        //кнопка для відображення статистичних даних роботи алгоритму
        private void statsData_Click(object sender, EventArgs e)
        {
            string numStr = "Кількість відвіданих вершин: " + _result.NumberOfCheckedVertices.ToString();
            string timeStr = "Час роботи алгоритму: " + _result.OperationTime.ToString() + " мс";
            MessageBox.Show(numStr + "\n" + timeStr);
        }  
    }
}
