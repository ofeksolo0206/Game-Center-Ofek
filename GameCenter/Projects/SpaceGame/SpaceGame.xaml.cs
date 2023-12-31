﻿using GameCenter.Projects.SpaceGame.Models;
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

namespace GameCenter.Projects.SpaceGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class SpaceGame : Window
    {
        private PlayerCar playerCar;
        private List<Obstacle> obstacles;
        private Random random;
        private int score;
        private int record;
        DispatcherTimer gameTimer = new DispatcherTimer();
        public SpaceGame()
        {
            InitializeComponent();
            backgroundVideo.Source = new Uri("Projects/SpaceGame/Assets/galaxy.mp4", UriKind.Relative);
            backgroundVideo.Play();


            playerCar = new PlayerCar(200, 300, 3, playerImage);
            obstacles = new List<Obstacle>();
            random = new Random();


            gameTimer.Interval = TimeSpan.FromMilliseconds(10);
            gameTimer.Tick += GameLoop;
            gameTimer.Start();

            this.Closed += SpaceGame_Closed;

        }

        public object MessageBoxButtons { get; private set; }

        private void SpaceGame_Closed(object sender, EventArgs e)
        {
            backgroundVideo.Stop();
            gameTimer.Stop();
        }

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


        private void GameLoop(object ? sender, EventArgs e)
        {
            bool isGameOver = false;
            playerCar.Move();

            if (random.Next(0, 50) == 1)
            {
                Image obstacleImage = new Image();
                var uri1 = new Uri("Assets/alianSpaceship.png", UriKind.Relative);
                obstacleImage.Source = new BitmapImage(uri1);
                obstacleImage.Width = 70;
                obstacleImage.Height = 70;
                Obstacle obstacle = new Obstacle(random.Next(0, (int)Width), 0, 2, obstacleImage);
                obstacles.Add(obstacle);
                gameCanvas.Children.Add(obstacleImage);
            }

            double collisionBuffer = 15;
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
                    if (score > record)
                    {
                        record = score;
                        recordTextBlock.Text = "Record: " + score;
                    }
                    scoreTextBlock.Text = "score: " + score;
                }

                if (playerCar.Representation.Margin.Left + playerCar.Representation.Width - collisionBuffer >= obstacle.Representation.Margin.Left + collisionBuffer
                   && playerCar.Representation.Margin.Left + collisionBuffer <= obstacle.Representation.Margin.Left + obstacle.Representation.Width - collisionBuffer
                   && playerCar.Representation.Margin.Top + collisionBuffer <= obstacle.Representation.Margin.Top + obstacle.Representation.Height - collisionBuffer
                   && playerCar.Representation.Margin.Top + playerCar.Representation.Height - collisionBuffer >= obstacle.Representation.Margin.Top + collisionBuffer)
                {
                    
                    (sender as DispatcherTimer)!.Stop();
                    isGameOver = true;
                    break;
                }
            }

            if (isGameOver)
            {
                backgroundVideo.Stop();
                playerCar.LeftKeyPressed = false;
                playerCar.RightKeyPressed = false;

                MessageBoxResult result = MessageBox.Show($"Your Best Score is: {record} \n would you like to play again?", "Game Over", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {

                    score = 0;
                    scoreTextBlock.Text = "score: " + score;
                    foreach (var obstacle in obstacles)
                    {
                        gameCanvas.Children.Remove(obstacle.Representation);
                    }

                    obstacles.Clear();
                    playerCar.X = 200;
                    playerCar.Y = 300;
                    (sender as DispatcherTimer)!.Start();
                    backgroundVideo.Play();
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
