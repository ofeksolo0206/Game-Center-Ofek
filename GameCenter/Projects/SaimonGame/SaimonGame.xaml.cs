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
using System.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace GameCenter.Projects.SaimonGame
{
    /// <summary>
    /// Interaction logic for SaimonGame.xaml
    /// </summary>
    public partial class SaimonGame : Window
    {
        int scoreCount = 0;
        int record;
        Random random = new Random();
        bool talk = false;
        List<int> CurrentSequence;

        public SaimonGame()
        {
            random = new Random();
            CurrentSequence = new List<int>();
            InitializeComponent();
        }

        private void Simon_Talk()
        {
            talk = true;
            Thread.Sleep(150);

            foreach(int i in CurrentSequence)
            {
                switch(i)
                {
                    case 0:
                            Red_0.Source = new BitmapImage(new Uri("C:\\Users\\OFEK SOLOMON\\Desktop\\GameCenter\\GameCenter\\Projects\\SaimonGame\\saimon assets\\R2.png"));
                            Thread.Sleep(150);
                            Red_0.Source = new BitmapImage(new Uri("C:\\Users\\OFEK SOLOMON\\Desktop\\GameCenter\\GameCenter\\Projects\\SaimonGame\\saimon assets\\R1.png"));
                        break;

                    case 1:
                            Yellow_1.Source = new BitmapImage(new Uri("C:\\Users\\OFEK SOLOMON\\Desktop\\GameCenter\\GameCenter\\Projects\\SaimonGame\\saimon assets\\Y2.png"));
                            Thread.Sleep(150);
                            Yellow_1.Source = new BitmapImage(new Uri("C:\\Users\\OFEK SOLOMON\\Desktop\\GameCenter\\GameCenter\\Projects\\SaimonGame\\saimon assets\\Y1.png"));
                        break;

                    case 2:
                            Blue_2.Source = new BitmapImage(new Uri("C:\\Users\\OFEK SOLOMON\\Desktop\\GameCenter\\GameCenter\\Projects\\SaimonGame\\saimon assets\\B2.png"));
                            Thread.Sleep(150);
                            Blue_2.Source = new BitmapImage(new Uri("C:\\Users\\OFEK SOLOMON\\Desktop\\GameCenter\\GameCenter\\Projects\\SaimonGame\\saimon assets\\B1.png"));
                        break;

                    case 3:
                            Green_3.Source = new BitmapImage(new Uri("C:\\Users\\OFEK SOLOMON\\Desktop\\GameCenter\\GameCenter\\Projects\\SaimonGame\\saimon assets\\G2.png"));
                            Thread.Sleep(150);
                            Green_3.Source = new BitmapImage(new Uri("C:\\Users\\OFEK SOLOMON\\Desktop\\GameCenter\\GameCenter\\Projects\\SaimonGame\\saimon assets\\G1.png"));
                        break;
                }
            }
            talk = false;
        }

        private void startGame_Click(object sender, RoutedEventArgs e)
        {
            Score.Text = "Score: " + scoreCount;
            if(scoreCount > record)
            {
                record = scoreCount;
                Record.Text = "Best Score: " + record;
            }
            CurrentSequence.Add(random.Next(0,4));
            new Thread(Simon_Talk).Start();
            scoreCount = 0;
        }

        private void verify_Sequence(int button_pressed)
        {
            if (talk == false && CurrentSequence.Count > 0)
            {
                {
                    if (scoreCount >= CurrentSequence.Count)
                    {
                        MessageBox.Show("Game Over ! Too many Sequences!");
                        scoreCount = 0;
                        CurrentSequence.Clear();
                    }
                    else
                        if (button_pressed == CurrentSequence[scoreCount])
                    {
                        scoreCount++;
                    }
                    else
                    {
                        MessageBox.Show("Game Over! Maybe Next Time...");
                        scoreCount = 0;
                        CurrentSequence.Clear();
                    }

                }
            }
        }

        private void Red_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Red_0.Source = new BitmapImage(new Uri("C:\\Users\\OFEK SOLOMON\\Desktop\\GameCenter\\GameCenter\\Projects\\SaimonGame\\saimon assets\\R2.png"));
            
        }
        private void Red_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Red_0.Source = new BitmapImage(new Uri("C:\\Users\\OFEK SOLOMON\\Desktop\\GameCenter\\GameCenter\\Projects\\SaimonGame\\saimon assets\\R1.png"));

        }
        private void Yellow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Yellow_1.Source = new BitmapImage(new Uri("C:\\Users\\OFEK SOLOMON\\Desktop\\GameCenter\\GameCenter\\Projects\\SaimonGame\\saimon assets\\Y2.png"));

        }
        private void Yellow_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Yellow_1.Source = new BitmapImage(new Uri("C:\\Users\\OFEK SOLOMON\\Desktop\\GameCenter\\GameCenter\\Projects\\SaimonGame\\saimon assets\\Y1.png"));
        }
        private void Blue_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Blue_2.Source = new BitmapImage(new Uri("C:\\Users\\OFEK SOLOMON\\Desktop\\GameCenter\\GameCenter\\Projects\\SaimonGame\\saimon assets\\B2.png"));

        }
        private void Blue_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Blue_2.Source = new BitmapImage(new Uri("C:\\Users\\OFEK SOLOMON\\Desktop\\GameCenter\\GameCenter\\Projects\\SaimonGame\\saimon assets\\B1.png"));
        }
        private void Green_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Green_3.Source = new BitmapImage(new Uri("C:\\Users\\OFEK SOLOMON\\Desktop\\GameCenter\\GameCenter\\Projects\\SaimonGame\\saimon assets\\G2.png"));

        }
        private void Green_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Green_3.Source = new BitmapImage(new Uri("C:\\Users\\OFEK SOLOMON\\Desktop\\GameCenter\\GameCenter\\Projects\\SaimonGame\\saimon assets\\G1.png"));
        }
    }
}

//System.Windows.Controls.Image image = (System.Windows.Controls.Image)sender;
//verify_Sequence(int.Parse(image.Name.ToString().Split('_')[1]));