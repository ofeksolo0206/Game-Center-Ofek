using GameCenter.Projects.MemoryGame.Model;
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
           // StartClock();
        }
        int time = 60;
        memoryGame currentGame;
        Button[] buttons = new Button[16];
        Random random = new Random();
        int[] doubleIndexArray = new int[16];

        private void StartClock()
        {
            DispatcherTimer timer = new()
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            timer.Tick += Tick;
            timer.Start();
        }

        private void Tick(object sender, EventArgs e)
        {
            timer.Content = timer;
            time--;
        }

        

        private void ResetButton(object sender, RoutedEventArgs e)
        {
            if (currentGame != null)
            {
                for (int i = 0; i < 16; i++)
                {
                    buttons[i].Content = "";
                }
                currentGame = null;
            }
        }
        private void StartButton(object sender, RoutedEventArgs e)
        {
            if (currentGame == null)
            {
                var test = Enumerable.Range(1, 16).OrderBy(x => random.Next()).ToArray();
                for (int i = 0; i < 16; i++)
                {
                    buttons[i] = wrapPanel.Children[i] as Button;
                    doubleIndexArray[i] = (test[i] - 1) % 8 + 1;
                }
                currentGame = new memoryGame(buttons, doubleIndexArray);
            }
        }

        private void CardClick(object sender, RoutedEventArgs e)
        {
            if (currentGame != null)
            {
                int buttonName = int.Parse((sender as Button).Name.Substring(6)) - 1;
                currentGame.CheckButton(buttons, buttonName);
            }
        }

        
    }
}
