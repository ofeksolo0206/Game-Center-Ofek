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
using static System.Formats.Asn1.AsnWriter;

namespace GameCenter.Projects.SniperShootingGame
{
    /// <summary>
    /// Interaction logic for SniperShootingGame.xaml
    /// </summary>
    public partial class SniperShootingGame : Window
    {
        ImageBrush backgroundImage = new ImageBrush();
        ImageBrush ghostSprite = new ImageBrush();

        DispatcherTimer DummyMoveTimer = new DispatcherTimer();
        DispatcherTimer showGhostTimer = new DispatcherTimer();


        int topCount = 0;
        int bottomCount = 0;

        int score;
        int miss;

        List<int> topLocation;
        List<int> bottomLocation;

        List<Rectangle> removeThis = new List<Rectangle>();

        Random random = new Random();
        public SniperShootingGame()
        {
            InitializeComponent();

            GameCanvas.Focus();
            this.Cursor = Cursors.None;

            backgroundImage.ImageSource = new BitmapImage(new Uri("C:\\Users\\OFEK SOLOMON\\Desktop\\GameCenter\\GameCenter\\Projects\\SniperShootingGame\\Assets\\background.png"));
            GameCanvas.Background = backgroundImage;

            scopeImage.Source = new BitmapImage(new Uri("C:\\Users\\OFEK SOLOMON\\Desktop\\GameCenter\\GameCenter\\Projects\\SniperShootingGame\\Assets\\sniper-aim.png"));
            scopeImage.IsHitTestVisible = false;

            ghostSprite.ImageSource = new BitmapImage(new Uri("C:\\Users\\OFEK SOLOMON\\Desktop\\GameCenter\\GameCenter\\Projects\\SniperShootingGame\\Assets\\ghost.png"));

            DummyMoveTimer.Tick += DummyMoveTick;
            DummyMoveTimer.Interval = TimeSpan.FromMilliseconds(random.Next(800,2000));
            DummyMoveTimer.Start();

            showGhostTimer.Tick += GhostAnimation;
            showGhostTimer.Interval = TimeSpan.FromMilliseconds(30);
            showGhostTimer.Start();

            topLocation = new List<int>() { 270, 540, 23, 540, 270, 23 };
            bottomLocation = new List<int>() { 133, 678, 420, 678, 133, 420 };

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

        
        ///decides which color the dummy will have and adding it to the game canvas
        private void ShowDummies(int x, int y, int skin, string tag)
        {
            ImageBrush dummyBackground = new ImageBrush();

            switch (skin)
            {
                case 1:
                    dummyBackground.ImageSource = new BitmapImage(new Uri("C:\\Users\\OFEK SOLOMON\\Desktop\\GameCenter\\GameCenter\\Projects\\SniperShootingGame\\Assets\\dummy01.png"));
                    break;

                case 2:
                    dummyBackground.ImageSource = new BitmapImage(new Uri("C:\\Users\\OFEK SOLOMON\\Desktop\\GameCenter\\GameCenter\\Projects\\SniperShootingGame\\Assets\\dummy02.png"));
                    break;

                case 3:
                    dummyBackground.ImageSource = new BitmapImage(new Uri("C:\\Users\\OFEK SOLOMON\\Desktop\\GameCenter\\GameCenter\\Projects\\SniperShootingGame\\Assets\\dummy03.png"));
                    break;

                case 4:
                    dummyBackground.ImageSource = new BitmapImage(new Uri("C:\\Users\\OFEK SOLOMON\\Desktop\\GameCenter\\GameCenter\\Projects\\SniperShootingGame\\Assets\\dummy04.png"));
                    break;
            }


            Rectangle newRec = new Rectangle
            {
                Tag = tag,
                Width = 80,
                Height = 155,
                Fill = dummyBackground
            };

            Canvas.SetLeft(newRec, x);
            Canvas.SetTop(newRec, y);

            GameCanvas.Children.Add(newRec);
        }

        ///showing the ghost when succeed to hit the dummy + update score & misses
        private void GhostAnimation(object? sender, EventArgs e)
        {
            scoreText.Content = "Score: " + score;
            missText.Content = "Missed: " + miss;

            foreach(var x in GameCanvas.Children.OfType<Rectangle>())
            {
                if((string)x.Tag == "ghost")
                {
                    Canvas.SetTop(x, Canvas.GetTop(x) - 5);
                    if(Canvas.GetTop(x) < 0)
                    {
                        removeThis.Add(x);
                    }
                }
            }

            foreach (Rectangle y in removeThis)
            {
                GameCanvas.Children.Remove(y);
            }

        }

        ///makes a random pair of dummies from top and bottom appears for a random time on the game canvas
        private void DummyMoveTick(object? sender, EventArgs e)
        {
            removeThis.Clear();

            foreach (var i in GameCanvas.Children.OfType<Rectangle>())
            {
                if((string)i.Tag =="top" ||  (string)i.Tag == "bottom")
                {
                    removeThis.Add(i);

                    topCount--;
                    bottomCount--;

                    miss++;

                    if(miss >= 20)
                    {
                        DummyMoveTimer.Stop();
                        MessageBoxResult result = MessageBox.Show("Game Over! Would you like to play again?", "Game Over", MessageBoxButton.YesNo);
                        if (result == MessageBoxResult.Yes)
                        {
                            score = 0;
                            miss = 0;
                            scoreText.Content = "Score: " + score;
                            scoreText.Content = "Missed: " + score;
                            GameCanvas.Children.Clear();
                        }
                        if (result == MessageBoxResult.No)
                        {
                            Close();
                        }
                    }

                }
            }

            //-makes sure there wont be 2 dummies together in the same window-//
            if(topCount < 3)
            {
                ShowDummies(topLocation[random.Next(0,5)], 35, random.Next(1,5), "top");
                topCount++;
            }

            if (bottomCount < 3)
            {
                ShowDummies(bottomLocation[random.Next(0, 5)], 230, random.Next(1, 5), "bottom");
                bottomCount++;
            }
        }


        ///if the aim click the dummy, remove the dummy from the canvas + add the ghost to the canvas + add 1 to score
        private void ShootDummy(object sender, MouseButtonEventArgs e)
        {
            if(e.OriginalSource is Rectangle)
            {
                Rectangle activeRec = (Rectangle)e.OriginalSource;

                if((string)activeRec.Tag == "top" || (string)activeRec.Tag == "bottom")
                {
                    GameCanvas.Children.Remove(activeRec);

                    score++;

                    Rectangle ghostRec = new Rectangle
                    {
                        Width = 60,
                        Height = 60,
                        Fill = ghostSprite,
                        Tag = "ghost",
                    };

                    Canvas.SetLeft(ghostRec, Mouse.GetPosition(GameCanvas).X - 40);
                    Canvas.SetTop(ghostRec, Mouse.GetPosition(GameCanvas).Y - 60);

                    GameCanvas.Children.Add(ghostRec);
                }

                if((string)activeRec.Tag == "top")
                {
                    topCount--;
                }

                if ((string)activeRec.Tag == "bottom")
                {
                    bottomCount--;
                }
            }
        }

        
    }
}
