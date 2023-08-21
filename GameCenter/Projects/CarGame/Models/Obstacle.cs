using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GameCenter.Projects.CarGame.Models
{
    public class Obstacle : GameObject
    {
        private int direction;

        public Obstacle(int x, int y, int speed, Image carImage) : base(x, y, speed, carImage)
        {
            Random rand = new Random();
            direction = rand.Next(-1, 2);
        }

        public override void Move()
        {
            Y += Speed;
            X += direction * Speed;
            Draw();
        }
    }
}
