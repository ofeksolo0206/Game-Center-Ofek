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
using System.Windows.Threading;
using GameCenter.Projects.SaimonGame.Model;

namespace GameCenter.Projects.SaimonGame
{
    /// <summary>
    /// Interaction logic for SaimonGame.xaml
    /// </summary>
    public partial class SaimonGame : Window
    {
        SaimonModel saimon;
        Random random = new Random();

        public SaimonGame()
        {
            random = new Random();
            saimon = new SaimonModel();

            InitializeComponent();
        }
        private void startGame_Click(object sender, RoutedEventArgs e)
        {
            Score.Text = "Score: " + saimon.scoreCount;
            saimon.CurrentSequence.Add(random.Next(0,4));
            Simon_Talk();
            saimon.scoreCount = 0;
        }

        private void GameOver()
        {
            if(saimon.If_To_Play_Again()==true)
            {
                Score.Text = "Score: " + saimon.scoreCount;
                Red_0.Opacity = 1;
                Yellow_1.Opacity = 1;
                Blue_2.Opacity = 1;
                Green_3.Opacity = 1;
            }
            else
            {
                Close();
            }
        }

        private async void Simon_Talk()
        {
            saimon.talk = true;

                foreach (int i in saimon.CurrentSequence)
                {
                    switch (i)
                    {
                        case 0:
                            Red_0.Opacity = 0.3;
                            await Task.Delay(TimeSpan.FromSeconds(0.1));
                            Red_0.Opacity = 1;
                            break;
                        case 1:
                            Yellow_1.Opacity = 0.3;
                            await Task.Delay(TimeSpan.FromSeconds(0.1));
                            Yellow_1.Opacity = 1;
                            break;
                        case 2:
                            Blue_2.Opacity = 0.3;
                            await Task.Delay(TimeSpan.FromSeconds(0.1));
                            Blue_2.Opacity = 1;
                            break;
                        case 3:
                            Green_3.Opacity = 0.3;
                            await Task.Delay(TimeSpan.FromSeconds(0.1));
                            Green_3.Opacity = 1;
                            break;

                    }
                    await Task.Delay(TimeSpan.FromSeconds(0.1));
                }
                saimon.talk = false;
        }

        private void Verify_Sequence(int button_pressed)
        {
            if(saimon.Verify_play(button_pressed) == false)
            {
                GameOver();
            }
            else
            {
                Score.Text = "Score: " + saimon.scoreCount;
                Record.Text = "Best Score: " + saimon.record;
            }
        }

        private void Button_MouseDown(object sender, MouseButtonEventArgs e)
        {

                Image ? image = sender as Image;
                if (image != null)
                {
                    image.Opacity = 0.5;
                    Verify_Sequence(int.Parse(image.Name.ToString().Split('_')[1]));
                }
                else
                {
                    MessageBox.Show($"Image type cannot be null");
                }
        }


        private void Button_MouseUp(object sender, MouseEventArgs e)
        {
            Image image = (sender as Image)!;
            image.Opacity = 1;
        }
    }
}