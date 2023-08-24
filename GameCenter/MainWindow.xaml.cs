using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Threading;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GameCenter.Projects.FlappyBirdGame;
using GameCenter.Projects.Project1;
using GameCenter.Projects.Tic_tac_toe;
using GameCenter.Projects.ToDoList;
using GameCenter.Projects.CarGame;
using GameCenter.Projects.CurrencyConverter;
using GameCenter.Projects.MemoryGame;
using GameCenter.Projects.SaimonGame;
using GameCenter.Projects.SniperShootingGame;
using GameCenter.Projects;

namespace GameCenter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DispatcherTimer clock = new DispatcherTimer()
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            clock.Tick += ShowCurrentDate!;
            clock.Start();
        }

        private void ShowCurrentDate(object sender, EventArgs e)
        {
            TimeDateLabel.Content = DateTime.UtcNow.ToString("dddd, dd, MMMM, yyyy HH:mm:ss");
        }
        private void Image_MouseEnter(object sender, MouseEventArgs e)
        {
            Image image = (sender as Image)!;
            image.Opacity = 0.7;
            GameText.Content = (image.Name) switch
            {
                "Image1" => "User Management System",
                "Image2" => "To Do List Project",
                "Image3" => "Tic tac toe Game",
                "Image4" => "Flappy Bird Game",
                "Image5" => "Car Game",
                "Image6" => "Currency Convertor Application",
                "Image7" => "Memory Game",
                "Image8" => "Saimon Game",
                "Image9" => "Sniper Shooting Game",
                _ => "please pick a Game"
            };
        }

        private void Image_MouseLeave(object sender, MouseEventArgs e)
        {
            (sender as Image)!.Opacity = 1;
            GameText.Content = "Please Pick a Game";
        }

        //private void Image1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        //{
        //    Project1 project1 = new();
        //    Hide();
        //    project1.ShowDialog();
        //    Show();
        //}

        //private void Image2_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        //{
        //    TodoList todoList = new();
        //    Hide();
        //    todoList.ShowDialog();
        //    Show();
        //}

        //private void Image3_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        //{
        //    tic_tac_toe tic = new();
        //    Hide();
        //    tic.ShowDialog();
        //    Show();
        //}

        //private void Image4_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        //{
        //    FlappyBird flappyBird = new();
        //    Hide();
        //    flappyBird.ShowDialog();
        //    Show();
        //}

        //private void Image5_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        //{
        //    CarGame car = new();
        //    Hide();
        //    car.ShowDialog();
        //    Show();
        //}

        //private async void Image6_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        //{
        //    CurrencyConvertorView currencyConvertor = new();
        //    await currencyConvertor.InitializeAsync();
        //    Hide();
        //    currencyConvertor.ShowDialog();
        //    Show();
        //}

        //private void Image7_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        //{
        //    MemoryGame memoryGame = new();
        //    Hide();
        //    memoryGame.ShowDialog();
        //    Show();
        //}

        //private void Image8_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        //{
        //    SaimonGame saimon = new();
        //    Hide();
        //    saimon.ShowDialog();
        //    Show();
        //}

        private void Image1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Project1 project1 = new();
            projectPresentetationPage presentetion = new();
            presentetion.OnStart("Users Managment System", "" +
                "Welcome to my Users-Managmant. " +
                "Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, " +
                "when an unknown printer took a galley of type and scrambled it to make a type specimen book. " +
                "It has survived not only five centuries, but also the leap into electronic typesetting, " +
                "remaining essentially unchanged. " +
                "It was popularised in the 1960s with the release of Letraset sheets containing Lorem " +
                "Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker " +
                "including versions of Lorem Ipsum.",
                Image1.Source,
                project1
                );
            Hide();
            presentetion.ShowDialog();
            ShowDialog();
            presentetion.Close();
            project1.Close();
        }

        private void Image2_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TodoList todoList = new();
            projectPresentetationPage presentetion = new();
            presentetion.OnStart("To-Do List Program", "" +
                "Welcome to my Users-Managmant. " +
                "Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, " +
                "when an unknown printer took a galley of type and scrambled it to make a type specimen book. " +
                "It has survived not only five centuries, but also the leap into electronic typesetting, " +
                "remaining essentially unchanged. " +
                "It was popularised in the 1960s with the release of Letraset sheets containing Lorem " +
                "Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker " +
                "including versions of Lorem Ipsum.",
                Image2.Source,
                todoList
                );
            Hide();
            presentetion.ShowDialog();
            ShowDialog();
            presentetion.Close();
            todoList.Close();
        }

        private void Image3_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            tic_tac_toe tic_Tac_Toe = new();
            projectPresentetationPage presentetion = new();
            presentetion.OnStart("Tic Tac Toe Game", "" +
                "Welcome to my Users-Managmant. " +
                "Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, " +
                "when an unknown printer took a galley of type and scrambled it to make a type specimen book. " +
                "It has survived not only five centuries, but also the leap into electronic typesetting, " +
                "remaining essentially unchanged. " +
                "It was popularised in the 1960s with the release of Letraset sheets containing Lorem " +
                "Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker " +
                "including versions of Lorem Ipsum.",
                Image3.Source,
                tic_Tac_Toe
                );
            Hide();
            presentetion.ShowDialog();
            ShowDialog();
            presentetion.Close();
            tic_Tac_Toe.Close();
        }

        private void Image4_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            FlappyBird flappyBird = new();
            projectPresentetationPage presentetion = new();
            presentetion.OnStart("Flappy Bird Game", "" +
                "Welcome to my Users-Managmant. " +
                "Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, " +
                "when an unknown printer took a galley of type and scrambled it to make a type specimen book. " +
                "It has survived not only five centuries, but also the leap into electronic typesetting, " +
                "remaining essentially unchanged. " +
                "It was popularised in the 1960s with the release of Letraset sheets containing Lorem " +
                "Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker " +
                "including versions of Lorem Ipsum.",
                Image4.Source,
                flappyBird
                );
            Hide();
            presentetion.ShowDialog();
            ShowDialog();
            presentetion.Close();
            flappyBird.Close();
        }

        private void Image5_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            CarGame carGame = new();
            projectPresentetationPage presentetion = new();
            presentetion.OnStart("Car Game", "" +
                "Welcome to my Users-Managmant. " +
                "Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, " +
                "when an unknown printer took a galley of type and scrambled it to make a type specimen book. " +
                "It has survived not only five centuries, but also the leap into electronic typesetting, " +
                "remaining essentially unchanged. " +
                "It was popularised in the 1960s with the release of Letraset sheets containing Lorem " +
                "Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker " +
                "including versions of Lorem Ipsum.",
                Image5.Source,
                carGame
                );
            Hide();
            presentetion.ShowDialog();
            ShowDialog();
            presentetion.Close();
            carGame.Close();
        }

        private void Image6_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            CurrencyConvertorView currencyConvertor = new();
            projectPresentetationPage presentetion = new();
            presentetion.OnStart("Currency Convertor Program", "" +
                "Welcome to my Users-Managmant. " +
                "Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, " +
                "when an unknown printer took a galley of type and scrambled it to make a type specimen book. " +
                "It has survived not only five centuries, but also the leap into electronic typesetting, " +
                "remaining essentially unchanged. " +
                "It was popularised in the 1960s with the release of Letraset sheets containing Lorem " +
                "Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker " +
                "including versions of Lorem Ipsum.",
                Image6.Source,
                currencyConvertor
                );
            Hide();
            presentetion.ShowDialog();
            ShowDialog();
            presentetion.Close();
            currencyConvertor.Close();
        }

        private void Image7_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MemoryGame memoryGame = new();
            projectPresentetationPage presentetion = new();
            presentetion.OnStart("Memory Game", "" +
                "Welcome to my Users-Managmant. " +
                "Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, " +
                "when an unknown printer took a galley of type and scrambled it to make a type specimen book. " +
                "It has survived not only five centuries, but also the leap into electronic typesetting, " +
                "remaining essentially unchanged. " +
                "It was popularised in the 1960s with the release of Letraset sheets containing Lorem " +
                "Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker " +
                "including versions of Lorem Ipsum.",
                Image7.Source,
                memoryGame
                );
            Hide();
            presentetion.ShowDialog();
            ShowDialog();
            presentetion.Close();
            memoryGame.Close();
        }

        private void Image8_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            SaimonGame saimonGame = new();
            projectPresentetationPage presentetion = new();
            presentetion.OnStart("Simon Game", "" +
                "Welcome to my Users-Managmant. " +
                "Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, " +
                "when an unknown printer took a galley of type and scrambled it to make a type specimen book. " +
                "It has survived not only five centuries, but also the leap into electronic typesetting, " +
                "remaining essentially unchanged. " +
                "It was popularised in the 1960s with the release of Letraset sheets containing Lorem " +
                "Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker " +
                "including versions of Lorem Ipsum.",
                Image8.Source,
                saimonGame
                );
            Hide();
            presentetion.ShowDialog();
            ShowDialog();
            presentetion.Close();
            saimonGame.Close();
        }

        private void Image9_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            SniperShootingGame sniperShootingGame = new();
            projectPresentetationPage presentetion = new();
            presentetion.OnStart("Sniper Shooting Game", "" +
                "Welcome to my Users-Managmant. " +
                "Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, " +
                "when an unknown printer took a galley of type and scrambled it to make a type specimen book. " +
                "It has survived not only five centuries, but also the leap into electronic typesetting, " +
                "remaining essentially unchanged. " +
                "It was popularised in the 1960s with the release of Letraset sheets containing Lorem " +
                "Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker " +
                "including versions of Lorem Ipsum.",
                Image9.Source,
                sniperShootingGame
                );
            Hide();
            presentetion.ShowDialog();
            ShowDialog();
            presentetion.Close();
            sniperShootingGame.Close();
        }


    }
}


//https://github.com/TzachLectures/PlayCenter