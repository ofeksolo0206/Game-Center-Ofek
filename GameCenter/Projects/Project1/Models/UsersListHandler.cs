using System;
using System.Collections.Generic;
using System.Linq;
using WpfApp1.Models;

namespace GameCenter.Projects.Project1.Models
{
    class UsersListHandler
    {
        public List<User1> UsersList { get; private set; }

        public UsersListHandler()
        {
            UsersList = GenerateUsersList();
        }

        public void AddUser(User1 user)
        {
            UsersList.Add(user);
        }

        public void RemoveUser(int id)
        {
            UsersList.Remove(UsersList[id]);
            SetIds();
        }

        public void UpdateUser(User1 user)
        {
            UsersList[user.Id - 1] = user;
        }

        public bool ToggleLogUser(int id)
        {
            User1 user = UsersList[id - 1];
            if (user.Status != UserStatusTypes.Freeze.ToString())
            {
                if (user.Status == UserStatusTypes.Logged_Off.ToString())
                {
                    user.Status = UserStatusTypes.Logged_In.ToString();
                    user.LastLogIn = DateTime.Now;
                }
                else
                {
                    user.Status = UserStatusTypes.Logged_Off.ToString();
                }
                return true;
            }
            return false;
        }

        public void ToogleFreezeUser(int id)
        {
            User1 user = UsersList[id - 1];
            if (user.Status == UserStatusTypes.Freeze.ToString())
            {
                user.Status = UserStatusTypes.Logged_Off.ToString();
                return;
            }
            user.Status = UserStatusTypes.Freeze.ToString();
        }

        public bool CheckIfEmailExists(string email)
        {
            return UsersList.Any(user => user.Email == email);
        }

        private void SetIds()
        {
            for (int i = 0; i < UsersList.Count; i++)
            {
                UsersList[i].Id = i + 1;
            }
        }

        private List<User1> GenerateUsersList()
        {
            return new List<User1>()
            {
                new User1(
                    id: 1,
                    name: "Joe",
                    email: "joe@email.com"
                ),
                new User1(
                    id : 2,
                    name : "Bob",
                    email: "bob@email.com"
                ),
                new User1(
                    id : 3,
                    name : "Gil",
                    email: "gil@email.com"
                ),
                new User1(
                    id : 4,
                    name: "Shosh",
                    email: "shosh@email.com"
                )
            };
        }
    }
}
