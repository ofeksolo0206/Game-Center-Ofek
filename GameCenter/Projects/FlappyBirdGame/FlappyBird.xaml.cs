using GameCenter.Projects.FlappyBirdGame.Models;
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

namespace GameCenter.Projects.FlappyBirdGame
{
    /// <summary>
    /// Interaction logic for FlappyBird.xaml
    /// </summary>
    public partial class FlappyBird : Window
    {
        DispatcherTimer gameTimer = new DispatcherTimer();

       FlappyBirdModel flappyBird = new FlappyBirdModel();
        public FlappyBird()
        { 
            InitializeComponent();

            gameTimer.Tick += MainEventTimer;
            gameTimer.Interval = TimeSpan.FromMilliseconds(20);
            StartGame();
        }

        private void MainEventTimer(object? sender, EventArgs e)
        {
            ScoreText.Content = "Score: " + flappyBird.Score;
            RecordText.Content = "Record: "+ flappyBird.Record;

            flappyBird.SetBirdPosition(Bird);
            Canvas.SetTop(Bird, Canvas.GetTop(Bird) + flappyBird.Gravity);

            if(Canvas.GetTop(Bird) < -10|| Canvas.GetTop(Bird) > 458)
            {
                EndGame();
            }

            foreach(var x in GameCanvas.Children.OfType<Image>())
            {
                if((string)x.Tag == "obs1" ||  (string)x.Tag == "obs2" || (string)x.Tag == "obs3")
                {
                    Canvas.SetLeft(x, Canvas.GetLeft(x) - 10);

                    if(Canvas.GetLeft(x) < -100)
                    {
                        Canvas.SetLeft(x, 800);
                        flappyBird.Score += .5;
                        if(flappyBird.CheckForNewRecord() == true)
                        {
                            RecordText.Content = $"Record: {flappyBird.Record}";
                        }
                    }

                    Rect pipeHitBox = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);

                    if (flappyBird.BirdHitBox.IntersectsWith(pipeHitBox))
                    {
                        EndGame();
                    }
                }

                if((string)x.Tag == "cloud")
                {
                    Canvas.SetLeft(x, Canvas.GetLeft(x) - 2);

                    if(Canvas.GetLeft(x) < -250)
                    {
                        Canvas.SetLeft(x, 550);
                    }

                }
            }
        
        }

        private void StartGame()
        {
            flappyBird.IsGameOver = false;
            flappyBird.Score = 0;
            GameCanvas.Focus();
            int temp = 300;
            Canvas.SetTop(Bird, 190);

            foreach (var x in GameCanvas.Children.OfType<Image>())
            {
                if ((string)x.Tag == "obs1")
                {
                    Canvas.SetLeft(x, 500);
                }
                if ((string)x.Tag == "obs2")
                {
                    Canvas.SetLeft(x, 800);
                }
                if ((string)x.Tag == "obs3")
                {
                    Canvas.SetLeft(x, 1100);
                }
                if ((string)x.Tag == "cloud")
                {
                    Canvas.SetLeft(x, 300 + temp);
                    temp = 800;
                }
            }

            gameTimer.Start();
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.R && flappyBird.IsGameOver == true) StartGame();

            else flappyBird.BirdUp(e.Key,Bird);
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            flappyBird.BirdDown(e.Key,Bird);
        }

        private void EndGame()
        {
            gameTimer.Stop();
            ScoreText.Content = flappyBird.EndGameText();
        }
    }
}



