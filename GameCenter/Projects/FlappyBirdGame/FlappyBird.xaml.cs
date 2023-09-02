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
            gameTimer.Interval = TimeSpan.FromMilliseconds(25);
            StartGame();
        }

        private void MainEventTimer(object? sender, EventArgs e)
        {
            ScoreText.Content = "Score: " + flappyBird.score;
            RecordText.Content = "Record: "+ flappyBird.record;

            flappyBird.birdHitBox = new Rect(Canvas.GetLeft(Bird), Canvas.GetTop(Bird), Bird.Width - 30, Bird.Height ) ;
            Canvas.SetTop(Bird, Canvas.GetTop(Bird) + flappyBird.gravity);

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
                        flappyBird.score += .5;
                        if(flappyBird.score > flappyBird.record)
                        {
                            flappyBird.record = flappyBird.score;
                            flappyBird.isNewRecord = true;
                        }
                    }

                    Rect pipeHitBox = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);

                    if (flappyBird.birdHitBox.IntersectsWith(pipeHitBox))
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

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                Bird.RenderTransform = new RotateTransform(-20, Bird.Width / 2, Bird.Height / 2);
                flappyBird.gravity = -8;
            }

            if (e.Key == Key.R && flappyBird.gameOver == true)
            {
                StartGame();
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Space)
            {
                Bird.RenderTransform = new RotateTransform(5, Bird.Width/2, Bird.Height/2);
                flappyBird.gravity = 8;
            }
        }

        private void StartGame()
        {
            flappyBird.gameOver = false;
            flappyBird.score = 0;
            GameCanvas.Focus();
            int temp = 300;
            Canvas.SetTop(Bird, 190);

            foreach(var x in GameCanvas.Children.OfType<Image>())
            {
                if((string)x.Tag == "obs1")
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

        private void EndGame()
        {
            gameTimer.Stop();
            flappyBird.gameOver = true;
            ScoreText.Content = "Game Over! Press R to try again";
            if (flappyBird.isNewRecord)
            {
                RecordText.Content = $"Record: {flappyBird.record}. New Record Acheived!";
            } 
        }
    }
}



