using GameCenter.Projects.SniperShootingGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace GameCenter.Projects.SniperShootingGame
{
    /// <summary>
    /// Interaction logic for SniperShootingGame.xaml
    /// </summary>
    public partial class SniperShootingGame : Window
    {
        ShoothingGameModel gameModel = new();

        DispatcherTimer DummyMoveTimer = new DispatcherTimer();
        DispatcherTimer showGhostTimer = new DispatcherTimer();
        Random random = new Random();

        public SniperShootingGame()
        {
            InitializeComponent();
            InitializeGame();
            this.Closed += SniperShootingGame_Closed;
        }

        private void SniperShootingGame_Closed(object sender, EventArgs e)
        {
            DummyMoveTimer.Stop();
            showGhostTimer.Stop();
        }

        private void InitializeGame()
        {
            GameCanvas.Focus();
            this.Cursor = Cursors.None;

            scopeImage.Source = new BitmapImage(new Uri("C:\\Users\\OFEK SOLOMON\\Desktop\\GameCenter\\GameCenter\\Projects\\SniperShootingGame\\Assets\\sniper-aim.png"));
            scopeImage.IsHitTestVisible = false;
            GameCanvas.Background = gameModel.backgroundImage;

            DummyMoveTimer.Tick += DummyMoveTick;
            DummyMoveTimer.Interval = TimeSpan.FromMilliseconds(random.Next(800,2000));
            DummyMoveTimer.Start();

            showGhostTimer.Tick += GhostAnimation;
            showGhostTimer.Interval = TimeSpan.FromMilliseconds(30);
            showGhostTimer.Start();
        }
        // moves the aim by the mouse movement
        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            Point position = e.GetPosition(this);

            double pX = position.X;
            double pY = position.Y;

            Canvas.SetLeft(scopeImage, pX - (scopeImage.Width / 2));
            Canvas.SetTop(scopeImage, pY - (scopeImage.Height / 2));

        } 

        ///showing the ghost when succeed to hit the dummy + update score & misses
        private void GhostAnimation(object? sender, EventArgs e)
        {
            scoreText.Content = "Score: " + gameModel.score;
            missText.Content = "Missed: " + gameModel.miss;

            foreach (var x in GameCanvas.Children.OfType<Rectangle>())
            {
                if ((string)x.Tag == "ghost")
                {
                    Canvas.SetTop(x, Canvas.GetTop(x) - 5);
                    if (Canvas.GetTop(x) < 0)
                    {
                        gameModel.removeThis.Add(x);
                    }
                }
            }

            foreach (Rectangle y in gameModel.removeThis)
            {
                GameCanvas.Children.Remove(y);
            }
        
        }

        ///makes a random pair of dummies from top and bottom appears for a random time on the game canvas
        private void DummyMoveTick(object? sender, EventArgs e)
        {
            gameModel.removeThis.Clear();

            foreach (var dummy in GameCanvas.Children.OfType<Rectangle>())
            {
                if ((string)dummy.Tag == "top" || (string)dummy.Tag == "bottom")
                {
                    gameModel.RectanglesListsHandler(dummy);
                }
                if (gameModel.miss >= 10)
                {
                    DummyMoveTimer.Stop();
                    List<Rectangle> rectangles = GameCanvas.Children.OfType<Rectangle>().ToList();
                    foreach (Rectangle rect in rectangles)
                    {
                        GameCanvas.Children.Remove(rect);
                    }

                    if (gameModel.GameOverMessage() == true)
                    {
                        scoreText.Content = "Score: " + gameModel.score;
                        missText.Content = "Missed: " + gameModel.score;
                        DummyMoveTimer.Start();
                        return;
                    }
                    else
                    {
                        Close();
                        break;
                    }
                }
            }
            gameModel.AddDummyRec(GameCanvas);
        }

        ///if the aim click the dummy, remove the dummy from the canvas + add the ghost to the canvas + add 1 to score
        private void ShootDummy(object sender, MouseButtonEventArgs e)
        {
            if(e.OriginalSource is Rectangle)
            {
                gameModel.ShootDummy((Rectangle)e.OriginalSource, GameCanvas);
            }
        }
    }
}
