using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.Projects.Tic_tac_toe.Models
{
    internal class TicTacToeModel
    {
        public char CurrentPlayer { get; set; }
        public char [,] GameBoard { get; set; }
        public TicTacToeModel()
        {
            CurrentPlayer = 'X';
            GameBoard = new char[3, 3];
        }
        public bool IsBoardFull()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (GameBoard[i, j] == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public bool CheckForWin()
        {
            for (int i = 0; i < 3; i++)
            {
                if (GameBoard[i, 0] == CurrentPlayer && GameBoard[i, 1] == CurrentPlayer && GameBoard[i, 2] == CurrentPlayer)
                    return true;
            }

            for (int i = 0; i < 3; i++)
            {
                if (GameBoard[0, i] == CurrentPlayer && GameBoard[1, i] == CurrentPlayer && GameBoard[2, i] == CurrentPlayer)
                    return true;
            }

            if (GameBoard[0, 0] == CurrentPlayer && GameBoard[1, 1] == CurrentPlayer && GameBoard[2, 2] == CurrentPlayer)
                return true;

            if (GameBoard[0, 2] == CurrentPlayer && GameBoard[1, 1] == CurrentPlayer && GameBoard[2, 0] == CurrentPlayer)
                return true;

            return false;
        }

        public void ToggleCurrentPlayer()
        {
            CurrentPlayer = CurrentPlayer == 'X' ? 'O' : 'X';
        }

    }

    }
