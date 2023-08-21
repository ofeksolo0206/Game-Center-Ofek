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

namespace GameCenter.Projects.MemoryGame.Model
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
            

        //initializing the buttons array
        public memoryGame(Button[] box, int[] TArray)
        {

            xBox = box;
            testarray = TArray;

            for (int i = 0; i < 16; i++)
            {
                box[i].Content = "";
            }
        }
            //add image to the clicked button
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

        //wait for a pair of cards , if there is a pair - check for a match
        public void CheckButton(Button[] box, int index)
        {
            if (counter == 2 || opened[index] || counter == 1 && pressed[0] == index)
                return;

            xBox[index].Content = SetImage((matchIconProf)testarray[index]);
            pressed[counter] = index;
            counter++;
            if (counter == 2)
            {
                ButtonCompare(pressed[0], pressed[1]);
            }
        }

        //compare between 2 cards: match = keep them open / unmatch = clear their content
        public void ButtonCompare(int check1, int check2)
        {

            if (testarray[check1] == testarray[check2])
            {
                pairsCounter++;
                opened[check1] = true;
                opened[check2] = true;
                if (pairsCounter == 8)
                {
                    MessageBox.Show("You Won!!!!!");
                }
                counter = 0;
            }
            else
            {
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
        }


    }
}


