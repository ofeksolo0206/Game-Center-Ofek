using GameCenter.Projects.MemoryGame.Models;
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
using System.Windows.Threading;

namespace GameCenter.Projects.MemoryGame
{
    /// <summary>
    /// Interaction logic for MemoryGame.xaml
    /// </summary>
    public partial class MemoryGame : Window
    {
        public MemoryGame()
        {
            InitializeComponent();
        }
        memoryGame? currentGame;
        Button[] buttons = new Button[16];
        Random random = new Random();
        int[] doubleIndexArray = new int[16];


        private void StartButton(object sender, RoutedEventArgs e)
        {
            if(currentGame != null)
            {
                currentGame.pairsCounter = 0;
                //attemptsText.Text = $"Attempts: 15";

                for (int i = 0; i < 16; i++)
                {
                    buttons[i].Content = "";
                }
                currentGame = null;
            }

            if (currentGame == null)
            {
                var test = Enumerable.Range(1, 16).OrderBy(x => random.Next()).ToArray();
                for (int i = 0; i < 16; i++)
                {
                    buttons[i] = (Button)wrapPanel.Children[i];
                    doubleIndexArray[i] = (test[i] - 1) % 8 + 1;
                }
                currentGame = new memoryGame(buttons, doubleIndexArray);
                currentGame.pairsCounter = 0;
                attemptsText.Text = $"Attempts: {currentGame.attempts}";
            }
        }

        private void CardClick(object sender, RoutedEventArgs e)
        {
            if (currentGame != null)
            {
                int buttonName = int.Parse(((Button)sender).Name.Substring(6)) - 1;
                currentGame.CheckButton(buttons, buttonName);
                attemptsText.Text = $"Attempts: {currentGame.attempts}";
            }
        }


    }
}