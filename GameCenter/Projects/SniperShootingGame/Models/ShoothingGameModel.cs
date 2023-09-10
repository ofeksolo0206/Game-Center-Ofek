using System;
using System.Collections.Generic;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows;
using System.Windows.Controls;
using System.Linq;
using System.Windows.Input;

namespace GameCenter.Projects.SniperShootingGame.Models
{
    class ShoothingGameModel
    {
        Random random = new Random();
        public ImageBrush ghostSprite = new ImageBrush();
        public ImageBrush backgroundImage = new ImageBrush();
        public int score;
        public int miss;
        public int topCount;
        public int bottomCount;
        public List<int> topLocation { get; set; }
        public List<int> bottomLocation { get; set; }
        public List<Rectangle> removeThis = new List<Rectangle>();

        public ShoothingGameModel()
        {

            score = 0;
            miss = 0;
            topCount = 0;
            bottomCount = 0;
            topLocation = new List<int>() { 270, 540, 23, 540, 270, 23 };
            bottomLocation = new List<int>() { 133, 678, 420, 678, 133, 420 };
            backgroundImage.ImageSource = new BitmapImage(new Uri("C:\\Users\\OFEK SOLOMON\\Desktop\\GameCenter\\GameCenter\\Projects\\SniperShootingGame\\Assets\\background.png"));
            ghostSprite.ImageSource = new BitmapImage(new Uri("C:\\Users\\OFEK SOLOMON\\Desktop\\GameCenter\\GameCenter\\Projects\\SniperShootingGame\\Assets\\ghost.png"));
        }

        public Rectangle CreateRectangle(int width, int height, ImageBrush image, string tag)
        {
            Rectangle rectangle = new Rectangle()
            {
                Width = width,
                Height = height,
                Fill = image,
                Tag = tag
            };
            return rectangle;
        }

        public void CreateDummy(int x, int y,int skin, string tag, Canvas gameCanvas)
        {
            ImageBrush dummyBackground = new();

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

            Rectangle dummyRec = CreateRectangle(80, 155, dummyBackground, tag);
            Canvas.SetLeft(dummyRec, x);
            Canvas.SetTop(dummyRec, y);
            gameCanvas.Children.Add(dummyRec);
        }

        public void RectanglesListsHandler(Rectangle dummy)
        {
            removeThis.Add(dummy);
            topCount--;
            bottomCount--;
            miss++;
        }

        public void AddDummyRec(Canvas gameCanvas)
        {
            if(topCount < 3)
            {
                CreateDummy(topLocation[random.Next(0, 5)], 35, random.Next(1, 5), "top", gameCanvas);
            }

            if (bottomCount < 3)
            {
                CreateDummy(bottomLocation[random.Next(0, 5)], 230, random.Next(1, 5), "bottom", gameCanvas);
                bottomCount++;
            }
        }

        public void ShootDummy(Rectangle Shooteddummy ,Canvas gameCanvas)
        {
            gameCanvas.Children.Remove(Shooteddummy);
            score++;
            Rectangle ghostRec = CreateRectangle(60, 60, ghostSprite, "ghost");
            Canvas.SetLeft(ghostRec, Mouse.GetPosition(gameCanvas).X - 40);
            Canvas.SetTop(ghostRec, Mouse.GetPosition(gameCanvas).Y - 60);
            gameCanvas.Children.Add(ghostRec);

            if(Shooteddummy.Tag == "top")
            {
                topCount-- ;
            }
            if (Shooteddummy.Tag == "bottom")
            {
                bottomCount--;
            }
        }

        public bool GameOverMessage()
        {
            MessageBoxResult result = MessageBox.Show("Game Over! Would you like to play again?", "Game Over", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                score = 0;
                miss = 0;
                return true;
            }
            if (result == MessageBoxResult.No)
            {
                return false;
            }
            return false;
        }


    }
}
