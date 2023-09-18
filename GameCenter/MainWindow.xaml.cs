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
using GameCenter.Projects.Tic_tac_toe;
using GameCenter.Projects.ToDoList;
using GameCenter.Projects.CarGame;
using GameCenter.Projects.CurrencyConverter;
using GameCenter.Projects.MemoryGame;
using GameCenter.Projects.SaimonGame;
using GameCenter.Projects;
using GameCenter.Projects.UsersManagment;

namespace GameCenter
{
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
                _ => "please pick a Game"
            };
        }

        private void Image_MouseLeave(object sender, MouseEventArgs e)
        {
            (sender as Image)!.Opacity = 1;
            GameText.Content = "Please Pick a Game";
        }

        private void Image1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            UserManagment project1 = new UserManagment();
            projectPresentetationPage presentetation = new();
            presentetation.OnStart("Users Managment System", "" +
                "- This is a Users-Managment Program.\n" +
                "- The Technologies i used this project: C#, .NET.\n\n" +

                "- This Program will help you manage all the users on your website.\n" +
                "- You can add/delete/edit all your users's name and email.\n" +
                "- You can also sign-in/out your users.\n" +
                "- In addition you can decide to freeze-up/down any of the accounts.\n\n" +

                "- To Start the program click the Image.\n" +
                "- To Return the Home Page click the user's avatar on the header.",
                Image1.Source,
                project1
                );
            Hide();
            presentetation.ShowDialog();
            ShowDialog();
            presentetation.Close();
            project1.Close();
        }

        private void Image2_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TodoList todoList = new();
            projectPresentetationPage presentetion = new();
            presentetion.OnStart("To-Do List Program", "" +
                "- This is a To-do List Project.\n" +
                "- The Technologies i used this project: C#, .NET.\n\n" +

                "- The application will help you manage your schedule by organizing all tasks in one place.\n" +
                "- You can edit, delete, add or mark as complete your to-do missions.\n" +
                "- To edit task double click the task, then edit or remove the task.\n" +
                "- To create new task double click the 'enter new task' text box on the bottom of the page, then click the save button.\n\n" +

                "- To Start the program click the Image.\n" +
                "- To Return the Home Page click the user's avatar on the header.",
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
            Tic_tac_toe tic_tac_toe = new();
            projectPresentetationPage presentetion = new();
            presentetion.OnStart("Tic Tac Toe Game", "" +
                "- This is a classic Tic Tac Toe Game.\n" +
                "- The Technologies i used this project: C#, .Net, Task.Delay.\n\n" +

                "- This game you'll play againts the computer.\n" +
                "- To play click one of the buttons on the panel.\n" +
                "- The winner is the first one to reach 3 buttons in a row of is symbol (X/O).\n" +
                "- Each win will add to the player/computer score.\n\n" +

                "- To Start the program click the Image.\n" +
                "- To Return the Home Page click the user's avatar on the header.",
                Image3.Source,
                tic_tac_toe
                );
            Hide();
            presentetion.ShowDialog();
            ShowDialog();
            presentetion.Close();
            tic_tac_toe.Close();
        }

        private void Image4_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            FlappyBird flappyBird = new();
            projectPresentetationPage presentetion = new();
            presentetion.OnStart("Flappy Bird Game", "" +
                "- This is My version of the original Flappy Bird Game.\n" +
                "- The Technologies i used this project: C#, .Net, Time Dispatcher and the Controls Library.\n\n" +

                "- Your mission is to avoid the pipes and reach the highest score you can.\n" +
                "- To control the bird vertical location click rapidly the Press key on your key board\n" +
                "- The game will over when you first hit the pipe.\n" +
                "- To play again click the 'R' key.\n\n" +

                "- To Start the program click the Image.\n" +
                "- To Return the Home Page click the user's avatar on the header.",
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
                "- This is a Car avoiding bombs game.\n" +
                "- The Technologies i used this project: C#, .Net, Time Dispatcher and the Controls Library.\n\n" +

                "- Your mission is to avoid all the bombs and reach the highest score.\n" +
                "- Every Bomb you dodged and got out of the window will add to your score\n" +
                "- To move the car press the right and left keys on your key board \n" +
                "- The game will over on the first time you hit a bomb and your score will reset\n\n" +

                "- To Start the program click the Image.\n" +
                "- To Return the Home Page click the user's avatar on the header.",
                Image5.Source,
                carGame
                );
            Hide();
            presentetion.ShowDialog();
            ShowDialog();
            presentetion.Close();
            carGame.Close();
        }

        private async void Image6_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {


            CurrencyConvertorView currencyconvertor = new();
            await currencyconvertor.InitializeAsync();
            projectPresentetationPage presentetion = new();
            presentetion.OnStart("currency convertor program", "" +
                "- This is a currencies convertor project.\n" +
                "- The technologies i used this project: C#, .Net, Async, Json, Api.\n\n" +

                "- This project will show you the value of money you convert by the currencies on that exact day.\n" +
                "- My program communicate with a currencies api to get the updated currencies every day.\n" +
                "- Enter the amount to convert and the currencies to see the exchange.\n" +
                "- Notice my api key is encoded so make sure you enter my key by the instructions i send you mail.\n" +

                "- To start the program click the image.\n" +
                "- To return the home page click the user's avatar on the header.",
               Image6.Source,
               currencyconvertor
               );
            Hide();
            presentetion.ShowDialog();
            ShowDialog();
            presentetion.Close();
            currencyconvertor.Close();
        }

        private void Image7_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MemoryGame memoryGame = new();
            projectPresentetationPage presentetion = new();
            presentetion.OnStart("Memory Game", "" +
                "- This is a Heros Memory Game. \n" +
                "- The Technologies i used this project: C#, .Net, Time Dispatcher.\n\n" +

                "- To Start playing press the Restart Game Button, then click the buttons on the panel to flip them.\n" +
                "- To win you'll need to find all the 8 heros pairs.\n" +
                "- Pay attention that every click on the Restart Button will reset the game and the attempts left.\n" +
                "- Notice you have only 15 attempts so pick the cards wisely.\n\n" +

                "- To Start the program click the Image.\n" +
                "- To Return the Home Page click the user's avatar on the header.",
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
                "- This is a Classic Simon Game. \n" +
                "- The Technologies i used this project: C#, .Net, Task.Delay.\n\n" +

                "- This game will test your memory by remembering a random sequence of colors.\n" +
                "- To Start the Simon click the Start Game and a press of one of the color will add to the current sequence.\n" +
                "- When the Simon finishs click the colors by the exact sequence played.\n" +
                "- If you'll click an different button then the Simon sequence the game will Stop and your score will reset.\n\n" +

                "- To Start the program click the Image.\n" +
                "- To Return the Home Page click the user's avatar on the header.",
                Image8.Source,
                saimonGame
                );
            Hide();
            presentetion.ShowDialog();
            ShowDialog();
            presentetion.Close();
            saimonGame.Close();
        }

    }
}
