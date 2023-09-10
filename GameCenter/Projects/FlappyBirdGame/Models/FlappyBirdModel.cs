using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace GameCenter.Projects.FlappyBirdGame.Models
{

    internal class FlappyBirdModel
    {
        public double Score { get; set; }
        public double Record { get; set; }
        public int Gravity { get; set; }
        public bool IsGameOver { get; set; }
        public Rect BirdHitBox { get; set; }
        public Rect PipeHitBox { get; set; }

        public FlappyBirdModel()
        { 
            Score = 0;
            Record = 0;
            Gravity = 8;
            IsGameOver = false;
            BirdHitBox = new Rect();
        }

        public void SetBirdPosition(Image bird)
        {
            BirdHitBox = new Rect(Canvas.GetLeft(bird), Canvas.GetTop(bird), bird.Width - 30, bird.Height);
        }

        public bool CheckForNewRecord()
        {
            if(Score > Record)
            {
                Record = Score;
            }
            return true;
        }

        public string EndGameText()
        {
            IsGameOver = true;
            return "Game Over! Press R to try again";
        }

        public void BirdUp(Key key,Image bird)
        {
            if(key == Key.Space)
            {
                bird.RenderTransform = new RotateTransform(-20, bird.Width / 2, bird.Height / 2);
                Gravity = -8;
            }
        }

        public void BirdDown(Key key, Image bird)
        {
            if (key == Key.Space)
            {
                bird.RenderTransform = new RotateTransform(5, bird.Width / 2, bird.Height / 2);
                Gravity = 8;
            }
        }

    }
}
