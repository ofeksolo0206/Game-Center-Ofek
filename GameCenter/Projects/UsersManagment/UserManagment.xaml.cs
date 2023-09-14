using GameCenter.Projects.UsersManagment.Utils;
using GameCenter.Projects.UsersManagment.Models;
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


namespace GameCenter.Projects.UsersManagment
{
    /// <summary>
    /// Interaction logic for UserManagment.xaml
    /// </summary>
    public partial class UserManagment : Window
    {
        private readonly UsersListHandler _listHandler;
        private readonly List<User> _users;

        private int _selectedUserId;
        public UserManagment()
        {
            _listHandler = new();
            _users = _listHandler.UsersList;
            _selectedUserId = 0;

            InitializeComponent();

            UsersDataGrid.ItemsSource = _users;
        }

        private void On_Add_Button_Click(object sender, RoutedEventArgs e)
        {
            if (_listHandler.CheckIfEmailExists(UserEmail.Text))
            {
                MessageBox.Show("Email Already Taken!");
                return;
            }
            if (CheckFields() && Validate.UserName(UserName) && Validate.Email(UserEmail))
            {
                _listHandler.AddUser(
                    new User(_users.Count + 1, UserName.Text, UserEmail.Text)
                );

                UpdateGrid();
                ClearFields();
            }
        }
        private void On_Remove_Button_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedUserId == 0)
            {
                MessageBox.Show("Please Pick a User!");
                return;
            }
            _listHandler.RemoveUser(_selectedUserId - 1);
            UpdateGrid();
        }
        private void On_Update_Button_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedUserId == 0)
            {
                MessageBox.Show("Please Pick a User!");
                return;
            }
            _listHandler.UpdateUser(
                new User(_selectedUserId, UserName.Text, UserEmail.Text)
            );

            UpdateGrid();
            ClearFields();
        }

        private void On_ToggleUserLog_Button_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedUserId == 0)
            {
                MessageBox.Show("Please Pick a User!");
                return;
            }
            if (_listHandler.ToggleLogUser(_selectedUserId))
            {
                UpdateGrid();
                return;
            }
            MessageBox.Show("User Status Is Freeze, cant log in!");
        }
        private void On_ToogleFreezeUser_Button_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedUserId == 0)
            {
                MessageBox.Show("Please Pick a User!");
                return;
            }
            _listHandler.ToogleFreezeUser(_selectedUserId);
            UpdateGrid();
        }

        private void On_UserEmail_LostFocus(object sender, EventArgs e)
        {
            Validate.Email(UserEmail);
        }

        private void On_UserName_LostFocus(object sender, RoutedEventArgs e)
        {
            Validate.UserName(UserName);

        }




        private void On_UsersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (UsersDataGrid.SelectedItem != null)
            {
                var selectedUser = (User)UsersDataGrid.SelectedItem;
                _selectedUserId = selectedUser.Id;
                UserName.Text = selectedUser.Name;
                UserEmail.Text = selectedUser.Email;
            }
            else
            {
                _selectedUserId = 0;
                UserName.Text = string.Empty;
                UserEmail.Text = string.Empty;
            }
        }


        private void ClearFields()
        {
            UserEmail.Text = string.Empty;
            UserName.Text = string.Empty;
            _selectedUserId = 0;
        }

        private bool CheckFields()
        {
            if (UserName.Text == String.Empty ||
                UserName.Text == null ||
                UserEmail.Text == String.Empty ||
                UserEmail.Text == null)
            {
                MessageBox.Show("Please Fill All Details!");
                return false;
            }
            return true;
        }

        private void UpdateGrid()
        {
            UsersDataGrid.ItemsSource = _users.ToList();
        }

    }
}