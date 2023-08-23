using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GameCenter.Projects.Tic_tac_toe
{
    /// <summary>
    /// Interaction logic for tic_tac_toe.xaml
    /// </summary>
    public partial class tic_tac_toe : Window
    {
        private char _currentPlayer = 'X';
        private char[,] _board = new char[3, 3];

        public tic_tac_toe()
        {
            InitializeComponent();
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    _board[i, j] = ' ';
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            int row = Grid.GetRow(btn);
            int col = Grid.GetColumn(btn);

            if (_board[row, col] == ' ')
            {
                _board[row, col] = _currentPlayer;
                btn.Content = _currentPlayer;

                if (CheckForWin(_currentPlayer))
                {
                    MessageBox.Show($"{_currentPlayer} wins!", "Game Over", MessageBoxButton.OK, MessageBoxImage.Information);
                    ResetGame();

                }
                else if (IsBoardFull())
                {
                    MessageBox.Show("It's a draw!", "Game Over", MessageBoxButton.OK, MessageBoxImage.Information);
                    ResetGame();

                }
                else
                {
                    _currentPlayer = (_currentPlayer == 'X') ? 'O' : 'X';
                }
            }
        }

        private bool CheckForWin(char player)
        {
            // Check rows, columns, and diagonals for a win
            for (int i = 0; i < 3; i++)
            {
                if (_board[i, 0] == player && _board[i, 1] == player && _board[i, 2] == player)
                    return true;

                if (_board[0, i] == player && _board[1, i] == player && _board[2, i] == player)
                    return true;
            }

            if (_board[0, 0] == player && _board[1, 1] == player && _board[2, 2] == player)
                return true;

            if (_board[0, 2] == player && _board[1, 1] == player && _board[2, 0] == player)
                return true;

            return false;
        }

        private bool IsBoardFull()
        {
            foreach (char cell in _board)
            {
                if (cell == ' ')
                {
                    return false;
                }
            }
            return true;
        }

        private void ResetGame()
        {
            _currentPlayer = 'X';
            InitializeBoard();

            foreach (Button btn in MainGrid.Children)
            {
                btn.Content = null;


            }
        }


    }
}