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
using System.Threading;
using System.Windows.Threading;

namespace GameCenter.Projects.SaimonGame
{
    /// <summary>
    /// Interaction logic for SaimonGame.xaml
    /// </summary>
    public partial class SaimonGame : Window
    {
        int scoreCount = 0;
        int record;
        Random random = new Random();
        bool talk = false;
        List<double> CurrentSequence;

        public SaimonGame()
        {
            random = new Random();
            CurrentSequence = new List<double>();
            InitializeComponent();
        }
        private void startGame_Click(object sender, RoutedEventArgs e)
        {
            Score.Text = "Score: " + scoreCount;
            CurrentSequence.Add(random.Next(0,4));
            Simon_Talk();
            scoreCount = 0;
        }

        private void GameOver()
        {
            MessageBoxResult result = MessageBox.Show("Game Over! Would you like to play again?", "Game Over", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                scoreCount = 0;
                Score.Text = "Score: " + scoreCount;
                CurrentSequence.Clear();
                Red_0.Opacity = 1;
                Yellow_1.Opacity = 1;
                Blue_2.Opacity = 1;
                Green_3.Opacity = 1;

            }
            if (result == MessageBoxResult.No)
            {
                Close();
            }
        }

        private void Simon_Talk()
        {
            var timer1 = new DispatcherTimer { Interval = TimeSpan.FromSeconds(0.4) };
            var timer2 = new DispatcherTimer { Interval = TimeSpan.FromSeconds(CurrentSequence.Count / 10 + 0.8) };
            talk = true;

            foreach (int i in CurrentSequence)
            {
                switch (i)
                {
                    case 0:
                        timer1.Start();
                        timer1.Tick += (sender, args) =>
                        {
                            Red_0.Opacity = 0.5;
                            timer1.Stop();
                        };
                        timer2.Start();
                        timer2.Tick += (sender, args) =>
                        {
                            Red_0.Opacity = 1;
                            timer2.Stop();
                        };
                        break;

                    case 1:
                        timer1.Start();
                        timer1.Tick += (sender, args) =>
                        {
                            Yellow_1.Opacity = 0.5;
                            timer1.Stop();
                        };
                        timer2.Start();
                        timer2.Tick += (sender, args) =>
                        {
                            Yellow_1.Opacity = 1;
                            timer2.Stop();
                        };
                        break;

                    case 2:
                        timer1.Start();
                        timer1.Tick += (sender, args) =>
                        {
                            Blue_2.Opacity = 0.5;
                            timer1.Stop();
                        };
                        timer2.Start();
                        timer2.Tick += (sender, args) =>
                        {
                            Blue_2.Opacity = 1;
                            timer2.Stop();
                        };
                        break;

                    case 3:
                        timer1.Start();
                        timer1.Tick += (sender, args) =>
                        {
                            Green_3.Opacity = 0.5;
                            timer1.Stop();
                        };
                        timer2.Start();
                        timer2.Tick += (sender, args) =>
                        {
                            Green_3.Opacity = 1;
                            timer2.Stop();
                        };
                        break;
                }
            }
            talk = false;
        }

        private void Verify_Sequence(int button_pressed)
        {
            if (talk == false && CurrentSequence.Count > 0)
            {
                {
                    if (scoreCount >= CurrentSequence.Count)
                    {
                        GameOver();
                    }
                    else
                        if (button_pressed == CurrentSequence[scoreCount])
                    {
                        scoreCount++;
                        Score.Text = "Score: " + scoreCount;

                        if(scoreCount > record)
                        {
                            record = scoreCount;
                            Record.Text = "Best Score: " + record;
                        }
                    }
                    else
                    {
                        GameOver();
                    }
                }

            }
        }

        private void Button_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Image image = (sender as Image)!;
            image.Opacity = 0.5;
            Verify_Sequence(int.Parse(image.Name.ToString().Split('_')[1]));
        }

        private void Button_MouseUp(object sender, MouseEventArgs e)
        {
            Image image = (sender as Image)!;
            image.Opacity = 1;
        }
    }
}