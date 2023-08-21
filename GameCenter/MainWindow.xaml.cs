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
        }
        private void Image_MouseEnter(object sender, MouseEventArgs e)
        {
            Image image = (sender as Image)!;
            image.Opacity = 0.7;
            GameText.Content = (image.Name) switch
            {
                "Image1" => "User Management System",
                "Image2" => "To Do List project",
                "Image3" => "Tic tac toe game",
                "Image4" => "Flappy Bird game",
                "Image5" => "Car dodge Bombs game",
                "Image6" => "Currency Convertor Application",
                "Image7" => "Memory game",
                "Image8" => "Saimon game",
                _ => "please pick a game"
            };
        }

        private void Image_MouseLeave(object sender, MouseEventArgs e)
        {
            (sender as Image)!.Opacity = 1;
            GameText.Content = "please pick a game";
        }

        private void Image1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Project1 project1 = new();
            Hide();
            project1.ShowDialog();
            Show();
        }

        private void Image2_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TodoList todoList = new();
            Hide();
            todoList.ShowDialog();
            Show();
        }

        private void Image3_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            tic_tac_toe tic = new();
            Hide();
            tic.ShowDialog();
            Show();
        }

        private void Image4_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            FlappyBird flappyBird = new();
            Hide();
            flappyBird.ShowDialog();
            Show();
        }

        private void Image5_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            CarGame car = new();
            Hide();
            car.ShowDialog();
            Show();
        }

        private async void Image6_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            CurrencyConvertorView currencyConvertor = new();
            await currencyConvertor.InitializeAsync();
            Hide();
            currencyConvertor.ShowDialog();
            Show();
        }

        private void Image7_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MemoryGame memoryGame = new();
            Hide();
            memoryGame.ShowDialog();
            Show();
        }

        private void Image8_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            SaimonGame saimon = new();
            Hide();
            saimon.ShowDialog();
            Show();
        }
    }
}


//https://github.com/TzachLectures/PlayCenter