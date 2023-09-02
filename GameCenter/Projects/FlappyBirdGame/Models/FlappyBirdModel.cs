using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GameCenter.Projects.FlappyBirdGame.Models
{

    internal class FlappyBirdModel
    {
        public double score { get; set; }
        public double record { get; set; }
        public bool isNewRecord { get; set; }
        public int gravity { get; set; }
        public bool gameOver { get; set; }
        public Rect birdHitBox { get; set; }
        public Rect pipeHitBox { get; set; }

        public FlappyBirdModel(double score = 0, double record = 0, bool isNewRecord = false, int gravity = 8, bool gameOver = false)
        { 
            this.score = score;
            this.record = record;
            this.isNewRecord = isNewRecord;
            this.gravity = gravity;
            this.gameOver = gameOver;
        }
    }
}
