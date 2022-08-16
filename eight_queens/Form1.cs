using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eight_queens
{
    public partial class Form1 : Form
    {
        


        public Form1()
        {
            InitializeComponent();
            ShowBtnGrid();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*const int tileSize = 50;
            const int gridSize = 8;
            var clr1 = Color.DarkGray;
            var clr2 = Color.White;

            // initialize the "chess board"
            _chessBoardPanels = new Panel[gridSize, gridSize];

            // double for loop to handle all rows and columns
            for (var n = 0; n < gridSize; n++)
            {
                for (var m = 0; m < gridSize; m++)
                {
                    // create new Panel control which will be one 
                    // chess board tile
                    var newPanel = new Panel
                    {
                        Size = new Size(tileSize, tileSize),
                        Location = new Point(tileSize * n, tileSize * m)
                    };

                    // add to Form's Controls so that they show up
                    Controls.Add(newPanel);

                    // add to our 2d array of panels for future use
                    _chessBoardPanels[n, m] = newPanel;

                    // color the backgrounds
                    if (n % 2 == 0)
                        newPanel.BackColor = m % 2 != 0 ? clr1 : clr2;
                    else
                        newPanel.BackColor = m % 2 != 0 ? clr2 : clr1;
                }
            }*/
        }

        private static ChessBoard _chessBoard = new ChessBoard();
        
        private Button[,] btnGrid = new Button[_chessBoard.Size, _chessBoard.Size];

        private void ShowBtnGrid()
        {
            int buttonSize = boardPnl.Width / _chessBoard.Size;
            boardPnl.Height = boardPnl.Width;

            Color clrDark = Color.SaddleBrown;
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

        private void solveBtn_Click(object sender, EventArgs e)
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

        private void saveResultBtn_Click(object sender, EventArgs e)
        {

        }

        private void statsData_Click(object sender, EventArgs e)
        {

        }

        
    }
}
