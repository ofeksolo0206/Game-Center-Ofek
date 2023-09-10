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
        private User _selectedUser;
        List<User> users = new List<User>
            {
                new User("Bob", "bob@email.com", "Qaz123!123Qaz"),
                new User("Sara", "Sara@email.com", "Qaz123!123Qaz"),
                new User("Neomi", "Neomi@email.com", "Qaz123!123Qaz"),
                new User("Abed", "Abed@email.com", "Qaz123!123Qaz"),
            };
        public UserManagment()
        {
            InitializeComponent();
            UpdateDataGrid();
        }

        private void Btn_Add_Click(object sender, RoutedEventArgs e)
        {
            TextBox box = (TextBox)sender;
            if (Validate.UserName(box))
            {
                users.Add(new User(Input_UserName.Text, Input_Email.Text, "Qaz123!123Qaz"));
                UpdateDataGrid();
            }
        }

        private void UpdateDataGrid()
        {
            DataGrid1.ItemsSource = users.ToList();
        }

        private void RowSelected(object sender, SelectedCellsChangedEventArgs e)
        {
            if (DataGrid1.SelectedCells.Count != 0)
            {
                _selectedUser = DataGrid1.SelectedCells[0].Item as User;
            }
        }

        private void Btn_Remove_Click(object sender, RoutedEventArgs e)
        {
            users.Remove(_selectedUser);
            UpdateDataGrid();
        }



        ///
        private void DataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e) 
        {
            var idCell = DataGrid1.SelectedCells[0];
            var nameCell = DataGrid1.SelectedCells[1];
            var emailCell = DataGrid1.SelectedCells[2];
            var passwordCell = DataGrid1.SelectedCells[3];

            try
            {
                string id = ((TextBlock)idCell.Column.GetCellContent(idCell.Item)).Text;
                Input_UserName.Text = ((TextBlock)nameCell.Column.GetCellContent(nameCell.Item)).Text;
                Input_Email.Text = ((TextBlock)emailCell.Column.GetCellContent(emailCell.Item)).Text;
                _selectedUser = users.Single(item => item.Id.ToString() == id);
            }
            catch
            {

            }
        }
        ///
    }
}
