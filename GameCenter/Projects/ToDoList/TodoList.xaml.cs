using GameCenter.Projects.ToDoList.Models;
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

namespace GameCenter.Projects.ToDoList
{
    /// <summary>
    /// Interaction logic for TodoList.xaml
    /// </summary>
    public partial class TodoList : Window
    {
        private ToDoListModel  _todoList;
        Random random = new Random();
        public TodoList()
        {
            InitializeComponent();
            InitializeTasks();
        }

        private void InitializeTasks()
        {
            _todoList = new ToDoListModel();
            _todoList.AddNewTask(new ToDoTask("a", "To Do Homework"));
            _todoList.AddNewTask(new ToDoTask("b", "To Finish the Project"));
            listTasks.ItemsSource = _todoList.Tasks;

        }

        private void OnTextBlockMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ClickCount == 2)
            {
                TextBlock ? textBlock = sender as TextBlock;
                StackPanel ? parent = textBlock!.Parent as StackPanel;
                TextBox ? editTextBox = parent!.FindName("editTaskDescription") as TextBox;
                Button ? btnSave = parent.FindName("btnSave") as Button;
                Button? btnRemove = parent.FindName("btnRemove") as Button;
                textBlock!.Visibility = Visibility.Collapsed;
                editTextBox!.Visibility = Visibility.Visible;
                btnSave!.Visibility = Visibility.Visible;
                btnRemove!.Visibility = Visibility.Visible;
                editTextBox.Text = textBlock.Text;
            }
        }

        private void OnTaskToggled(object sender, RoutedEventArgs e)
        {
            if(sender is CheckBox check && check.DataContext is ToDoTask task)
            {
                _todoList.ToggleTaskIsCompleted(task.Id);
            }
        }

        private void OnAddTask(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNewTask.Text))
            {
                ToDoTask newTask = new ToDoTask(DateTime.Now.Ticks.ToString(), txtNewTask.Text);
                _todoList.AddNewTask(newTask);
                txtNewTask.Text = "Enter new task";
            }
        }

        private void OnRemoveTask(object sender, RoutedEventArgs e)
        {
            Button? btnRemove = sender as Button;
            StackPanel? parent = btnRemove!.Parent as StackPanel;
            Button? btnSave = parent!.FindName("btnSave") as Button;
            TextBox? editTextBox = parent!.FindName("editTaskDescription") as TextBox;
            TextBlock? textBlock = parent.FindName("txtTaskDescription") as TextBlock;
            ToDoTask? task = editTextBox!.DataContext as ToDoTask;

            btnSave!.Visibility = Visibility.Collapsed;
            btnRemove.Visibility = Visibility.Collapsed;
            editTextBox.Visibility = Visibility.Collapsed;
            textBlock!.Visibility = Visibility.Visible;
            textBlock.Text = editTextBox.Text;
            _todoList.RemoveTask(task);
        }

        private void OnSaveEdit(object sender, RoutedEventArgs e)
        {
            Button ? btnSave = sender as Button;
            StackPanel ? parent = btnSave!.Parent as StackPanel;
            Button? btnRemove = parent!.FindName("btnRemove") as Button;
            TextBox ? editTextBox = parent!.FindName("editTaskDescription") as TextBox;
            TextBlock ? textBlock = parent.FindName("txtTaskDescription") as TextBlock;
            ToDoTask ? task = editTextBox!.DataContext as ToDoTask;

            btnSave.Visibility = Visibility.Collapsed;
            btnRemove!.Visibility = Visibility.Collapsed;
            editTextBox.Visibility = Visibility.Collapsed;
            textBlock!.Visibility = Visibility.Visible;
            textBlock.Text = editTextBox.Text;
            _todoList.UpdateTask(task!.Id, editTextBox.Text);   
        }

        private void EnterNewTask(object sender, RoutedEventArgs e)
        {
            txtNewTask.Text = "";
        }
    }
}
