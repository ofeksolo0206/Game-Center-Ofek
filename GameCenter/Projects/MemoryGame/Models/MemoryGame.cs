using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GameCenter.Projects.MemoryGame.MemoryGame;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.Windows;

namespace GameCenter.Projects.MemoryGame.Models
{
    public enum matchIconProf
    {
        img1 = 1,
        img2 = 2,
        img3 = 3,
        img4 = 4,
        img5 = 5,
        img6 = 6,
        img7 = 7,
        img8 = 8,
    }
    public class memoryGame
    {
        public readonly int[] testarray = new int[16];
        public int pairsCounter = 0;
        public readonly Button[] xBox;
        public int counter = 0;
        public int[] pressed = new int[2];
        public bool[] opened = new bool[16];
        public int attempts = 15;

        public memoryGame(Button[] box, int[] TArray)
        {

            xBox = box;
            testarray = TArray;

            for (int i = 0; i < 16; i++)
            {
                box[i].Content = "";
            }
        }

        public StackPanel SetImage(matchIconProf test)
        {
            Image img = new Image();
            StackPanel stackPnl = new StackPanel();
            img.Source = new BitmapImage(new Uri("C:\\Users\\OFEK SOLOMON\\Desktop\\GameCenter\\GameCenter\\Projects\\MemoryGame\\Assets\\" + test.ToString() + ".png"));
            stackPnl.Orientation = Orientation.Horizontal;
            stackPnl.Margin = new Thickness(1);
            stackPnl.Children.Add(img);
            return stackPnl;
        }

        public void CheckButton(Button[] box, int index)
        {
            if (counter == 2 || opened[index] || counter == 1 && pressed[0] == index)
                return;

            xBox[index].Content = SetImage((matchIconProf)testarray[index]);
            pressed[counter] = index;
            counter++;
            if (counter == 2)
            {
              bool flag =  ButtonCompare(pressed[0], pressed[1]);
                if (flag == false)
                {

                    attempts--;
                    if (attempts == 0)
                    {
                        MessageBox.Show($"Game Over!\n To play again click the Restart Button");
                        xBox[pressed[0]].Content = "";
                        xBox[pressed[1]].Content = "";
                    }
                }
            }
        }

        public bool ButtonCompare(int check1, int check2)
        {
            bool matching;
            if (testarray[check1] == testarray[check2])
            {
                matching = true;
                pairsCounter += 1;
                opened[check1] = true;
                opened[check2] = true;
                if (pairsCounter == 8)
                {
                    MessageBox.Show($"You won!\n To play again click the restart Button");

                }
                counter = 0;
            }
            else
            {
                matching = false;
                var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(0.5) };
                timer.Start();
                timer.Tick += (sender, args) =>
                {
                    timer.Stop();
                    xBox[check1].Content = "";
                    xBox[check2].Content = "";
                    counter = 0;
                };

            }
            return matching;
        }


    }
}


