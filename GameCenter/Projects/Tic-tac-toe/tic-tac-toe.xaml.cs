using GameCenter.Projects.Tic_tac_toe.Models;
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
    public partial class Tic_tac_toe : Window
    {
        TicTacToeModel GameModel;
        int UserScore = 0;
        int ComputerScore = 0;

        public Tic_tac_toe()
        {
            InitializeComponent();
            GameModel = new TicTacToeModel();
        }

        private void UserPlay(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int boardRow = Grid.GetRow(button);
            int boardCol = Grid.GetColumn(button);
            if (button != null  && GameModel.GameBoard[boardRow,boardCol] == '\0' )
            {
                button.Content = GameModel.CurrentPlayer.ToString();
                int row = Grid.GetRow(button);
                int column = Grid.GetColumn(button);
                GameModel.GameBoard[row, column] = GameModel.CurrentPlayer;

                if (GameModel.CheckForWin())
                {
                    UserScore++;
                    MessageBox.Show($"Computer Score: {ComputerScore} \n User Score: {UserScore}", "Game Over", MessageBoxButton.OK, MessageBoxImage.Information);
                    ResetGame();
                }
                else
                {
                    if (GameModel.IsBoardFull())
                    {
                        MessageBox.Show($"It's a draw! \n Computer Score: {ComputerScore} \n User Score: {UserScore}", "Game Over", MessageBoxButton.OK, MessageBoxImage.Information);
                        ResetGame();
                    }
                    else
                    {
                        ComputerPlay();
                    }
                }
            }
        }

        private async void ComputerPlay()
        {
            try
            {
                await Task.Delay(500);
                GameModel.CurrentPlayer = 'O';
                Random random = new Random();
                int row, column;

                do
                {
                    row = random.Next(3);
                    column = random.Next(3);
                } while (GameModel.GameBoard[row, column] != '\0');
                Button? computerButton = FindButton(row, column);

                if (computerButton != null)
                {
                    computerButton.Content = GameModel.CurrentPlayer;
                    GameModel.GameBoard[row, column] = GameModel.CurrentPlayer;
                    if (GameModel.CheckForWin())
                    {
                        ComputerScore++;
                        MessageBox.Show($"Computer Score: {ComputerScore} \n User Score: {UserScore}", "Game Over", MessageBoxButton.OK, MessageBoxImage.Information);
                        ResetGame();
                    }
                    else
                    {
                        GameModel.CurrentPlayer = 'X';
                    }



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Occured: {ex.Message}");
            }
        }

        private Button ? FindButton(int row, int column)
        {
            foreach(UIElement element in MainGrid.Children)
            {
                if(element is Button button && Grid.GetRow(button) == row && Grid.GetColumn(button) == column)
                {
                    return button;
                }
            }
            return null;
        }
        private void ResetGame()
        {
            GameModel = new TicTacToeModel();

            // Clear the game board
            foreach (Button button in MainGrid.Children)
            {
                button.Content = "";
            }
        }


    }
}