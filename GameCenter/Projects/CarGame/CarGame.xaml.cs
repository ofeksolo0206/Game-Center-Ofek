using GameCenter.Projects.CarGame.Models;
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

namespace GameCenter.Projects.CarGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class CarGame : Window
    {
        private PlayerCar playerCar;
        private List<Obstacle> obstacles;
        private Random random;
        private int score;

        public CarGame()
        {
            InitializeComponent();
            backgroundVideo.Source = new Uri("C:\\Users\\OFEK SOLOMON\\Desktop\\GameCenter\\GameCenter\\Projects\\CarGame\\Assets\\roadway.mp4");
            backgroundVideo.Play();


            playerCar = new PlayerCar(200, 300, 2, playerCarImage);
            obstacles = new List<Obstacle>();
            random = new Random();

            DispatcherTimer gameTimer = new DispatcherTimer();
            gameTimer.Interval = TimeSpan.FromMilliseconds(20);
            gameTimer.Tick += GameLoop;
            gameTimer.Start();

        }

        public object MessageBoxButtons { get; private set; }

        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {

            switch (e.Key)
            {
                case Key.Left:
                    playerCar.LeftKeyPressed = true;
                    break;
                case Key.Right:
                    playerCar.RightKeyPressed = true;
                    break;
            }
        }

        protected override void OnPreviewKeyUp(KeyEventArgs e)
        {

            switch (e.Key)
            {
                case Key.Left:
                    playerCar.LeftKeyPressed = false;
                    break;
                case Key.Right:
                    playerCar.RightKeyPressed = false;
                    break;
            }
        }


        private void GameLoop(object sender, EventArgs e)
        {
            bool isGameOver = false;
            playerCar.Move();

            if (random.Next(0, 50) == 1)
            {
                Image obstacleImage = new Image();
                obstacleImage.Source = new BitmapImage(new Uri("C:\\Users\\OFEK SOLOMON\\Desktop\\GameCenter\\GameCenter\\Projects\\CarGame\\Assets\\bomb.png"));
                obstacleImage.Width = 50;
                obstacleImage.Height = 50;
                Obstacle obstacle = new Obstacle(random.Next(0, (int)Width), 0, 2, obstacleImage);
                obstacles.Add(obstacle);
                gameCanvas.Children.Add(obstacleImage);
            }

            double collisionBuffer = 5;
            List<Obstacle> copiedList = new List<Obstacle>(obstacles);

            foreach (var obstacle in copiedList)
            {
                obstacle.Move();

                if (obstacle.Representation.Margin.Top > this.Height ||
                    obstacle.Representation.Margin.Left + obstacle.Representation.Width < 0 ||
                    obstacle.Representation.Margin.Left > this.Width)
                {

                    gameCanvas.Children.Remove(obstacle.Representation);
                    obstacles.Remove(obstacle);
                    score++;
                    scoreTextBlock.Text = "score: " + score;
                }

                if (playerCar.Representation.Margin.Left + playerCar.Representation.Width - collisionBuffer >= obstacle.Representation.Margin.Left + collisionBuffer
                   && playerCar.Representation.Margin.Left + collisionBuffer <= obstacle.Representation.Margin.Left + obstacle.Representation.Width - collisionBuffer
                   && playerCar.Representation.Margin.Top + collisionBuffer <= obstacle.Representation.Margin.Top + obstacle.Representation.Height - collisionBuffer
                   && playerCar.Representation.Margin.Top + playerCar.Representation.Height - collisionBuffer >= obstacle.Representation.Margin.Top + collisionBuffer)
                {
                    // End the game

                    (sender as DispatcherTimer).Stop();
                    isGameOver = true;
                    break;
                }
            }

            if (isGameOver)
            {
                score = 0;
                scoreTextBlock.Text = "score: " + score;
                MessageBoxResult result = MessageBox.Show("Game Over! Would you like to play again?", "Game Over", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    foreach (var obstacle in obstacles)
                    {
                        gameCanvas.Children.Remove(obstacle.Representation);
                    }

                    obstacles.Clear();
                    playerCar.X = 200;
                    playerCar.Y = 300;
                    (sender as DispatcherTimer).Start();

                }
                if (result == MessageBoxResult.No)
                {
                    Close();
                }

            }


        }


        private void MediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            backgroundVideo.Position = TimeSpan.Zero;
            backgroundVideo.Play();
        }

        private void MediaElement_MediaFailed(object sender, ExceptionRoutedEventArgs e)
        {
            MessageBox.Show(e.ErrorException.Message);
        }


    }
}