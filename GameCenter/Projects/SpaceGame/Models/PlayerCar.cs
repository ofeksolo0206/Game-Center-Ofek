using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GameCenter.Projects.SpaceGame.Models
{
    internal class PlayerCar : GameObject
    {
        public bool LeftKeyPressed { get; set; }
        public bool RightKeyPressed { get; set; }
        public PlayerCar(int x, int y, int speed, Image playerImage) : base(x, y, speed, playerImage)
        {

        }

        public override void Move()
        {
            if (LeftKeyPressed && X > 0)
            {
                X -= Speed;
            }

            if (RightKeyPressed && X < 800 - Representation.Width) 
            {
                X += Speed;
            }
            Draw();
        }

    }
}
