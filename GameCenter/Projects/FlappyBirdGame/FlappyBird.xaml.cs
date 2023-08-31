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

        double score;
        double record;
        bool isNewRecord = false;
        int gravity = 8;
        bool gameOver;
        Rect flappyBirdHitBox;
        public FlappyBird()
        { 
            InitializeComponent();

            gameTimer.Tick += MainEventTimer;
            gameTimer.Interval = TimeSpan.FromMilliseconds(30);
            StartGame();
        }

        private void MainEventTimer(object? sender, EventArgs e)
        {
            ScoreText.Content = "Score: " + score;
            RecordText.Content = "Record: "+ record;

            flappyBirdHitBox = new Rect(Canvas.GetLeft(Bird), Canvas.GetTop(Bird), Bird.Width - 30, Bird.Height ) ;
            Canvas.SetTop(Bird, Canvas.GetTop(Bird) + gravity);

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
                        score += .5;
                        if(score > record)
                        {
                            record = score;
                            isNewRecord = true;
                        }
                    }

                    Rect pipeHitBox = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);

                    if (flappyBirdHitBox.IntersectsWith(pipeHitBox))
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
                gravity = -8;
            }

            if (e.Key == Key.R && gameOver == true)
            {
                StartGame();
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Space)
            {
                Bird.RenderTransform = new RotateTransform(5, Bird.Width/2, Bird.Height/2);
                gravity = 8;
            }
        }

        private void StartGame()
        {
            GameCanvas.Focus();
            int temp = 300;
            score = 0;
            isNewRecord = false;
            gameOver = false;
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
            gameOver = true;
            ScoreText.Content = "Game Over! Press R to try again";
            if (isNewRecord)
            {
                RecordText.Content = $"Record: {record}. New Record Achived!";
            } 
        }
    }
}



